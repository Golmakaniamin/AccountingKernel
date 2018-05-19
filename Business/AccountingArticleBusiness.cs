using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Data;

namespace AccountingKernel
{
    public class AccountingArticleBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<Data.AccountingArticle> Table { get { return ak1.AccountingArticles; } }

        public IQueryable<Data.AccountingArticle> GetAll()
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


        public void Insert(AccountingArticle entity)
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

        public AccountingArticle GetById(Guid Id)
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

        public void Delete(Data.AccountingArticle entity)
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




        public IQueryable<Data.AccountingArticle> GetByAccountingDcoumentId(Guid AccountingDocumentId)
        {
            try
            {
                return this.GetAll().Where(r => r.IDAccountingDocument == AccountingDocumentId);
            }
            catch
            {

                throw;
            }
        }

        public void Save(AccountingArticle entity)
        {
            try
            {
                this.Save(new List<AccountingArticle>() { entity });
            }
            catch
            {

                throw;
            }
        }

        public void Save(List<AccountingArticle> entityList)
        {
            try
            {
                entityList.FindAll(r => r.ID == Guid.Empty).ForEach(r =>
                {
                    r.ID = Guid.NewGuid();
                    this.Table.Add(r);
                });

                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// فاکتور خرید
        /// </summary>
        /// <param name="storeOrder"></param>
        /// <param name="document"></param>
        public void SaveAutomaticForPurchaseInvoice(StoreOrder storeOrder, AccountingDocument document)
        {
            try
            {

                var accountingArticles = new List<Data.AccountingArticle>();
                var accountingTafsilArticles = new List<Data.AccountingTafsilArticle>();
                var dictionary = new Dictionary<Data.AccountingArticle, Data.AccountingTafsilArticle>();

                var company = Business.GetCompanyBusiness().GetById(storeOrder.IdCompany.Value);
                if (!company.IdAccountingTafsillevelsDetails.HasValue)
                    throw new Exception(string.Format(Localize.ex_company_no_accountingtafsillevelsdetails, company.CName));

                var storeOrderDetails = Business.GetStoreOrderDetailBusiness().GetByStoreOrderId(storeOrder.Id).ToList();

                var accountingArticle = new AccountingArticle()
                {
                    IDAccountingDocument = document.Id,
                    ADescription = null,
                    ADebtor = null,
                    ACreditor = storeOrder.OSumMoney,
                    ACount = 1
                };
                accountingArticles.Add(accountingArticle);

                var companyTafsilLevelsDetail = Business.GetAccountingTafsilLevelDetailBusiness().GetById(company.IdAccountingTafsillevelsDetails.Value);
                var companyTafsilLevel = Business.GetAccountingTafsilLevelBusiness().GetById(companyTafsilLevelsDetail.IdAccountingTafsilLevels.Value);
                var companyAccountingMoeinTafsilLevel = Business.GetAccountingMoeinTafsilLevelBusiness().GetByIdAccountingTafsilLevels(companyTafsilLevel.Id);

                var accountingTafsilArticle = new AccountingTafsilArticle()
                {
                    IDAccountingMoein = companyAccountingMoeinTafsilLevel.IdAccountingMoein,
                    IdAccountingTafsilLDetails = companyTafsilLevelsDetail.Id,
                    //IdAccountingTafsilLevels = tafsilLevel.Id
                };

                accountingTafsilArticles.Add(accountingTafsilArticle);

                dictionary.Add(accountingArticle, accountingTafsilArticle);

                var commodities = Business.GetGoodiesBusiness().GetByIds(storeOrderDetails.Select(r => r.IdCommodity).ToList()).ToList();
                if (commodities.Any(r => !r.IdAccountingTafsillevelsDetails.HasValue))
                    throw new Exception(string.Format(Localize.ex_commodity_no_accountingtafsillevelsdetails, commodities.First(r => !r.IdAccountingTafsillevelsDetails.HasValue).CName));

                var tafsilLevelsDetails = Business.GetAccountingTafsilLevelDetailBusiness().GetByIds(commodities.Where(r => r.IdAccountingTafsillevelsDetails.HasValue).Select(r => r.IdAccountingTafsillevelsDetails.Value).ToList());
                var tafsilLevels = Business.GetAccountingTafsilLevelBusiness().GetByIds(tafsilLevelsDetails.Where(r => r.IdAccountingTafsilLevels.HasValue).Select(r => r.IdAccountingTafsilLevels.Value).ToList());
                var accountingMoeinTafsilLevels = Business.GetAccountingMoeinTafsilLevelBusiness().GetByIdAccountingTafsilLevels(tafsilLevels.Select(r => r.Id).ToList()).ToList();

                foreach (var item in storeOrderDetails)
                {
                    accountingArticle = new AccountingArticle()
                    {
                        IDAccountingDocument = document.Id,
                        ADescription = item.ODDescription,
                        ADebtor = item.ODMoney,
                        ACreditor = null,
                        ACount = item.ODCount
                    };
                    accountingArticles.Add(accountingArticle);

                    var commodity = commodities.Find(r => r.ID == item.IdCommodity);
                    var tafsilLevelDetail = tafsilLevelsDetails.Find(r => r.Id == commodity.IdAccountingTafsillevelsDetails);
                    var tafsilLevel = tafsilLevels.Find(r => r.Id == tafsilLevelDetail.IdAccountingTafsilLevels);
                    var accountingMoeinTafsilLevel = accountingMoeinTafsilLevels.Find(r => r.IdAccountingTafsilLevels == tafsilLevel.Id);

                    accountingTafsilArticle = new AccountingTafsilArticle()
                    {
                        IDAccountingMoein = accountingMoeinTafsilLevel.IdAccountingMoein,
                        IdAccountingTafsilLDetails = tafsilLevelDetail.Id,
                        //IdAccountingTafsilLevels = tafsilLevel.Id
                    };
                    accountingTafsilArticles.Add(accountingTafsilArticle);

                    dictionary.Add(accountingArticle, accountingTafsilArticle);
                }
                this.Save(accountingArticles);

                foreach (var item in dictionary)
                    item.Value.IdAccountingArticle = item.Key.ID;

                Business.GetAccountingTafsilArticleBusiness().Save(accountingTafsilArticles);

            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// فاکتور فروش
        /// </summary>
        /// <param name="storeOrder"></param>
        /// <param name="document"></param>
        public void SaveAutomaticForSaleInvoice(StoreOrder storeOrder, AccountingDocument document)
        {
            try
            {
                var accountingArticles = new List<Data.AccountingArticle>();
                var accountingTafsilArticles = new List<Data.AccountingTafsilArticle>();
                var dictionary = new Dictionary<Data.AccountingArticle, Data.AccountingTafsilArticle>();

                var company = Business.GetCompanyBusiness().GetById(storeOrder.IdCompany.Value);
                if (!company.IdAccountingTafsillevelsDetails.HasValue)
                    throw new Exception(string.Format(company.CName, Localize.ex_company_no_accountingtafsillevelsdetails));

                var storeOrderDetails = Business.GetStoreOrderDetailBusiness().GetByStoreOrderId(storeOrder.Id).ToList();

                var accountingArticle = new AccountingArticle()
                {
                    IDAccountingDocument = document.Id,
                    ADescription = null,
                    ADebtor = storeOrder.OSumMoney,
                    ACreditor = null,
                    ACount = 1
                };
                accountingArticles.Add(accountingArticle);

                var companyTafsilLevelsDetail = Business.GetAccountingTafsilLevelDetailBusiness().GetById(company.IdAccountingTafsillevelsDetails.Value);
                var companyTafsilLevel = Business.GetAccountingTafsilLevelBusiness().GetById(companyTafsilLevelsDetail.IdAccountingTafsilLevels.Value);
                var companyAccountingMoeinTafsilLevel = Business.GetAccountingMoeinTafsilLevelBusiness().GetByIdAccountingTafsilLevels(companyTafsilLevel.Id);

                var accountingTafsilArticle = new AccountingTafsilArticle()
                {
                    IDAccountingMoein = companyAccountingMoeinTafsilLevel.IdAccountingMoein,
                    IdAccountingTafsilLDetails = companyTafsilLevelsDetail.Id,
                    //IdAccountingTafsilLevels = tafsilLevel.Id
                };

                accountingTafsilArticles.Add(accountingTafsilArticle);

                dictionary.Add(accountingArticle, accountingTafsilArticle);

                var commodities = Business.GetGoodiesBusiness().GetByIds(storeOrderDetails.Select(r => r.IdCommodity).ToList()).ToList();
                if (commodities.Any(r => !r.IdAccountingTafsillevelsDetails.HasValue))
                    throw new Exception(string.Format(Localize.ex_commodity_no_accountingtafsillevelsdetails, commodities.First(r => !r.IdAccountingTafsillevelsDetails.HasValue).CName));

                var tafsilLevelsDetails = Business.GetAccountingTafsilLevelDetailBusiness().GetByIds(commodities.Where(r => r.IdAccountingTafsillevelsDetails.HasValue).Select(r => r.IdAccountingTafsillevelsDetails.Value).ToList());
                var tafsilLevels = Business.GetAccountingTafsilLevelBusiness().GetByIds(tafsilLevelsDetails.Where(r => r.IdAccountingTafsilLevels.HasValue).Select(r => r.IdAccountingTafsilLevels.Value).ToList());
                var accountingMoeinTafsilLevels = Business.GetAccountingMoeinTafsilLevelBusiness().GetByIdAccountingTafsilLevels(tafsilLevels.Select(r => r.Id).ToList()).ToList();

                foreach (var item in storeOrderDetails)
                {
                    accountingArticle = new AccountingArticle()
                    {
                        IDAccountingDocument = document.Id,
                        ADescription = item.ODDescription,
                        ADebtor = null,
                        ACreditor = item.ODMoney,
                        ACount = item.ODCount
                    };
                    accountingArticles.Add(accountingArticle);

                    var commodity = commodities.Find(r => r.ID == item.IdCommodity);
                    var tafsilLevelDetail = tafsilLevelsDetails.Find(r => r.Id == commodity.IdAccountingTafsillevelsDetails);
                    var tafsilLevel = tafsilLevels.Find(r => r.Id == tafsilLevelDetail.IdAccountingTafsilLevels);
                    var accountingMoeinTafsilLevel = accountingMoeinTafsilLevels.Find(r => r.IdAccountingTafsilLevels == tafsilLevel.Id);

                    accountingTafsilArticle = new AccountingTafsilArticle()
                    {
                        IDAccountingMoein = accountingMoeinTafsilLevel.IdAccountingMoein,
                        IdAccountingTafsilLDetails = tafsilLevelDetail.Id,
                        //IdAccountingTafsilLevels = tafsilLevel.Id
                    };
                    accountingTafsilArticles.Add(accountingTafsilArticle);

                    dictionary.Add(accountingArticle, accountingTafsilArticle);
                }
                this.Save(accountingArticles);

                foreach (var item in dictionary)
                    item.Value.IdAccountingArticle = item.Key.ID;

                Business.GetAccountingTafsilArticleBusiness().Save(accountingTafsilArticles);

            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// فاکتور فروش
        /// </summary>
        /// <param name="storeOrder"></param>
        /// <param name="document"></param>
        public void SaveAutomaticForSaleReturnInvoice(StoreOrder storeOrder, AccountingDocument document)
        {
            try
            {
                var accountingArticles = new List<Data.AccountingArticle>();
                var accountingTafsilArticles = new List<Data.AccountingTafsilArticle>();
                var dictionary = new Dictionary<Data.AccountingArticle, Data.AccountingTafsilArticle>();

                var company = Business.GetCompanyBusiness().GetById(storeOrder.IdCompany.Value);
                if (!company.IdAccountingTafsillevelsDetails.HasValue)
                    throw new Exception(string.Format(Localize.ex_company_no_accountingtafsillevelsdetails, company.CName));
                var storeOrderDetails = Business.GetStoreOrderDetailBusiness().GetByStoreOrderId(storeOrder.Id).ToList();

                var accountingArticle = new AccountingArticle()
                {
                    IDAccountingDocument = document.Id,
                    ADescription = null,
                    ADebtor = null,
                    ACreditor = storeOrder.OSumMoney,
                    ACount = 1
                };
                accountingArticles.Add(accountingArticle);

                var companyTafsilLevelsDetail = Business.GetAccountingTafsilLevelDetailBusiness().GetById(company.IdAccountingTafsillevelsDetails.Value);
                var companyTafsilLevel = Business.GetAccountingTafsilLevelBusiness().GetById(companyTafsilLevelsDetail.IdAccountingTafsilLevels.Value);
                var companyAccountingMoeinTafsilLevel = Business.GetAccountingMoeinTafsilLevelBusiness().GetByIdAccountingTafsilLevels(companyTafsilLevel.Id);

                var accountingTafsilArticle = new AccountingTafsilArticle()
                {
                    IDAccountingMoein = companyAccountingMoeinTafsilLevel.IdAccountingMoein,
                    IdAccountingTafsilLDetails = companyTafsilLevelsDetail.Id,
                    //IdAccountingTafsilLevels = tafsilLevel.Id
                };

                accountingTafsilArticles.Add(accountingTafsilArticle);

                dictionary.Add(accountingArticle, accountingTafsilArticle);

                var commodities = Business.GetGoodiesBusiness().GetByIds(storeOrderDetails.Select(r => r.IdCommodity).ToList()).ToList();
                if (commodities.Any(r => !r.IdAccountingTafsillevelsDetails.HasValue))
                    throw new Exception(string.Format(Localize.ex_commodity_no_accountingtafsillevelsdetails, commodities.First(r => !r.IdAccountingTafsillevelsDetails.HasValue).CName));
                var tafsilLevelsDetails = Business.GetAccountingTafsilLevelDetailBusiness().GetByIds(commodities.Where(r => r.IdAccountingTafsillevelsDetails.HasValue).Select(r => r.IdAccountingTafsillevelsDetails.Value).ToList());
                var tafsilLevels = Business.GetAccountingTafsilLevelBusiness().GetByIds(tafsilLevelsDetails.Where(r => r.IdAccountingTafsilLevels.HasValue).Select(r => r.IdAccountingTafsilLevels.Value).ToList());
                var accountingMoeinTafsilLevels = Business.GetAccountingMoeinTafsilLevelBusiness().GetByIdAccountingTafsilLevels(tafsilLevels.Select(r => r.Id).ToList()).ToList();

                foreach (var item in storeOrderDetails)
                {
                    accountingArticle = new AccountingArticle()
                    {
                        IDAccountingDocument = document.Id,
                        ADescription = item.ODDescription,
                        ADebtor = item.ODMoney,
                        ACreditor = null,
                        ACount = item.ODCount
                    };
                    accountingArticles.Add(accountingArticle);

                    var commodity = commodities.Find(r => r.ID == item.IdCommodity);
                    var tafsilLevelDetail = tafsilLevelsDetails.Find(r => r.Id == commodity.IdAccountingTafsillevelsDetails);
                    var tafsilLevel = tafsilLevels.Find(r => r.Id == tafsilLevelDetail.IdAccountingTafsilLevels);
                    var accountingMoeinTafsilLevel = accountingMoeinTafsilLevels.Find(r => r.IdAccountingTafsilLevels == tafsilLevel.Id);

                    accountingTafsilArticle = new AccountingTafsilArticle()
                    {
                        IDAccountingMoein = accountingMoeinTafsilLevel.IdAccountingMoein,
                        IdAccountingTafsilLDetails = tafsilLevelDetail.Id,
                        //IdAccountingTafsilLevels = tafsilLevel.Id
                    };
                    accountingTafsilArticles.Add(accountingTafsilArticle);

                    dictionary.Add(accountingArticle, accountingTafsilArticle);
                }
                this.Save(accountingArticles);

                foreach (var item in dictionary)
                    item.Value.IdAccountingArticle = item.Key.ID;

                Business.GetAccountingTafsilArticleBusiness().Save(accountingTafsilArticles);

            }
            catch
            {

                throw;
            }
        }
    }
}
