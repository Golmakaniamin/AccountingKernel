using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Data;

namespace AccountingKernel
{
    public class PayrollLoanBusiness : BaseBusiness
    {
        public DbSet<Data.PayrollLoan> Table { get { return ak1.PayrollLoans; } }

        public void Save(List<Data.PayrollLoan> _payrollLoan)
        {

            try
            {
                foreach (var item in _payrollLoan)
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

        public void Insert(PayrollLoan _payrollLoan)
        {
            try
            {
                if (_payrollLoan.ID == Guid.Empty)
                    _payrollLoan.ID = Guid.NewGuid();
                this.Table.Add(_payrollLoan);
                this.SubmitChanges();
            }
            catch
            {
                throw;
            }
        }

    }
}
