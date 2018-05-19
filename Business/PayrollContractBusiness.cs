using Common;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingKernel
{
    public class PayrollContractBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<PayrollContract> Table { get { return ak1.PayrollContracts; } }

        public Data.PayrollContract GetByPersonID(Guid personID)
        {
            try
            {
                return this.Table.Where(r => r.IDPayrollPerson == personID).FirstOrDefault();
            }
            catch
            {

                throw;
            }
        }



        public static List<Data.PayrollContract> _PayrollContract;

        public static List<Data.PayrollContract> PayrollContract
        {
            get
            {
                if (_PayrollContract != null)
                    return _PayrollContract;
                _PayrollContract = Business.GetPayrollContractBusiness().Table.ToList();
                return _PayrollContract;
            }
        }

        public IQueryable<Data.PayrollContract> GetAll()
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

        public void Save(Data.PayrollContract PayrollContract)
        {
            try
            {
                if (PayrollContract.ID == Guid.Empty)
                    this.Insert(PayrollContract);
                else
                    this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public void Insert(Data.PayrollContract payrollContract)
        {
            try
            {
                if (payrollContract.ID == Guid.Empty)
                    payrollContract.ID = Guid.NewGuid();
                this.Table.Add(payrollContract);
                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public Data.PayrollContract GetById(Guid Id)
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

        public IQueryable<Class.Variable.PayrollContarctSentences> GetItems(Guid _personID)
        {

            return Business.GetPayrollSentencesBusiness().GetAll().
                 Join(Business.GetBaseInfoBusiness().GetAll(),
                 rFrist => rFrist.PrSType, o => o.Id, (rFrist, oFrist) =>
                     new { PayrollSentence = rFrist, BaseInfo = oFrist }).
                     Join(Business.GetBaseInfoBusiness().GetAll(),
                     rSecend => rSecend.PayrollSentence.PrSOType, oSecend => oSecend.Id,
             (r, i) => new { all = r, i }).
             Join(Business.GetPayrollPersonSentencesBusiness().GetAll().Where(r => r.IDPayrollPerson == _personID),
             r => r.all.PayrollSentence.ID, i => i.IDPayrollSentences,
             (r, i) => new Class.Variable.PayrollContarctSentences
             {
                 PayrollSentencesID = r.all.PayrollSentence.ID,
                 ID = i.ID,
                 PrSType = r.all.PayrollSentence.PrSType,
                 PrSOType = r.all.PayrollSentence.PrSOType,
                 PrSDescription = r.all.PayrollSentence.PrSDescription,
                 PrSMoney = r.all.PayrollSentence.PrSMoney,
                 PrSIsInsurance = r.all.PayrollSentence.PrSIsInsurance,
                 PrSIsTax = r.all.PayrollSentence.PrSIsTax,
                 PrSInsuranceEmployer = r.all.PayrollSentence.PrSInsuranceEmployer,
                 PrSInsuranceUnemployment = r.all.PayrollSentence.PrSInsuranceUnemployment,
                 PrSInsuranceEmployee = r.all.PayrollSentence.PrSInsuranceEmployee,
                 PrSOTypeDesc = r.i.AssignName,
                 PrSTypeDesc = r.all.BaseInfo.AssignName,
                 Money = i.PrPSMoney,
             });
        }
    }
}
