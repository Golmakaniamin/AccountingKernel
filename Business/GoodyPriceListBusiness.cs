using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingKernel
{
    public class GoodyPriceListBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<GoodyPriceList> Table { get { return ak1.GoodyPriceLists; } }

        public IQueryable<GoodyPriceList> GetAll()
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

        public void Insert(GoodyPriceList entity)
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

        public GoodyPriceList GetById(Guid Id)
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

        public void Delete(GoodyPriceList entity)
        {
            try
            {
                this.Delete(new List<Data.GoodyPriceList>() { entity });
            }
            catch
            {

                throw;
            }
        }

        public void Delete(List<GoodyPriceList> entityList)
        {
            try
            {
                if (!entityList.Any())
                    return;

                entityList.ForEach(r => this.Table.Remove(r));
                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public GoodyPriceList GetByGoodyIdCompanyPriceTypeId(Guid companyPriceTypeId, Guid GoodyId)
        {
            try
            {
                return this.GetAll().Where(r => r.IDBaseInfo == companyPriceTypeId && r.IDGoody == GoodyId).FirstOrDefault();
            }
            catch
            {

                throw;
            }
        }

        public void Save(GoodyPriceList goodyPriceList)
        {
            try
            {
                if (goodyPriceList.Id == Guid.Empty)
                {
                    goodyPriceList.Id = Guid.NewGuid();
                    this.Insert(goodyPriceList);
                }
                else
                    this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<GoodyPriceList> GetByGoodyId(Guid goodyId)
        {
            try
            {
                return this.GetAll().Where(r => r.IDGoody == goodyId);
            }
            catch
            {

                throw;
            }
        }
    }
}
