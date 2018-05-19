using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace AccountingKernel
{
    public class AssetBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<Data.Asset> Table { get { return ak1.Assets; } }

        public IQueryable<Data.Asset> GetAll()
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

        public void Insert(Data.Asset entity)
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

        public Data.Asset GetById(Guid Id)
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

        public void Delete(Data.Asset entity)
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


        public void Save(Data.Asset entity)
        {
            try
            {
                this.Save(new List<Data.Asset>() { entity });
            }
            catch
            {

                throw;
            }
        }

        public void Save(List<Data.Asset> entityList)
        {
            try
            {
                entityList.FindAll(r => r.ID == Guid.Empty).ForEach(r =>
                {
                    r.ID = Guid.NewGuid();
                    this.Table.Add(r);
                });

                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Data.Asset> GetByAssetGoodId(Guid assetGoodId)
        {
            try
            {
                return this.GetAll().Where(r => r.Idassetgoods == assetGoodId);
            }
            catch 
            {
                
                throw;
            }
        }

    }
}
