using Dapper;
using Spending.Domain;
using Spending.Domain.Interfaces.IRepositories;
using Spending.Repository.Data.Sql.BaseCrudRepository;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Spending.Repository.Data.Sql
{
    public class UserRepository : BaseCrudRepository<UserEntity, Guid>, IUserRepository
    {
        public async Task<UserEntity> GetByLoginAsync(string login, IDbConnection connection, IDbTransaction transaction)
        {

            var sql = @"SELECT * FROM dbo.Users WHERE Login = @login";

            var user = await connection.QueryAsync<UserEntity>(sql, new { login });

            return user.FirstOrDefault();
        }
    }
}
