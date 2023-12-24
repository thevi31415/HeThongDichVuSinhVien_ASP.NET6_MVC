using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HeThongDichVuSinhVien.Controllers
{
    public class Authentication: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("Role") == null)
            {
                context.Result = new RedirectToRouteResult(
                     new RouteValueDictionary
                     {
                         {"Controller", "DangNhap" },
                         {"Action", "Index" }
                     }
                    );
            }
        }
    }
}
