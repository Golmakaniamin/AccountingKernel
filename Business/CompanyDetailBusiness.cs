using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
namespace AccountingKernel
{
    public class CompanyDetailBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<CompanyDetail> Table { get { return ak1.CompanyDetails; } }

        public IQueryable<CompanyDetail> GetAll()
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

        public void Insert(List<CompanyDetail> companyDetails)
        {
            try
            {
                companyDetails.ForEach(r =>
                {
                    r.Id = Guid.NewGuid();
                    this.Table.Add(r);
                });
                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public CompanyDetail GetById(Guid Id)
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

        public void Delete(List<CompanyDetail> entityList)
        {
            try
            {
                if (entityList == null)
                    return;

                entityList.ForEach(r => this.Table.Remove(r));
                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public void Save(List<CompanyDetail> companyDetails)
        {
            try
            {
                if (companyDetails.Any(r => r.Id == Guid.Empty))
                    this.Insert(companyDetails);
                else
                    this.SubmitChanges();

            }
            catch
            {

                throw;
            }
        }

        public void Save(CompanyDetail companyDetail)
        {
            try
            {
                this.Save(new List<Data.CompanyDetail>() { companyDetail });
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<CompanyDetail> GetByCompanyId(Guid companyId)
        {
            try
            {
                return this.GetAll().Where(r => r.IDCompany == companyId);
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<CompanyDetail> GetByCompanyId(Guid companyId, Guid codeTitleId)
        {
            try
            {
                return this.GetAll().Where(r => r.IDCompany == companyId && r.IDCodeTitle == codeTitleId);
            }
            catch
            {

                throw;
            }
        }

        public string GetNewCode(Guid codeTitleId, string prefixCode)
        {
            try
            {
                var codeTitleBusiness = Business.GetCodeTitleBusiness();
                var codeTitle = Business.GetCodeTitleBusiness().GetById(codeTitleId);
                var companyDetail = this.GetAll().Where(r => r.IDCodeTitle == codeTitleId && r.CDIDIn.StartsWith(prefixCode)).
                    OrderByDescending(r => r.LastEdit).FirstOrDefault();

                if (companyDetail == null)
                    return codeTitle.CodeStart.ToInt().ToString().Calibrate('0', codeTitle.CodeLen.ToInt());

                var cdidin = (companyDetail.CDIDIn.Remove(0, prefixCode.Length)).ToInt() + 1;
                string code = prefixCode + cdidin.ToString().Calibrate('0', codeTitle.CodeLen.ToInt());
                while (this.GetByCDIDIn(code).Any())
                {
                    code = prefixCode + (++cdidin).ToString().Calibrate('0', codeTitle.CodeLen.ToInt());
                }

                return code.Remove(0, prefixCode.Length);

            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Data.CompanyDetail> GetByCodeTitleId(Guid codeTitelId)
        {
            try
            {
                return this.GetAll().Where(r => r.IDCodeTitle == codeTitelId);
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Data.CompanyDetail> GetByName(string name, Guid codeTitleId)
        {
            try
            {
                return this.GetAll().Where(r => r.CDName == name && r.IDCodeTitle == codeTitleId);
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Data.CompanyDetail> GetByCode(string code, Guid codeTitleId)
        {
            try
            {
                return this.GetAll().Where(r => r.CDIDIn == code && r.IDCodeTitle == codeTitleId);
            }
            catch
            {

                throw;
            }
        }



        public IQueryable<Data.CompanyDetail> GetByPrefix(string prefixCode)
        {
            try
            {
                return this.GetAll().Where(r => r.CDIDIn.StartsWith(prefixCode));
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Data.CompanyDetail> GetByCompanyId(Guid? CompanyId, Guid codeTitleId)
        {
            try
            {
                return this.GetAll().Where(r => r.IDCompany == CompanyId && r.IDCodeTitle == codeTitleId);

            }
            catch
            {

                throw;
            }
        }

        private IQueryable<Data.CompanyDetail> GetByCDIDIn(string code)
        {
            try
            {
                return this.GetAll().Where(r => r.CDIDIn == code);

            }
            catch
            {

                throw;
            }
        }

    }
}
