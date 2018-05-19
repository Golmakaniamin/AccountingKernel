using Common;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingKernel
{
    public class PayrollTaxCodeBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<PayrollTaxCode> Table { get { return ak1.PayrollTaxCodes; } }

        public static List<PayrollTaxCode> _PayrollTaxCodes;
         
        public IQueryable<PayrollTaxCode> GetAll()
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

        public IQueryable<Data.PayrollTaxCode> GetByMCode(PayrollTaxCodeEnum payrollTaxCodeEnum)
        {
            try
            {
                return this.GetAll().Where(r => r.MCode == (int)payrollTaxCodeEnum);
            }
            catch
            {

                throw;
            }
        }
    }
}
