using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingKernel
{
    public class OperativeBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<Operative> Table { get { return ak1.Operatives; } }

        public IQueryable<Operative> GetAll()
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

        public void Insert(Operative operative)
        {
            try
            {
                if (operative.Id == Guid.Empty)
                    operative.Id = Guid.NewGuid();
                this.Table.Add(operative);
                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public Operative GetById(Guid Id)
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

        public void Delete(Operative entity)
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

        public Operative GetByOName(string name)
        {
            try
            {
                return this.GetAll().Where(r => r.OName == name).FirstOrDefault();
            }
            catch
            {

                throw;
            }
        }

        public void Save(Operative operative)
        {
            try
            {
                if (operative.Id == Guid.Empty)
                    this.Insert(operative);
                else
                    this.SubmitChanges();

            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Operative> GetByOISEffective(bool isEffective)
        {
            try
            {
                return this.GetAll().Where(r => r.OISEffective == isEffective);
            }
            catch
            {

                throw;
            }
        }
    }
}
