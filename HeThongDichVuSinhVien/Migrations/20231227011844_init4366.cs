using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeThongDichVuSinhVien.Migrations
{
    public partial class init4366 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_dangNhaps",
                table: "dangNhaps");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dangNhaps",
                table: "dangNhaps",
                columns: new[] { "ID", "MaTaiKhoan" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_dangNhaps",
                table: "dangNhaps");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dangNhaps",
                table: "dangNhaps",
                column: "MaTaiKhoan");
        }
    }
}
