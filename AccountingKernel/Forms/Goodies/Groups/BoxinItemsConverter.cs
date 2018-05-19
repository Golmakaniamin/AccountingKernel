using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using System.Linq;

namespace AccountingKernel.Forms.Goodies.Groups
{
    public class BoxinItemsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var values = value as IEnumerable;
            var type = parameter as Type;

            if (values == null || type == null)
                return null;

            if (type.GetInterfaces().Any(x => x == typeof (IItemsWrapper)))
            {
                var instance = (IItemsWrapper) type.Assembly.CreateInstance(type.FullName);
                instance.Items = (IEnumerable) value;
                return new List<IItemsWrapper> {instance};
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}