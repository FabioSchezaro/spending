using Dapper.Contrib.Extensions;
using Spending.Domain.Shared;
using System;
using System.Collections.Generic;

namespace Spending.Domain
{
    [Table("dbo.Gastos")]
    public class SpendingEntity : BaseEntity
    {
        public Guid ProductId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Parcel { get; set; }
        public float ParcelValue { get; set; }
        [Write(false)] public string TotalValue { get; set; }
        [Write(false)] public string ProductDescription { get; set; }
        [Write(false)] public int CurrentParcel { get; set; }
        [Write(false)] public int RemaingParcel { get; set; }
        [Write(false)] public string MonthDescription { get; set; }
        [Write(false)] public List<ProductEntity> ProductsCollection { get; set; } = new List<ProductEntity>();
    }
}
