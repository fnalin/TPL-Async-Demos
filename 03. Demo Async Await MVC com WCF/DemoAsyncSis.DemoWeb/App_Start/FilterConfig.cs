using System.Web;
using System.Web.Mvc;

namespace DemoAsyncSis.DemoWeb
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new UseStopwatchAttribute());
        }
    }
}
