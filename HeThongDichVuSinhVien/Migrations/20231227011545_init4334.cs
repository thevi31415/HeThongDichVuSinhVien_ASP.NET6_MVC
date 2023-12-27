using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeThongDichVuSinhVien.Migrations
{
    public partial class init4334 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_dangNhaps",
                table: "dangNhaps");

            migrationBuilder.AlterColumn<string>(
                name: "MaTaiKhoan",
                table: "dangNhaps",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "dangNhaps",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dangNhaps",
                table: "dangNhaps",
                column: "MaTaiKhoan");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_dangNhaps",
                table: "dangNhaps");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "dangNhaps",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "MaTaiKhoan",
                table: "dangNhaps",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dangNhaps",
                table: "dangNhaps",
                column: "ID");
        }
    }
}
