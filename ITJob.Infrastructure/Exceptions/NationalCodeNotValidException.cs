namespace ITJob.Infrastructure.Exceptions
{
	public class NationalCodeNotValidException : DomainException
	{
		public NationalCodeNotValidException() : this("کد ملی وارد شده غیر مجاز است.")
		{
		}

		public NationalCodeNotValidException(string nationalCode) : base("کد ملی وارد شده غیر مجاز است: " + nationalCode)
		{
			
		}
	}
}