using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Utils.Extenstions.String;

namespace Infrastructure.Utils.Extenstions.DateTime
{
    public static class DateTimeHelpers
    {
        public static string ToArabicDate(this System.DateTime x)
        {
            string day, month, year;
            day = x.Day.ToString().ToArabicNumbers();
            month = x.Month.ToString().ToArabicNumbers();
            year = x.Year.ToString().ToArabicNumbers();
            return year + "/" + month + "/" + day;
        }
        public static string ToArabicDateNullable(this System.DateTime? x)
        {
            string day, month, year;
            System.DateTime y = (System.DateTime)x;
            day = y.Day.ToString().ToArabicNumbers();
            month = y.Month.ToString().ToArabicNumbers();
            year = y.Year.ToString().ToArabicNumbers();
            return year + "/" + month + "/" + day;
        }

    }
}
