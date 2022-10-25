using System;
using ITJob.Infrastructure.Domain;

namespace ITJob.Infrastructure.Exceptions
{
    /// <summary>
    /// خطای دامین
    /// </summary>
	public class DomainException : Exception, ICustomException
    {
        /// <summary>
        /// یک وهله از خطای دامین ایجاد میکند
        /// </summary>
        public DomainException()
        {
        }

        /// <summary>
        /// یک وهله از خطای دامین ایجاد میکند
        /// </summary>
        /// <param name="message">پیام خطا</param>
        public DomainException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// یک وهله از خطای دامین ایجاد میکند
        /// </summary>
        /// <param name="message">پیام خطا</param>
        /// <param name="innerException">خطای درونی</param>
        public DomainException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}