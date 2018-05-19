using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingKernel.Class
{
    public class MyMenuItem
    {
        //Payroll
        public MyMenuItem()
        {
            this.Items = new ObservableCollection<MyMenuItem>();
        }


        public Guid ID { get; set; }

        public string Name { get; set; }

        public string Title
        {
            get
            { return string.Format("{0}/{1}", Code, Name); }
        }

        public string Code { get; set; }

        public Guid? Type { get; set; }

        public ObservableCollection<MyMenuItem> Items { get; set; }
    }
}
