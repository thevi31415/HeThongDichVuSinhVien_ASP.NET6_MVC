using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeThongDichVuSinhVien.Migrations
{
    public partial class init343366 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_dangNhaps",
                table: "dangNhaps");

            migrationBuilder.DropColumn(
                name: "MaTaiKhoan",
                table: "dangNhaps");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "dangNhaps",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dangNhaps",
                table: "dangNhaps",
                column: "ID");
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
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "MaTaiKhoan",
                table: "dangNhaps",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dangNhaps",
                table: "dangNhaps",
                columns: new[] { "ID", "MaTaiKhoan" });
        }
    }
}
