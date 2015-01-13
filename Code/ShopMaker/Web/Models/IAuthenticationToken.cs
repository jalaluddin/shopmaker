namespace ShopMaker.Web
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public interface IAuthenticationToken 
	{
		string EmailAddress { get;set; }

		string FirstName { get;set; }

		string LastName { get;set; }

		UserTypeOptions UserType { get;set; }

	}
}

