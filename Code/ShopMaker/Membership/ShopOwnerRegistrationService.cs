using ShopMaker.DAL;
using ShopMaker.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopMaker.Membership
{
	public class ShopOwnerRegistrationService : IShopOwnerRegistrationService
	{
        private IMembershipRepositoryFactory _membershipRepositoryFactory;

        public ShopOwnerRegistrationService(IMembershipRepositoryFactory membershipRepositoryFactory)
        {
            _membershipRepositoryFactory = membershipRepositoryFactory;
        }

		public virtual void Signup(string emailAddress, string password)
		{
            throw new System.NotImplementedException();
		}

		public virtual void VerifySignupEmailAddress(string emailAddress, string verificationCode)
		{
			throw new System.NotImplementedException();
		}

		public virtual bool IsEmailAddressAlreadyUsed(string emailAddress)
		{
			throw new System.NotImplementedException();
		}
	}
}

