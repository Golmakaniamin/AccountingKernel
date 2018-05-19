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
    
    public partial class StoreOrder
    {
        public StoreOrder()
        {
            this.StoreOperatives = new HashSet<StoreOperative>();
        }
    
        public System.Guid Id { get; set; }
        public string OId { get; set; }
        public Nullable<int> OOwnerId { get; set; }
        public string ODate { get; set; }
        public Nullable<System.Guid> IdCompany { get; set; }
        public string ODescription { get; set; }
        public Nullable<bool> OReverse { get; set; }
        public Nullable<bool> ODelete { get; set; }
        public Nullable<decimal> OSumMoney { get; set; }
        public Nullable<decimal> ODiscount { get; set; }
        public Nullable<decimal> OTax { get; set; }
        public Nullable<decimal> OMunicipalTax { get; set; }
        public Nullable<System.Guid> OOrderType { get; set; }
        public Nullable<System.Guid> IdStoreOperation { get; set; }
        public Nullable<bool> OIsDeleted { get; set; }
        public Nullable<System.DateTime> LastEdit { get; set; }
    
        public virtual ICollection<StoreOperative> StoreOperatives { get; set; }
    }
}
