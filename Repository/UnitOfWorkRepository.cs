using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TazaFood_Core.IRepositories;
using TazaFood_Core.Models;
using TazaFood_Repository.Context;

namespace TazaFood_Repository.Repository
{
    public class UnitOfWorkRepository : IUnitOfWork
    {
        private readonly TazaDbContext dbContext;
        private Hashtable repositories;
        public UnitOfWorkRepository(TazaDbContext DbContext)
        {
            dbContext = DbContext;
            repositories = new Hashtable();
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseModel
        {
            var type= typeof(TEntity).Name;
            if(!repositories.ContainsKey(type))
            {
                var repo = new GenericRepository<TEntity>(dbContext);
                repositories.Add(type,repo);
            }
            return repositories[type] as IGenericRepository<TEntity>;
        }

        public async Task<int> complete()
            =>await dbContext.SaveChangesAsync();

        public async ValueTask DisposeAsync()
            => await dbContext.DisposeAsync();
        
    }
}
