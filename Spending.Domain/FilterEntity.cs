using System;
using System.Collections.Generic;

namespace Spending.Domain
{
    public class FilterEntity
    {
        public string Id { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public string TotalValue { get; set; }
        public List<DetailEntity> DetailCollection { get; set; } = new List<DetailEntity>();
    }
}
