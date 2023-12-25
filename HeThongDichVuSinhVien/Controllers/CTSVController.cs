using HeThongDichVuSinhVien.Data;
using HeThongDichVuSinhVien.Models;
using Microsoft.AspNetCore.Mvc;

namespace HeThongDichVuSinhVien.Controllers
{
    public class CTSVController : Controller
    {

        private readonly ApplicationDbContext _db;
        public CTSVController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ThongTin()
        {
            string MaNguoiDung = HttpContext.Session.GetString("MaNguoiDung");



            NguoiDung nguoidung = _db.nguoiDungs.SingleOrDefault(nd => nd.MaNguoiDung == MaNguoiDung);

            // Kiểm tra xem người dùng có tồn tại hay không
            if (nguoidung == null)
            {
                // Xử lý trường hợp người dùng không tồn tại
                return NotFound(); // hoặc thực hiện xử lý khác tùy thuộc vào yêu cầu của bạn
            }

            // Truyền thông tin người dùng đến View
            return View(nguoidung);

        }
       
    }
}
