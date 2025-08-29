using System.Web;
using System.Web.Mvc;

namespace ASP.NET_WebForm_Dapper_VB.NET_C_
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
