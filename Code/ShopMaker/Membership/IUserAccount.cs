using ShopMaker.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopMaker.Membership
{
	public interface IUserAccount : IEntity
	{
		string EmailAddress { get;set; }

		string Password { set; }

        string EncryptedPassword { get; }

		string FirstName { get;set; }

		string LastName { get;set; }

		DateTime LastLoginDateTime { get;set; }

		string MobileNumber { get;set; }

		int WrongPasswordAttempt { get;set; }

		DateTime LastWrongPasswordAttemptDateTime { get;set; }

		string IPAddress { get;set; }

        DateTime AccountCreationDateTime { get; set; }

		AccountStatusOptions AccountStatus { get;set; }

		bool MatchPassword(string plainPassword);
	}
}

