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
        //GET
        public IActionResult TaoThongBao()
        {

            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TaoThongBao(ThongBao thongbao)
        {
         
            thongbao.MaTB = GenerateRandomString("TB", 8);
            thongbao.MaNguoiGui = HttpContext.Session.GetString("MaNguoiDung"); ;
            thongbao.NgayGui = DateTime.Now;
            Console.WriteLine("To thong bao" + thongbao.TieuDe + thongbao.NoiDung);
            Console.WriteLine("Doi tuong" + thongbao.MaTB);
         
                _db.thongbaos.Add(thongbao);
                _db.SaveChanges();
                return RedirectToAction("Index");
        }
        static string GenerateRandomString(string prefix, int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            // Tạo một mảng ký tự ngẫu nhiên có độ dài `length - prefix.Length`
            char[] randomChars = new char[length - prefix.Length];
            for (int i = 0; i < randomChars.Length; i++)
            {
                randomChars[i] = chars[random.Next(chars.Length)];
            }

            // Kết hợp prefix và mảng ký tự ngẫu nhiên để tạo chuỗi hoàn chỉnh
            string randomString = prefix + new string(randomChars);
            return randomString;
        }

    }
}
