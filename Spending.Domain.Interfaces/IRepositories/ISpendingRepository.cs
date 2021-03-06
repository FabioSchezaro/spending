using Spending.Domain.Interfaces.IRepositories.IBaseCrudRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Spending.Domain.Interfaces.IRepositories
{
    public interface ISpendingRepository : IBaseCrudRepository<SpendingEntity, Guid>
    {
        Task<List<SpendingEntity>> GetYearsAsync(IDbConnection connection);
        Task<List<SpendingEntity>> GetMonthsByYearAsync(IDbConnection connection, int year);
        Task<List<SpendingEntity>> GetSpendingProductsAsync(IDbConnection connection);
    }
}
