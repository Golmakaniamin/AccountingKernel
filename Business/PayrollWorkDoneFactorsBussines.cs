using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingKernel
{
    public class PayrollWorkDoneFactorsBussiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<PayrollWorkDoneFactor> Table { get { return ak1.PayrollWorkDoneFactors; } }

        public IQueryable<PayrollWorkDoneFactor> GetAll()
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

        public void Insert(PayrollWorkDoneFactor payrollWorkDoneFactor)
        {
            try
            {
                if (payrollWorkDoneFactor.ID == Guid.Empty)
                    payrollWorkDoneFactor.ID = Guid.NewGuid();
                this.Table.Add(payrollWorkDoneFactor);
                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public void Delete(PayrollWorkDoneFactor DeletedItem)
        {
            try
            {
                if (DeletedItem.ID == Guid.Empty)
                    return;
                Table.Remove(DeletedItem);
                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public void Save(List<PayrollWorkDoneFactor> payrollWorkDoneFactors)
        {
            try
            {
                foreach (var item in payrollWorkDoneFactors)
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

        public PayrollWorkDoneFactor GetByID(Guid ID)
        {
            return this.GetAll().Where(r => r.ID == ID).FirstOrDefault();
        }

        public Dictionary<Guid, string> GetDic()
        {
            return this.GetAll().Select(r => new { r.ID, r.PrWFDescription }).ToDictionary(k => k.ID, v => v.PrWFDescription);
        }
    }
}
