using Microsoft.AspNetCore.Http;
using Spending.Domain.Interfaces.IRepositories.IBaseCrudRepository;
using Spending.Domain.Interfaces.IServices.IBaseCrudService;
using Spending.Domain.Interfaces.IUnitOfWork;
using Spending.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Spending.Service.BaseCrudService
{
    public class BaseCrudService<TIRepository, TEntity> : IBaseCrudService<TEntity>
        where TIRepository : IBaseCrudRepository<TEntity, Guid>
        where TEntity : BaseEntity
    {
        protected readonly TIRepository _repository;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IHttpContextAccessor _httpContextAccessor;

        public BaseCrudService(TIRepository repository, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id, _unitOfWork.GetConnection());
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync(_unitOfWork.GetConnection());
        }

        public virtual async Task<bool> InsertAsync(TEntity entity, IDbTransaction transaction = null)
        {
            await SetCreateUser(entity);
            return await _repository.InsertAsync(entity, _unitOfWork.GetConnection(), transaction);
        }

        public virtual async Task<bool> UpdateAsync(TEntity entity, IDbTransaction transaction = null)
        {
            TEntity newEntity = await GetByIdAsync(entity.Id);
            entity.CreateUser = newEntity.CreateUser;
            entity.CreateDate = newEntity.CreateDate;

            await SetUpdateUser(entity);

            return await _repository.UpdateAsync(entity, _unitOfWork.GetConnection(), transaction);
        }

        public virtual async Task<bool> DeleteAsync(TEntity entity, IDbTransaction transaction = null)
        {
            TEntity newEntity = await GetByIdAsync(entity.Id);
            entity.CreateUser = newEntity.CreateUser;
            entity.CreateDate = newEntity.CreateDate;

            await SetUpdateUser(entity);
            return await _repository.DeleteAsync(entity, _unitOfWork.GetConnection(), transaction);
        }

        public async Task SetCreateUser(TEntity entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.CreateUser = Guid.Parse(await GetLoggedUser());
        }

        public async Task SetUpdateUser(TEntity entity)
        {
            entity.UpdateDate = DateTime.Now;
            entity.UpdateUser = Guid.Parse(await GetLoggedUser());
        }

        private Task<string> GetLoggedUser()
        {
            return Task.Run(() =>
            {
                var identity = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier).Value;

                return identity;
            });
        }
    }
}