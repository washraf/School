using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Utils.Extenstions.EnumExtensions
{
    public class EnumRepresentation
    {
        public string Text { get; set; }
        public string Value { set; get; }

        public override string ToString()
        {
            return this.Value;
        }
    }
    public static class EnumHelpers
    {
        public static string GetDescription<TEnum>(this TEnum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }

        public static List<EnumRepresentation> GetEnumRepresentationList(System.Enum tEnum)
        {
            List<EnumRepresentation> result = new List<EnumRepresentation>();
            var list = Enum.GetValues(tEnum.GetType());
            foreach (var item in list)
            {
                result.Add(new EnumRepresentation() { Value = item.ToString(), Text = item.GetDescription() });
            }
            return result;
        }
        
         
    }
}
