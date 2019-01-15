using Microsoft.EntityFrameworkCore.Migrations;

namespace WEBProject.Migrations
{
    public partial class LanguageFixConnections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LangID",
                table: "Text",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Text_LangID",
                table: "Text",
                column: "LangID");

            migrationBuilder.AddForeignKey(
                name: "FK_Text_Languages_LangID",
                table: "Text",
                column: "LangID",
                principalTable: "Languages",
                principalColumn: "LangID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Text_Languages_LangID",
                table: "Text");

            migrationBuilder.DropIndex(
                name: "IX_Text_LangID",
                table: "Text");

            migrationBuilder.DropColumn(
                name: "LangID",
                table: "Text");
        }
    }
}
