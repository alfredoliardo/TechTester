using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.Interfaces;
using Data.EFCore;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {    protected readonly ApplicationContext _context;

    public Repository(ApplicationContext context)
    {
        _context = context;
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void AddRange(IEnumerable<T> entities)
    {
        _context.Set<T>().AddRange(entities);
    }

    public bool Contains(ISpecification<T> specification = null)
    {
        return Count(specification) > 0 ? true : false;
    }

    public bool Contains(Expression<Func<T, bool>> predicate)
    {
        return Count(predicate) > 0 ? true : false;
    }

    public int Count(ISpecification<T> specification = null)
    {
        return ApplySpecification(specification).Count();
    }

    public int Count(Expression<Func<T, bool>> predicate)
    {
        return _context.Set<T>().Where(predicate).Count();
    }

    public IEnumerable<T> Find(ISpecification<T> specification = null)
    {
        return ApplySpecification(specification);
    }

    public T FindById(int id)
    {
        return _context.Set<T>().Find(id);
    }

    public void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
    }

    public void Update(T entity)
    {
        _context.Set<T>().Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }

    private IQueryable<T> ApplySpecification(ISpecification<T> spec)
    {
        var query = _context.Set<T>().AsQueryable();
        if(spec != null)
            return SpecificationEvaluator<T>.Evaluate(query, spec);
        return query;
    }
    }
}