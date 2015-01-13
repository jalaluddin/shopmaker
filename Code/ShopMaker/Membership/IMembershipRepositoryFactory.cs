namespace ShopMaker.Membership
{
    using ShopMaker.Web;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

	public interface IMembershipRepositoryFactory 
	{
		IMembershipRepository CreateMembershipRepository(UserTypeOptions userType);
	}
}

