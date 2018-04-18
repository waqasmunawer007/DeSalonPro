using System;
using System.Globalization;
using Xamarin.Forms;

namespace Salon_Pro_APP.Convertors
{
    public class DataHasEnteredConvertor: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Label label = parameter as Label;
            if (value != null)
            {
                var val = value as string;
                if (string.IsNullOrWhiteSpace(val))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return true; //page firstly open then not show error message
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
