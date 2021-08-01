using System;

namespace Core.Interfaces
{
    public interface IDatabase : IDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;
        int Complete();
    }
}