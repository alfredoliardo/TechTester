using System.Linq;
using Core.Interfaces;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class SpecificationEvaluator<T> where T : class
    {
        public static IQueryable<T> Evaluate(IQueryable<T> inputQuery, ISpecification<T> spec)
        {
            var query = inputQuery;
            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            if (spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy);
            }
            if (spec.OrderByDescending != null)
            {
                query = query.OrderByDescending(spec.OrderByDescending);
            }


            // Includes all expression-based includes
            query = spec.Includes.Aggregate(query,
                                    (current, include) => current.Include(include));

            // Include any string-based include statements
            query = spec.IncludeStrings.Aggregate(query,
                                    (current, include) => current.Include(include));

            if (spec.GroupBy != null)
            {
                query = query.GroupBy(spec.GroupBy).SelectMany(x => x);
            }

            // Apply paging if enabled
            if (spec.IsPagingEnabled)
            {
                query = query.Skip(spec.Skip)
                             .Take(spec.Take);
            }
            return query;
        }
    }
}