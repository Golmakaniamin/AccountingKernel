using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingKernel
{
    public class AccountingMoeinTafsilRelationBussiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<Data.AccountingMoeinTafsilRelation> Table { get { return ak1.AccountingMoeinTafsilRelations; } }

        public IQueryable<Data.AccountingMoeinTafsilRelation> GetAll()
        {
            try
            {
                return this.Table;
            }
            catch
            {

                throw;
            }
        }

        public List<AccountingMoeinTafsilRelation> SetRelation(AccountingMoeinStructureDefine TafsilLevel, List<AccountingTafsilStructureDefine> TafsilGroup)
        {
            List<AccountingMoeinTafsilRelation> result = new List<AccountingMoeinTafsilRelation>();
            foreach (var item in TafsilGroup)
            {
                result.Add(new AccountingMoeinTafsilRelation() { AcountingMoein_ID = TafsilLevel.ID, AccountingTafsil_ID = item.ID });
            }
            return result;
        }

        public void Save(List<AccountingMoeinTafsilRelation> Items)
        {
            try
            {
                foreach (var item in Items)
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

        public void Insert(Data.AccountingMoeinTafsilRelation Item)
        {
            try
            {
                if (Item.ID == Guid.Empty)
                    Item.ID = Guid.NewGuid();
                this.Table.Add(Item);

            }
            catch
            {
                throw;
            }
        }

        public IQueryable<AccountingMoeinTafsilRelation> GetByMoeinID(Guid MoeinID)
        {
            try
            {
                return this.GetAll().Where(r => r.AcountingMoein_ID == MoeinID);
            }
            catch
            {

                throw;
            }
        }

        public void Delete(AccountingMoeinTafsilRelation entity)
        {
            try
            {
                if (entity == null)
                    return;

                this.Table.Remove(entity);
                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public AccountingMoeinTafsilRelation GetByTafsilID(Guid TafsilID, Guid MoeinID)
        {
            return this.GetAll().Where(r => r.AccountingTafsil_ID == TafsilID && r.AcountingMoein_ID == MoeinID).FirstOrDefault();
        }
    }
}
