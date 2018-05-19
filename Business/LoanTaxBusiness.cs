using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Data;
using Common;

namespace AccountingKernel
{
    public class LoanTaxBusiness : BaseBusiness
    {
        public DbSet<Data.PayrollTaximmunity> Table { get { return ak1.PayrollTaximmunities; } }

        public IQueryable<Data.PayrollTaximmunity> GetAll()
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
    }
}