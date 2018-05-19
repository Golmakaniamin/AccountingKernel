using Common;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingKernel
{
    public class PayrollPersonBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<Data.PayrollPerson> Table { get { return ak1.PayrollPersons; } }

        public IQueryable<Data.PayrollPerson> GetAll()
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

        public void Insert(PayrollPerson payrollPerson)
        {
            try
            {
                if (payrollPerson.id == Guid.Empty)
                    payrollPerson.id = Guid.NewGuid();
                this.Table.Add(payrollPerson);
                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public PayrollPerson GetById(Guid Id)
        {
            try
            {
                return this.GetAll().Where(r => r.id == Id).FirstOrDefault();
            }
            catch
            {

                throw;
            }
        }

        public void Delete(Data.PayrollPerson entity)
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

        public void Save(PayrollPerson payrollPerson)
        {
            try
            {
                if (payrollPerson.id == Guid.Empty)
                    this.Insert(payrollPerson);
                else
                    this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public Data.PayrollPerson GetByPPerson_Code(string code)
        {
            try
            {
                return this.GetAll().FirstOrDefault(r => r.PPerson_Code == code);
            }
            catch
            {

                throw;
            }
        }
    }
}
