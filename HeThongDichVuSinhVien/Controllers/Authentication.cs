using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HeThongDichVuSinhVien.Controllers
{
    public class AuthenticationSinhVien: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("Role") == null || context.HttpContext.Session.GetString("Role") !="SV")
            {
                context.Result = new RedirectToRouteResult(
                     new RouteValueDictionary
                     {
                           {"Controller", "DangNhap" },
                           {"Action", "Index" }
                     }
                    );
            }
            /* var role = context.HttpContext.Session.GetString("Role");

             if (string.IsNullOrEmpty(role))
             {
                 // Nếu không có vai trò, chuyển hướng đến trang đăng nhập
                 context.Result = new RedirectToRouteResult(
                     new RouteValueDictionary
                     {
                     {"Controller", "DangNhap" },
                     {"Action", "Index" }
                     }
                 );
             }
             else
             {
                 // Nếu là Admin, chuyển hướng đến trang Admin, ngược lại chuyển hướng đến trang User
                 if (role.Equals("CTSV", StringComparison.OrdinalIgnoreCase))
                 {
                     context.Result = new RedirectToRouteResult(
                         new RouteValueDictionary
                         {
                         {"Controller", "CTSV" },
                         {"Action", "Index" }
                         }
                     );
                 }
                 else
                 {
                     context.Result = new RedirectToRouteResult(
                         new RouteValueDictionary
                         {
                         {"Controller", "SinhVien" },
                         {"Action", "Index" }
                         }
                     );
                 }
             }*/
        }
    }
}
