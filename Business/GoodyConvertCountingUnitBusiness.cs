using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using AccountingKernel;

namespace AccountingKernel
{
    public class GoodyConvertCountingUnitBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<GoodyConvertCountingUnit> Table { get { return ak1.GoodyConvertCountingUnits; } }

        public IQueryable<GoodyConvertCountingUnit> GetAll()
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

        public void Insert(GoodyConvertCountingUnit goodyConvertCountingUnit)
        {
            try
            {
                if (goodyConvertCountingUnit.ID == Guid.Empty)
                    goodyConvertCountingUnit.ID = Guid.NewGuid();
                this.Table.Add(goodyConvertCountingUnit);
                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public GoodyConvertCountingUnit GetById(Guid id)
        {
            try
            {
                return this.GetAll().Where(r => r.ID == id).FirstOrDefault();
            }
            catch
            {

                throw;
            }
        }

        public void Save(GoodyConvertCountingUnit goodyConvertCountingUnit)
        {
            try
            {
                if (goodyConvertCountingUnit.ID == Guid.Empty)
                    this.Insert(goodyConvertCountingUnit);
                else
                    this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public GoodyConvertCountingUnit GetByGoodyId(Guid CommodityId, Guid firstUnitId, Guid secondUnitId)
        {
            try
            {
                return this.GetAll().Where(r => r.IDCommodity == CommodityId && r.CCCUIDBaseInfo1 == firstUnitId && r.CCCUIDBaseInfo2 == secondUnitId).FirstOrDefault();
            }
            catch
            {

                throw;
            }
        }

        public List<GoodyConvertCountingUnit> GetByGoodyId(Guid CommodityId)
        {
            try
            {
                return this.GetAll().Where(r => r.IDCommodity == CommodityId).ToList();
            }
            catch
            {

                throw;
            }
        }

        public void Delete(GoodyConvertCountingUnit entity)
        {
            try
            {
                this.Delete(new List<Data.GoodyConvertCountingUnit>() { entity });
            }
            catch
            {

                throw;
            }
        }

        public void Delete(List<GoodyConvertCountingUnit> entityList)
        {
            try
            {
                entityList.ForEach(r => this.Table.Remove(r));
                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public decimal FindCoefficient(Guid goodyId, Guid firstUnit, Guid secondUnit)
        {
            try
            {
                if (firstUnit == secondUnit)
                    return 1;
                var convert = this.GetAll().Where(r => r.IDCommodity == goodyId && r.CCCUIDBaseInfo1 == firstUnit && r.CCCUIDBaseInfo2 == secondUnit).FirstOrDefault();
                if (convert == null)
                    throw new Exception(Localize.ex_converting_unit_not_found);

                if (convert.CCCUCount2.ToInt() == 0)
                    throw new Exception(Localize.ex_invalid_converting_unit);

                return (decimal)convert.CCCUCount1 / (decimal)convert.CCCUCount2;
            }
            catch
            {

                throw;
            }
        }
         
    }
}
