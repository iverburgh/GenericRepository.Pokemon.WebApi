using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Pokemon.Data.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> SaveOrUpdateAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task<T> GetSingleByExpressionAsync(Expression<Func<T, bool>> expression);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetByExpressionAsync(Expression<Func<T, bool>> expression);
        void Delete(T entity);
        void DeleteById(int id);
    }

}
