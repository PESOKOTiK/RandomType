using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace RandomType.MVVM.Core
{
    public class EnumToBool : IValueConverter
    {
        public object Convert(object value, Type targetType, object trueValue, CultureInfo culture)
        {
            if (value != null && value.GetType().IsEnum)
                return (Enum.Equals(value, trueValue));
            else
                return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object trueValue, CultureInfo culture)
        {
            if (value is bool && (bool)value)
                return trueValue;
            else
                return DependencyProperty.UnsetValue;
        }
    }
}
