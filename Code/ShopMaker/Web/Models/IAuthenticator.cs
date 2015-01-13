using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopMaker.Web
{
	public interface IAuthenticator 
	{
		IAuthenticationToken AuthenticateAdmin(string emailAddress, string password);

		IAuthenticationToken AuthenticateShowOwner(string emailAddress, string password);

	}
}

