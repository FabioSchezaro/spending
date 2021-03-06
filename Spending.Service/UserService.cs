using Microsoft.AspNetCore.Http;
using Spending.Domain;
using Spending.Domain.Interfaces.IRepositories;
using Spending.Domain.Interfaces.IServices;
using Spending.Domain.Interfaces.IUnitOfWork;
using Spending.Service.BaseCrudService;
using Spending.Token.Security;
using System.Data;
using System.Threading.Tasks;

namespace Spending.Service
{
    public class UserService : BaseCrudService<IUserRepository, UserEntity>, IUserService
    {
        public UserService(IUserRepository repository, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(repository, unitOfWork, httpContextAccessor)
        {
        }

        public Task<UserEntity> AuthenticateAsync(UserEntity user)
        {
            return Task.Run(() =>
            {
                var userEntity = _repository.GetByLoginAsync(user.Login, _unitOfWork.GetConnection()).Result;
                user.Password = CryptHelper.EncryptPassword(user.Password);

                if (userEntity != null)
                    if (userEntity.Password != user.Password)
                        return null;

                return userEntity;
            });
        }

        public async override Task<bool> InsertAsync(UserEntity entity, IDbTransaction transaction = null)
        {
            entity.Password = CryptHelper.EncryptPassword(entity.Password);
            return await base.InsertAsync(entity, transaction);
        }

        public async override Task<bool> UpdateAsync(UserEntity entity, IDbTransaction transaction = null)
        {
            entity.Password = CryptHelper.EncryptPassword(entity.Password);
            return await base.UpdateAsync(entity, transaction);
        }
    }
}
