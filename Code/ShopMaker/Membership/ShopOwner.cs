using ShopMaker.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopMaker.Membership
{
	public class ShopOwner : IEntity, IUserAccount
	{
		public virtual IAddress BillingAddress
		{
			get;
			set;
		}

		public virtual IMembershipPackage MembershipPlan
		{
			get;
			set;
		}

		public virtual bool MatchPassword(string plainPassword)
		{
			throw new System.NotImplementedException();
		}

		public virtual void ChangeMembershipPlan(IMembershipPackage newPlan)
		{
			throw new System.NotImplementedException();
		}

        public string EmailAddress
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Password
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string FirstName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string LastName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public DateTime LastLoginDateTime
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string MobileNumber
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int WrongPasswordAttempt
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public DateTime LastWrongPasswordAttemptDateTime
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string IPAddress
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public DateTime AccountCreationDateTime
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public AccountStatusOptions AccountStatus
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Guid ID
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}

