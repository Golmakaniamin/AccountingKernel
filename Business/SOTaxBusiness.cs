using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Data;

namespace AccountingKernel
{
    public class SOTaxBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<Data.SOTax> Table { get { return ak1.SOTaxes; } }
        public System.Data.Entity.DbSet<Data.SOTaxView> View { get { return ak1.SOTaxViews; } }

        public IQueryable<Data.SOTax> GetAll()
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

        public IQueryable<Data.SOTaxView> GetViewAll()
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

        public void Insert(SOTax entity)
        {
            try
            {
                if (entity.Id == Guid.Empty)
                    entity.Id = Guid.NewGuid();
                this.Table.Add(entity);
                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public SOTax GetById(Guid Id)
        {
            try
            {
                return this.GetAll().Where(r => r.Id == Id).FirstOrDefault();
            }
            catch
            {

                throw;
            }
        }

        public void Delete(Data.SOTax entity)
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

        public void Save(SOTax entity)
        {
            try
            {
                if (entity.Id == Guid.Empty)
                    this.Insert(entity);
                else
                    this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public Data.SOTax GetByFinancialYearBaseInfo(Guid financialMainYearId, Guid baseInfoId)
        {
            try
            {
                return this.GetAll().FirstOrDefault(r => r.IdFinancialMainYear == financialMainYearId && r.IdBaseinfo == baseInfoId);
            }
            catch 
            {
                
                throw;
            }
        }

        public IQueryable<Data.SOTaxView> GetViewByCorporationId(Guid corporationId)
        {
            try
            {
                return this.GetViewAll().Where(r => r.IDCorporation == corporationId);
            }
            catch 
            {
                
                throw;
            }
        }
    }
}
