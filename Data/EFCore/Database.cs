using System;
using System.Collections;
using Core.Interfaces;
using Data.Repositories;

namespace Data.EFCore
{
    public class Database : IDatabase
    {
        private readonly ApplicationContext _context;
        private Hashtable _repositories;

        public Database(ApplicationContext context)
        {
            _context = context;
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public IRepository<T> Repository<T>() where T : class
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);

                var repositoryInstance =
                    Activator.CreateInstance(repositoryType
                        .MakeGenericType(typeof(T)), _context);

                _repositories.Add(type, repositoryInstance);
            }

            return (IRepository<T>)_repositories[type];
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}