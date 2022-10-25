using System;
using ITJob.Infrastructure.Exceptions;
using ITJob.Infrastructure.Services;

namespace ITJob.Infrastructure.Domain.SharedValueObjects
{
	public class NationalCode : ValueObjectBase<NationalCode>
	{
        public virtual string Value { get; private set; }

		/// <summary>
		/// For NH!
		/// </summary>
		protected internal NationalCode()
		{
			Value = "";
		}

		public NationalCode(string value)
		{
			Value = NationalCodeValidator.Extract(value);
		}

		protected override void Validate()
		{
			bool isValid = NationalCodeValidator.Validate(Value);
			if (!isValid)
				throw new NationalCodeNotValidException(Value);
		}

		public override string ToString()
		{
			return Value;
		}

		public override bool Equals(NationalCode other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return base.Equals(other) && string.Equals(Value, other.Value);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((NationalCode) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (base.GetHashCode()*397) ^ (Value != null ? Value.GetHashCode() : 0);
			}
		}
	}
}
