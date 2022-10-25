using System;
using ITJob.Infrastructure.Domain;

namespace ITJob.Infrastructure.Exceptions
{
	public abstract class CustomException : Exception, ICustomException
	{
		protected CustomException()
		{
			
		}
		protected CustomException(string message) : base(message)
		{
			
		}

		protected CustomException(string message, Exception innerException) : base(message, innerException)
		{
			
		}

		
	}
}
