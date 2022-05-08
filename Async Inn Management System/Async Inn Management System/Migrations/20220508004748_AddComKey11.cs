using Microsoft.EntityFrameworkCore.Migrations;

namespace Async_Inn_Management_System.Migrations
{
    public partial class AddComKey11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "HotelRooms",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ID",
                table: "HotelRooms");
        }
    }
}
