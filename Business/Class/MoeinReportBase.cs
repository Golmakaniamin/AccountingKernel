using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingKernel.Class
{
    public class MoeinReportBase
    {
        public Guid ID { get; set; }

        public string FirstLevelCode { get; set; }

        public string FirstLevelName { get; set; }

        public string SecondLevelCode { get; set; }

        public string SecondLevelName { get; set; }
    }
}
