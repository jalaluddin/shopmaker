namespace ShopMaker.Membership
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public class ShopOwnerRepository : IMembershipRepository
	{
		public virtual void Add(IUserAccount user)
		{
			throw new System.NotImplementedException();
		}

		public virtual void Remove(string EmailAddress)
		{
			throw new System.NotImplementedException();
		}

		public virtual void Edit(IUserAccount user)
		{
			throw new System.NotImplementedException();
		}

		public virtual IUserAccount Get(string emailAddress)
		{
			throw new System.NotImplementedException();
		}

	}
}

