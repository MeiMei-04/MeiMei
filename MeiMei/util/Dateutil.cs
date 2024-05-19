using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeiMei.util
{
    internal class Dateutil
    {
        public static DateTime ConvertStringToDateTime(string dateTimeString, string format = "M/d/yyyy")
        {
            DateTime dateTime;
            if (DateTime.TryParseExact(dateTimeString, format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dateTime))
            {
                return dateTime;
            }
            else
            {
                throw new FormatException($"Chuỗi '{dateTimeString}' không được nhận dạng là một DateTime hợp lệ.");
            }
        }
        public static TimeSpan ConvertStringToTimeSpan(string timeSpanString, string format = "h:mm:ss tt")
        {
            DateTime dateTime;
            if (DateTime.TryParseExact(timeSpanString, format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dateTime))
            {
                return dateTime.TimeOfDay;
            }
            else
            {
                throw new FormatException($"Chuỗi '{timeSpanString}' không được nhận dạng là một TimeSpan hợp lệ.");
            }
        }

    }
}
