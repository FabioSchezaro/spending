using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Spending.Domain.Interfaces.IRepositories.IBaseCrudRepository
{
    public interface IBaseCrudRepository<T, V> where T : class
                                     where V : struct
    {
        Task<bool> InsertAsync(T entity, IDbConnection connection, IDbTransaction transaction = null);
        Task<bool> DeleteAsync(T entity, IDbConnection connection, IDbTransaction transaction = null);
        Task<bool> UpdateAsync(T entity, IDbConnection connection, IDbTransaction transaction = null);
        Task<T> GetByIdAsync(V id, IDbConnection connection);
        Task<List<T>> GetAllAsync(IDbConnection connection);
    }
}
