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

            int sz = emailAddress.Length;
            if (String.IsNullOrEmpty(emailAddress))
            {
                throw new ArgumentNullException("Email address is empty.");
            }

            else if (String.IsNullOrEmpty(password))
            {
                
                throw new ArgumentNullException("Password is empty.");
            }

            else if ((password.Length) < 6)
            {
                
                throw new ArgumentException("Password is small.");
            }
             else if (emailAddress[sz - 1] != 'm' && emailAddress[sz - 2] != 'o' && emailAddress[sz - 3] != 'c' && emailAddress[sz - 4] != '.')
             {
                 
                 throw new ArgumentException("Invalid email address.");
             }

            else Console.WriteLine("Login Succcessful");
            
		}

		public virtual void VerifySignupEmailAddress(string emailAddress, string verificationCode)
		{
			
		}

		public virtual bool IsEmailAddressAlreadyUsed(string emailAddress)
		{
			throw new System.NotImplementedException();
		}
	}
}

