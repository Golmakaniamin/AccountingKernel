using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingKernel
{
    public class BaseBusiness
    {
        static protected Data.AccountingKernelEntities10 ak1 = new Data.AccountingKernelEntities10();

        public void SubmitChanges()
        {
            try
            {
                ak1.SaveChanges();
            }
            catch 
            {
                
                throw;
            }
        }


    }
}
