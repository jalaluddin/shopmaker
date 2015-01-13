using System.Web.Mvc;

namespace ShopMaker.Web.Areas.MyAccount
{
    public class MyAccountAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "MyAccount";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "MyAccount_default",
                "MyAccount/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
