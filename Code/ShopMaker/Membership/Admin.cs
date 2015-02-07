using ShopMaker.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopMaker.Membership
{
	public class Admin : IEntity, IUserAccount
	{
		public virtual bool MatchPassword(string plainPassword)
		{
			throw new System.NotImplementedException();
		}

        public string EmailAddress
        {
            get;
            set;
        }

        private string _password;
        public string Password
        {
            set
            {
                _password = value;
            }
        }

        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
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
            get;
            set;
        }

        public int WrongPasswordAttempt
        {
            get;
            set;
        }

        public DateTime LastWrongPasswordAttemptDateTime
        {
            get;
            set;
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
            get;
            set;

        }

        public AccountStatusOptions AccountStatus
        {
            get;
            set;
        }

        public Guid ID
        {
            get;
            set;
        }

        public string EncryptedPassword
        {
            get { throw new NotImplementedException(); }
        }
    }
}


