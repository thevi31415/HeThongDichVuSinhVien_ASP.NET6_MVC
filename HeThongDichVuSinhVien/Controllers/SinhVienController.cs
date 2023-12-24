using Microsoft.AspNetCore.Mvc;

namespace HeThongDichVuSinhVien.Controllers
{
    public class SinhVienController : Controller
    {
        [AuthenticationSinhVien]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ThongTin()
        { 
            
            return View(); 
        

        }
    }
}
