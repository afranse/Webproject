using Microsoft.EntityFrameworkCore.Migrations;

namespace WEBProject.Migrations
{
    public partial class Add_Region_and_Country_or_province_strings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CountryOrProvince",
                table: "Employee_Profiles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "Employee_Profiles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryOrProvince",
                table: "Employee_Profiles");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "Employee_Profiles");
        }
    }
}
