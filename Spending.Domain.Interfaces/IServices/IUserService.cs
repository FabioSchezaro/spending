using Spending.Domain.Interfaces.IServices.IBaseCrudService;
using System.Threading.Tasks;

namespace Spending.Domain.Interfaces.IServices
{
    public interface IUserService : IBaseCrudService<UserEntity>
    {
        Task<UserEntity> AuthenticateAsync(UserEntity user);
    }
}
