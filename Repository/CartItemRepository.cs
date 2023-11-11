using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TazaFood_Core.IRepositories;
using TazaFood_Core.Models;

namespace TazaFood_Repository.Repository
{
    public class CartItemRepository : ICartItemsRepository
    {
        private readonly IDatabase _database;
        public CartItemRepository(IConnectionMultiplexer multiplexer)
        {
            _database=multiplexer.GetDatabase();
        }

        public async Task<bool> DeleteCartAsync(string cartId)
        {
            return await _database.KeyDeleteAsync(cartId);
        }

        public async Task<UserCart?> GetCartAsync(string cartId)
        {
            var cart=await _database.StringGetAsync(cartId);
            return cart.IsNull?null: JsonSerializer.Deserialize<UserCart>(cart);
        }

        public async Task<UserCart?> UpdateCartAsync(UserCart cart)
        {
            var newcart = await _database.StringSetAsync(cart.Id,JsonSerializer.Serialize<UserCart>(cart),
                TimeSpan.FromDays(1));

            if (newcart is false) return null;
            return await GetCartAsync(cart.Id);


        }
    }
}
