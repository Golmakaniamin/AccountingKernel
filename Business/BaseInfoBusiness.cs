using AccountingKernel;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingKernel
{
    public class BaseInfoBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<BaseInfo> Table { get { return ak1.BaseInfoes; } }

        public static List<BaseInfo> _baseInfos;

 
        public static List<BaseInfo> BaseInfos
        {
            get
            {
                if (_baseInfos != null)
                    return _baseInfos;
                _baseInfos = Business.GetBaseInfoBusiness().Table.ToList();
                return _baseInfos;
            }
        }

        public List<BaseInfo> GetByType(Guid PID)
        {
            try
            {
                return BaseInfoBusiness.BaseInfos.FindAll(r => r.PID == PID).OrderBy(r => r.Priority).ToList();
            }
            catch
            {

                throw;
            }
        }


        public IQueryable<BaseInfo> IQGetByType(Guid PID)
        {
            try
            {
                return this.GetAll().Where(r => r.PID == PID).OrderBy(r => r.Priority);
            }
            catch
            {

                throw;
            }
        }


        public IQueryable<BaseInfo> GetAll()
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

        public BaseInfo GetById(Guid id)
        {
            try
            {
                return this.GetAll().Where(r => r.Id == id).FirstOrDefault();
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<BaseInfo> GetByIds(List<Guid> ids)
        {
            try
            {
                return this.GetAll().Where(r => ids.Contains(r.Id));
            }
            catch
            {

                throw;
            }
        }


        public Data.BaseInfo GetByAssginName(string storeName, Guid baseInfoType)
        {
            try
            {
                return this.GetAll().Where(r => r.AssignName == storeName && r.PID == baseInfoType).FirstOrDefault();
            }
            catch
            {

                throw;
            }
        }

        public void Save(BaseInfo entity)
        {
            try
            {
                ValidateData(entity);

                if (entity.Id == Guid.Empty)
                {
                    entity.Id = Guid.NewGuid();
                    this.Insert(entity);
                }
                else
                    this.Update();

            }
            catch
            {

                throw;
            }
        }

        private void ValidateData(BaseInfo entity)
        {
            try
            {
                if (this.GetAll().Any(r=>r.Id != entity.Id && (r.AssignName == entity.AssignName || r.Explain == entity.Explain)))
                    throw new Exception(Localize.ex_dupliatedname);

                if (this.GetAll().Any(r=>r.Id != entity.Id && r.PID == entity.PID && r.Priority == entity.Priority))
                    throw new Exception(Localize.ex_dupliatedpriority);
            }
            catch 
            {
                
                throw;
            }
        }

        public void Insert(BaseInfo entity)
        {
            try
            {
                if (entity.Id == Guid.Empty)
                    entity.Id = Guid.NewGuid();
                this.Table.Add(entity);
                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public void Update()
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


    }
}
