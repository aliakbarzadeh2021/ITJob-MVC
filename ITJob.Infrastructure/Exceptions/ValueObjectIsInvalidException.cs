namespace ITJob.Infrastructure.Exceptions
{
	class ValueObjectIsInvalidException : DomainException
    {
        public ValueObjectIsInvalidException(string message)
            : base(message)
        {

        }
    }
}
