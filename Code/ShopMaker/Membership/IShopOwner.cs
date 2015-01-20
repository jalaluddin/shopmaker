using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMaker.Membership
{
    public interface IShopOwner : IUserAccount
    {
        IAddress BillingAddress { get; set; }

        IMembershipPackage MembershipPlan { get; set; }
    }
}
