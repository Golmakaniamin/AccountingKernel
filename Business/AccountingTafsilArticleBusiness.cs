using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Data;

namespace AccountingKernel
{
    public class AccountingTafsilArticleBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<Data.AccountingTafsilArticle> Table { get { return ak1.AccountingTafsilArticles; } }

        public IQueryable<Data.AccountingTafsilArticle> GetAll()
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


        public AccountingTafsilArticle GetById(Guid Id)
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

        public void Delete(Data.AccountingTafsilArticle entity)
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

        public void Delete(List<AccountingTafsilArticle> entities)
        {
            try
            {
                if (!entities.Any())
                    return;

                entities.ForEach(r => this.Table.Remove(r));
                this.SubmitChanges();

            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Data.AccountingTafsilArticle> GetByAccountingArticleId(Guid accountingArticleId)
        {
            try
            {
                return this.GetAll().Where(r => r.IdAccountingArticle == accountingArticleId);
            }
            catch
            {

                throw;
            }
        }



        public IQueryable<Data.AccountingTafsilArticle> GetByArticleId(Guid articleId)
        {
            try
            {
                return this.GetAll().Where(r => r.IdAccountingArticle == articleId);

            }
            catch
            {

                throw;
            }
        }


        public void Save(List<AccountingTafsilArticle> entityList)
        {
            try
            {
                entityList.FindAll(r => r.Id == Guid.Empty).ForEach(r =>
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
    }
}
