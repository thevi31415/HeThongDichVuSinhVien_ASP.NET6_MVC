using HeThongDichVuSinhVien.Data;
using HeThongDichVuSinhVien.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
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
                    // Cập nhật thời gian truy cập gần nhất và tăng giá trị LuotTruyCap
                    u.TruyCapGanNhat = DateTime.Now;
                    u.LuotTruyCap++;

                    // Lưu thay đổi vào cơ sở dữ liệu
                    _db.SaveChanges();
                    HttpContext.Session.SetString("Role", u.VaiTro.ToString());
                    HttpContext.Session.SetString("MaNguoiDung", u.MaNguoiDung.ToString());
                    HttpContext.Session.SetString("TenDangNhap", u.TenDangNhap.ToString());

                    string MaNguoiDung = HttpContext.Session.GetString("MaNguoiDung");
                    NguoiDung nguoidung = _db.nguoiDungs.SingleOrDefault(nd => nd.MaNguoiDung == MaNguoiDung);

                    // Kiểm tra xem người dùng có tồn tại hay không
                    if (nguoidung == null)
                    {
                        // Xử lý trường hợp người dùng không tồn tại
                        return NotFound(); // hoặc thực hiện xử lý khác tùy thuộc vào yêu cầu của bạn
                    }
                    HttpContext.Session.SetString("TenNguoiDung",nguoidung.HoTen.ToString().Trim());


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
            /*            HttpContext.Session.Clear();
                        HttpContext.Session.Remove("Role");
                        return RedirectToAction("Index", "DangNhap");*/


            // Xóa tất cả thông tin đăng nhập và session
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("Role");

            // Xóa tất cả cookies
            var cookies = Request.Cookies.Keys;
            foreach (var cookie in cookies)
            {
                Response.Cookies.Delete(cookie);
            }

            // Redirect đến trang đăng nhập
            return RedirectToAction("Index", "DangNhap");
        }
    }
}
