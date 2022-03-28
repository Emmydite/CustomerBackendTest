using Microsoft.EntityFrameworkCore.Migrations;

namespace Customer.DAL.Migrations
{
    public partial class UpdateCust : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumber_verified",
                table: "Customers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber_verified",
                table: "Customers");
        }
    }
}
