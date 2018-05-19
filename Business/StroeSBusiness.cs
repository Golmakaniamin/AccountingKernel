using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Data;

namespace AccountingKernel
{
    public class StoreSBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<Data.Store> Table { get { return ak1.StoreS; } }

        public IQueryable<Data.Store> GetAll()
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

        public void Insert(Data.Store store)
        {
            try
            {
                if (store.Id == Guid.Empty)
                    store.Id = Guid.NewGuid();
                this.Table.Add(store);
                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public void Delete(List<Data.Store> entities)
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

        public void Delete(Data.Store entity)
        {
            try
            {
                if (entity == null)
                    return;

                this.Delete(new List<Data.Store>() { entity });
            }
            catch
            {

                throw;
            }
        }

        public void Save(Store store)
        {
            try
            {
                if (store.Id == Guid.Empty)
                {
                    store.Id = Guid.NewGuid();
                    this.Insert(store);
                }
                else
                    this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }


        public Store GetById(Guid StoreId)
        {
            try
            {
                return this.GetAll().FirstOrDefault(r => r.Id == StoreId);
            }
            catch
            {

                throw;
            }
        }


        public Store GetByStoreSName(Guid storeDetailId)
        {
            try
            {
                return this.GetAll().Where(r => storeDetailId == r.IdStoreOrderDetail).FirstOrDefault();
            }
            catch
            {

                throw;
            }
        }

        public Data.Store GetLastForCommodity(Guid commodityId)
        {
            try
            {
                return this.GetAll().Where(r => r.IdCommodity == commodityId).OrderByDescending(r => r.ApprovedDate).FirstOrDefault();
            }
            catch
            {

                throw;
            }
        }

        public void Insert(List<Store> stores)
        {
            try
            {
                stores.ForEach(r =>
                {
                    r.Id = Guid.NewGuid();
                    this.Table.Add(r);
                });
                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public List<Data.Store> GetByStoreOrderDetailIds(List<Guid> storeOrderDetailIds)
        {
            try
            {
                return this.GetAll().Where(r => storeOrderDetailIds.Contains(r.IdStoreOrderDetail)).ToList();
            }
            catch
            {

                throw;
            }
        }
    }
}
