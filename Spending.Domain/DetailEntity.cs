using System;

namespace Spending.Domain
{
    public class DetailEntity
    {
        public Guid ProductId{ get; set; }
        public string ProductDescription { get; set; }
        public int CurrentParcel { get; set; }
        public int RemaingParcel { get; set; }
        public int Month { get; set; }
        public float ParcelValue { get; set; }
        public int Year { get; set; }
    }
}
