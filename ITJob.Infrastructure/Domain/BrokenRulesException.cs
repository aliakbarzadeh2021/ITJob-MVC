using System;
using System.Collections.Generic;

namespace ITJob.Infrastructure.Domain
{
	public class BrokenRulesException : Exception, ICustomException
	{
	    public BrokenRulesException()
	    {
	    }

	    public IList<BusinessRule> BusinessRules { get; set; }

		public BrokenRulesException(IList<BusinessRule> businessRules)
		{
			BusinessRules = businessRules;
		}

		public override string Message
		{
			get { return "در هنگام ثبت خطا های زیر رخ داده است."; }
		}
	}
}