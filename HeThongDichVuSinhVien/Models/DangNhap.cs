namespace HeThongDichVuSinhVien.Models
{
    public class DangNhap
    {
        public int ID { get; set; }
        public string MaNguoiDung { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string VaiTro { get; set; }
        public int LuotTruyCap { get; set; }
        public DateTime TruyCapGanNhat { get; set; }

    }
}
