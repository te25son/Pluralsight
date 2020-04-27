using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace QueryIt
{
    public class EmployeeDb : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }

    public interface IRepository<T> : IDisposable
    {
        void Add(T newEntity);
        void Delete(T entity);
        void FindById(int Id);
        IQueryable<T> FindAll();
        int Commit();
    }

    public class SqlRepository<T> : IRepository<T>
        where T : class, IEntity
    {
        DbContext _context;
        DbSet<T> _set;

        public SqlRepository(DbContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public void Add(T newEntity)
        {
            if (newEntity.IsValid())
            {
                _set.Add(newEntity);
            }
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IQueryable<T> FindAll()
        {
            return _set;
        }

        public void FindById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
