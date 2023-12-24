using Microsoft.AspNetCore.Mvc;

namespace HeThongDichVuSinhVien.Controllers
{
    public class SinhVienController : Controller
    {
        [Authentication]
        public IActionResult Index()
        {
            return View();
        }
    }
}
