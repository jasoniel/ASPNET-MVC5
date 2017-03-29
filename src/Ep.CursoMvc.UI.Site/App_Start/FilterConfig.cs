using EP.CursoMvc.Infra.CrossCutting.MvcFilters;
using System.Web.Mvc;

namespace Ep.CursoMvc.UI.Site
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GlobalActionLogger());
        }
    }
}
