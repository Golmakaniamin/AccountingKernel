using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Data;

namespace AccountingKernel
{
    public class PayrollLoanDetailBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<Data.PayrollLoanDetail> Table { get { return ak1.PayrollLoanDetails; } }

        public IQueryable<Data.PayrollLoanDetail> GetAll()
        {
            try
            {
                return Table;
            }
            catch
            {

                throw;
            }
        }

        public void Save(List<Data.PayrollLoanDetail> _payrollLoanDetail)
        {

            try
            {
                foreach (var item in _payrollLoanDetail)
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

        public void Insert(Data.PayrollLoanDetail _payrollLoanDetail)
        {
            try
            {
                if (_payrollLoanDetail.ID == Guid.Empty)
                    _payrollLoanDetail.ID = Guid.NewGuid();
                this.Table.Add(_payrollLoanDetail);
                this.SubmitChanges();
            }
            catch
            {
                throw;
            }
        }

    }
}
