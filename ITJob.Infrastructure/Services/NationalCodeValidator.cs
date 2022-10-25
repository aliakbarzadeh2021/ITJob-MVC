using System;

namespace ITJob.Infrastructure.Services
{
	public static class NationalCodeValidator
	{
		public static bool Validate(string nationalCode)
		{
			try
			{
				string code = Extract(nationalCode);
				if (code.StartsWith("9")) // اتباع خارجی
					return true;
				if (code.Length != 10)
					return false;

				if (code == "0000000000" || code == "1111111111" || code == "2222222222" ||
					code == "3333333333" || code == "4444444444" || code == "5555555555" ||
					code == "6666666666" || code == "7777777777" || code == "8888888888" || code == "9999999999")
					return false;

				int a = int.Parse(code[9] + "");

				int b = 0;
				for (int i = 10; i >= 2; i--)
					b += int.Parse(code[10 - i] + "") * i;

				int c = b - ((b / 11) * 11);

				if (c == 0 && a == c)
					return true;
				if (c == 1 && a == 1)
					return true;
				if (c > 1 && a == 11 - c)
					return true;
				return false;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public static string Extract(string nationalCode)
		{
			string code = nationalCode.Replace("-", "").Replace("_", "");
			if (string.IsNullOrEmpty(code))
				return "";

			if (code.Length < 10)
			{
				for (int i = code.Length; i < 10; i++)
					code = "0" + code;
			}

			code = StringTools.CorrectNumbersToStandard(code);
			return code;
		}

		public static string Normalize(string nationalCode)
		{
			string code = Extract(nationalCode);
			if (code.Length >= 3)
				code = code.Insert(3, "-");
			if (code.Length >= 10)
				code = code.Insert(10, "-");
			return code;
		}

		public static bool IsEqual(string nc1, string nc2)
		{
			return Extract(nc1) == Extract(nc2);
		}
	}

}
