using ShopMaker.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMaker.Membership
{
    public class MembershipRepositoryFactory : IMembershipRepositoryFactory
    {
        public IMembershipRepository CreateMembershipRepository(UserTypeOptions userType)
        {
            throw new NotImplementedException();
        }
    }
}
