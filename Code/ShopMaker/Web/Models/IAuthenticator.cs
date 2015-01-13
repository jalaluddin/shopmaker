namespace ShopMaker.Web
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public interface IAuthenticator 
	{
		IAuthenticationToken AuthenticateAdmin(string emailAddress, string password);

		IAuthenticationToken AuthenticateShowOwner(string emailAddress, string password);

	}
}

