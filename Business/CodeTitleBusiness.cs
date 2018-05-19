using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingKernel
{
    public class CodeTitleBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<CodeTitle> Table { get { return ak1.CodeTitles; } }

        public IQueryable<CodeTitle> GetAll()
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

        public void Insert(CodeTitle codeTitle)
        {
            try
            {
                if (codeTitle.Id == Guid.Empty)
                    codeTitle.Id = Guid.NewGuid();
                this.Table.Add(codeTitle);
                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public CodeTitle GetById(Guid Id)
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

        public void Delete(CodeTitle entity)
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


        public IQueryable<CodeTitle> GetByCodeGroup(int? codeGroup)
        {
            try
            {
                return this.GetAll().Where(r => r.CodeGroup == codeGroup);
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<CodeTitle> GetByCodeGroups(List<int> codeGroups)
        {
            try
            {
                return this.GetAll().Where(r => codeGroups.Contains(r.CodeGroup.Value));
            }
            catch
            {

                throw;
            }
        }

    }
}
