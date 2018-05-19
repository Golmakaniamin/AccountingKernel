using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class ExtentionMethods
    {
        public static decimal ToDecimal(this object i)
        {
            try
            {
                return Convert.ToDecimal(i);
            }
            catch
            {
                return 0;
            }
        }

        public static int ToInt(this object i)
        {
            try
            {
                string str = i.ToString().Replace(",", "");
                return Convert.ToInt32(str);
            }
            catch
            {
                return 0;
            }
        }

        public static Int64 ToInt64(this object i)
        {
            try
            {
                string str = i.ToString().Replace(",", "");
                return Convert.ToInt64(str);

            }
            catch
            {
                return 0;
            }
        }

        public static double ToDouble(this object i)
        {
            try
            {
                string str = i.ToString().Replace(",", "");
                return Convert.ToDouble(str);
            }
            catch
            {
                return 0;
            }
        }

        public static int? ToNullableInt(this object i)
        {
            try
            {
                return Convert.ToInt16(i);
            }
            catch
            {
                return null;
            }
        }

        public static decimal? ToNullableDecimal(this object i)
        {
            try
            {
                return Convert.ToDecimal(i);
            }
            catch
            {
                return null;
            }
        }

        public static Guid ToGUID(this object i)
        {
            try
            {
                return (Guid)i;
            }
            catch
            {
                return Guid.Empty;
            }
        }

        public static string Calibrate(this string str, char character, int len)
        {
            try
            {
                if (str.Length > len)
                    str = str.Substring(str.Length - len);
                return str.PadLeft(len, character);
            }
            catch
            {

                throw;
            }
        }

        public static bool ToBoolean(this object i)
        {
            try
            {
                return Convert.ToBoolean(i);
            }
            catch
            {

                return false;
            }
        }

        public static string ToPersian(this DateTime dt)
        {
            try
            {
                var persianCalendar = new PersianCalendar();
                string year = persianCalendar.GetYear(dt).ToString();
                string month = persianCalendar.GetMonth(dt).ToString().PadLeft(2, '0');
                string day = persianCalendar.GetDayOfMonth(dt).ToString().PadLeft(2, '0');
                return String.Format("{0}/{1}/{2}", year, month, day);

            }
            catch
            {

                throw;
            }
        }

        public static DateTime ToDate(this string date)
        {
            var pc = new System.Globalization.PersianCalendar();

            string[] mount = date.Split('/');
            int year = int.Parse(mount[0]);
            int month = int.Parse(mount[1]);
            int day = int.Parse(mount[2]);

            var target = pc.ToDateTime(year, month, day, 0, 0, 0, 0);
            return target;
        }

        public static string ToNormalDate(this string date)
        {
            try
            {
                var splits = date.Split('/');


                return string.Format("{0}/{1}/{2}", splits[0].Calibrate('0', 4), splits[1].Calibrate('0', 2), splits[2].Calibrate('0', 2));
            }
            catch
            {

                throw;
            }
        }
        public static Guid? ToNullableGUID(this object i)
        {
            try
            {
                return (Guid)i;
            }
            catch
            {
                return null;
            }
        }

        public static bool IsNullOrEmpty(this string str)
        {
            try
            {
                return str == null || str == string.Empty;
            }
            catch
            {

                throw;
            }
        }

        public static char ToChar(this object obj)
        {
            try
            {
                return Convert.ToChar(obj);
            }
            catch
            {

                throw;
            }
        }

        public static string ToString(this object obj, string mask)
        {
            try
            {
                try
                {
                    return obj.ToString();
                }
                catch
                {
                    return string.Empty;
                }
            }
            catch
            {

                throw;
            }
        }

        //public static string SepratNumber(this string str)
        //{
        //    try
        //    {
        //        decimal Number;
        //        if (decimal.TryParse(str, out Number))
        //        {
        //            var a = Number;
        //            return string.Format("{0:N0}", Number);             
        //        }
        //        return str;
        //    }
        //    catch
        //    {

        //        throw;
        //    }
        //}

        public static string ExtractYear(this string date)
        {
            try
            {
                return date.Substring(0, 4);
            }
            catch
            {

                throw;
            }
        }


    }
}
