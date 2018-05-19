using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Data;
using Common;

namespace AccountingKernel
{
    public class FundsBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<Data.Fund> Table { get { return ak1.Funds; } }
        public System.Data.Entity.DbSet<Data.FundView> View { get { return ak1.FundViews; } }

        public IQueryable<Data.Fund> GetAll()
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

        public IQueryable<Data.FundView> GetViewAll()
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

        public Fund GetById(Guid Id)
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

        public FundView GetViewById(Guid Id)
        {
            try
            {
                return this.GetViewAll().Where(r => r.ID == Id).FirstOrDefault();
            }
            catch
            {

                throw;
            }
        }


        public void Delete(Data.Fund entity)
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

        public void Save(Data.Fund entity)
        {
            try
            {
                if (entity.ID == Guid.Empty)
                {
                    entity.ID = Guid.NewGuid();
                    entity.LastEdit = DateTime.Now;
                    this.Table.Add(entity);

                }
                else
                {
                    var view = this.GetViewById(entity.ID);
                    if (view.FBankNO != entity.FBankNO)
                        entity.LastEdit = DateTime.Now;
                }
                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Data.Fund> GetByName(string bankName)
        {
            try
            {
                return this.GetAll().Where(r => r.FName == bankName);
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Data.Fund> GetByFType(Guid bankTypeId)
        {
            try
            {
                return this.GetAll().Where(r => r.FType == bankTypeId);
            }
            catch
            {

                throw;
            }
        }

        public Fund GetByFType(Guid bankTypeId, string text, char seperator)
        {
            try
            {
                var splittedStrings = text.Split(seperator);
                if (splittedStrings.Count() != 2)
                    return null;

                var accountNumber = splittedStrings[0];
                var name = splittedStrings[1];
                if (bankTypeId == Common.Constants.BankType.Sandogh)
                    return this.GetAll().Where(r => r.FAccountnumber == accountNumber && r.FName == name).FirstOrDefault();
                else
                    return this.GetAll().Where(r => r.FAccountnumber == accountNumber && r.FBank == name).FirstOrDefault();

            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Fund> GetByFBank(string bankName)
        {
            try
            {
                return this.GetAll().Where(r => r.FBank == bankName);
            }
            catch
            {

                throw;
            }
        }

        public string GetNewCode()
        {
            try
            {
                var codeTitle = Business.GetCodeTitleBusiness().GetById(Common.Constants.CodeTitle.Bank);
                var fund = this.GetAll().Where(r => r.FType == Common.Constants.BankType.Bank).OrderByDescending(r => r.LastEdit).FirstOrDefault();

                if (fund == null)
                    return codeTitle.CodeStart.ToInt().ToString().Calibrate('0', codeTitle.CodeLen.ToInt());

                var cdidin = fund.FBankNO.ToInt() + 1;
                string code = cdidin.ToString().Calibrate('0', codeTitle.CodeLen.ToInt());
                while (this.GetByFbank(code).Any())
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

        private IQueryable<Data.Fund> GetByFbank(string code)
        {
            try
            {
                return this.GetAll().Where(r => r.FBank == code);
            }
            catch
            {

                throw;
            }
        }

        public Data.Fund GetByFBankNO(string p)
        {
            try
            {
                return this.GetAll().FirstOrDefault(i => i.FBankNO == p);
            }
            catch
            {

                throw;
            }
        }
    }
}
