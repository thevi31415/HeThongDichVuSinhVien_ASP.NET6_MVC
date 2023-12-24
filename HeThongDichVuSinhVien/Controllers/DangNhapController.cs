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
            Console.Out.WriteLine("Ten: " + dangnhap.TenDangNhap);
            if (dangnhap != null)
            {
                var u = _db.dangNhaps.Where(x => x.TenDangNhap.Equals(dangnhap.TenDangNhap.ToString().Trim()) && x.MatKhau.Equals(dangnhap.MatKhau.ToString().Trim())).FirstOrDefault();

                if (u != null)
                {

                    HttpContext.Session.SetString("Role", u.VaiTro.ToString());
                    if (u.VaiTro.Equals("SV"))
                    {
                        return RedirectToAction("Index", "SinhVien");
                    }
                    else
                    {
                        return RedirectToAction("Index", "CTSV");
                    }
                 
                }
            }
            else
            {
                Console.WriteLine("La null");
            }
           
            return View();

        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("Role");
            return RedirectToAction("Index", "DangNhap");
        }
    }
}
