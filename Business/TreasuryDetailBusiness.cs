using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Data;

namespace AccountingKernel
{
    public class TreasuryDetailBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<Data.TreasuryDetail> Table { get { return ak1.TreasuryDetails; } }
        public System.Data.Entity.DbSet<Data.TreasuryDetailsView> View { get { return ak1.TreasuryDetailsViews; } }

        public IQueryable<Data.TreasuryDetail> GetAll()
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

        public IQueryable<Data.TreasuryDetailsView> GetViewAll()
        {
            try
            {
                return View;
            }
            catch
            {

                throw;
            }
        }


        public void Insert(TreasuryDetail entity)
        {
            try
            {
                if (entity.ID == Guid.Empty)
                    entity.ID = Guid.NewGuid();
                this.Table.Add(entity);
                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public TreasuryDetail GetById(Guid Id)
        {
            try
            {
                return this.GetAll().Where(r => r.ID == Id).FirstOrDefault();
            }
            catch
            {

                throw;
            }
        }

        public void Delete(Data.TreasuryDetail entity)
        {
            try
            {
                if (entity == null)
                    return;

                this.Delete(new List<Data.TreasuryDetail>() { entity });
            }
            catch
            {

                throw;
            }
        }

        public void Delete(List<Data.TreasuryDetail> entities)
        {
            try
            {
                if (!entities.Any())
                    return;

                entities.ForEach(r => this.Table.Remove(r));

                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }


        public void Save(Data.TreasuryDetail entity)
        {
            try
            {
                if (entity.ID == Guid.Empty)
                    this.Insert(entity);
                else
                    this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Data.TreasuryDetail> GetByTreasuryId(Guid TreasuryId)
        {
            try
            {
                return this.GetAll().Where(r => r.IDTreasury == TreasuryId);
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Data.TreasuryDetailsView> GetViewByTreasuryId(Guid TreasuryId)
        {
            try
            {
                return this.GetViewAll().Where(r => r.IDTreasury == TreasuryId);
            }
            catch 
            {
                
                throw;
            }
        }
    }
}
