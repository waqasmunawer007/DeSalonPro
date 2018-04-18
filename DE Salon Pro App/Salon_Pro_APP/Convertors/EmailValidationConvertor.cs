using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Salon_Pro_APP.Convertors
{
    public class EmailValidationConvertor: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
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
                    bool IsValid = false;
                    IsValid = (Regex.IsMatch(val, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
                    if (IsValid)
                    {
                        return true;
                    }
                    else
                    {
                        label.Text = "Valid Email Required";
                        return false;
                    }
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
