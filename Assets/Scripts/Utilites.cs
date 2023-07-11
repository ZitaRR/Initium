using System;

namespace Initium
{
    public static class Utilites
    {
        public static string FormatDay(this DateTime date)
        {
            return $"{(int)(date - DateTime.MinValue).TotalDays + 1}";
        }

        public static string FormatTime(this DateTime date, bool twelveHourclock = false)
        {
            return twelveHourclock
                ? date.ToString("hh:mm tt")
                : date.ToString("HH:mm");
        }
    }
}
