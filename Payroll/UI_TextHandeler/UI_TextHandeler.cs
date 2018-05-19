using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;

namespace AccountingKernel.Class.UI
{
    class TextHandeler
    {

        public bool Check_Phone(string In_Phone)
        {
            bool result = In_Phone.Length == 11;

            string Numbers = "0123456789";
            for (int i = 0; i < In_Phone.Length; i++)
                if (Numbers.IndexOf(In_Phone.Substring(i, 1)) == -1)
                {
                    result = false;
                    break;
                }

            return result;
        }

        public void CheckIsNumeric(TextCompositionEventArgs e)
        {
            int result;
            if (!(int.TryParse(e.Text, out result) || e.Text == "."))
            {
                e.Handled = true;
            }
        }

        public void CheckIsAccountNumber(TextCompositionEventArgs e)
        {
            int result;
            if (!(int.TryParse(e.Text, out result) || e.Text == "-"))
            {
                e.Handled = true;
            }
        }

        public void chequeSerial(TextCompositionEventArgs e)
        {
            int result;
            if (!(int.TryParse(e.Text, out result) || e.Text == "-" || e.Text == "/" || e.Text == @"\"))
            {
                e.Handled = true;
            }
        }
        public void SepratTextBox(object sender, TextChangedEventArgs e)
        {
            try
            {
                TextBox tb = sender as TextBox;

                decimal Number;
                if (decimal.TryParse(tb.Text, out Number))
                {
                    tb.Text = string.Format("{0:N0}", Number);
                }
                tb.Text = tb.Text;

                tb.SelectionStart = tb.Text.Length;

            }
            catch
            {
                throw;
            }
        }            
        public void AddZero(object sender, TextCompositionEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (e.Text == "+")
            {
                e.Handled = true;
                tb.AppendText("000");
            }

            if (e.Text == "-")
            {
                e.Handled = true;
                tb.AppendText("00");
            }
        }

        public string SepratNumber(int InputNumber)
        {
            string Result = InputNumber.ToString("N0", new System.Globalization.NumberFormatInfo()
            {
                NumberGroupSizes = new[] { 3 },
                NumberGroupSeparator = ","
            });

            return Result;
        }

        //در تکس باکس فقط می توان حروف فارسی و سیمبلها را تایپ نمود
        public void JustPersian(TextCompositionEventArgs e)
        {
            try
            {
                char c = char.Parse(e.Text);
                int a = (int)c;

                if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
                    e.Handled = true;
            }
            catch
            {

                throw;
            }
        }
        public void JustEnglish(TextCompositionEventArgs e)
        {
            char c = char.Parse(e.Text);
            int a = (int)c;

            if ((c >= 'آ' && c <= 'ی'))
                e.Handled = true;
        }


        public void Change_Lan_Fa()
        {
            System.Globalization.CultureInfo Language = new System.Globalization.CultureInfo("fa-ir");
            System.Windows.Forms.InputLanguage.CurrentInputLanguage = System.Windows.Forms.InputLanguage.FromCulture(Language);
        }

    }
}
