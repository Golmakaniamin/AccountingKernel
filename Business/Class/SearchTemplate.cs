using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingKernel.Class
{
    public class SearchTemplate
    {
        public Guid ID { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public Guid? Type { get; set; }

        public Guid? ParentID { get; set; }
    }
}
