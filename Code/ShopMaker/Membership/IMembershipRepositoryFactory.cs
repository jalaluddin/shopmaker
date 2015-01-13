using ShopMaker.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopMaker.Membership
{
	public interface IMembershipRepositoryFactory 
	{
		IMembershipRepository CreateMembershipRepository(UserTypeOptions userType);
	}
}

