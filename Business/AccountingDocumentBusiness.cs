using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace AccountingKernel
{
    public class AccountingDocumentBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<AccountingDocument> Table { get { return ak1.AccountingDocuments; } }

        public IQueryable<AccountingDocument> GetAll()
        {
            try
            {
                return Table.Where(r => r.AISDeleted != true);
            }
            catch
            {

                throw;
            }
        }

        public Data.AccountingDocument GetById(Guid AccountingDocumentId)
        {
            try
            {
                return this.GetAll().Where(r => r.Id == AccountingDocumentId).FirstOrDefault();
            }
            catch
            {

                throw;
            }
        }

        public void Delete(Data.AccountingDocument document)
        {
            try
            {
                document.AISDeleted = true;
                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        ///  ثبت سند خودکار برای فاکتور خرید
        /// </summary>
        /// <param name="storeOrder"></param>
        public void SaveAutomaticDocumentForPurchaseInvoice(Data.StoreOrder storeOrder)
        {
            try
            {
                var document = new Data.AccountingDocument()
                        {
                            ADCode = this.GetNextCode(),
                            ADType = Common.Constants.DocumentType.PurchaseInvoice,
                            ADDate = storeOrder.ODate,
                            ADDescription = storeOrder.ODescription,
                            AIdStatus = Common.Constants.DocumentStatus.TemporaryApproved,
                            AISDeleted = false
                        };

                this.Save(document);

                Business.GetAccountingArticleBusiness().SaveAutomaticForPurchaseInvoice(storeOrder, document);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        ///  ثبت سند خودکار برای فاکتور فروش
        /// </summary>
        /// <param name="storeOrder"></param>
        public void SaveAutomaticDocumentForSaleInvoice(Data.StoreOrder storeOrder)
        {
            try
            {
                var document = new Data.AccountingDocument()
                {
                    ADCode = this.GetNextCode(),
                    ADType = Common.Constants.DocumentType.SaleInvoice,
                    ADDate = storeOrder.ODate,
                    ADDescription = storeOrder.ODescription,
                    AIdStatus = Common.Constants.DocumentStatus.TemporaryApproved,
                    AISDeleted = false
                };

                this.Save(document);

                Business.GetAccountingArticleBusiness().SaveAutomaticForSaleInvoice(storeOrder, document);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        ///  ثبت سند خودکار برای فاکتور برگشت از فروش
        /// </summary>
        /// <param name="storeOrder"></param>
        public void SaveAutomaticDocumentForSaleReturnInvoice(Data.StoreOrder storeOrder)
        {
            try
            {
                var document = new Data.AccountingDocument()
                {
                    ADCode = this.GetNextCode(),
                    ADType = Common.Constants.DocumentType.SaleReturnInvoice,
                    ADDate = storeOrder.ODate,
                    ADDescription = storeOrder.ODescription,
                    AIdStatus = Common.Constants.DocumentStatus.TemporaryApproved,
                    AISDeleted = false
                };

                this.Save(document);

                Business.GetAccountingArticleBusiness().SaveAutomaticForSaleReturnInvoice(storeOrder, document);
            }
            catch
            {

                throw;
            }
        }

        public void Save(AccountingDocument entity)
        {
            try
            {
                if (entity.Id == Guid.Empty)
                {
                    entity.Id = Guid.NewGuid();
                    entity.LastEdit = DateTime.Now;
                    this.Table.Add(entity);
                }

                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public int GetNextCode()
        {
            try
            {
                return this.GetAll().Max(r => r.ADCode).ToInt() + 1;
            }
            catch
            {

                throw;
            }
        }

    }
}
