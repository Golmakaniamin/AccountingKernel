using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingKernel
{
    public class CompanyStructureDefineBusiness : BaseBusiness
    {
        private int MainLen;
        private int SubsidiaryLen;
        public CompanyStructureDefineBusiness()
        {
            MainLen = (int)Business.GetCodeTitleBusiness().GetById(Constants.CodeTitle.CompanyMainGroup).CodeLen;
            SubsidiaryLen = (int)Business.GetCodeTitleBusiness().GetById(Constants.CodeTitle.CompanySubsidiaryGroup).CodeLen;
        }
        
        public System.Data.Entity.DbSet<Data.CompanyStructureDefine> Table { get { return ak1.CompanyStructureDefines; } }

        public IQueryable<Data.CompanyStructureDefine> GetAll()
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

        public IQueryable<Data.CompanyStructureDefine> GetStartWithCode(string code)
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

        public IQueryable<Data.CompanyStructureDefine> GetByParentID(Guid? ID)
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

        public IQueryable<Data.CompanyStructureDefine> GetByType(Guid? type)
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

        public IQueryable<Data.CompanyStructureDefine> GetById(Guid? Pid)
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

        public IQueryable<Data.CompanyStructureDefine> GetMaxCode(string PersonCode)
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

        public string GetCode(Guid? ParentID, Guid? Type, string Code)
        {
            try
            {
                DateTime? LastEdit = null;
                if (Type == Constants.CodeTitle.CompanyType)
                    LastEdit = this.GetAll().Where(r => r.Type == Type && r.Parent_ID == ParentID && r.Code == Code).Max(r => r.LastEdit);

                if (LastEdit != null)
                    Code = this.GetAll().Where(r => r.Type == Type && r.LastEdit == LastEdit).FirstOrDefault().Code;
                do
                {
                    if (CodeIsValid(Code, Type))
                        break;
                    else
                        Code = IncrementCode(Code, Type);
                } while (true);

                return Code;
            }
            catch
            {
                throw;
            }
        }

        private bool CodeIsValid(string Code, Guid? Type)
        {
            try
            {
                return this.GetAll().Where(r => r.Type == Type && r.Code == Code).Count() == 0 ? true : false;
            }
            catch
            {
                throw;
            }
        }

        private string IncrementCode(string Code, Guid? Type)
        {
            try
            {
                List<string> code = new List<string>();
                int j = 0;
                for (int i = 0; j < Code.Length / MainLen; i = i + MainLen)
                {
                    code.Add(Code.Substring(i, MainLen));
                    j++;
                }

                int a = 0;

                if (Type == Constants.CodeTitle.CompanyMainGroup)
                    a = Convert.ToInt32(code[0]);
                else if (Type == Constants.CodeTitle.CompanySubsidiaryGroup)
                    a = Convert.ToInt32(code[1]);
                else if (Type == Constants.CodeTitle.CompanyType)
                    a = Convert.ToInt32(code[2]);

                a++;

                if (a < 10 && Type == Constants.CodeTitle.CompanyMainGroup)
                    return string.Format("0{0}", a);
                else if (a >= 10 && a < 100 && Type == Constants.CodeTitle.CompanyMainGroup)
                    return string.Format("{0}", a);

                if (a < 10 && Type == Constants.CodeTitle.CompanySubsidiaryGroup)
                    return string.Format("{0}0{1}", code[0], a);
                else if (a >= 10 && a < 100 && Type == Constants.CodeTitle.CompanySubsidiaryGroup)
                    return string.Format("{0}{1}", code[0], a);

                if (a < 10 && Type == Constants.CodeTitle.CompanyType)
                    return string.Format("{0}{1}0{2}", code[0], code[1], a);
                else if (a >= 10 && a < 100 && Type == Constants.CodeTitle.CompanyType)
                    return string.Format("{0}{1}{2}", code[0], code[1], a);

                else return "ErrorCode";
            }
            catch
            {
                throw;
            }
        }

        public bool HaveChildren(Guid? ID)
        {
            try
            {
                return this.GetAll().Where(r => r.Parent_ID == ID).Count() == 0 ? false : true;
            }
            catch
            {

                throw;
            }
        }

        public Data.CompanyStructureDefine GetRecord(string Code, Guid Type)
        {
            try
            {
                return this.GetAll().Where(r => r.Code == Code && r.Type == Type).FirstOrDefault();
            }
            catch
            {

                throw;
            }
        }

        public Data.CompanyStructureDefine GetStructure(Guid Type, string Name, Guid? ParentID, string Code)
        {
            Data.CompanyStructureDefine _entity = new Data.CompanyStructureDefine();

            _entity.ID = Guid.NewGuid();
            _entity.Type = Type;
            _entity.Name = Name;
            _entity.Parent_ID = ParentID;

            _entity.Code = GetCode(_entity.Parent_ID, _entity.Type, Code);

            _entity.LastEdit = DateTime.Now;
            _entity.Uniq_Path = GetUniqPath(_entity);

            return _entity;
        }

        private string GetUniqPath(Data.CompanyStructureDefine entity)
        {
            if (entity.Type == Constants.CodeTitle.CompanyMainGroup)
                return string.Format("#{0}", entity.ID);
            else if (entity.Type == Constants.CodeTitle.CompanySubsidiaryGroup)
                return string.Format("#{0}#{1}", GetParentID(entity).ID, entity.ID);
            else if (entity.Type == Constants.CodeTitle.CompanyType)
                return string.Format("#{0}#{1}#{2}", GetParentID(GetParentID(entity)).ID, GetParentID(entity).ID, entity.ID);
            else return "error";
        }

        private Data.CompanyStructureDefine GetParentID(Data.CompanyStructureDefine entity)
        {
            Data.CompanyStructureDefine result = null;
            try
            {
                if (entity.Type == Constants.CodeTitle.CompanySubsidiaryGroup)
                    result = this.GetAll().Where(r => r.Code.StartsWith(entity.Code.Substring(0, MainLen)) && r.Type == Constants.CodeTitle.CompanyMainGroup).FirstOrDefault();
                if (entity.Type == Constants.CodeTitle.CompanyType)
                    result = this.GetAll().Where(r => r.Code.StartsWith(entity.Code.Substring(0, SubsidiaryLen)) && r.Type == Constants.CodeTitle.CompanySubsidiaryGroup).FirstOrDefault();

                return result;
            }
            catch
            {
                throw;
            }
        }

        public void SaveByID(Data.CompanyStructureDefine _companyStructureDefine)
        {
            try
            {
                Guid i = Business.GetCompanyStructureDefineBusiness().GetAll().Where(r => r.ID == _companyStructureDefine.ID).Select(r => r.ID).FirstOrDefault();
                if (i == Guid.Empty)
                    this.Insert(_companyStructureDefine);
                else
                    this.SubmitChanges();
            }
            catch
            {
                throw;
            }
        }

        public void Insert(Data.CompanyStructureDefine _companyStructureDefine)
        {
            try
            {
                if (_companyStructureDefine.ID == Guid.Empty)
                    _companyStructureDefine.ID = Guid.NewGuid();
                this.Table.Add(_companyStructureDefine);
                this.SubmitChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
