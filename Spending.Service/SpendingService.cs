using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Spending.Domain;
using Spending.Domain.Interfaces.IRepositories;
using Spending.Domain.Interfaces.IServices;
using Spending.Domain.Interfaces.IUnitOfWork;
using Spending.Service.BaseCrudService;

namespace Spending.Service
{
    public class SpendingService : BaseCrudService<ISpendingRepository, SpendingEntity>, ISpendingService
    {
        private readonly IProductService _productService;
        public SpendingService(ISpendingRepository repository, 
            IUnitOfWork unitOfWork, 
            IHttpContextAccessor httpContextAccessor,
            IProductService productService) : base(repository, unitOfWork, httpContextAccessor)
        {
            _productService = productService;
        }

        public async override Task<bool> InsertAsync(SpendingEntity entity, IDbTransaction transaction = null)
        {
            bool success = false;
            transaction = _unitOfWork.GetTransaction();
            try
            {
                ProductEntity product = await _productService.GetByIdAsync(entity.ProductId);

                entity.ParcelValue = (product.Price - product.InputValue) / product.Parcel;

                for (int i = entity.Parcel; i <= product.Parcel; i++)
                {
                    success = await base.InsertAsync(entity, transaction);
                    if (entity.Month == 12)
                    {
                        entity.Month = 0;
                        entity.Year++;
                    }
                    entity.Month++;
                    entity.Parcel++;
                    entity.Id = Guid.NewGuid();
                }
            }
            finally
            {
                if (success)
                    _unitOfWork.Commit();
                else
                    _unitOfWork.Rollback();
            }

            return success;
        }
    }
}
