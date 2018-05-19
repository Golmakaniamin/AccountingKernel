using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingKernel
{
    public class PayrollWork
    {
        public Guid PersonID { get; set; }

        public Guid ID { get; set; }

        public string PersonFirstName { get; set; }

        public string PersonLastName { get; set; }

        public Guid? Financialyear { get; set; }

        public IDictionary<Guid, string> FactorContent { get; set; }

        public IEnumerable<string> PersonContent { get; set; }

        public IEnumerable<string> FactorHeader { get; set; }

        public object Content { get; set; }
    }


}
