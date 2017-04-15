using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Race.Infrastructure.CrossCutting.Utils.Extenstions.EnumExtensions;

namespace Race.Infrastructure.CrossCutting.Utils.Extenstions.String
{
    public static class StringHelpers
    {
        public static Enum GetEnum(this string x, Type type)
        {
            System.Enum r = Enum.Parse(type, x, true) as Enum;
            return r;
        }
        public static string GetEnumDescrption(this string x, Type type)
        {
            System.Enum r = Enum.Parse(type, x, true) as Enum;
            return (r.GetDescription());
        }              
        public static string GetBooleanDesciption(this bool x)
        {
            
           return x? "تم" : "لم يتم";
        }
        public static string ToArabicNumbers(this string input)
        {
            if (input == null)
                return "";
            var info = new CultureInfo("ar-EG");
            var nativeNums = info.NumberFormat.NativeDigits;
            var sb = new StringBuilder();
            foreach (var character in input.ToCharArray())
            {
                if (char.IsDigit(character))
                {
                    var index = int.Parse(character.ToString());
                    sb.Append(nativeNums[index]);
                }
                else
                    sb.Append(character);
            }
            return sb.ToString();
        }
        public static string ToOppositDirection(this string x)
        {
            var xx = x.Split('/');

            if (xx[0].CompareTo(xx[1])>0)
            {
                return xx[1].ToArabicNumbers() + " / " + xx[0].ToArabicNumbers();

            }
            else
            {
                return xx[0].ToArabicNumbers() + " / " + xx[1].ToArabicNumbers();
            }
            throw new NotImplementedException();
        }

        public static string GetPreviousYear(this string x)
        {
            var xx = x.Split('/');
            return (Convert.ToInt32(xx[0])-1) + "/" + (Convert.ToInt32(xx[1])-1);
        }
    }


}
