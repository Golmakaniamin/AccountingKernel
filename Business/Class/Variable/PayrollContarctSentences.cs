using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingKernel.Class.Variable
{
    public class PayrollContarctSentences
    {
        public Guid ID { get; set; }
        public Guid PayrollSentencesID { get; set; }
        public Guid? PrSType { get; set; }
        public Guid? PrSOType { get; set; }
        public string PrSDescription { get; set; }
        public decimal? PrSMoney { get; set; }
        public bool? PrSIsInsurance { get; set; }
        public bool? PrSIsTax { get; set; }
        public string PrSInsuranceEmployer { get; set; }
        public string PrSInsuranceUnemployment { get; set; }
        public string PrSInsuranceEmployee { get; set; }
        public string PrSOTypeDesc { get; set; }
        public string PrSTypeDesc { get; set; }
        public decimal? Money { get; set; }
        public bool IsSelected { get; set; }
    }
}
