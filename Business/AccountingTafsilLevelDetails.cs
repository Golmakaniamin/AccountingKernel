using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using System.Transactions;
using Common;

namespace AccountingKernel
{
    public class AccountingTafsilLevelDetailBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<AccountingTafsillevelsDetail> Table { get { return ak1.AccountingTafsillevelsDetails; } }
        public System.Data.Entity.DbSet<AccountingTafsillevelsDetailView> View { get { return ak1.AccountingTafsillevelsDetailViews; } }

        public IQueryable<AccountingTafsillevelsDetail> GetAll()
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

        public IQueryable<AccountingTafsillevelsDetailView> GetViewAll()
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


        public AccountingTafsillevelsDetail GetById(Guid guid)
        {
            try
            {
                return this.GetAll().FirstOrDefault(r => r.Id == guid);
            }
            catch
            {

                throw;
            }
        }

        public AccountingTafsillevelsDetailView GetViewById(Guid guid)
        {
            try
            {
                return this.GetViewAll().FirstOrDefault(r => r.Id == guid);
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<AccountingTafsillevelsDetail> GetByIdAccountingTafsilLevelsId(Guid tafsilLevelsId)
        {
            try
            {
                return this.GetAll().Where(r => r.IdAccountingTafsilLevels == tafsilLevelsId);
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<AccountingTafsillevelsDetail> GetByIdAccountingTafsilLevelsId(List<Guid> tafsilLevelsId)
        {
            try
            {
                return this.GetAll().Where(r => r.IdAccountingTafsilLevels.HasValue && tafsilLevelsId.Contains(r.IdAccountingTafsilLevels.Value));
            }
            catch
            {

                throw;
            }
        }

        public AccountingTafsillevelsDetail GetByIdAccountingTafsilLevels(Guid tafsilLevelId, Guid codeTiteId)
        {
            try
            {
                return this.GetAll().Where(r => r.IdAccountingTafsilLevels.HasValue && tafsilLevelId == r.IdAccountingTafsilLevels.Value &&
                    r.IdCodeTitle == codeTiteId).FirstOrDefault();
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<AccountingTafsillevelsDetail> GetByIdAccountingTafsilLevels(List<Guid> tafsilLevelsId, Guid codeTiteId)
        {
            try
            {
                return this.GetAll().Where(r => r.IdAccountingTafsilLevels.HasValue && tafsilLevelsId.Contains(r.IdAccountingTafsilLevels.Value) &&
                    r.IdCodeTitle == codeTiteId);
            }
            catch
            {

                throw;
            }
        }


        public IQueryable<Data.AccountingTafsillevelsDetail> GetByIdCodeTitle(Guid idCodeTitle)
        {
            try
            {
                return this.GetAll().Where(r => r.IdCodeTitle == idCodeTitle);
            }
            catch
            {

                throw;
            }
        }

        public List<Data.AccountingTafsillevelsDetail> GetByIds(List<Guid> ids)
        {
            try
            {
                return this.GetAll().Where(r => ids.Contains(r.Id)).ToList();
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Data.AccountingTafsillevelsDetail> GetByIdAccountingTafsilLevels(Guid? accountingTafsilLevelId)
        {
            try
            {
                return this.GetAll().Where(r => r.IdAccountingTafsilLevels == accountingTafsilLevelId);

            }
            catch
            {

                throw;
            }
        }

        public string GetNameByIdAccountingTafsilLevels(Guid? accountingTafsilLevels)
        {
            try
            {
                var atls = this.GetByIdAccountingTafsilLevels(accountingTafsilLevels);
                return atls.Any() ? atls.First().ATLName : string.Empty;

            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Data.AccountingTafsillevelsDetail> GetBySatheTafsil(Guid? SatheTafsil, Guid accountingMoeinId)
        {
            try
            {
                var accountingMoeinTafsilLevels = Business.GetAccountingMoeinTafsilLevelBusiness().GetByIdAccountingMoein(accountingMoeinId, SatheTafsil.Value);
                return this.GetAll().Where(r => r.IdCodeTitle == SatheTafsil &&
                    accountingMoeinTafsilLevels.Select(t => t.IdAccountingTafsilLevels).Contains(r.IdAccountingTafsilLevels));
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Data.AccountingTafsillevelsDetail> GetHesabTafsilByAccountingTafsilLevelsId(Guid AccountingTafsilLevelsId)
        {
            try
            {
                return this.GetByIdAccountingTafsilLevelsId(AccountingTafsilLevelsId).Where(r => r.IdCodeTitle == Common.Constants.CodeTitle.HesabTafsil);
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Data.AccountingTafsillevelsDetail> GetHesabTafsilByAccountingTafsilLevelsId(List<Guid> AccountingTafsilLevelsId)
        {
            try
            {
                return this.GetByIdAccountingTafsilLevelsId(AccountingTafsilLevelsId).Where(r => r.IdCodeTitle == Common.Constants.CodeTitle.HesabTafsil);
            }
            catch
            {

                throw;
            }
        }

        public void Delete(List<Data.AccountingTafsillevelsDetail> entities)
        {
            try
            {

                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted,
                    Timeout = new TimeSpan(2, 0, 0)
                }))
                {
                    this.BeforeDelete(entities);

                    entities.ForEach(r => this.Table.Remove(r));
                    this.SubmitChanges();


                    scope.Complete();
                }
            }
            catch
            {

                throw;
            }
        }

        private void BeforeDelete(List<Data.AccountingTafsillevelsDetail> entities)
        {
            try
            {

                var atlBusiness = Business.GetAccountingTafsilLevelBusiness();

                atlBusiness.Delete(atlBusiness.GetByIds(entities.Select(r => r.IdAccountingTafsilLevels.Value).ToList()).ToList());
            }
            catch
            {

                throw;
            }
        }

        public void Save(AccountingTafsillevelsDetail entity)
        {
            try
            {
                if (entity.Id == Guid.Empty)
                {
                    entity.Id = Guid.NewGuid();
                    entity.LastEdit = DateTime.Now;
                    this.Table.Add(entity);
                }
                else
                {
                    var view = this.GetViewById(entity.Id);
                    if (view.IdIn != entity.IdIn)
                        entity.LastEdit = DateTime.Now;
                }

                this.SubmitChanges();

            }
            catch
            {

                throw;
            }
        }


        public IQueryable<Data.AccountingTafsillevelsDetail> GetByATLName(string atlName, Guid codetitleId)
        {
            try
            {
                return this.GetByATLName(atlName).Where(r => r.IdCodeTitle == codetitleId);
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Data.AccountingTafsillevelsDetail> GetByATLName(string atlName)
        {
            try
            {
                return this.GetAll().Where(i => i.ATLName == atlName);
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Data.AccountingTafsillevelsDetail> GetByIdIn(string idin, Guid codeTitleId)
        {
            try
            {
                return this.GetAll().Where(r => r.IdIn == idin && r.IdCodeTitle == codeTitleId);
            }
            catch
            {

                throw;
            }
        }

        public string GetNewCodeForGroup(Guid codeTitleId)
        {
            try
            {
                var codeTitle = Business.GetCodeTitleBusiness().GetById(codeTitleId);
                var atld = this.GetAll().Where(r => r.IdCodeTitle == codeTitleId).OrderByDescending(r => r.LastEdit).FirstOrDefault();

                if (atld == null)
                    return codeTitle.CodeStart.ToInt().ToString().Calibrate('0', codeTitle.CodeLen.ToInt());

                var idin = atld.IdIn.ToInt() + 1;
                var code = idin.ToString().Calibrate('0', codeTitle.CodeLen.ToInt());
                while (this.GetByIdIn(code, codeTitleId).Any())
                {
                    code = (++idin).ToString().Calibrate('0', codeTitle.CodeLen.ToInt());
                }

                return code;

            }
            catch
            {

                throw;
            }
        }

        public string GetNewCodeForHesab(Guid codeTitleId, Data.AccountingTafsillevelsDetail group)
        {
            try
            {
                var codeTitle = Business.GetCodeTitleBusiness().GetById(codeTitleId);
                if (group == null)
                    return codeTitle.CodeStart.ToInt().ToString().Calibrate('0', codeTitle.CodeLen.ToInt());

                var coIdAccountingTafsilLevels = this.GetByIdIn(group.IdIn, Common.Constants.CodeTitle.GoruheTafsili).Select(r => r.IdAccountingTafsilLevels).ToList();

                var atld = this.GetAll().Where(r => r.IdCodeTitle == codeTitleId && coIdAccountingTafsilLevels.Contains(r.IdAccountingTafsilLevels)).
                    OrderByDescending(r => r.LastEdit).FirstOrDefault();

                if (atld == null)
                    return codeTitle.CodeStart.ToInt().ToString().Calibrate('0', codeTitle.CodeLen.ToInt());

                var idin = atld.IdIn.ToInt() + 1;
                var code = idin.ToString().Calibrate('0', codeTitle.CodeLen.ToInt());
                while (this.GetByIdIn(code, codeTitleId).Any())
                {
                    code = (++idin).ToString().Calibrate('0', codeTitle.CodeLen.ToInt());
                }

                return code;

            }
            catch
            {

                throw;
            }
        }


        public IQueryable<Data.AccountingTafsillevelsDetail> GetByKeys(IQueryable<Guid> keys)
        {
            try
            {
                return this.GetAll().Where(r => keys.Contains(r.Id));
            }
            catch
            {

                throw;
            }
        }
    }
}
