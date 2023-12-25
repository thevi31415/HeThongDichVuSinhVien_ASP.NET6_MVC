using HeThongDichVuSinhVien.Data;
using HeThongDichVuSinhVien.Models;
using Microsoft.AspNetCore.Mvc;

namespace HeThongDichVuSinhVien.Controllers
{
    public class SinhVienController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SinhVienController(ApplicationDbContext db)
        {
            _db = db;
        }
        [AuthenticationSinhVien]
        public IActionResult Index()
        {
            // Lọc thông báo theo MaNguoiNhan
            string maNguoiNhan = HttpContext.Session.GetString("MaNguoiDung");
            IEnumerable<ThongBao> thongbaoList = _db.thongbaos.Where(tb => tb.MaNguoiNhan == maNguoiNhan).ToList();
            List<ChiTietThongBao> chitietthongbaolist = new List<ChiTietThongBao>();
            foreach (var thongBao in thongbaoList)
            {
                NguoiDung nguoidung = _db.nguoiDungs.SingleOrDefault(nd => nd.MaNguoiDung == thongBao.MaNguoiGui);

                if (nguoidung != null)
                {
                    var chiTietThongBao = new ChiTietThongBao
                    {
                        Id = thongBao.Id,
                        MaThongBao = thongBao.MaTB,
                        TieuDe = thongBao.TieuDe,
                        NoiDung = thongBao.NoiDung,
                        MaNguoiNhan = thongBao.MaNguoiNhan,
                        MaNguoiGui = thongBao.MaNguoiGui,
                        TenNguoiGui = nguoidung.HoTen,
                        TenNguoiNhan = "CTSV",
                        NgayGui = thongBao.NgayGui
                        // Thêm các thuộc tính khác của ChiTietThongBao tại đây
                    };

                    chitietthongbaolist.Add(chiTietThongBao);
                }
                else
                {
                    // Handle the case where nguoidung is null, e.g., log an error or take appropriate action.
                }
            }


        
            return View(chitietthongbaolist);
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

        public IActionResult XemThongBao(int? id)
        {

             Console.WriteLine("MaTB:" + id);
            // Lọc thông báo theo MaNguoiNhan
            string maNguoiNhan = HttpContext.Session.GetString("MaNguoiDung");
            IEnumerable<ThongBao> thongbaoList = _db.thongbaos.Where(tb => tb.MaNguoiNhan == maNguoiNhan).ToList();
            List<ChiTietThongBao> chitietthongbaolist = new List<ChiTietThongBao>();
            foreach (var thongBao in thongbaoList)
            {
                NguoiDung nguoidung = _db.nguoiDungs.SingleOrDefault(nd => nd.MaNguoiDung == thongBao.MaNguoiGui);

                if (nguoidung != null)
                {
                    var chiTietThongBao = new ChiTietThongBao
                    {
                        Id = thongBao.Id,
                        MaThongBao = thongBao.MaTB,
                        TieuDe = thongBao.TieuDe,
                        NoiDung = thongBao.NoiDung,
                        MaNguoiNhan = thongBao.MaNguoiNhan,
                        MaNguoiGui = thongBao.MaNguoiGui,
                        TenNguoiGui = nguoidung.HoTen,
                        TenNguoiNhan = "CTSV",
                        NgayGui = thongBao.NgayGui
                        // Thêm các thuộc tính khác của ChiTietThongBao tại đây
                    };

                    chitietthongbaolist.Add(chiTietThongBao);
                }
                else
                {
                    // Handle the case where nguoidung is null, e.g., log an error or take appropriate action.
                }
            }

            string noidungthongbao = _db.thongbaos.FirstOrDefault(c => c.Id == id).NoiDung;

            ViewData["NoiDungThongBao"] =noidungthongbao;

            return View(chitietthongbaolist);
        }
    }
}
