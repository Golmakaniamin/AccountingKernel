//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class StoreOrderDetail
    {
        public StoreOrderDetail()
        {
            this.StoreOperatives = new HashSet<StoreOperative>();
        }
    
        public System.Guid Id { get; set; }
        public System.Guid IdStoreOrder { get; set; }
        public System.Guid IdStoreS { get; set; }
        public System.Guid IdCommodity { get; set; }
        public System.Guid ODCountingUnit { get; set; }
        public Nullable<int> ODCount { get; set; }
        public Nullable<int> ORemained { get; set; }
        public Nullable<decimal> ODMoney { get; set; }
        public Nullable<decimal> ODDiscount { get; set; }
        public string ODDescription { get; set; }
        public Nullable<int> PId { get; set; }
    
        public virtual ICollection<StoreOperative> StoreOperatives { get; set; }
    }
}
