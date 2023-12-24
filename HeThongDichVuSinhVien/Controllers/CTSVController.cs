using Microsoft.AspNetCore.Mvc;

namespace HeThongDichVuSinhVien.Controllers
{
    public class CTSVController : Controller
    {
        [Authentication]
        public IActionResult Index()
        {
            return View();
        }
    }
}
