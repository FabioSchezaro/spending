using Dapper.Contrib.Extensions;
using Spending.Domain.Shared;
using Spending.Domain.Shared.Interfaces;

namespace Spending.Domain
{
    [Table("dbo.Users")]
    public class UserEntity : BaseEntity, IUser
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool SuperUser { get; set; }
    }
}
