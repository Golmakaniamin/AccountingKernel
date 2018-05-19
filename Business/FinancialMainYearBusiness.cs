using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Data;
using Common;

namespace AccountingKernel
{
    public class FinancialMainYearBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<Data.FinancialMainYear> Table { get { return ak1.FinancialMainYears; } }

        public IQueryable<Data.FinancialMainYear> GetAll()
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


        public void Insert(FinancialMainYear entity)
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

        public FinancialMainYear GetById(Guid Id)
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

        public void Delete(Data.FinancialMainYear entity)
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

        public void Save(FinancialMainYear entity)
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

        public IQueryable<FinancialMainYear> GetByCorporationId(Guid CorposrationId)
        {
            try
            {
                return this.GetAll().Where(r => r.IDCorporation == CorposrationId);

            }
            catch
            {

                throw;
            }
        }


        public FinancialMainYear GetByYear(string date , Guid corporationId)
        {
            try
            {
                var year = date.ExtractYear().ToInt();
                return this.GetAll().Where(r => r.FYear == year && r.IDCorporation == corporationId).FirstOrDefault();
            }
            catch 
            {
                
                throw;
            }
        }

        public Data.FinancialMainYear GetByCorporartionId(Guid corporationId, int year)
        {
            try
            {
                return this.GetAll().FirstOrDefault(r => r.IDCorporation == corporationId && r.FYear == year);
            }
            catch
            {

                throw;
            }
        }
    }
}
