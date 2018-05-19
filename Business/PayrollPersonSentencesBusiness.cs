using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Data;
namespace AccountingKernel
{
    public class PayrollPersonSentencesBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<Data.PayrollPersonSentence> Table { get { return ak1.PayrollPersonSentences; } }

        public IQueryable<Data.PayrollPersonSentence> GetAll()
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
        public void Save(List<Data.PayrollPersonSentence> _payrollPersonSentence)
        {
            try
            {
                foreach (var item in _payrollPersonSentence)
                {
                    if (item.ID == Guid.Empty)
                        this.Insert(item);
                }
                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public void Insert(Data.PayrollPersonSentence _payrollPersonSentence)
        {
            try
            {
                if (_payrollPersonSentence.ID == Guid.Empty)
                    _payrollPersonSentence.ID = Guid.NewGuid();
                this.Table.Add(_payrollPersonSentence);
                this.SubmitChanges();
            }
            catch
            {
                throw;
            }
        }

        public void Delete(Data.PayrollPersonSentence DeletedItem)
        {
            try
            {
                Table.Remove(DeletedItem);
                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }


        public IQueryable<Data.PayrollPersonSentence> GetByPersonID(Guid _personID)
        {
            return Business.GetPayrollPersonSentencesBusiness().GetAll().Where(r => r.IDPayrollPerson == _personID);
        }

        public Data.PayrollPersonSentence GetByID(Guid ID)
        {
            return Business.GetPayrollPersonSentencesBusiness().GetAll().Where(r => r.ID == ID).FirstOrDefault();
        }
    }
}
