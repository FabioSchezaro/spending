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
    public class ProductRepository : BaseCrudRepository<ProductEntity, Guid>, IProductRepository
    {
        //public override Task<List<ProductEntity>> GetAllAsync(IDbConnection connection)
        //{
        //    return Task.Run(() =>
        //    {
        //        List<ProductEntity> products = connection.Query<ProductEntity, SpendingEntity, ProductEntity>(
        //            ProductCommands.GetAll,
        //            (product, spending) =>
        //            {
        //                product.Spending = spending;

        //                return product;
        //            },
        //            splitOn: "Id")
        //            .Distinct()
        //            .ToList();

        //        return products;
        //    });
        //}

        //public override Task<ProductEntity> GetByIdAsync(Guid id, IDbConnection connection)
        //{
        //    return Task.Run(() =>
        //    {
        //        ProductEntity entity = connection.Query<ProductEntity, SpendingEntity, ProductEntity>(
        //            ProductCommands.GetById,
        //            (product, spending) =>
        //            {
        //                product.Spending = spending;

        //                return product;
        //            },
        //            new { id },
        //            splitOn: "Id")
        //            .Distinct()
        //            .FirstOrDefault();

        //        return entity;
        //    });
        //}
        public Task<List<FilterEntity>> GetProductsFilterAsync(IDbConnection dbConnection)
        {
            throw new NotImplementedException();
        }
    }
}
