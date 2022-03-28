using Microsoft.EntityFrameworkCore.Migrations;

namespace Customer.DAL.Migrations
{
    public partial class UpdatePass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasssWord",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "PassWord",
                table: "Customers",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassWord",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "PasssWord",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
