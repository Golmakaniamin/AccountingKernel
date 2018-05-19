using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Common;

namespace AccountingKernel
{
    public class AssetGoodsBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<Data.AssetGood> Table { get { return ak1.AssetGoods; } }
        public System.Data.Entity.DbSet<Data.AssetGoodsView> View { get { return ak1.AssetGoodsViews; } }

        public IQueryable<Data.AssetGood> GetAll()
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

        public IQueryable<Data.AssetGoodsView> GetViewAll()
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


        public void Insert(Data.AssetGood entity)
        {
            try
            {
                if (entity.ID == Guid.Empty)
                    entity.ID = Guid.NewGuid();
                this.Table.Add(entity);
                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public Data.AssetGood GetById(Guid Id)
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

        private Data.AssetGoodsView GetViewById(Guid id)
        {
            try
            {
                return this.GetViewAll().FirstOrDefault(r => r.ID == id);
            }
            catch
            {

                throw;
            }
        }


        public void Delete(Data.AssetGood entity)
        {
            try
            {
                var parentId = entity.parentId;
                string errorMessage = string.Empty;
                if (!this.ValidateDelete(entity, out errorMessage))
                    throw new Exception(errorMessage);

                this.Table.Remove(entity);
                this.SubmitChanges();

                if (parentId != null && !this.GetByParentId(parentId.Value).Where(r => r.ID != entity.ID).Any())
                    this.Delete(this.GetById(parentId.Value));

            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Data.AssetGood> GetByParentId(Guid parentId)
        {
            try
            {
                return this.GetAll().Where(r => r.parentId == parentId);
            }
            catch
            {

                throw;
            }
        }

        private bool ValidateDelete(Data.AssetGood entity, out string errorMessage)
        {
            try
            {
                errorMessage = string.Empty;

                if (entity == null)
                {
                    errorMessage = Localize.ex_no_record;
                    return false;
                }

                if (Business.GetAssetBusiness().GetByAssetGoodId(entity.ID).Any())
                    errorMessage = Localize.ex_record_already_used;

                if (this.GetAll().Where(r => r.parentId == entity.ID).Any())
                    errorMessage = Localize.ex_record_already_used;

                return errorMessage == string.Empty;

            }
            catch
            {

                throw;
            }
        }

        public void Save(Data.AssetGood entity, string parentUniquePath)
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
                    if (view.code != entity.code)
                        entity.LastEdit = DateTime.Now;
                }

                entity.uniquepath = string.Format("{0}{1}{2}", parentUniquePath, Common.Constants.Seperators.UniquePath, entity.ID);

                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public Data.AssetGood GetByCode(string code)
        {
            try
            {
                return this.GetAll().FirstOrDefault(r => r.code == code);
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
                var assetGood = this.GetAll().Where(r => r.codetitleId == codeTitleId && r.code.StartsWith(prefixCode)).
                    OrderByDescending(r => r.LastEdit).FirstOrDefault();

                if (assetGood == null)
                    return codeTitle.CodeStart.ToInt().ToString().Calibrate('0', codeTitle.CodeLen.ToInt());

                var cdidin = (assetGood.code.Remove(0, prefixCode.Length)).ToInt() + 1;
                string code = prefixCode + cdidin.ToString().Calibrate('0', codeTitle.CodeLen.ToInt());
                while (this.GetByCode(code) != null)
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

        public Data.AssetGood GetByName(string name)
        {
            try
            {
                return this.GetAll().FirstOrDefault(r => r.name == name);
            }
            catch
            {

                throw;
            }
        }

        public bool IsNameExist(Data.AssetGood entity)
        {
            try
            {
                return this.GetAll().Any(r => r.name == entity.name && r.ID != entity.ID);
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Data.AssetGood> GetByCodeTitleId(Guid codeTitleId)
        {
            try
            {
                return this.GetAll().Where(r => r.codetitleId == codeTitleId);
            }
            catch
            {

                throw;
            }
        }
    }
}
