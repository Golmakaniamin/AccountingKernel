using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Transactions;

namespace AccountingKernel
{
    public class GoodiesBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<Goody> Table { get { return ak1.Goodies; } }

        public IQueryable<Goody> GetAll()
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

        public void Insert(Goody entity)
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

        public Goody GetById(Guid Id)
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


        public IQueryable<Goody> GetByIds(List<Guid> Ids)
        {
            try
            {
                return this.GetAll().Where(r => Ids.Contains(r.ID));
            }
            catch
            {

                throw;
            }
        }

        public void Delete(Goody entity)
        {
            try
            {
                if (entity == null)
                    return;


                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted,
                    Timeout = new TimeSpan(2, 0, 0)
                }))
                {
                    Business.GetGoodyConvertCountingUnitBusiness().Delete(Business.GetGoodyConvertCountingUnitBusiness().GetByGoodyId(entity.ID));
                    Business.GetGoodyPriceListBusiness().Delete(Business.GetGoodyPriceListBusiness().GetByGoodyId(entity.ID).ToList());
                    this.Table.Remove(entity);
                    this.SubmitChanges();


                    scope.Complete();
                }
            }
            catch
            {

                throw;
            }
        }

        public void Save(Goody entity)
        {
            try
            {
                if (entity.ID == Guid.Empty)
                {
                    entity.ID = Guid.NewGuid();
                    this.Insert(entity);
                }
                else
                    this.SubmitChanges();

            }
            catch
            {

                throw;
            }
        }


        public decimal SetPrice(Guid? unitId, Goody goody, Com company)
        {
            try
            {
                if (!unitId.HasValue)
                    return 0;

                if (goody == null || company == null || !company.CPersonType.HasValue)
                    return 0;

                var priceList = Business.GetPriceListBusiness().GetByCommodityIdCompanyPriceTypeId(company.CPriceType.Value, goody.ID);
                var coefficient = Business.GetGoodyConvertCountingUnitBusiness().FindCoefficient(goody.ID, goody.CBaseCountingUnit.ToGUID(), unitId.Value);
                if (priceList != null && priceList.PLPrice.HasValue)
                    return priceList.PLPrice.ToDecimal() * coefficient;
                return 0;
            }
            catch
            {

                throw;
            }
        }


        public Data.Goody GetByName(string name)
        {
            try
            {
                return this.GetAll().Where(r => r.CName == name).FirstOrDefault();
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Data.Goody> GetByIdGoodiesGroup(Guid idGoodiesGroup)
        {
            try
            {
                return this.GetAll().Where(r => r.IdGoodiesGroups == idGoodiesGroup);
            }
            catch 
            {
                
                throw;
            }
        }
    }
}
