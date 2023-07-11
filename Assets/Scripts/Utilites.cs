using System;

namespace Initium
{
    public static class Utilites
    {
        public static string FormatDate(this DateTime date, IFormatProvider format)
        {
            return $"{date.DayOfWeek}, {date.ToString("d MMMM yyyy", format)}";
        }

        public static string FormatTime(this DateTime date, IFormatProvider format)
        {
            return date.ToString("HH:mm", format);
        }
    }
}
