using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HeThongDichVuSinhVien.Models
{
    public class ThongBao
    {
        public int Id { get; set; }
       
        public string MaTB { get; set; }

        public string MaNguoiGui { get; set; }
        public string MaNguoiNhan { get; set; }

        public string TieuDe { get; set; }

        public string NoiDung { get; set; }

        public DateTime NgayGui { get; set; }

    }
}
