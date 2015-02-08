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
            get { return this._password; }
            set
            {
                this._password = value;

                if (this._password == string.Empty)
                {
                    throw new ArgumentException("Empty  Field!");
                }
                else if (this._password == null)
                {
                    throw new ArgumentException("Null  Field!");
                }
                   else if (this._password.Length <= 5)
                   {
                       throw new ArgumentException("Too short Password field");
                   }
                   Console.WriteLine("Valid Password");
            }
        }
        private string _firstname;
        public string FirstName
        {
            get
            {
                return this._firstname;
            }
            set
               {
                   this._firstname = value;
                  
                   
                   if (this._firstname == string.Empty)
                   {
                       throw new ArgumentException("Empty  Field!");
                   }
                   else if (this._firstname == null)
                   {
                       throw new ArgumentException("Null  Field!");
                   }
                   else if (this._firstname.Length <= 2)
                   {
                       throw new ArgumentException("Too short Name field");
                   }
                   Console.WriteLine("Valid Name");
                   
               }
        }
        private string _lastname;
        public string LastName
        {
            get { return this._lastname; }
            set
            {
                this._lastname = value;

                if (this._lastname == string.Empty)
                {
                    throw new ArgumentException("Empty  Field!");
                }
                else if (this._lastname == null)
                {
                    throw new ArgumentException("Null  Field!");
                }
                else if (this._lastname.Length <= 2)
                {
                    throw new ArgumentException("Too short Name field");
                }
                Console.WriteLine("Valid Name");
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
        private string _mobilenumber;
        public string MobileNumber
        {
            get { return this._mobilenumber; }
            set
            {
                this._mobilenumber = value;

                if (this._mobilenumber == string.Empty)
                {
                    throw new ArgumentException("Empty  Field!");
                }
                else if (this._mobilenumber == null)
                {
                    throw new ArgumentException("Null  Field!");
                }
                else if (this._mobilenumber.Length <= 10)
                {
                    throw new ArgumentException("Invalid Mobile Number");
                }
                Console.WriteLine("Valid Mobile Number");
            }
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


