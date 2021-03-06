using Dapper.Contrib.Extensions;
using Spending.Domain.Interfaces.IRepositories.IBaseCrudRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spending.Repository.Data.Sql.BaseCrudRepository
{
    public class BaseCrudRepository<TEntity, TGuid> : IBaseCrudRepository<TEntity, TGuid> where TEntity : class
                                                                      where TGuid : struct
    {
        public async virtual Task<List<TEntity>> GetAllAsync(IDbConnection connection)
        {
            
            var list = await connection.GetAllAsync<TEntity>();
            return list.ToList();
            
        }
        public async virtual Task<TEntity> GetByIdAsync(TGuid id, IDbConnection connection)
        {
            return await connection.GetAsync<TEntity>(id);
        }
        public async virtual Task<bool> InsertAsync(TEntity entity, IDbConnection connection, IDbTransaction transaction = null)
        {
            try
            {
                await connection.InsertAsync(entity, transaction);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        public async virtual Task<bool> UpdateAsync(TEntity entity, IDbConnection connection, IDbTransaction transaction = null)
        {
            try
            {
                return await connection.UpdateAsync(entity, transaction);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async virtual Task<bool> DeleteAsync(TEntity entity, IDbConnection connection, IDbTransaction transaction = null)
        {
            try
            {
                return await connection.DeleteAsync(entity, transaction);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
