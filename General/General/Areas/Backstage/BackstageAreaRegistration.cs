using System.Web.Mvc;

namespace General.Areas.Backstage
{
    public class BackstageAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Backstage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Backstage_default",
                "Backstage/{controller}/{action}/{id}",
                new { controller = "home", action = "index", id = UrlParameter.Optional },
                namespaces: new string[] { "General.Areas.Backstage.Controllers" }
            );
        }
    }
}
