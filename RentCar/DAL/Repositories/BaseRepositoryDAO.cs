using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public abstract class BaseRepositoryDAO<T> : IBaseRepositoryDAO<T> where T : class
    {
        private readonly ApplicationDbContext dbContext;

        public BaseRepositoryDAO(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbContext.Set<T>();
        }

        public virtual T GetById(int Id)
        {
            return dbContext.Set<T>().Find(Id);
        }

        public T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return dbContext.Set<T>().SingleOrDefault(predicate);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return dbContext.Set<T>().Where(predicate);
        }

        public virtual T Add(T entity)
        {
            dbContext.Set<T>().Add(entity);
            dbContext.SaveChanges();
            return entity;
        }

        public List<T> AddRange(List<T> entities)
        {
            dbContext.Set<T>().AddRange(entities);
            dbContext.SaveChanges();
            return entities;
        }

        public T Update(T entity)
        {
            dbContext.Set<T>().Update(entity);
            dbContext.SaveChanges();
            return entity;
        }

        public T Remove(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            dbContext.SaveChanges();
            return entity;
        }

        public List<T> RemoveRange(List<T> entities)
        {
            dbContext.Set<T>().RemoveRange(entities);
            dbContext.SaveChanges();
            return entities;
        }
    }
}
