using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingKernel.Forms.AssetGoods
{
    public class MainGroup
    {
        public System.Guid ID { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public List<SubGroup> SubGroups { get; set; }

        public MainGroup(Data.AssetGood assetGroup, List<Data.AssetGood> subGroups)
        {
            ID = assetGroup.ID;
            name = assetGroup.name;
            code = assetGroup.code;
            SubGroups = new List<SubGroup>();
            foreach (var item in subGroups)
            {
                SubGroups.Add(new SubGroup() { name = item.name, code = item.code, Id = item.ID });
            }

        }

        public MainGroup(Data.AccountingMoeinStructureDefine assetGroup, List<Data.AccountingMoeinStructureDefine> subGroups)
        {
            ID = assetGroup.ID;
            name = assetGroup.Name;
            code = assetGroup.Code;
            SubGroups = new List<SubGroup>();
            foreach (var item in subGroups)
            {
                SubGroups.Add(new SubGroup() { name = item.Name, code = item.Code, Id = item.ID });
            }

        }


    }

    public class SubGroup
    {
        public string name { get; set; }
        public string code { get; set; }
        public Guid Id { get; set; }

    }

}
