using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingKernel
{
    public class AccountingTafsilLevelBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<AccountingTafsilLevel> Table { get { return ak1.AccountingTafsilLevels; } }

        public IQueryable<AccountingTafsilLevel> GetAll()
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

        public IQueryable<AccountingTafsilLevel> GetByMoeinId(Guid moeinId)
        {
            try
            {
                //return this.GetAll().Where(r => r.IdAccountingMoein == moeinId);
                return this.GetAll();
            }
            catch
            {

                throw;
            }
        }


        public Data.AccountingTafsilLevel GetById(Guid id)
        {
            try
            {
                return this.GetAll().Where(r => r.Id == id).FirstOrDefault();
            }
            catch
            {

                throw;
            }
        }

        public List<Data.AccountingTafsilLevel> GetByIds(List<Guid> ids)
        {
            try
            {
                return this.GetAll().Where(r => ids.Contains(r.Id)).ToList();
            }
            catch
            {

                throw;
            }
        }



        public void Delete(List<Data.AccountingTafsilLevel> entities)
        {
            try
            {
                this.BeforeDelete(entities);

                entities.ForEach(r => this.Table.Remove(r));
                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        private void BeforeDelete(List<Data.AccountingTafsilLevel> entities)
        {
            try
            {

                var amtlBusiness = Business.GetAccountingMoeinTafsilLevelBusiness();


                amtlBusiness.Delete(amtlBusiness.GetByIdAccountingTafsilLevels(entities.Select(r => r.Id).ToList()).ToList());
            }
            catch
            {

                throw;
            }
        }

        public void Save(AccountingTafsilLevel entity)
        {
            try
            {
                if (entity.Id == Guid.Empty)
                {
                    entity.Id = Guid.NewGuid();
                    this.Table.Add(entity);
                }
                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Data.AccountingTafsilLevel> GetIdInStartWith(string idin)
        {
            try
            {
                return this.GetAll().Where(r => r.IdIn.StartsWith(idin));
            }
            catch
            {

                throw;
            }
        }
    }
}
