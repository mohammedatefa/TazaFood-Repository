﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TazaFood_Core.ISpecifications;
using TazaFood_Core.Models;

namespace TazaFood_Repository.SpecificationEvaluter
{
    public static class specificationEvaluter<T> where T:BaseModel
    {
        public static IQueryable<T> GetQuery(IQueryable<T> InputQuery,ISpecification<T> spec)
        {
            var query = InputQuery;

            //where Query
            if (spec.Ceritaria is not null)
            {
                query = query.Where(spec.Ceritaria);
            }

            //order Query
            if (spec.OrderBy is not null)
            {
                query = query.OrderByDescending(spec.OrderBy);
            }

            //Pagination Query
            if (spec.EnablePagination)
            {
                query = query.Skip(spec.Skip).Take(spec.Take);
            }

            //Include Query
            query = spec.Includes.Aggregate(query, (current, includeexpression) => current.Include(includeexpression));

            return query;
        }
    }
}
