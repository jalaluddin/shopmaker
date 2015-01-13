namespace ShopMaker.Membership
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public interface IAddress 
	{
		string AddressLine1 { get;set; }

		string AddressLine2 { get;set; }

		string City { get;set; }

		string Country { get;set; }

		string StateOrProvince { get;set; }

		string Zipcode { get;set; }

	}
}

