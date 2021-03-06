﻿using Spending.Domain.Interfaces.IRepositories.IBaseCrudRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Spending.Domain.Interfaces.IRepositories
{
    public interface IProductRepository : IBaseCrudRepository<ProductEntity, Guid>
    {
    }
}
