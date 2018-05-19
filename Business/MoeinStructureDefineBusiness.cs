using AccountingKernel.Class;
using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingKernel
{
    public class MoeinStructureDefineBusiness : BaseBusiness
    {
        public System.Data.Entity.DbSet<Data.AccountingMoeinStructureDefine> Table { get { return ak1.AccountingMoeinStructureDefines; } }

        private int GoruhLen;
        private int KolLen;
        private int TafsilLen;
        private int MoeinLen;

        public MoeinStructureDefineBusiness()
        {
            GoruhLen = (int)Business.GetCodeTitleBusiness().GetById(Constants.CodeTitle.Goruh).CodeLen;
            KolLen = (int)Business.GetCodeTitleBusiness().GetById(Constants.CodeTitle.Kol).CodeLen;
            MoeinLen = (int)Business.GetCodeTitleBusiness().GetById(Constants.CodeTitle.Moein).CodeLen;
            TafsilLen = (int)Business.GetCodeTitleBusiness().GetById(Constants.CodeTitle.Tafsil1).CodeLen;
        }

        public IQueryable<Data.AccountingMoeinStructureDefine> GetAll()
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

        public void SaveWithID(Data.AccountingMoeinStructureDefine _moeinStructureDefine)
        {
            try
            {
                Guid i = this.GetAll().Where(r => r.ID == _moeinStructureDefine.ID).Select(r => r.ID).FirstOrDefault();
                _moeinStructureDefine.Name = _moeinStructureDefine.Name.Trim();
                if (i == Guid.Empty)
                    this.Insert(_moeinStructureDefine);
                else
                    this.SubmitChanges();
            }
            catch
            {
                throw;
            }
        }

        public void Insert(Data.AccountingMoeinStructureDefine _moeinStructureDefine)
        {
            try
            {
                if (_moeinStructureDefine.ID == Guid.Empty)
                    _moeinStructureDefine.ID = Guid.NewGuid();
                this.Table.Add(_moeinStructureDefine);
                this.SubmitChanges();
            }
            catch
            {
                throw;
            }
        }

        public Data.AccountingMoeinStructureDefine GetRecord(string Code, Guid Type)
        {
            return this.GetAll().Where(r => r.Code == Code && r.Type == Type).FirstOrDefault();
        }

        public IQueryable<Data.AccountingMoeinStructureDefine> GetByID(Guid? ID)
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

        public void Delete(Data.AccountingMoeinStructureDefine DeletedItem)
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

        public bool ValidateDelete(Data.AccountingMoeinStructureDefine DeletedItem, out string errorMessage)
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

        public Data.AccountingMoeinStructureDefine GetStructure(Guid Type, string Name, string LatinName, Guid? ParentID, string Code)
        {
            Data.AccountingMoeinStructureDefine _entity = new Data.AccountingMoeinStructureDefine();

            _entity.ID = Guid.NewGuid();
            _entity.Type = Type;
            _entity.Name = Name;
            _entity.Latin_Name = LatinName;
            _entity.Parent_ID = ParentID;

            if ((Type == Constants.CodeTitle.Tafsil1 || Type == Constants.CodeTitle.Tafsil1 || Type == Constants.CodeTitle.Tafsil1) == false)
                _entity.Code = GetCode(_entity.Type, Code);

            _entity.LastEdit = DateTime.Now;
            _entity.Uniq_Path = GetUniqPath(_entity);

            return _entity;
        }

        private string GetUniqPath(Data.AccountingMoeinStructureDefine entity)
        {

            StringBuilder str = new StringBuilder();
            str.Append(string.Format("#{0}", entity.ID));

            Data.AccountingMoeinStructureDefine _entity = this.GetAll().Where(r => r.ID == entity.Parent_ID).FirstOrDefault();

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

                if (Type == Constants.CodeTitle.Goruh)
                    code.Add(Code.Substring(0, GoruhLen));
                if (Type == Constants.CodeTitle.Kol)
                {
                    code.Add(Code.Substring(0, GoruhLen));
                    code.Add(Code.Substring(GoruhLen, KolLen));
                }
                if (Type == Constants.CodeTitle.Moein)
                {
                    code.Add(Code.Substring(0, GoruhLen));
                    code.Add(Code.Substring(GoruhLen, KolLen));
                    code.Add(Code.Substring(GoruhLen + KolLen, MoeinLen));
                }
                if (Type == Constants.CodeTitle.Tafsil1 || Type == Constants.CodeTitle.Tafsil2 || Type == Constants.CodeTitle.Tafsil3)
                {
                    code.Add(Code.Substring(0, GoruhLen));
                    code.Add(Code.Substring(GoruhLen, KolLen));
                    code.Add(Code.Substring(GoruhLen + KolLen, MoeinLen));
                }

                int a = 0;
                if (Type == Constants.CodeTitle.Goruh)
                    a = Convert.ToInt32(code[0]);
                else if (Type == Constants.CodeTitle.Kol)
                    a = Convert.ToInt32(code[1]);
                else if (Type == Constants.CodeTitle.Moein)
                    a = Convert.ToInt32(code[2]);
                a++;

                int z = 0;
                if (a < 10)
                    z = 1;
                else if (a >= 10 && a < 100)
                    z = 2;
                else if (a >= 100)
                    z = 3;

                if (Type == Constants.CodeTitle.Goruh)
                {
                    for (int i = 0; i < GoruhLen - z; i++)
                        stringBuilder.Append("0");
                    stringBuilder.Append(a);
                }

                else if (Type == Constants.CodeTitle.Kol)
                {
                    stringBuilder.Append(code[0]);
                    for (int i = 0; i < KolLen - z; i++)
                        stringBuilder.Append("0");
                    stringBuilder.Append(a);
                }

                else if (Type == Constants.CodeTitle.Moein)
                {
                    stringBuilder.Append(code[0]);
                    stringBuilder.Append(code[1]);
                    for (int i = 0; i < KolLen - z; i++)
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
                    if (Type == Constants.CodeTitle.Goruh)
                    {
                        for (int i = 0; i < GoruhLen - 1; i++)
                            stringBuilder.Append("0");
                        stringBuilder.Append("1");
                    }
                    else if (Type == Constants.CodeTitle.Kol)
                    {
                        for (int i = 0; i < KolLen - 1; i++)
                            stringBuilder.Append("0");
                        stringBuilder.Append("1");
                    }
                    else if (Type == Constants.CodeTitle.Moein)
                    {
                        for (int i = 0; i < MoeinLen - 1; i++)
                            stringBuilder.Append("0");
                        stringBuilder.Append("1");
                    }
                    else if (Type == Constants.CodeTitle.Tafsil1)
                    {
                        for (int i = 0; i < TafsilLen - 1; i++)
                            stringBuilder.Append("0");
                        stringBuilder.Append("1");
                    }
                    else if (Type == Constants.CodeTitle.Tafsil2)
                    {
                        for (int i = 0; i < TafsilLen - 1; i++)
                            stringBuilder.Append("0");
                        stringBuilder.Append("1");
                    }
                    else if (Type == Constants.CodeTitle.Tafsil3)
                    {
                        for (int i = 0; i < TafsilLen - 1; i++)
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

        public IQueryable<Data.AccountingMoeinStructureDefine> GetByParentID(Guid? ParentID)
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

        public IEnumerable<MoeinReport> GetMoeins()
        {
            try
            {
                var s = this.GetAll().Where(r => r.Type == Constants.CodeTitle.Moein)
                    .Join(this.GetAll(), o => o.Parent_ID, i => i.ID, (m, k) => new { moein = m, kol = k })
                    .Join(this.GetAll(), o => o.kol.Parent_ID, i => i.ID, (m, g) => new { Mo = m, go = g }).ToList();
                var ssd = s.Select(r => new MoeinReport()
                {
                    ID = r.Mo.moein.ID,
                    FirstLevelCode = r.go.Code,
                    FirstLevelName = r.go.Name,
                    SecondLevelCode = r.Mo.kol.Code,
                    SecondLevelName = r.Mo.kol.Name,
                    ThirdLevelCode = r.Mo.moein.Code,
                    ThirdLevelName = r.Mo.moein.Name
                });

                return ssd;
            }
            catch
            {

                throw;
            }

        }

        public Data.AccountingMoeinStructureDefine GetByCode(string Code)
        {
            try
            {
                return this.GetAll().Where(r => r.Code == Code).FirstOrDefault();
            }
            catch
            {

                throw;
            }
        }

        public Data.AccountingMoeinStructureDefine GetParent(Data.AccountingMoeinStructureDefine ChangableItem)
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

        public IQueryable<Data.AccountingMoeinStructureDefine> GetTafsil(Guid ParentId, Guid Type)
        {
            try
            {
                return this.GetAll().Where(r => r.Parent_ID == ParentId && r.Type == Type);
            }
            catch
            {

                throw;
            }
        }

        private IQueryable<Data.AccountingMoeinStructureDefine> SearchByCode(string Code, List<Guid?> Types)
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

        private IQueryable<Data.AccountingMoeinStructureDefine> SearchByName(string Name, List<Guid?> Types)
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

        public IQueryable<Data.AccountingMoeinStructureDefine> Search(string Text, List<Guid?> Types)
        {
            if (string.IsNullOrEmpty(Text))
                return null;
            if (Char.IsNumber(Text, 0))
                return SearchByCode(Text, Types);
            else
                return SearchByName(Text, Types);

        }
    }
}
