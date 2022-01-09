using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepositoryBase<T> where T:class,IEntity,new()
    {
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter = null);
        //Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> filter = null);
        Task<T> GetByIdAsync(Expression<Func<T, bool>> filter);
        Task<T> AddAsync(T entity);
        Task<T> Update(T entity);
        Task<bool> DeleteAsync(int id);
    }
}
