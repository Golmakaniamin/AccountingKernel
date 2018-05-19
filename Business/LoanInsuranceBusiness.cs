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
    public class LoanInsuranceBusiness : BaseBusiness
    {
        public DbSet<Data.PayrollInsuranceimmunity> Table { get { return ak1.PayrollInsuranceimmunities; } }

        public IQueryable<Data.PayrollInsuranceimmunity> GetAll()
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
