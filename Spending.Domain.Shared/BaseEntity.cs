using Dapper.Contrib.Extensions;
using System;

namespace Spending.Domain.Shared
{
    public class BaseEntity
    {
        private Guid _id;

        [ExplicitKey]
        public Guid Id
        {
            get
            {
                if (_id == Guid.Empty || _id == null)
                    _id = Guid.NewGuid();

                return _id;
            }
            set
            {
                if (value == Guid.Empty || value == null)
                    _id = Guid.NewGuid();
                else
                    _id = value;
            }
        }


        public Guid? CreateUser { get; set; }
        public DateTime? CreateDate { get; set; }
        public Guid? UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
}
