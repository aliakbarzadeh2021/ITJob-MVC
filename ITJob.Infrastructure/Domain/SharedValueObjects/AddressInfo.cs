using System;
using System.Text.RegularExpressions;

namespace ITJob.Infrastructure.Domain.SharedValueObjects
{
//	[Serializable]
	public class AddressInfo : ValueObjectBase<AddressInfo>
	{
        /// <summary>
        /// استان
        /// </summary>
        public virtual string Province { get; private set; }
		
        /// <summary>
        /// شهر
        /// </summary>
        public virtual string City { get; private set; }
		
        /// <summary>
        /// آدرس پستی
        /// </summary>
        public virtual string Address { get; private set; }
		
        /// <summary>
        /// تلفن ثابت
        /// </summary>
        public virtual string Phone { get; private set; }
		
        /// <summary>
        /// تلفن همراه
        /// </summary>
        public virtual string MobilePhone { get; private set; }

        /// <summary>
        /// کد پستی
        /// </summary>
		public virtual string PostalCode { get; set; }

		/// <summary>
		/// For NH!
		/// </summary>
		protected AddressInfo()
		{
			Province = "";
			City = "";
			Address = "";
			Phone = "";
			MobilePhone = "";
			PostalCode = "";
		}

		public AddressInfo(string province, string city, string address, string phone, string mobilePhone, string postalCode)
		{
			Province = province;
			City = city;
			Address = address;
			Phone = phone;
			MobilePhone = mobilePhone;
			PostalCode = postalCode;
			CorrectValues();
		}

		public void CorrectValues()
		{
			Phone = GetPhone(Phone);
			MobilePhone = GetMobile(MobilePhone);
			PostalCode = GetPostalCode(PostalCode);
		}

		private static string GetMobile(string mobile)
		{
			mobile = Remove(mobile);
			if (mobile.Length != 11)
				return "";
			if (Regex.IsMatch(mobile, @"09\d{9}"))
				return mobile;
			return "";
		}
		private static string GetPhone(string phone)
		{
			phone = Remove(phone);
			if (phone.Length != 11)
				return "";
			if (Regex.IsMatch(phone, @"0\d{10}"))
				return phone;
			return "";
		}
		private static string GetPostalCode(string postCode)
		{
			postCode = Remove(postCode);
			if (postCode.Length != 10)
				return "";
			if (Regex.IsMatch(postCode, @"\d{10}"))
				return postCode;
			return "";
		}

		private static string Remove(string str)
		{
			return str.Replace(" ", "").Replace("-", "").Replace("_", "");
		}

	}
}
