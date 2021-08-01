using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Interfaces
{
    public interface IRepository<T>
    {
        T FindById(int id);

        IEnumerable<T> Find(ISpecification<T> specification = null);

        void Add(T entity);
        void AddRange(IEnumerable<T> entities);

        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

        void Update(T entity);

        bool Contains(ISpecification<T> specification = null);
        bool Contains(Expression<Func<T, bool>> predicate);

        int Count(ISpecification<T> specification = null);
        int Count(Expression<Func<T, bool>> predicate);
    }
}