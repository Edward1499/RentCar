using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IBaseRepositoryDAO<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int Id);
        T SingleOrDefault(Expression<Func<T, bool>> predicate);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        List<T> AddRange(List<T> entities);
        T Update(T entity);
        T Remove(T entity);
        List<T> RemoveRange(List<T> entities);
    }
}
