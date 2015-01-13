namespace ShopMaker.Membership
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public interface IMembershipRepository 
	{
		void Add(IUserAccount user);

		void Remove(string emailAddress);

		void Edit(IUserAccount user);

		IUserAccount Get(string emailAddress);

	}
}

