﻿using HeThongDichVuSinhVien.Data;
using HeThongDichVuSinhVien.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using X.PagedList;

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
            //Thong bao da gui

            IEnumerable<ThongBao> thongbaoListdagui = _db.thongbaos.Where(tb => tb.MaNguoiGui== maNguoiNhan).ToList();
            List<ChiTietThongBao> chitietthongbaolistdagui = new List<ChiTietThongBao>();
            foreach (var thongBao in thongbaoListdagui)
            {
                NguoiDung nguoidung = _db.nguoiDungs.SingleOrDefault(nd => nd.MaNguoiDung == thongBao.MaNguoiNhan);

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

                    chitietthongbaolistdagui.Add(chiTietThongBao);
                }
                else
                {
                    // Handle the case where nguoidung is null, e.g., log an error or take appropriate action.
                }
            }


            ViewData["ThongBaoDaGui"] = chitietthongbaolistdagui;
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
            Console.WriteLine("To thong bao: " + thongbao.TieuDe + " Nôi dung: " + thongbao.NoiDung);
            Console.WriteLine("Doi tuong" + thongbao.MaTB);
         
                _db.thongbaos.Add(thongbao);
                _db.SaveChanges();
                return RedirectToAction("Index");
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
            //Thong bao da gui

            IEnumerable<ThongBao> thongbaoListdagui = _db.thongbaos.Where(tb => tb.MaNguoiGui == maNguoiNhan).ToList();
            List<ChiTietThongBao> chitietthongbaolistdagui = new List<ChiTietThongBao>();
            foreach (var thongBao in thongbaoListdagui)
            {
                NguoiDung nguoidung = _db.nguoiDungs.SingleOrDefault(nd => nd.MaNguoiDung == thongBao.MaNguoiNhan);

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

                    chitietthongbaolistdagui.Add(chiTietThongBao);
                }
                else
                {
                    // Handle the case where nguoidung is null, e.g., log an error or take appropriate action.
                }
            }


            ViewData["ThongBaoDaGui"] = chitietthongbaolistdagui;
            string noidungthongbao = _db.thongbaos.FirstOrDefault(c => c.Id == id).NoiDung;

            ViewData["NoiDungThongBao"] = noidungthongbao;

            return View(chitietthongbaolist);
        }
        public IActionResult XoaThongBaoDaGui()
        {
            string maNguoigui = HttpContext.Session.GetString("MaNguoiDung");
            // Lấy danh sách các thongbao cần xóa theo MaNguoiGui
            var thongBaoToDelete = _db.thongbaos.Where(tb => tb.MaNguoiGui == maNguoigui).ToList();

            // Kiểm tra xem có thongbao cần xóa không
            if (thongBaoToDelete.Count > 0)
            {
                // Xóa thongbao từ DbSet
                _db.thongbaos.RemoveRange(thongBaoToDelete);

                // Lưu thay đổi vào database
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        public IActionResult QuanLyTaiKhoan(int? page, string searchString, string searchBy)
        {
            /* int pageSize = 10;
             int pageNumber = page==null || page<0?1:page.Value;

             IEnumerable<DangNhap> dangnhaplist = _db.dangNhaps;



             var listdangnhap = _db.dangNhaps.AsNoTracking().OrderBy(x => x.MaNguoiDung);
              PagedList<DangNhap> lst = new PagedList<DangNhap>(dangnhaplist, pageNumber, pageSize);


             return View(lst);
 */
            int pageSize = 10;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;

            IQueryable<DangNhap> dangnhaplist = _db.dangNhaps;

            if (!string.IsNullOrEmpty(searchString))
            {
                if ("TenDangNhap".Equals(searchBy, StringComparison.OrdinalIgnoreCase))
                {
                    dangnhaplist = dangnhaplist.Where(x => x.TenDangNhap.Contains(searchString));
                }
                else if ("MaNguoiDung".Equals(searchBy, StringComparison.OrdinalIgnoreCase))
                {
                    dangnhaplist = dangnhaplist.Where(x => x.MaNguoiDung.Contains(searchString));
                }
            }

            var listdangnhap = dangnhaplist.AsNoTracking().OrderBy(x => x.MaNguoiDung);
            PagedList<DangNhap> lst = new PagedList<DangNhap>(listdangnhap, pageNumber, pageSize);

            ViewData["CurrentFilter"] = searchString;
            ViewData["SearchBy"] = searchBy;

            return View(lst);
        }
        public IActionResult XoaTaiKhoan(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _db.dangNhaps.FirstOrDefault(c => c.ID == id);
            if (category == null)
            {
                return NotFound();
            }

            _db.dangNhaps.Remove(category);
            _db.SaveChanges();
            Console.WriteLine("Xoa tài khoan" + id.ToString());
            TempData["DeleteSuccess"] = "Tài khoản đã được xóa thành công.";
            return RedirectToAction("QuanLyTaiKhoan");
        }

        public IActionResult ThemTaiKhoan()
        {
            // Lấy danh sách người dùng chưa có tài khoản
            List<NguoiDung> usersWithoutAccount = _db.nguoiDungs
                .Where(u => !_db.dangNhaps.Any(d => d.MaNguoiDung == u.MaNguoiDung))
                .ToList();
            if(usersWithoutAccount.Count == 0)
            {
                Console.WriteLine("Khong tim thay nguoi nao 0");
            }
            else
            {
                ViewData["UsersWithoutAccount"] = usersWithoutAccount;
            }

            return View();
        }

        [HttpPost]
    
        public IActionResult ThemTaiKhoan(DangNhap taikhoan)
        {

        
            if (ModelState.IsValid)
            {
                taikhoan.TenDangNhap = taikhoan.TenDangNhap.Trim();
                taikhoan.MatKhau = taikhoan.MatKhau.Trim();
                taikhoan.MaNguoiDung = taikhoan.MaNguoiDung.Trim();
                taikhoan.VaiTro = taikhoan.VaiTro.Trim();
                _db.dangNhaps.Add(taikhoan);
                _db.SaveChanges();
                TempData["DeleteSuccess"] = "Thêm tài khoản thành công !";
                return RedirectToAction("QuanLyTaiKhoan");

            }
            return View();
        }

        //Chinh sua tai khoan

        public IActionResult ChinhSuaTaiKhoan(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var taikhoan = _db.dangNhaps.FirstOrDefault(c => c.ID == id);
            if (taikhoan == null)
            {
                return NotFound();
            }

            return View(taikhoan);
        }
        //POST
        [HttpPost]
        public IActionResult ChinhSuaTaiKhoan(DangNhap obj)
        {

            Console.WriteLine("id: " + obj.ID);

            if (ModelState.IsValid)
            {

                // Tìm đối tượng cần cập nhật trong cơ sở dữ liệu
                DangNhap taiKhoan = _db.dangNhaps.SingleOrDefault(nd => nd.ID == obj.ID); ;

                if (taiKhoan == null)
                {
                    // Trả về NotFound nếu không tìm thấy đối tượng
                    return NotFound();
                }

                // Cập nhật thông tin đối tượng
                taiKhoan.TenDangNhap = obj.TenDangNhap.Trim();
                taiKhoan.MatKhau = obj.MatKhau.Trim();
                taiKhoan.VaiTro = obj.VaiTro.Trim();

                // Lưu thay đổi vào cơ sở dữ liệu
                _db.SaveChanges();

                return RedirectToAction("QuanLyTaiKhoan");// Chuyển hướng đến trang Index hoặc trang khác


            }
            // Trả về View với model nếu ModelState không hợp lệ
            return View(obj);
         
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
