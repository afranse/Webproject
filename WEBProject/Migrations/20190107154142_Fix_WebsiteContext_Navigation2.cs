using Microsoft.EntityFrameworkCore.Migrations;

namespace WEBProject.Migrations
{
    public partial class Fix_WebsiteContext_Navigation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Details_Products_ArtikelNumber",
                table: "Product_Details");

            migrationBuilder.RenameColumn(
                name: "ArtikelNumber",
                table: "Products",
                newName: "ArticleNumber");

            migrationBuilder.RenameColumn(
                name: "ArtikelNumber",
                table: "Product_Details",
                newName: "ArticleNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Product_Details_ArtikelNumber",
                table: "Product_Details",
                newName: "IX_Product_Details_ArticleNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Details_Products_ArticleNumber",
                table: "Product_Details",
                column: "ArticleNumber",
                principalTable: "Products",
                principalColumn: "ArticleNumber",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Details_Products_ArticleNumber",
                table: "Product_Details");

            migrationBuilder.RenameColumn(
                name: "ArticleNumber",
                table: "Products",
                newName: "ArtikelNumber");

            migrationBuilder.RenameColumn(
                name: "ArticleNumber",
                table: "Product_Details",
                newName: "ArtikelNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Product_Details_ArticleNumber",
                table: "Product_Details",
                newName: "IX_Product_Details_ArtikelNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Details_Products_ArtikelNumber",
                table: "Product_Details",
                column: "ArtikelNumber",
                principalTable: "Products",
                principalColumn: "ArtikelNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
