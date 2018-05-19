using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingKernel
{
    public class GetMoeinCodesBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<Data.AccountingMoeinCode> Table { get { return ak1.AccountingMoeinCodes; } }

        public IQueryable<Data.AccountingMoeinCode> GetAll()
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


        public Data.AccountingMoeinCode GetMoeinCode(Guid StructureID, Guid MoeinType, Guid MoeinNature)
        {
            Data.AccountingMoeinCode _entity = new Data.AccountingMoeinCode();
            try
            {
                _entity.StructureDefine_ID = StructureID;
                _entity.MType = MoeinType;
                _entity.MNature = MoeinNature;
            }
            catch
            {

                throw;
            }
            return _entity;
        }

        public void Save(Data.AccountingMoeinCode MoeinCodes)
        {
            try
            {
                if (MoeinCodes.ID == Guid.Empty)
                    this.Insert(MoeinCodes);
                else
                    this.SubmitChanges();

            }
            catch
            {

                throw;
            }
        }

        private void Insert(Data.AccountingMoeinCode MoeinCodes)
        {
            try
            {
                if (MoeinCodes.ID == Guid.Empty)
                    MoeinCodes.ID = Guid.NewGuid();
                this.Table.Add(MoeinCodes);
                this.SubmitChanges();
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<Data.AccountingMoeinCode> GetByID(Guid id)
        {
            try
            {
                return this.GetAll().Where(r => r.ID == id);
            }
            catch
            {

                throw;
            }
        }

        public IEnumerable<Data.AccountingMoeinCode> GetByStructureDefine_ID(Guid id)
        {
            try
            {
                return this.GetAll().Where(r => r.StructureDefine_ID == id);
            }
            catch
            {

                throw;
            }
        }

        public void Delete(Data.AccountingMoeinCode deletedItem)
        {
            try
            {
                Table.Remove(deletedItem);
                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }
    }
}
