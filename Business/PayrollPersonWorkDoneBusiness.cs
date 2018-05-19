using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingKernel
{
    public class PayrollPersonWorkDoneBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<PayrollPersonWorkDone> Table { get { return ak1.PayrollPersonWorkDones; } }

        public System.Data.Entity.DbSet<PayrollFunction> View { get { return ak1.PayrollFunctions; } }

        public IQueryable<PayrollFunction> GetView()
        {
            try
            {
                return View;
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<PayrollPersonWorkDone> GetAll()
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

        public PayrollPersonWorkDone GetByID(Guid ID)
        {
            try
            {
                return this.GetAll().Where(r => r.ID == ID).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public void Delete(PayrollPersonWorkDone DeletedItem)
        {
            try
            {
                if (DeletedItem.ID == Guid.Empty)
                    return;
                Table.Remove(DeletedItem);
                this.SubmitChanges();
            }
            catch
            {
                throw;
            }
        }

        public void Save(List<PayrollPersonWorkDone> _payrollPersonWorkDone)
        {
            try
            {
                foreach (var item in _payrollPersonWorkDone)
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

        public void Save(PayrollPersonWorkDone _payrollPersonWorkDone)
        {
            try
            {
                if (_payrollPersonWorkDone.ID == Guid.Empty)
                    this.Insert(_payrollPersonWorkDone);
                this.SubmitChanges();
            }
            catch
            {

                throw;
            }

        }

        public void Insert(PayrollPersonWorkDone _payrollPersonWorkDone)
        {
            try
            {
                if (_payrollPersonWorkDone.ID == Guid.Empty)
                    _payrollPersonWorkDone.ID = Guid.NewGuid();
                this.Table.Add(_payrollPersonWorkDone);
            }
            catch
            {
                throw;
            }
        }


        public IQueryable<PayrollWork> GetPerson()
        {
            var person = from per in Business.GetPayrollPersonWorkDoneBusiness().GetView()
                         group per by per.PersonID into pergrp
                         select new PayrollWork()
                         {
                             PersonID = pergrp.Key,
                             ID = pergrp.Select(r => r.ID).FirstOrDefault(),
                             PersonFirstName = pergrp.Select(r => r.PersonFirstName).FirstOrDefault(),
                             PersonLastName = pergrp.Select(r => r.PersonLastName).FirstOrDefault(),
                             Financialyear = pergrp.Select(r => r.Financialyear).FirstOrDefault(),
                             PersonContent = pergrp.Select(r => r.PersonContent),
                             FactorHeader = pergrp.Select(r => r.FactorHeader),
                             Content = pergrp.Select(r => new { r.FactorHeader, r.PersonContent })
                         };
            return person;



            //Business.GetPayrollPersonBusiness().GetAll()
            //.Join(Business.GetPayrollPersonWorkDoneBusiness().GetAll(),
            //pList => pList.id, pWork => pWork.IDPayrollPerson, (pList, pWork) =>
            //new { Person = pList, PayrollWork = pWork })
            //.Join(Business.GetPayrollWorkDoneFactorsBussines().GetAll(),
            //pWork => pWork.PayrollWork.IDPayrollWorkDoneFactors, fWork => fWork.ID, (pWork, fWork) =>
            //new
            //{
            //    PersonID = pWork.Person.id,
            //    ID = pWork.PayrollWork.ID,
            //    PersonFirstName = pWork.Person.PFristName,
            //    PersonLastName = pWork.Person.PLastName,
            //    Financialyear = pWork.PayrollWork.IDFinancialyear,
            //    PersonContent = pWork.PayrollWork.PrPWContent,
            //    //FactorHeader = fWork.PrWFDescription,
            //    FactorID = fWork.ID
            //}).GroupBy(r => r.PersonID).Select(r => new PayrollWork()
            //{
            //    PersonID = r.Key,
            //    ID = r.Select(i => i.ID).FirstOrDefault(),
            //    PersonFirstName = r.Select(i => i.PersonFirstName).FirstOrDefault(),
            //    PersonLastName = r.Select(i => i.PersonLastName).FirstOrDefault(),
            //    Financialyear = r.Select(i => i.Financialyear).FirstOrDefault(),
            //    //PersonContent = r.Select(i => i.PersonContent),
            //    //FactorHeader = r.Select(i => i.FactorID),
            //    FactorContent = r.Select(i => new { factors = i.FactorID, content = i.PersonContent }).ToDictionary(f => f.factors, fv => fv.content)
            //    //new Dictionary<Guid,string>(i.FactorID,i.PersonContent))
            //});            
        }
    }
}

