using System;
using System.Data;

namespace Spending.Domain.Interfaces.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        bool Commit();
        bool Rollback();
        IDbConnection GetConnection();
        IDbTransaction GetTransaction();
    }
}
