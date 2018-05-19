using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Data;

namespace AccountingKernel
{
    public class CorporartionBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<Data.corporation> Table { get { return ak1.corporations; } }

        public IQueryable<Data.corporation> GetAll()
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

        public void Insert(corporation entity)
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

        public corporation GetById(Guid Id)
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

        public void Delete(Data.corporation entity)
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

        public void Save(corporation entity)
        {
            try
            {
                if (entity.ID == Guid.Empty)
                    this.Insert(entity);
                else
                    this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public Data.corporation GetByName(string name)
        {
            try
            {
                return this.GetAll().FirstOrDefault(r => r.CorporationName == name);
            }
            catch 
            {
                
                throw;
            }
        }
    }
}
