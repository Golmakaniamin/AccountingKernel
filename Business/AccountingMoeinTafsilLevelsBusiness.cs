using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingKernel
{
    public class AccountingMoeinTafsilLevelsBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<AccountingMoeinTafsilLevel> Table { get { return ak1.AccountingMoeinTafsilLevels; } }

        public IQueryable<AccountingMoeinTafsilLevel> GetAll()
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

        public AccountingMoeinTafsilLevel GetById(Guid guid)
        {
            try
            {
                return this.GetAll().FirstOrDefault(r => r.ID == guid);
            }
            catch
            {

                throw;
            }
        }

        public void Delete(List<AccountingMoeinTafsilLevel> entities)
        {
            try
            {
                entities.ForEach(r => Table.Remove(r));
                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<AccountingMoeinTafsilLevel> GetByMoeinId(Guid accountingMoeinId)
        {
            try
            {
                var tafsils = new List<Guid>();
                tafsils.Add(Common.Constants.CodeTitle.Tafsil1);
                tafsils.Add(Common.Constants.CodeTitle.Tafsil2);
                tafsils.Add(Common.Constants.CodeTitle.Tafsil3);
                return this.GetAll().Where(r => tafsils.Contains(r.IdTafsilGroup.Value) && r.IdAccountingMoein == accountingMoeinId);
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<AccountingMoeinTafsilLevel> GetByMoeinId(Guid accountingMoeinId, Guid tafsilId)
        {
            try
            {
                return this.GetAll().Where(r => r.IdTafsilGroup.Value == tafsilId && r.IdAccountingMoein == accountingMoeinId);
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Data.AccountingMoeinTafsilLevel> GetByIdAccountingTafsilLevels(List<Guid> ids)
        {
            try
            {
                return this.GetAll().Where(r => ids.Contains(r.IdAccountingTafsilLevels.Value));
            }
            catch
            {

                throw;
            }
        }


        public Data.AccountingMoeinTafsilLevel GetByIdAccountingTafsilLevels(Guid id)
        {
            try
            {
                return this.GetAll().Where(r => r.IdAccountingTafsilLevels == id).FirstOrDefault();
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Data.AccountingMoeinTafsilLevel> GetByIdAccountingMoein(Guid idAccountingMoein, Guid satheTafsil)
        {
            try
            {
                return this.GetAll().Where(r => r.IdAccountingMoein == idAccountingMoein && r.IdTafsilGroup == satheTafsil);
            }
            catch
            {

                throw;
            }
        }

    }
}
