using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingKernel
{
    public class StoreOrderDetailBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<StoreOrderDetail> Table { get { return ak1.StoreOrderDetails; } }

        public IQueryable<StoreOrderDetail> GetAll()
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

        public void Insert(List<StoreOrderDetail> storeOrderDetails)
        {
            try
            {
                storeOrderDetails.FindAll(r => r.Id == Guid.Empty).ForEach(r => r.Id = Guid.NewGuid());
                storeOrderDetails.ForEach(r => this.Table.Add(r));
                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public void Insert(StoreOrderDetail storeOrderDetail)
        {
            try
            {
                this.Insert(new List<StoreOrderDetail>() { storeOrderDetail });
            }
            catch
            {

                throw;
            }
        }

        public void Delete(List<StoreOrderDetail> entityList)
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

        public void Save(StoreOrderDetail storeOrderDetail)
        {
            try
            {
                if (storeOrderDetail.Id == Guid.Empty)
                {
                    storeOrderDetail.Id = Guid.NewGuid();
                    this.Insert(storeOrderDetail);
                }
                else
                    this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<StoreOrderDetail> GetByStoreOrderId(Guid storeOrderId)
        {
            try
            {
                return this.GetAll().Where(r => r.IdStoreOrder == storeOrderId);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// returns store order detail by commodityid and unit count
        /// </summary>
        /// <param name="commodityId"></param>
        /// <param name="guid2"></param>
        /// <returns></returns>
        public StoreOrderDetail GetByCommodity(Data.StoreOrder storeOrder, Guid commodityId, Guid unitCountId)
        {
            try
            {
                return this.GetAll().FirstOrDefault(r => r.IdCommodity == commodityId && r.ODCountingUnit == unitCountId && r.IdStoreOrder == storeOrder.Id);
            }
            catch
            {

                throw;
            }
        }

        public StoreOrderDetail GetById(Guid id)
        {
            try
            {
                return this.GetAll().FirstOrDefault(r => r.Id == id);
            }
            catch
            {

                throw;
            }
        }

        public StoreOrderDetail Clone(StoreOrderDetail storeOrderDetail)
        {
            try
            {
                return new StoreOrderDetail()
                {
                    IdStoreOrder = storeOrderDetail.IdStoreOrder,
                    IdStoreS = storeOrderDetail.IdStoreS,
                    IdCommodity = storeOrderDetail.IdCommodity,
                    ODCountingUnit = storeOrderDetail.ODCountingUnit,
                    ODCount = storeOrderDetail.ODCount,
                    ODMoney = storeOrderDetail.ODMoney,
                    ODDiscount = storeOrderDetail.ODDiscount,
                    ODDescription = storeOrderDetail.ODDescription
                };
            }
            catch
            {

                throw;
            }
        }

        public List<Data.StoreOrderDetail> GetByStoreOrderIds(List<Guid> storeOrderIds)
        {
            try
            {
                return this.GetAll().Where(r => storeOrderIds.Contains(r.IdStoreOrder)).ToList();
            }
            catch
            {

                throw;
            }
        }

        public void DeleteByStoreOrderId(Guid StoreOrderId)
        {
            try
            {
                this.Delete(this.GetByStoreOrderId(StoreOrderId).ToList());
            }
            catch
            {

                throw;
            }
        }
    }
}
