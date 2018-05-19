using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Common
{
    public class Enum
    {
        public enum FormMode
        {
            New,
            Edit
        }

        public enum CodeGroup
        {
            Yek = 1,
            Do = 2,
            Se = 3,
            Chahar = 4,
            Panj = 5
        }

        public enum InputTypes
        {
            Text,
            Numeric,
            Currency
        }

        public enum InputLanguages
        {
            Farsi,
            English
        }

    }
}
