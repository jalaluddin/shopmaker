namespace ShopMaker.Membership
{
	using ShopMaker.Web;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public class UserAuthenticationService : IAuthenticator
	{
		public virtual IAuthenticationToken AuthenticateAdmin(string emailAddress, string password)
		{
			throw new System.NotImplementedException();
		}

		public virtual IAuthenticationToken AuthenticateShowOwner(string emailAddress, string password)
		{
			throw new System.NotImplementedException();
		}

	}
}

