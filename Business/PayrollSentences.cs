using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingKernel
{
    public class PayrollSentencesBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<Data.PayrollSentence> Table { get { return ak1.PayrollSentences; } }

        public IQueryable<Data.PayrollSentence> GetAll()
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

        public void Insert(PayrollSentence payrollBenefitAndDeductions)
        {
            try
            {
                if (payrollBenefitAndDeductions.ID == Guid.Empty)
                    payrollBenefitAndDeductions.ID = Guid.NewGuid();
                this.Table.Add(payrollBenefitAndDeductions);
                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public PayrollSentence GetById(Guid Id)
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

        public void Save(PayrollSentence PayrollSentences)
        {
            try
            {
                if (PayrollSentences.ID == Guid.Empty)
                    this.Insert(PayrollSentences);
                else
                    this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Data.PayrollSentence> GetSentenceByUserId(Guid _Id)
        {
            try
            {
                return Business.GetPayrollPersonBusiness().GetAll().Where(r => r.id == _Id).
                       Join(Business.GetPayrollPersonSentencesBusiness().GetAll(),
                       p => p.id, ps => ps.IDPayrollSentences, (p, ps) =>
                                 new { PayrollPerson = p, PersonSentences = ps }).
                                 Join(Business.GetPayrollSentencesBusiness().GetAll(),
                                 ps => ps.PersonSentences.IDPayrollSentences, s => s.ID, (ps, s) =>
                                     new { PayrollSentence = s }).Select(r => r.PayrollSentence);
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Class.Variable.PayrollContarctSentences> GetItems()
        {
            try
            {
                return this.GetAll().
                        Join(Business.GetBaseInfoBusiness().GetAll(),
                        r => r.PrSType, o => o.Id, (r, o) =>
                            new { PayrollSentence = r, BaseInfo = o }).Join(Business.GetBaseInfoBusiness().GetAll(),
                        o => o.PayrollSentence.PrSOType, i => i.Id,

                    (r, i) =>
                     new Class.Variable.PayrollContarctSentences
                     {
                         PayrollSentencesID = r.PayrollSentence.ID,
                         PrSType = r.PayrollSentence.PrSType,
                         PrSOType = r.PayrollSentence.PrSOType,
                         PrSDescription = r.PayrollSentence.PrSDescription,
                         PrSMoney = r.PayrollSentence.PrSMoney,
                         PrSIsInsurance = r.PayrollSentence.PrSIsInsurance,
                         PrSIsTax = r.PayrollSentence.PrSIsTax,
                         PrSInsuranceEmployer = r.PayrollSentence.PrSInsuranceEmployer,
                         PrSInsuranceUnemployment = r.PayrollSentence.PrSInsuranceUnemployment,
                         PrSInsuranceEmployee = r.PayrollSentence.PrSInsuranceEmployee,
                         PrSOTypeDesc = i.AssignName,
                         PrSTypeDesc = r.BaseInfo.AssignName,
                     });
            }
            catch
            {
                throw;
            }
        }
    }
}
