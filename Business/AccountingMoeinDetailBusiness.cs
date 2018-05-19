using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace AccountingKernel
{
    public class AccountingMoeinDetailBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<AccountingMoeinDetail> Table { get { return ak1.AccountingMoeinDetails; } }
        public System.Data.Entity.DbSet<AccountingMoeinDetailsView> View { get { return ak1.AccountingMoeinDetailsViews; } }

        public IQueryable<AccountingMoeinDetail> GetAll()
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

        public IQueryable<AccountingMoeinDetailsView> GetViewAll()
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

        public AccountingMoeinDetail GetById(Guid guid)
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

        public AccountingMoeinDetailsView GetViewById(Guid guid)
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

        public void Delete(AccountingMoeinDetail moi)
        {
            try
            {
                Table.Remove(moi);
                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Data.AccountingMoeinDetail> GetByIdCodeTitle(Guid? idCodeTitle)
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

        public IQueryable<Data.AccountingMoeinDetail> GetByMoeinId(Guid moeinId)
        {
            try
            {
                return this.GetAll().Where(r => r.IdAccountingMoein == moeinId);
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Data.AccountingMoeinDetail> GetKolsByGroupsCode(string code)
        {
            try
            {
                var groups = this.GetAll().Where(r => r.IdCodeTitle == Common.Constants.CodeTitle.Goruh && r.IdIn == code);
                var kols = this.GetAll().Where(r => r.IdCodeTitle == Common.Constants.CodeTitle.Kol);
                return groups.Join(kols, o => o.IdAccountingMoein, i => i.IdAccountingMoein, (o, i) => new { kols = i }).Select(r => r.kols);
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Data.AccountingMoeinDetail> GetMoeinsByKolCode(string goruhCode, string kolCode)
        {
            try
            {
                var kols = this.GetKolsByGroupsCode(goruhCode).Where(r => r.IdIn == kolCode);

                var moein = this.GetAll().Where(r => r.IdCodeTitle == Common.Constants.CodeTitle.Moein);
                return kols.Join(moein, o => o.IdAccountingMoein, i => i.IdAccountingMoein, (o, i) => new { Moeins = i }).Select(r => r.Moeins);

            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Data.AccountingMoeinDetail> GetByMDName(string mdName)
        {
            try
            {
                return this.GetAll().Where(i => i.MDName == mdName);
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Data.AccountingMoeinDetail> GetByMDName(string mdName, Guid codeTitelId)
        {
            try
            {
                return this.GetAll().Where(i => i.MDName == mdName && i.IdCodeTitle == codeTitelId);
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Data.AccountingMoeinDetail> GetByAccountingMoeinDetailId(Guid? AccountingMoeinId, Guid codeTitleId)
        {
            try
            {
                return this.GetAll().Where(r => r.IdAccountingMoein == AccountingMoeinId && r.IdCodeTitle == codeTitleId);
            }
            catch
            {

                throw;
            }
        }

        public void Insert(List<Data.AccountingMoeinDetail> entities)
        {
            try
            {
                foreach (var item in entities)
                {
                    if (item.Id == Guid.Empty)
                        item.Id = Guid.NewGuid();
                    this.Table.Add(item);
                }
                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public void Save(List<AccountingMoeinDetail> entities)
        {
            try
            {
                foreach (var item in entities.FindAll(r => r.Id == Guid.Empty))
                {
                    item.Id = Guid.NewGuid();
                    this.Table.Add(item);
                }

                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public void Save(AccountingMoeinDetail entity)
        {
            try
            {
                this.Save(new List<Data.AccountingMoeinDetail>() { entity });
            }
            catch
            {

                throw;
            }
        }

        private void Update()
        {
            try
            {
                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Data.AccountingMoeinDetail> GetByIdIn(string idIn, Guid codeTitelId)
        {
            try
            {
                return this.GetAll().Where(r => r.IdIn == idIn && r.IdCodeTitle == codeTitelId);
            }
            catch
            {

                throw;
            }
        }

        public string GetNewCode(Guid codeTitleId, Data.AccountingMoeinDetail parentAmd)
        {
            try
            {
                IQueryable<Guid?> coParentAmdIds= null;
                if (parentAmd != null)
                    // پیدا کردن رکوردهای هم کد با والد
                    coParentAmdIds = this.GetByIdIn(parentAmd.IdIn, parentAmd.IdCodeTitle.ToGUID()).Select(r => r.IdAccountingMoein);


                var codeTitle = Business.GetCodeTitleBusiness().GetById(codeTitleId);

                var amds = this.GetAll().Where(r => r.IdCodeTitle == codeTitle.Id);

                if (coParentAmdIds!= null && coParentAmdIds.Any())
                    amds = coParentAmdIds.Join(amds, o => o, i => i.IdAccountingMoein, (o, i) => new { i = i }).Select(r => r.i);

                amds = amds.OrderByDescending(r => r.LastEdit);

                var amd = amds.FirstOrDefault();
                if (amd == null)
                    return codeTitle.CodeStart.ToInt().ToString().Calibrate('0', codeTitle.CodeLen.ToInt());

                var idin = amd.IdIn.ToInt() + 1;
                var code = idin.ToString().Calibrate('0', codeTitle.CodeLen.ToInt());
                while (this.GetByIdIn(code, codeTitle.Id).Any())
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

        public IQueryable<Data.AccountingMoeinDetail> GetByCodeTiteId(Guid codeTitelId)
        {
            try
            {
                return this.GetAll().Where(r => r.IdCodeTitle == codeTitelId);
            }
            catch
            {

                throw;
            }
        }
    }
}
