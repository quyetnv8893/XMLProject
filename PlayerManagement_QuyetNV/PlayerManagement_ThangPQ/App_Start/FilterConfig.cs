using System.Web;
using System.Web.Mvc;

namespace PlayerManagement_ThangPQ
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
