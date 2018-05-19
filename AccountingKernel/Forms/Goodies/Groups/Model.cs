using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingKernel.Forms.Goodies.Groups
{
    public class MainGroup
    {
        public System.Guid ID { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public List<SubGroup> SubGroups { get; set; }

        public MainGroup(Data.GoodiesGroup mainGroup, List<Data.GoodiesGroup> subGroups)
        {
            ID = mainGroup.ID;
            name = mainGroup.CName;
            code = mainGroup.Code;
            SubGroups = new List<SubGroup>();
            foreach (var item in subGroups)
            {
                SubGroups.Add(new SubGroup() { name = item.CName, code = item.Code, Id = item.ID });
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
