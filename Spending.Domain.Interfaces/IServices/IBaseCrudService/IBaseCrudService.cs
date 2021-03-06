using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Spending.Domain.Interfaces.IServices.IBaseCrudService
{
    public interface IBaseCrudService<T>
    {
        Task<T> GetByIdAsync(Guid id);
        Task<List<T>> GetAllAsync();
        Task<bool> InsertAsync(T entity, IDbTransaction transaction = null);
        Task<bool> UpdateAsync(T entity, IDbTransaction transaction = null);
        Task<bool> DeleteAsync(T entity, IDbTransaction transaction = null);
    }
}
