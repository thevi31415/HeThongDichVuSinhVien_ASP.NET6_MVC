using HeThongDichVuSinhVien.Models;
using Microsoft.EntityFrameworkCore;

namespace HeThongDichVuSinhVien.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {



        }
       public DbSet<DangNhap> dangNhaps { get; set; }
       public DbSet<NguoiDung> nguoiDungs { get; set; }
        public DbSet<ThongBao> thongbaos { get; set; }
    }
}
