using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingKernel
{
    public class PersonStructureDefineChildBusiness : BaseBusiness
    {
        private int PrimeryLen;
        private int SecendryLen;
        private int PersonLen;
        public System.Data.Entity.DbSet<Data.PersonStructureDefine> Table { get { return ak1.PersonStructureDefines; } }

        public PersonStructureDefineChildBusiness()
        {
            PrimeryLen = (int)Business.GetCodeTitleBusiness().GetById(Constants.CodeTitle.PersonPrimeryGroup).CodeLen;
            SecendryLen = (int)Business.GetCodeTitleBusiness().GetById(Constants.CodeTitle.PersonSecendryGroup).CodeLen;
            PersonLen = (int)Business.GetCodeTitleBusiness().GetById(Constants.CodeTitle.PersonIDGroup).CodeLen;
        }

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

        public void SaveWithID(Data.PersonStructureDefine _personStructureDefine)
        {
            try
            {
                Guid i = Business.GetPersonStructureDefineChildBusiness().GetAll().Where(r => r.ID == _personStructureDefine.ID).Select(r => r.ID).FirstOrDefault();
                if (i == Guid.Empty)
                    this.Insert(_personStructureDefine);
                else
                    this.SubmitChanges();
            }
            catch
            {
                throw;
            }
        }

        public void Insert(Data.PersonStructureDefine _personStructureDefine)
        {
            try
            {
                if (_personStructureDefine.ID == Guid.Empty)
                    _personStructureDefine.ID = Guid.NewGuid();
                this.Table.Add(_personStructureDefine);
                this.SubmitChanges();
            }
            catch
            {
                throw;
            }
        }

        public IQueryable<Data.PersonStructureDefine> GetByID(Guid? ID)
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

        private bool ValidateDelete(Data.PersonStructureDefine DeletedItem, out string errorMessage)
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


        public Data.PersonStructureDefine GetStructure(Guid Type, string Name, Guid? ParentID, string Code)
        {
            Data.PersonStructureDefine _entity = new Data.PersonStructureDefine();

            _entity.ID = Guid.NewGuid();
            _entity.Type = Type;
            _entity.Name = Name;
            _entity.Parent_ID = ParentID;
            _entity.Code = GetCode(_entity.Type, Code);

            _entity.LastEdit = DateTime.Now;
            _entity.Uniq_Path = GetUniqPath(_entity);

            return _entity;
        }

        private string GetUniqPath(Data.PersonStructureDefine entity)
        {

            StringBuilder str = new StringBuilder();
            str.Append(string.Format("#{0}", entity.ID));

            Data.PersonStructureDefine _entity = this.GetAll().Where(r => r.ID == entity.Parent_ID).FirstOrDefault();

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

                if (Type == Constants.CodeTitle.PersonPrimeryGroup)
                    code.Add(Code.Substring(0, PrimeryLen));
                if (Type == Constants.CodeTitle.PersonSecendryGroup)
                {
                    code.Add(Code.Substring(0, PrimeryLen));
                    code.Add(Code.Substring(PrimeryLen, SecendryLen));
                }
                if (Type == Constants.CodeTitle.PersonIDGroup)
                {
                    code.Add(Code.Substring(0, PrimeryLen));
                    code.Add(Code.Substring(PrimeryLen, SecendryLen));
                    code.Add(Code.Substring(PrimeryLen + SecendryLen, PersonLen));
                }

                int a = 0;
                if (Type == Constants.CodeTitle.PersonPrimeryGroup)
                    a = Convert.ToInt32(code[0]);
                else if (Type == Constants.CodeTitle.PersonSecendryGroup)
                    a = Convert.ToInt32(code[1]);
                else if (Type == Constants.CodeTitle.PersonIDGroup)
                    a = Convert.ToInt32(code[2]);
                a++;

                int z = 0;
                if (a < 10)
                    z = 1;
                else if (a >= 10 && a < 100)
                    z = 2;
                else if (a >= 100)
                    z = 3;

                if (Type == Constants.CodeTitle.PersonPrimeryGroup)
                {
                    for (int i = 0; i < PrimeryLen - z; i++)
                        stringBuilder.Append("0");
                    stringBuilder.Append(a);
                }

                else if (Type == Constants.CodeTitle.PersonSecendryGroup)
                {
                    stringBuilder.Append(code[0]);
                    for (int i = 0; i < SecendryLen - z; i++)
                        stringBuilder.Append("0");
                    stringBuilder.Append(a);
                }

                else if (Type == Constants.CodeTitle.PersonIDGroup)
                {
                    stringBuilder.Append(code[0]);
                    stringBuilder.Append(code[1]);
                    for (int i = 0; i < SecendryLen - z; i++)
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
                    if (Type == Constants.CodeTitle.PersonPrimeryGroup)
                    {
                        for (int i = 0; i < PrimeryLen - 1; i++)
                            stringBuilder.Append("0");
                        stringBuilder.Append("1");
                    }
                    else if (Type == Constants.CodeTitle.PersonSecendryGroup)
                    {
                        for (int i = 0; i < SecendryLen - 1; i++)
                            stringBuilder.Append("0");
                        stringBuilder.Append("1");
                    }
                    else if (Type == Constants.CodeTitle.PersonIDGroup)
                    {
                        for (int i = 0; i < PersonLen - 1; i++)
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

        public IQueryable<Data.PersonStructureDefine> GetByParentID(Guid? ParentID)
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

        //public IEnumerable<MoeinReport> GetMoeins()
        //{
        //    try
        //    {
        //        var s = this.GetAll().Where(r => r.Type == Constants.CodeTitle.PersonIDGroup)
        //            .Join(this.GetAll(), o => o.Parent_ID, i => i.ID, (m, k) => new { moein = m, kol = k })
        //            .Join(this.GetAll(), o => o.kol.Parent_ID, i => i.ID, (m, g) => new { Mo = m, go = g }).ToList();
        //        var ssd = s.Select(r => new MoeinReport()
        //        {
        //            ID = r.Mo.moein.ID,
        //            GoruhCode = r.go.Code,
        //            GoruhName = r.go.Name,
        //            KolCode = r.Mo.kol.Code,
        //            KolName = r.Mo.kol.Name,
        //            MoeinCode = r.Mo.moein.Code,
        //            MoeinName = r.Mo.moein.Name
        //        });

        //        return ssd;
        //    }
        //    catch
        //    {

        //        throw;
        //    }

        //}

        //public Data.PersonStructureDefine GetByCode(string Code)
        //{
        //    try
        //    {
        //        return this.GetAll().Where(r => r.Code == Code).FirstOrDefault();
        //    }
        //    catch
        //    {

        //        throw;
        //    }
        //}

        //public string GetMoeinFromParentCode(string ParentCode)
        //{
        //    try
        //    {
        //        return this.GetAll().Where(r => r.Code.Contains(ParentCode)).Max(r => r.Code);
        //    }
        //    catch
        //    {

        //        throw;
        //    }
        //}

        public Data.PersonStructureDefine GetParent(Data.PersonStructureDefine ChangableItem)
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

        //public IQueryable<Data.PersonStructureDefine> GetTafsil(Guid ParentId, Guid Type)
        //{
        //    try
        //    {
        //        return this.GetAll().Where(r => r.Parent_ID == ParentId && r.Type == Type);
        //    }
        //    catch
        //    {

        //        throw;
        //    }
        //}

    }
}
