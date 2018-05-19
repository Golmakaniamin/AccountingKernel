using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingKernel
{
    public class CompanyBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<Company> Table { get { return ak1.Companies; } }

        public IQueryable<Company> GetAll()
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

        public void Insert(Company company)
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

        public Company GetById(Guid Id)
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

        public void Delete(Company entity)
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


        public void Save(Company company)
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

        public Company GetByName(string name)
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

        public IQueryable<Data.Company> GetByCType(Guid ctype)
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

        public List<Data.Company> GetByIds(List<Guid?> companyIds)
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
