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
    
    public partial class FundView
    {
        public System.Guid ID { get; set; }
        public string FName { get; set; }
        public string FBank { get; set; }
        public string FBankNO { get; set; }
        public string Fbranch { get; set; }
        public string FbranchNO { get; set; }
        public string FAccountnumber { get; set; }
        public string FCartNO { get; set; }
        public string FAddress { get; set; }
        public Nullable<decimal> Fprice { get; set; }
        public Nullable<System.Guid> FType { get; set; }
        public System.DateTime LastEdit { get; set; }
    }
}