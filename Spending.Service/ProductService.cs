using Microsoft.AspNetCore.Http;
using Spending.Domain;
using Spending.Domain.Interfaces.IRepositories;
using Spending.Domain.Interfaces.IServices;
using Spending.Domain.Interfaces.IUnitOfWork;
using Spending.Service.BaseCrudService;

namespace Spending.Service
{
    public class ProductService : BaseCrudService<IProductRepository, ProductEntity>, IProductService
    {
        public ProductService(IProductRepository repository, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base (repository, unitOfWork, httpContextAccessor)
        {
        }
    }
}
