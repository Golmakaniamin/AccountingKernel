using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingKernel
{
    public class PriceListBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<PriceList> Table { get { return ak1.PriceLists; } }

        public IQueryable<PriceList> GetAll()
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

        public void Insert(PriceList priceList)
        {
            try
            {
                if (priceList.Id == Guid.Empty)
                    priceList.Id = Guid.NewGuid();
                this.Table.Add(priceList);
                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public PriceList GetById(Guid Id)
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

        public void Delete(PriceList entity)
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

        public PriceList GetByCommodityIdCompanyPriceTypeId(Guid companyPriceTypeId, Guid CommodityId)
        {
            try
            {
                return this.GetAll().Where(r => r.IDBaseInfo == companyPriceTypeId && r.IDCommodity == CommodityId).FirstOrDefault();
            }
            catch 
            {
                
                throw;
            }
        }

        public void Save(PriceList priceList)
        {
            try
            {
                if (priceList.Id == Guid.Empty)
                {
                    priceList.Id = Guid.NewGuid();
                    this.Insert(priceList);
                }
                else
                    this.SubmitChanges();
            }
            catch 
            {
                
                throw;
            }
        }

        public IQueryable<PriceList> GetByCommodityId(Guid commodityId)
        {
            try
            {
                return this.GetAll().Where (r=>r.IDCommodity== commodityId);
            }
            catch 
            {
                
                throw;
            }
        }
    }
}
