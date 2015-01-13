using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopMaker.Web
{
	public interface IShopOwnerRegistrationService 
	{
		void Signup(string emailAddress, string password);

		void VerifySignupEmailAddress(string emailAddress, string verificationCode);

		bool IsEmailAddressAlreadyUsed(string emailAddress);

	}
}

