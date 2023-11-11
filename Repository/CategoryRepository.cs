using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TazaFood_Core.IRepositories;
using TazaFood_Core.Models;
using TazaFood_Repository.Context;

namespace TazaFood_Repository.Repository
{
    public class CategoryRepository : ICategoryRepository 
    {
        private readonly TazaDbContext context;

        public CategoryRepository(TazaDbContext _context) 
        {
            context = _context;
        }
        public async Task<List<Category>> GetByName(string name)
        {
            return await context.Set<Category>().Where(C => C.Name.Contains(name)).ToListAsync();
        }
    }
}
