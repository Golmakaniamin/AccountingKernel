using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingKernel
{
    public class AccountingMoeinBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<AccountingMoein> Table { get { return ak1.AccountingMoeins; } }

        public IQueryable<AccountingMoein> GetAll()
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

        public AccountingMoein GetById(Guid guid)
        {
            try
            {
                return this.GetAll().FirstOrDefault(r => r.Id == guid);
            }
            catch
            {

                throw;
            }
        }

        public void Delete(AccountingMoein moi)
        {
            try
            {
                Table.Remove(moi);
                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Data.AccountingMoein> GetByStartWithMIdMoein(string mIdMoein)
        {
            try
            {
                return this.GetAll().Where(r => r.MIdMoein.StartsWith(mIdMoein));
            }
            catch
            {

                throw;
            }
        }


        public Data.AccountingMoein GetByMIdMoein(string mIdMoein)
        {
            try
            {
                return this.GetAll().Where(r => r.MIdMoein == mIdMoein).FirstOrDefault();
            }
            catch
            {

                throw;
            }
        }

        public void Save(List<AccountingMoein> entities)
        {
            try
            {
                foreach (var item in entities.FindAll(r => r.Id == Guid.Empty))
                {
                    item.Id = Guid.NewGuid();
                    this.Table.Add(item);
                }
                
                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public void Save(AccountingMoein entity)
        {
            try
            {
                this.Save(new List<Data.AccountingMoein>() { entity });
            }
            catch
            {

                throw;
            }
        }

        public Data.AccountingMoein GetByName(string goruh, string kol, string moein)
        {
            try
            {
                return this.GetAll().FirstOrDefault(r => r.MIdGroup == goruh && r.MIdAll == kol && r.MName == moein);
            }
            catch 
            {
                
                throw;
            }
        }
    }
}
