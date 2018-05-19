using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Data;

namespace AccountingKernel
{
    public class PayrollSalaryFactorBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<Data.PayrollSalaryFactor> Table { get { return ak1.PayrollSalaryFactors; } }

        public void Save(List<Data.PayrollSalaryFactor> _payrollSalaryFactor)
        {
            try
            {
                foreach (var item in _payrollSalaryFactor)
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

        public void Insert(Data.PayrollSalaryFactor _payrollSalaryFactor)
        {
            try
            {
                if (_payrollSalaryFactor.ID == Guid.Empty)
                    _payrollSalaryFactor.ID = Guid.NewGuid();
                this.Table.Add(_payrollSalaryFactor);

            }
            catch
            {
                throw;
            }
        }
    }
}
