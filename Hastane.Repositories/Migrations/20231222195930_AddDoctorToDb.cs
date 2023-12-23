using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hastane.Repositories.Migrations
{
    public partial class AddDoctorToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDoctors",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDoctors",
                table: "AspNetUsers");
        }
    }
}
