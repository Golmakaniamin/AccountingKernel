using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingKernel
{
    public class StoreOperativeBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<StoreOperative> Table { get { return ak1.StoreOperatives; } }

        public IQueryable<StoreOperative> GetAll()
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

        public void Insert(StoreOperative storeOperative)
        {
            try
            {
                if (storeOperative.Id == Guid.Empty)
                    storeOperative.Id = Guid.NewGuid();
                this.Table.Add(storeOperative);
                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public void Delete(List<StoreOperative> entityList)
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

        public void Save(StoreOperative storeOperative)
        {
            try
            {
                if (storeOperative.Id == Guid.Empty)
                {
                    storeOperative.Id = Guid.NewGuid();
                    this.Insert(storeOperative);
                }
                else
                    this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public StoreOperative GetById(Guid id)
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

        public StoreOperative GetByStoreOrderDetailId(Guid storeDetailId, Guid operativeId)
        {
            try
            {
                return this.GetAll().Where(r => r.IdStoreDetail == storeDetailId && r.IdOperative == operativeId).FirstOrDefault();
            }
            catch
            {

                throw;
            }
        }

        public StoreOperative GetByStoreOrderId(Guid storeOrderId, Guid operativeId)
        {
            try
            {
                return this.GetAll().Where(r => r.IdStoreOrder == storeOrderId && r.IdOperative == operativeId).FirstOrDefault();
            }
            catch 
            {
                
                throw;
            }
        }

        public IQueryable<StoreOperative> GetByStoreOrderId(Guid storeOrderId)
        {
            try
            {
                return this.GetAll().Where(r => r.IdStoreOrder == storeOrderId );
            }
            catch
            {

                throw;
            }
        }

    }
}
