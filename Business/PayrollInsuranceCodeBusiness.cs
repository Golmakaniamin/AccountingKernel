using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AccountingKernel
{
    public class PayrollInsuranceCodeBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<PayrollInsuranceCode> Table { get { return ak1.PayrollInsuranceCodes; } }

        public static List<PayrollInsuranceCode> _PayrollInsuranceCode;

        public static List<PayrollInsuranceCode> PayrollInsuranceCode
        {
            get
            {
                if (_PayrollInsuranceCode != null)
                    return _PayrollInsuranceCode;
                _PayrollInsuranceCode = Business.GetPayrollInsuranceCodeBusiness().Table.ToList();
                return _PayrollInsuranceCode;
            }
        }

        public IQueryable<PayrollInsuranceCode> GetAll()
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
