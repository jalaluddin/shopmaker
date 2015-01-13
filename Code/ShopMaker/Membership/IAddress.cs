using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopMaker.Membership
{
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

