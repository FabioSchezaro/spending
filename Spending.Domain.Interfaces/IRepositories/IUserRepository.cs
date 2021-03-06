using Spending.Domain.Interfaces.IRepositories.IBaseCrudRepository;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Spending.Domain.Interfaces.IRepositories
{
    public interface IUserRepository : IBaseCrudRepository<UserEntity, Guid>
    {
        Task<UserEntity> GetByLoginAsync(string login, IDbConnection dbConnection = null, IDbTransaction transaction = null);
    }
}
