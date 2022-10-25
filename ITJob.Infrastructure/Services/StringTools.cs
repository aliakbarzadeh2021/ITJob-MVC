using System;
using System.Globalization;

namespace ITJob.Infrastructure.Services
{
    public static class StringTools
    {
        public static string DtsFarsi(double d, int floatDigitCount)
        {
            string s = Math.Round(d, floatDigitCount) + "";
            s = s.Replace('.', '/');
            if (d < 0)
                s = s.Remove(0, 1) + "-";

            return s;
        }
        public static string Dts(double d)
        {
            bool IsNegative = false;
            if (d < 0)
            {
                d = -d;
                IsNegative = true;
            }
            int i = (int)d;
            int j = (int)(d * 100) - i * 100;
            string J = (j.ToString()).PadLeft(2, '0');
            string s;
            if (IsNegative)
            {
                if (j != 0)
                    s = i + "/" + J + "-";
                else
                    s = i + "-";
            }
            else
            {
                if (j != 0)
                    s = i + "/" + J;
                else
                    s = i + "";
            }

            return s;
        }

        public static string Dts(double d, int floatDigitCount)
        {
            return Math.Round(d, floatDigitCount) + "";
        }
        public static string ConvertMinutesToHour(int minutes)
        {
            int h = minutes / 60;
            int m = minutes - (h * 60);
            return h + ":" + m.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0');
        }
        public static double RoundDouble(double d)
        {
            return Math.Round(d, 2);
        }
        
		/// <summary>
		/// تبدیل حروف ی و ک عربی به فارسی 
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static string Correct(string s)
        {
            return s.Replace("ي", "ی").Replace("ك", "ک");
        }
        public static string RemoveAdditionalLetters(string str)
        {
			return RemoveNonAlphabetLetters(Correct(str).Replace("آ", "ا").Replace(" ", ""));
        }
        public static string RemoveNonAlphabetLetters(string str)
        {
	        return str.Replace("ـ", "")
					  .Replace("-", "")
					  .Replace("_", "")
					  .Replace(".", "")
					  .Replace("\n", "")
					  .Replace("\r", "");
        }

		/// <summary>
		/// حذف حروفی که در نام و نام خانوادگی استفاده نمی شود
		/// <remarks>مانند اعداد، علائم نقطه گذاری و غیره</remarks>
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
        public static string RemoveNonNamingUseLetters(string str)
        {
	        str = Correct(str);
			str = str.Replace("÷", "پ").Replace("×", "پ");

			// حذف اعداد
	        str = CorrectNumbersToStandard(str);
			str = str.Replace("0", "")
					 .Replace("1", "")
					 .Replace("2", "")
					 .Replace("3", "")
					 .Replace("4", "")
					 .Replace("5", "")
					 .Replace("6", "")
					 .Replace("7", "")
					 .Replace("8", "")
					 .Replace("9", "");

			// حذف حروف غیر مرتبط
	        str = RemoveNonAlphabetLetters(str);
	        return str.Trim();
        }

		public static string CorrectNumbersToStandard(string str)
		{
			for (char ch = '0'; ch <= '9'; ch++)
				str = str.Replace((char)(0x660 + ch - '0'), ch);

			return str;
		}

        public static int PureCompare(string str1, string str2)
        {
            string p1 = RemoveAdditionalLetters(str1);
            string p2 = RemoveAdditionalLetters(str2);
            return String.CompareOrdinal(p1, p2);
        }
        public static bool IsPureEqual(string str1, string str2)
        {
            return PureCompare(str1, str2) == 0;
        }

    }
}