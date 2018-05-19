using Common;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingKernel
{
    public class FinancialyearBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<Data.Financialyear> Table { get { return ak1.Financialyears; } }
        public static List<Data.Financialyear> _Financialyear;
        public static List<Data.Financialyear> Financialyear
        {
            get
            {
                if (_Financialyear != null)
                    return _Financialyear;
                _Financialyear = Business.GetFinancialyearBusiness().Table.ToList();
                return _Financialyear;
            }
        }

        public IQueryable<Data.Financialyear> GetAll()
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


        public void Save(List<Data.Financialyear> fyList)
        {
            try
            {
                fyList.FindAll(r => r.ID == Guid.Empty).ForEach(r =>
                {
                    r.ID = Guid.NewGuid();
                    this.Table.Add(r);
                });

                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }
    }
}
