using AccountingKernel.Class;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingKernel
{
    public class TafsilStructureDefineBussiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<Data.AccountingTafsilStructureDefine> Table { get { return ak1.AccountingTafsilStructureDefines; } }
        private int TafsilGroupLen;
        private int AccountLen;

        public TafsilStructureDefineBussiness()
        {
            TafsilGroupLen = (int)Business.GetCodeTitleBusiness().GetById(Constants.CodeTitle.TafsilGroup).CodeLen;
            AccountLen = (int)Business.GetCodeTitleBusiness().GetById(Constants.CodeTitle.AccountGroup).CodeLen;
        }

        public IQueryable<Data.AccountingTafsilStructureDefine> GetAll()
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



        public void SaveWithID(Data.AccountingTafsilStructureDefine _tafsilStructureDefine)
        {
            try
            {
                Guid i = this.GetAll().Where(r => r.ID == _tafsilStructureDefine.ID).Select(r => r.ID).FirstOrDefault();
                _tafsilStructureDefine.Name = _tafsilStructureDefine.Name.Trim();
                if (i == Guid.Empty)
                    this.Insert(_tafsilStructureDefine);
                else
                    this.SubmitChanges();
            }
            catch
            {
                throw;
            }
        }

        public void Insert(Data.AccountingTafsilStructureDefine _tafsilStructureDefine)
        {
            try
            {
                if (_tafsilStructureDefine.ID == Guid.Empty)
                    _tafsilStructureDefine.ID = Guid.NewGuid();
                this.Table.Add(_tafsilStructureDefine);
                this.SubmitChanges();
            }
            catch
            {
                throw;
            }
        }

        public Data.AccountingTafsilStructureDefine GetRecord(string Code, Guid Type)
        {
            return this.GetAll().Where(r => r.Code == Code && r.Type == Type).FirstOrDefault();
        }

        public IQueryable<Data.AccountingTafsilStructureDefine> GetByID(Guid? ID)
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

        public void Delete(Data.AccountingTafsilStructureDefine DeletedItem)
        {
            try
            {
                string errorMessage = string.Empty;
                if (!this.ValidateDelete(DeletedItem, out errorMessage))
                    throw new Exception(errorMessage);

                this.Table.Remove(DeletedItem);
                this.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public bool ValidateDelete(Data.AccountingTafsilStructureDefine DeletedItem, out string errorMessage)
        {
            try
            {
                errorMessage = string.Empty;

                if (DeletedItem == null)
                {
                    errorMessage = Localize.ex_no_record;
                    return false;
                }

                if (this.GetAll().Where(r => r.Parent_ID == DeletedItem.ID).Any())
                    errorMessage = Localize.ex_record_already_used;

                return errorMessage == string.Empty;
            }
            catch
            {

                throw;
            }
        }

        public Data.AccountingTafsilStructureDefine GetStructure(Guid Type, string Name, string LatinName, Guid? ParentID, string Code)
        {
            Data.AccountingTafsilStructureDefine _entity = new Data.AccountingTafsilStructureDefine();

            _entity.ID = Guid.NewGuid();
            _entity.Type = Type;
            _entity.Name = Name;
            _entity.Latin_Name = LatinName;
            _entity.Parent_ID = ParentID;
            _entity.Code = GetCode(_entity.Type, Code);
            _entity.LastEdit = DateTime.Now;
            _entity.Uniq_Path = GetUniqPath(_entity);

            return _entity;
        }

        private string GetUniqPath(Data.AccountingTafsilStructureDefine entity)
        {

            StringBuilder str = new StringBuilder();
            str.Append(string.Format("#{0}", entity.ID));

            Data.AccountingTafsilStructureDefine _entity = this.GetAll().Where(r => r.ID == entity.Parent_ID).FirstOrDefault();

            while (_entity != null)
            {
                str.Insert(0, string.Format("#{0}", _entity.ID));
                _entity = this.GetAll().Where(r => r.ID == _entity.Parent_ID).FirstOrDefault();
            }
            return str.ToString();
        }

        public string GetCode(Guid? Type, string Code)
        {
            try
            {
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

        public bool CodeIsValid(string Code, Guid? Type)
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

        public string IncrementCode(string Code, Guid? Type)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                List<string> code = new List<string>();

                if (Type == Constants.CodeTitle.TafsilGroup)
                    code.Add(Code.Substring(0, TafsilGroupLen));
                if (Type == Constants.CodeTitle.AccountGroup)
                {
                    code.Add(Code.Substring(0, TafsilGroupLen));
                    code.Add(Code.Substring(TafsilGroupLen, AccountLen));
                }

                int a = 0;
                if (Type == Constants.CodeTitle.TafsilGroup)
                    a = Convert.ToInt32(code[0]);
                else if (Type == Constants.CodeTitle.AccountGroup)
                    a = Convert.ToInt32(code[1]);
                a++;

                int z = 0;
                if (a < 10)
                    z = 1;
                else if (a >= 10 && a < 100)
                    z = 2;
                else if (a >= 100)
                    z = 3;

                if (Type == Constants.CodeTitle.TafsilGroup)
                {
                    for (int i = 0; i < TafsilGroupLen - z; i++)
                        stringBuilder.Append("0");
                    stringBuilder.Append(a);
                }

                else if (Type == Constants.CodeTitle.AccountGroup)
                {
                    stringBuilder.Append(code[0]);
                    for (int i = 0; i < AccountLen - z; i++)
                        stringBuilder.Append("0");
                    stringBuilder.Append(a);
                }

                else
                    stringBuilder.Append("ErrorCode");

                return stringBuilder.ToString();
            }
            catch
            {
                throw;
            }
        }

        public string GetDefualtCode(Guid Type, Guid? ParentID)
        {
            try
            {
                string Code;
                DateTime? LastEdit = null;

                //EF is'nt support 'is null' syntax in T-SQL
                if (ParentID == null)
                    LastEdit = this.GetAll().Where(r => r.Type == Type && r.Parent_ID.Equals(ParentID)).Max(r => r.LastEdit);
                else
                    LastEdit = this.GetAll().Where(r => r.Type == Type && r.Parent_ID == ParentID).Max(r => r.LastEdit);


                if (LastEdit != null)
                {
                    //EF is'nt support 'is null' syntax in T-SQL
                    if (ParentID == null)
                        Code = this.GetAll().Where(r => r.LastEdit == LastEdit && r.Type == Type && r.Parent_ID.Equals(ParentID)).FirstOrDefault().Code;
                    else
                        Code = this.GetAll().Where(r => r.LastEdit == LastEdit && r.Type == Type && r.Parent_ID == ParentID).FirstOrDefault().Code;
                }

                else
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    if (Type == Constants.CodeTitle.TafsilGroup)
                    {
                        for (int i = 0; i < TafsilGroupLen - 1; i++)
                            stringBuilder.Append("0");
                        stringBuilder.Append("1");
                    }
                    else if (Type == Constants.CodeTitle.AccountGroup)
                    {
                        for (int i = 0; i < AccountLen - 1; i++)
                            stringBuilder.Append("0");
                        stringBuilder.Append("1");
                    }
                    Code = stringBuilder.ToString();
                }
                return GetCode(Type, Code);
            }
            catch
            {
                throw;
            }
        }

        public IQueryable<Data.AccountingTafsilStructureDefine> GetByParentID(Guid? ParentID)
        {
            try
            {
                return this.GetAll().Where(r => r.Parent_ID == ParentID);
            }
            catch
            {
                throw;
            }
        }

        public Data.AccountingTafsilStructureDefine GetParent(Data.AccountingTafsilStructureDefine ChangableItem)
        {
            try
            {
                if (ChangableItem.Parent_ID == null)
                    return this.GetAll().Where(r => r.ID.Equals(ChangableItem.Parent_ID)).FirstOrDefault();
                else
                    return this.GetAll().Where(r => r.ID == ChangableItem.Parent_ID).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        private IQueryable<Data.AccountingTafsilStructureDefine> SearchByCode(string Code, List<Guid?> Types)
        {
            try
            {
                return this.GetAll().Where(r => r.Code.StartsWith(Code) && Types.Contains(r.Type));
            }
            catch
            {

                throw;
            }
        }

        private IQueryable<Data.AccountingTafsilStructureDefine> SearchByName(string Name, List<Guid?> Types)
        {
            try
            {
                return this.GetAll().Where(r => r.Name.StartsWith(Name) && Types.Contains(r.Type));
            }
            catch
            {

                throw;
            }
        }

        public IQueryable<Data.AccountingTafsilStructureDefine> Search(string Text, List<Guid?> Types)
        {
            if (string.IsNullOrEmpty(Text))
                return null;
            if (Char.IsNumber(Text, 0))
                return SearchByCode(Text, Types);
            else
                return SearchByName(Text, Types);

        }

        public IQueryable<Data.AccountingTafsilStructureDefine> NotInFilter()
        {
            IQueryable<Guid?> FilterItems = Business.GetAccountingMoeinTafsilRelationBussiness().GetAll().Select(r => r.AccountingTafsil_ID);
            try
            {
                return this.GetAll().Where(r => !FilterItems.Contains(r.ID));
            }
            catch
            {
                throw;
            }
        }

        public IQueryable<Data.AccountingTafsilStructureDefine> InFilter(IQueryable<Guid?> FilterItem)
        {
            try
            {
                return this.GetAll().Where(r => FilterItem.Contains(r.ID));
            }
            catch
            {

                throw;
            }
        }
    }
}