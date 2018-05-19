using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
namespace AccountingKernel
{
    public class PayrollMPJBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<Data.PayrollImprest> Table { get { return ak1.PayrollImprests; } }

        public void Save(List<Data.PayrollImprest> _payrollImprest)
        {
            try
            {
                foreach (var item in _payrollImprest)
                {
                    if (item.ID == Guid.Empty)
                        this.Insert(item);
                }
                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public void Insert(Data.PayrollImprest _payrollImprest)
        {
            try
            {
                if (_payrollImprest.ID == Guid.Empty)
                    _payrollImprest.ID = Guid.NewGuid();
                this.Table.Add(_payrollImprest);
                this.SubmitChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
