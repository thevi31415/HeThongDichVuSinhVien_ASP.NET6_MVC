using HeThongDichVuSinhVien.Data;
using HeThongDichVuSinhVien.Models;
using Microsoft.AspNetCore.Mvc;

namespace HeThongDichVuSinhVien.Controllers
{
    public class DangNhapController : Controller
    {
        private readonly ApplicationDbContext _db;
        public DangNhapController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(DangNhap dangnhap)
        {
            return View();
        }
    }
}
