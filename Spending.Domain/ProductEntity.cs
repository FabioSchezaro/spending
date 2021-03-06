using Dapper.Contrib.Extensions;
using Spending.Domain.Shared;

namespace Spending.Domain
{
    [Table("dbo.Produto")]
    public class ProductEntity : BaseEntity
    {
        public string Description { get; set; }
        public float Price { get; set; }
        public int Parcel { get; set; }
        public float InputValue { get; set; }
    }
}
