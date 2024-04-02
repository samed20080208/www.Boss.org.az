using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace www.Boss.org.az.Models.Extentions
{
    public static class StringExtentions
    {
        public static string FirstCharToUpper(this string text)
        {
            if (!String.IsNullOrEmpty(text))
                return text.First().ToString().ToUpper() + text[1..];
            else
                throw new ArgumentNullException($"{nameof(text)} null or empty!");
        }

        public static bool HasSpecialChar(this string text)
        {
            string specialChar = @"\|!#$%&/()=?»«@£§€{};'<>_,";
            foreach (var item in specialChar)
            {
                if (text.Contains(item)) return true;
            }

            return false;
        }

    }
}
