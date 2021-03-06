using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Spending.Domain.Interfaces.IRepositories;
using Spending.Domain.Interfaces.IServices;
using Spending.Domain.Interfaces.IUnitOfWork;
using Spending.Repository.Data.Sql;
using Spending.Repository.Data.Sql.UnitOfWork;
using Spending.Service;

namespace Spending.IoC
{
    public class DependencyInjection
    {
        public static void Register(IServiceCollection service, IConfiguration configuration)
        {
            service.AddSingleton<IUnitOfWork>(s =>
                new UnitOfWork(configuration.GetConnectionString("SpendingConnectionString")));

            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IUserRepository, UserRepository>();

            service.AddScoped<IProductService, ProductService>();
            service.AddScoped<IProductRepository, ProductRepository>();

            service.AddScoped<ISpendingService, SpendingService>();
            service.AddScoped<ISpendingRepository, SpendingRepository>();

            service.AddScoped<IFilterService, FilterService>();
            service.AddScoped<IFilterRepository, FilterRepository>();

            service.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
