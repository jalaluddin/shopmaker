using ShopMaker.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopMaker.Membership
{
	public class UserAuthenticationService : IAuthenticator
	{
        private IMembershipRepositoryFactory _membershipRepositoryFactory;

        public UserAuthenticationService(IMembershipRepositoryFactory membershipRepositoryFactory)
        {
            _membershipRepositoryFactory = membershipRepositoryFactory;
        }

		public virtual IAuthenticationToken AuthenticateAdmin(string emailAddress, string password)
		{
			throw new System.NotImplementedException();
		}

		public virtual IAuthenticationToken AuthenticateShopOwner(string emailAddress, string password)
		{
			throw new System.NotImplementedException();
		}
	}
}

