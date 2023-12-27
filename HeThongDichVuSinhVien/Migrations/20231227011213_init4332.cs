using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeThongDichVuSinhVien.Migrations
{
    public partial class init4332 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaTaiKhoan",
                table: "dangNhaps",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaTaiKhoan",
                table: "dangNhaps");
        }
    }
}
