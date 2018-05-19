using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Data;
using System.Transactions;
using Common;

namespace AccountingKernel
{
    public class TreasuryBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<Data.Treasury> Table { get { return ak1.Treasuries; } }

        public IQueryable<Data.Treasury> GetAll()
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

        public IQueryable<Treasury> IQGetById(Guid Id)
        {
            try
            {
                return this.GetAll().Where(r => r.ID == Id);
            }
            catch
            {

                throw;
            }
        }

        public Treasury GetById(Guid Id)
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

        public void Delete(Data.Treasury entity)
        {
            try
            {
                if (entity == null)
                    return;


                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted,
                    Timeout = new TimeSpan(2, 0, 0)
                }))
                {
                    Business.GetTreasuryDetailBusiness().Delete(Business.GetTreasuryDetailBusiness().GetByTreasuryId(entity.ID).ToList());

                    this.Table.Remove(entity);
                    this.SubmitChanges();


                    scope.Complete();
                }
            }
            catch
            {

                throw;
            }
        }


        public void Save(Data.Treasury entity)
        {
            try
            {
                if (entity.ID == Guid.Empty)
                {
                    entity.ID = Guid.NewGuid();
                    entity.LastEdit = DateTime.Now;
                    this.Table.Add(entity);
                }
                this.SubmitChanges();

            }
            catch
            {

                throw;
            }
        }

        public bool IsCodeExists(Guid treasuryId, string code)
        {
            try
            {
                return this.GetAll().Any(r => r.TNO == code && r.ID != treasuryId);
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Data.Treasury> GetByType(Guid treasuryTypeId)
        {
            try
            {
                return this.GetAll().Where(r => r.Ttype == treasuryTypeId);
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Data.Treasury> GetByTNo(string code, Guid baseInfoId)
        {
            try
            {
                return this.GetByBaseInfoId(baseInfoId).Where(r => r.TNO == code);
            }
            catch
            {

                throw;
            }
        }

        public string GetNewCode(Guid codeTitleId)
        {
            try
            {
                var codeTitle = Business.GetCodeTitleBusiness().GetById(codeTitleId);
                var baseInfoId = Common.Constants.TreasuryType.Payment;
                if (codeTitleId == Common.Constants.CodeTitle.Recive)
                    baseInfoId = Common.Constants.TreasuryType.Recive;

                var treasury = this.GetByBaseInfoId(baseInfoId).OrderByDescending(r => r.LastEdit).FirstOrDefault();

                if (treasury == null)
                    return codeTitle.CodeStart.ToInt().ToString().Calibrate('0', codeTitle.CodeLen.ToInt());

                var cdidin = treasury.TNO.ToInt() + 1;
                string code = cdidin.ToString().Calibrate('0', codeTitle.CodeLen.ToInt());
                while (this.GetByTNo(code, baseInfoId).Any())
                {
                    code = (++cdidin).ToString().Calibrate('0', codeTitle.CodeLen.ToInt());
                }

                return code;

            }
            catch
            {

                throw;
            }
        }

        private IQueryable<Data.Treasury> GetByBaseInfoId(Guid baseInfoId)
        {
            try
            {
                return this.GetAll().Where(r => r.Ttype == baseInfoId);

            }
            catch
            {

                throw;
            }
        }
    }
}
