using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Data;

namespace AccountingKernel
{
    public class ChequeBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<Data.Check> Table { get { return ak1.Checks; } }

        public IQueryable<Data.Check> GetAll()
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


        public Check GetById(Guid Id)
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

        public void Delete(Data.Check entity)
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


        public void Save(Data.Check cheque)
        {
            try
            {
                this.Save(new List<Data.Check>() { cheque });
            }
            catch
            {

                throw;
            }
        }

        public void Save(List<Data.Check> entities)
        {
            try
            {
                foreach (var item in entities.FindAll(r => r.ID == Guid.Empty))
                {
                    item.ID = Guid.NewGuid();
                    this.Table.Add(item);
                }

                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public Data.Check GetByNumber(string chequeNumber, string bankName)
        {
            try
            {
                var funds = Business.GetFundsBusiness().GetByFBank(bankName).ToList();
                var cheques = this.GetByCNO(chequeNumber).ToList();
                return cheques.Join(funds, o => o.CBank, i => i.ID, (o, i) => new { Cheque = o }).Select(r => r.Cheque).FirstOrDefault();
            }
            catch
            {

                throw;
            }
        }

        private IQueryable<Check> GetByCNO(string chequeNumber)
        {
            try
            {
                return this.GetAll().Where(r => r.CNO == chequeNumber);
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Data.Check> GetByFundId(Guid FundId, string minSerial, string maxSerial)
        {
            try
            {
                return this.GetAll().Where(r => r.CBank == FundId && r.CNO.CompareTo(minSerial) >= 0 && r.CNO.CompareTo(maxSerial) <= 0);
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Data.Check> GetByCType(Guid guid)
        {
            try
            {
                return this.GetAll().Where(r => r.CType == guid);
            }
            catch
            {

                throw;
            }
        }
    }
}
