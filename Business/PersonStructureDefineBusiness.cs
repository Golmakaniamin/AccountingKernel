using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace AccountingKernel
{
    public class PersonStructureDefineBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<Data.PersonStructureDefine> Table { get { return ak1.PersonStructureDefines; } }

        public IQueryable<Data.PersonStructureDefine> GetAll()
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

        public IQueryable<Data.PersonStructureDefine> GetStartWithCode(string code)
        {
            try
            {
                return this.GetAll().Where(r => r.Code.StartsWith(code));
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Data.PersonStructureDefine> GetByParentID(Guid? ID)
        {
            try
            {
                return this.GetAll().Where(r => r.Parent_ID == ID);
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Data.PersonStructureDefine> GetByType(Guid? type)
        {
            try
            {
                return this.GetAll().Where(r => r.Type == type);
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Data.PersonStructureDefine> GetById(Guid? Pid)
        {
            try
            {
                return this.GetAll().Where(r => r.ID == Pid);
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Data.PersonStructureDefine> GetMaxCode(string PersonCode)
        {
            try
            {
                return this.GetAll().Where(r => r.Code == PersonCode);

            }
            catch
            {
                throw;
            }
        }

        public object GetByID(Guid ID)
        {
            try
            {
                return this.GetAll().Where(r => r.ID == ID);
            }
            catch
            {
                throw;
            }
        }

        public void Delete(Data.PersonStructureDefine DeletedItem)
        {
            try
            {
                try
                {
                    if (DeletedItem == null)
                        return;

                    this.Table.Remove(DeletedItem);
                    this.SubmitChanges();
                }
                catch
                {

                    throw;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
