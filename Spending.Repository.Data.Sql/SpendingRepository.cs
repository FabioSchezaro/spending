using Dapper;
using Spending.Domain;
using Spending.Domain.Interfaces.IRepositories;
using Spending.Repository.Data.Sql.BaseCrudRepository;
using Spending.Repository.Data.Sql.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Spending.Repository.Data.Sql
{
    public class SpendingRepository : BaseCrudRepository<SpendingEntity, Guid>, ISpendingRepository
    {
        public async Task<List<SpendingEntity>> GetYearsAsync(IDbConnection connection)
        {
            var years = await connection.QueryAsync<SpendingEntity>(SpendingCommands.GetSpendingYears);

            return years.ToList();
        }

        public async Task<List<SpendingEntity>> GetMonthsByYearAsync(IDbConnection connection, int year)
        {
            var months = await connection.QueryAsync<SpendingEntity>(SpendingCommands.GetSpendingMonthsByYear, new { year });

            return months.ToList();
        }

        public async Task<List<SpendingEntity>> GetSpendingProductsAsync(IDbConnection connection)
        {
            var products = await connection.QueryAsync<SpendingEntity>(SpendingCommands.GetSpendingProducts);

            return products.ToList();
        }
    }
}
