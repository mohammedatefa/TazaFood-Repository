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


        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }


        #region get model using specification
        public async Task<IReadOnlyList<T>> GetAllWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<T> GetByIdWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<int> GetCountWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
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
                   
                }
                catch (Exception ex)
                {
                    throw new Exception("there is error occured during add new item in the data base",ex);
                    
                }
            }
            
        }

        public async Task<bool> Update(int id, T entity)
        {
            var found = context.Set<T>().Find(id);
            if(found is not null)
            {
                try
                {
                    context.Set<T>().Update(entity);
                    return  true;
                }
                catch (Exception ex)
                {
                    throw new Exception("there is error occured during add new item in the data base", ex);
                }
            }
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var found = context.Set<T>().Find(id);
            if(found is not null)
            {
                try
                {
                    context.Set<T>().Remove(found);
                    return true;
                }
                catch (Exception ex)
                {

                    throw new Exception("there is error occured during add new item in the data base", ex);
                }
            }
            return false;
        }


    }
}
