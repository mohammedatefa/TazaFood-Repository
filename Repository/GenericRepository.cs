using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TazaFood_Core.IRepositories;
using TazaFood_Core.ISpecifications;
using TazaFood_Core.Models;
using TazaFood_Repository.Context;
using TazaFood_Repository.SpecificationEvaluter;

namespace TazaFood_Repository.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        private TazaDbContext context;

        public GenericRepository(TazaDbContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {

            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            //return await context.Set<T>().Where(t => t.Id == id).FirstOrDefaultAsync();
            return await context.Set<T>().FindAsync(id);
        }



        #region get model using specification
        public async Task<IEnumerable<T>> GetAllWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<T> GetByIdWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        } 

        private IQueryable<T> ApplySpecification(ISpecification<T> specification)
        {
            return specificationEvaluter<T>.GetQuery(context.Set<T>(), specification);
        }
        #endregion
    }
}
