using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Data;
using AccountingKernel;

namespace AccountingKernel
{
    public class StoreOrderBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<StoreOrder> Table { get { return ak1.StoreOrders; } }
        public System.Data.Entity.DbSet<StoreOrderView> View { get { return ak1.StoreOrderViews; } }

        public IQueryable<StoreOrder> GetAll()
        {
            try
            {
                return Table.Where(r => r.OIsDeleted == false);
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<StoreOrderView> GetViewAll()
        {
            try
            {
                return View.Where(r => r.OIsDeleted == false);
            }
            catch
            {

                throw;
            }
        }

        public void Insert(StoreOrder storeOrder)
        {
            try
            {
                if (storeOrder.Id == Guid.Empty)
                    storeOrder.Id = Guid.NewGuid();
                storeOrder.OIsDeleted = false;
                this.Table.Add(storeOrder);
                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public void Delete(StoreOrder entity)
        {
            try
            {
                if (entity == null)
                    return;

                this.Delete(new List<Data.StoreOrder>() { entity });
            }
            catch
            {

                throw;
            }
        }

        private void Delete(List<StoreOrder> entities)
        {
            try
            {
                if (!entities.Any())
                    return;

                entities.ForEach(r => r.OIsDeleted = true);
                this.SubmitChanges();

            }
            catch
            {

                throw;
            }
        }

        public void Save(StoreOrder entity)
        {
            try
            {
                if (entity.Id == Guid.Empty)
                {
                    entity.LastEdit = DateTime.Now;
                    entity.Id = Guid.NewGuid();
                    this.Insert(entity);
                }
                else
                {
                    var entityView = this.GetViewById(entity.Id);
                    if (entityView.OId != entity.OId)
                    {
                        if (this.IsOIdExits(entity))
                            throw new Exception(Localize.ex_replicate_code);
                        entity.LastEdit = DateTime.Now;
                    }
                    this.SubmitChanges();
                }
            }
            catch
            {

                throw;
            }
        }



        public StoreOrderView GetViewById(Guid StoreOrderId)
        {
            try
            {
                return this.GetViewAll().FirstOrDefault(r => r.Id == StoreOrderId);
            }
            catch
            {

                throw;
            }
        }

        public StoreOrder GetById(Guid StoreOrderId)
        {
            try
            {
                return this.GetAll().FirstOrDefault(r => r.Id == StoreOrderId);
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<StoreOrder> GetByStoreOperation(Guid storeOperation)
        {
            try
            {
                return this.GetAll().Where(r => r.IdStoreOperation == storeOperation);
            }
            catch
            {

                throw;
            }
        }

        public string GetLastEditedOId(Guid storeOperationId)
        {
            try
            {
                var codeTitle = Business.GetCodeTitleBusiness().GetById(Common.Constants.CodeTitle.SaleFactor);
                var storeOrder = this.GetByStoreOperation(storeOperationId).OrderByDescending(r => r.LastEdit).FirstOrDefault();
                if (storeOrder == null)
                    return codeTitle.CodeStart.ToString().Calibrate('0', codeTitle.CodeLen.ToInt());

                var cdidin = storeOrder.OId.ToInt() + 1;
                string code = cdidin.ToString().Calibrate('0', codeTitle.CodeLen.ToInt());
                while (this.GetByOId(code, storeOperationId).Any())
                {
                    code = (++cdidin).ToString().Calibrate('0', codeTitle.CodeLen.ToInt());
                }

                return code;
            }
            catch
            {

                throw;
            }
        }

        private IQueryable<Data.StoreOrder> GetByOId(string oId, Guid? storeOperationId)
        {
            try
            {

                return this.GetAll().Where(r => r.OId == oId && r.IdStoreOperation == storeOperationId);

            }
            catch
            {

                throw;
            }
        }

        private bool IsOIdExits(Data.StoreOrder storeOrder)
        {
            try
            {
                return this.GetAll().Where(r => r.OId == storeOrder.OId && r.IdStoreOperation == storeOrder.IdStoreOperation && r.Id != storeOrder.Id).Any();

            }
            catch
            {

                throw;
            }
        }

        public StoreOrder Clone(StoreOrder storeOrder)
        {
            try
            {
                return new StoreOrder()
                {
                    OId = storeOrder.OId,
                    ODate = storeOrder.ODate,
                    IdCompany = storeOrder.IdCompany,
                    ODescription = storeOrder.ODescription,
                    OReverse = storeOrder.OReverse,
                    ODelete = storeOrder.ODelete,
                    OSumMoney = storeOrder.OSumMoney,
                    ODiscount = storeOrder.ODiscount,
                    OTax = storeOrder.OTax,
                    OMunicipalTax = storeOrder.OMunicipalTax,
                    OOrderType = storeOrder.OOrderType,
                    IdStoreOperation = storeOrder.IdStoreOperation
                };
            }
            catch
            {

                throw;
            }
        }

        public string GetMaxOIdByRepository(BaseInfo repository)
        {
            try
            {
                var storesBusiness = Business.GetStoreSBusiness();
                var storeOrderDetailBusiness = Business.GetStoreOrderDetailBusiness();

                var stores = storesBusiness.GetAll();
                var storeOrders = this.GetByStoreOperation(Common.Constants.StoreOperation.Order).Where(r => r.OIsDeleted == false);
                var storeDetails = storeOrderDetailBusiness.GetAll();
                var repositories = Business.GetBaseInfoBusiness().IQGetByType(Common.Constants.BaseInfoType.Repository);

                var tt = stores.Join(storeDetails, o => o.Id, i => i.IdStoreS, (o, i) => new { StoreS = o, StoreDetails = i });
                var storesJstoreDetails = repositories.Join(tt,
                    o => o.Id, i => i.StoreS.Sname, (o, i) => new { repositories = o, stores = i });

                var maxOid = storeOrders.Join(storesJstoreDetails, o => o.Id, i => i.stores.StoreDetails.IdStoreOrder, (o, i) => new
                {
                    storeOrdersJcompanies = o,
                    storesJstoreDetails = i
                }).Where(r => r.storesJstoreDetails.repositories.Id == repository.Id).OrderByDescending(r => r.storeOrdersJcompanies.OId).
                    Select(r => r.storeOrdersJcompanies.OId).FirstOrDefault();

                if (maxOid == null)
                    return string.Format("{0}{1}", repository.Priority, "1");

                var start = maxOid.Substring(0, repository.Priority.ToString().Length);
                var remained = maxOid.Substring(start.Length, start.Length).ToInt();
                return string.Format("{0}{1}", repository.Priority, remained.ToInt() + 1);


            }
            catch
            {

                throw;
            }
        }

        public void PhysicalDeleting(Guid StoreOrderId)
        {
            try
            {
                Business.GetStoreOrderDetailBusiness().Delete(Business.GetStoreOrderDetailBusiness().GetByStoreOrderId(StoreOrderId).ToList());
                var entity = this.GetById(StoreOrderId);
                if (entity != null)
                    this.Table.Remove(entity);
                this.SubmitChanges();

            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Data.StoreOrder> GetByCompany(Com company, Guid storeOperationId, string billCode)
        {
            try
            {
                return this.GetAll().Where(r => r.IdCompany == company.Id && r.IdStoreOperation == storeOperationId && r.OId == billCode);
            }
            catch
            {

                throw;
            }
        }

        public bool IsCodeExist(Com company, Guid guid, string billCode, Guid storeOrderId)
        {
            try
            {
                return this.GetByCompany(company, guid, billCode).Where(r => r.Id != storeOrderId).Any();
            }
            catch
            {

                throw;
            }
        }


    }
}
