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
    
    public partial class Goody
    {
        public System.Guid ID { get; set; }
        public string CID1 { get; set; }
        public string CName { get; set; }
        public string CNameEn { get; set; }
        public Nullable<int> COrderPoint { get; set; }
        public Nullable<int> COrderMax { get; set; }
        public Nullable<int> COrderMin { get; set; }
        public Nullable<int> CPointCritical { get; set; }
        public Nullable<int> CInventoryMax { get; set; }
        public Nullable<System.Guid> CType { get; set; }
        public Nullable<System.Guid> CBaseCountingUnit { get; set; }
        public Nullable<System.Guid> IdAccountingTafsillevelsDetails { get; set; }
        public Nullable<System.Guid> IdGoodiesGroups { get; set; }
    }
}