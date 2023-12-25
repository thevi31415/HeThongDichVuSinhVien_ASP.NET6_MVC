namespace HeThongDichVuSinhVien.Models
{
    public class ChiTietThongBao
    {

        public int Id { get; set; }
        public string MaThongBao { get; set; }
        public string TieuDe {  get; set; }
        public string NoiDung { get; set; }
        public string MaNguoiGui { get; set; }  
        public string MaNguoiNhan { get; set; }

        public string TenNguoiGui { get; set; }

        public string TenNguoiNhan { get; set; }    

        public DateTime NgayGui { get; set; }   
    }
}
