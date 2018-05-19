using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace AccountingKernel
{
    public class GoodiesGroupsBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<GoodiesGroup> Table { get { return ak1.GoodiesGroups; } }
        public System.Data.Entity.DbSet<GoodiesGroupsView> View { get { return ak1.GoodiesGroupsViews; } }

        public IQueryable<Data.GoodiesGroup> GetAll()
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

        public IQueryable<Data.GoodiesGroupsView> GetViewAll()
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

        public void Insert(GoodiesGroup entity)
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

        public GoodiesGroup GetById(Guid Id)
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

        public Data.GoodiesGroupsView GetViewById(Guid Id)
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


        public IQueryable<GoodiesGroup> GetByIds(List<Guid> Ids)
        {
            try
            {
                return this.GetAll().Where(r => Ids.Contains(r.ID));
            }
            catch
            {

                throw;
            }
        }

        public void Delete(GoodiesGroup entity)
        {
            try
            {
                if (entity == null)
                    return;

                if (this.HasChild(entity))
                    throw new Exception(Localize.ex_invalid_delete_operation);

                this.Table.Remove(entity);
                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public void Save(GoodiesGroup entity)
        {
            try
            {
                if (entity.ID == Guid.Empty)
                {
                    entity.ID = Guid.NewGuid();
                    this.Insert(entity);
                }
                else
                    this.SubmitChanges();

            }
            catch
            {

                throw;
            }
        }

        public Data.GoodiesGroup GetByName(string name, Guid codeTitle)
        {
            try
            {
                return this.GetAll().Where(r => r.CName == name && r.CodeTitleId == codeTitle).FirstOrDefault();
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
                var good = this.GetAll().Where(r => r.CodeTitleId == codeTitleId && r.Code.StartsWith(prefixCode)).
                    OrderByDescending(r => r.LastEdit).FirstOrDefault();

                if (good == null)
                    return codeTitle.CodeStart.ToInt().ToString().Calibrate('0', codeTitle.CodeLen.ToInt());

                var cdidin = (good.Code.Remove(0, prefixCode.Length)).ToInt() + 1;
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

        public Data.GoodiesGroup GetByCode(string code)
        {
            try
            {
                return this.GetAll().FirstOrDefault(r => r.Code == code);
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Data.GoodiesGroup> GetByParentId(Guid parentId)
        {
            try
            {
                return this.GetAll().Where(r => r.ParentId == parentId);
            }
            catch
            {

                throw;
            }
        }

        public Data.GoodiesGroup GetByCode(string code, Guid codeTitle)
        {
            try
            {
                return this.GetAll().Where(r => r.Code == code && r.CodeTitleId == codeTitle).FirstOrDefault();
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Data.GoodiesGroup> GetByCodeTitleId(Guid codeTitelId)
        {
            try
            {
                return this.GetAll().Where(r => r.CodeTitleId == codeTitelId);
            }
            catch
            {

                throw;
            }
        }


        public bool IsNameExist(Data.GoodiesGroup entity)
        {
            try
            {
                return this.GetAll().Any(r => r.CName == entity.CName && r.ID != entity.ID);
            }
            catch
            {

                throw;
            }
        }

        public void Save(Data.GoodiesGroup entity, string parentUniquePath)
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
                    if (view.Code != entity.Code)
                    {
                        if (HasChild(entity))
                            throw new Exception(Localize.ex_invalid_code_changing);
                        entity.LastEdit = DateTime.Now;
                    }
                }

                entity.uniquepath = string.Format("{0}{1}{2}", parentUniquePath, Common.Constants.Seperators.UniquePath, entity.ID);

                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        private bool HasChild(Data.GoodiesGroup entity)
        {
            try
            {
                return (entity.CodeTitleId == Common.Constants.CodeTitle.CommodityMainGroup && this.GetByParentId(entity.ID).Any()) ||
                                    (entity.CodeTitleId == Common.Constants.CodeTitle.CommoditySubsidiaryGroup && Business.GetGoodiesBusiness().GetByIdGoodiesGroup(entity.ID).Any());

            }
            catch 
            {
                
                throw;
            }
        }
    }
}
