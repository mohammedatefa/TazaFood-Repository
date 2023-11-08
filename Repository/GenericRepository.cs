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
        public async Task<IEnumerable<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
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

        public async Task Add(T entity)
        {
            if (entity is not null)
            {
                try
                {
                    await context.Set<T>().AddAsync(entity);
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception("there is error occured during add new item in the data base",ex);
                    
                }
            }
            
        }
    }
}
