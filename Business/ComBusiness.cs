using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingKernel
{
    public class ComBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<Data.Com> Table { get { return ak1.Coms; } }

        public Data.Com GetById(Guid Id)
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

        public IQueryable<Data.Com> GetAll()
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

        public void Insert(Data.Com company)
        {
            try
            {
                if (company.Id == Guid.Empty)
                    company.Id = Guid.NewGuid();
                this.Table.Add(company);
                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }


        public void Delete(Data.Com entity)
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


        public void Save(Data.Com company)
        {
            try
            {
                if (company.Id == Guid.Empty)
                    this.Insert(company);
                else
                    this.SubmitChanges();

            }
            catch
            {

                throw;
            }
        }

        public Data.Com GetByName(string name)
        {
            try
            {
                return this.GetAll().Where(r => r.CName == name).FirstOrDefault();
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Data.Com> GetByCType(Guid ctype)
        {
            try
            {
                return this.GetAll().Where(r => r.CType == ctype);
            }
            catch
            {

                throw;
            }
        }

        public List<Data.Com> GetByIds(List<Guid?> companyIds)
        {
            try
            {
                return this.GetAll().Where(r => companyIds.Contains(r.Id)).ToList();
            }
            catch
            {

                throw;
            }
        }




    }
}
