using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Data;

namespace AccountingKernel
{
    public class AccountingInterfaceBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<Data.AccountingInterface> Table { get { return ak1.AccountingInterfaces; } }

        public IQueryable<Data.AccountingInterface> GetAll()
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


        public void Insert(AccountingInterface entity)
        {
            try
            {
                if (entity.Id == Guid.Empty)
                    entity.Id = Guid.NewGuid();
                this.Table.Add(entity);
                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public AccountingInterface GetById(Guid Id)
        {
            try
            {
                return this.GetAll().Where(r => r.Id == Id).FirstOrDefault();
            }
            catch
            {

                throw;
            }
        }

        public void Delete(Data.AccountingInterface entity)
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




        public void Save(AccountingInterface entity)
        {
            try
            {
                if (entity.Id == Guid.Empty)
                    this.Insert(entity);
                else
                    this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }
    }
}
