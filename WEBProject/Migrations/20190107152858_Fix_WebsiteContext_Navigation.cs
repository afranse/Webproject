using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WEBProject.Migrations
{
    public partial class Fix_WebsiteContext_Navigation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Profile_Email_Employee_Profiles_Employee_ProfileID",
                table: "Employee_Profile_Email");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Profile_Phone_Number_Employee_Profiles_Employee_ProfileID",
                table: "Employee_Profile_Phone_Number");

            migrationBuilder.DropForeignKey(
                name: "FK_News_Item_News_Category_CategoryID",
                table: "News_Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Photo_News_News_Item_NewsID",
                table: "Photo_News");

            migrationBuilder.DropForeignKey(
                name: "FK_Photo_News_Photo_PhotoID",
                table: "Photo_News");

            migrationBuilder.DropForeignKey(
                name: "FK_Text_News_News_Item_NewsID",
                table: "Text_News");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Photo",
                table: "Photo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_News_Item",
                table: "News_Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_News_Category",
                table: "News_Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee_Profile_Phone_Number",
                table: "Employee_Profile_Phone_Number");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee_Profile_Email",
                table: "Employee_Profile_Email");

            migrationBuilder.RenameTable(
                name: "Photo",
                newName: "Photos");

            migrationBuilder.RenameTable(
                name: "News_Item",
                newName: "News_Items");

            migrationBuilder.RenameTable(
                name: "News_Category",
                newName: "News_Categories");

            migrationBuilder.RenameTable(
                name: "Employee_Profile_Phone_Number",
                newName: "Employee_Profile_Phone_Numbers");

            migrationBuilder.RenameTable(
                name: "Employee_Profile_Email",
                newName: "Employee_Profile_Emails");

            migrationBuilder.RenameIndex(
                name: "IX_News_Item_CategoryID",
                table: "News_Items",
                newName: "IX_News_Items_CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_Profile_Phone_Number_Employee_ProfileID",
                table: "Employee_Profile_Phone_Numbers",
                newName: "IX_Employee_Profile_Phone_Numbers_Employee_ProfileID");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_Profile_Email_Employee_ProfileID",
                table: "Employee_Profile_Emails",
                newName: "IX_Employee_Profile_Emails_Employee_ProfileID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Photos",
                table: "Photos",
                column: "PhotoID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_News_Items",
                table: "News_Items",
                column: "NewsID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_News_Categories",
                table: "News_Categories",
                column: "CategoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee_Profile_Phone_Numbers",
                table: "Employee_Profile_Phone_Numbers",
                column: "Number");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee_Profile_Emails",
                table: "Employee_Profile_Emails",
                column: "Email");

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    LangID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LangTag = table.Column<string>(maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.LangID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ArtikelNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Contents = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ArtikelNumber);
                });

            migrationBuilder.CreateTable(
                name: "Product_Details",
                columns: table => new
                {
                    DetailID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductDetails = table.Column<string>(nullable: false),
                    ArtikelNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Details", x => x.DetailID);
                    table.ForeignKey(
                        name: "FK_Product_Details_Products_ArtikelNumber",
                        column: x => x.ArtikelNumber,
                        principalTable: "Products",
                        principalColumn: "ArtikelNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_Details_ArtikelNumber",
                table: "Product_Details",
                column: "ArtikelNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Profile_Emails_Employee_Profiles_Employee_ProfileID",
                table: "Employee_Profile_Emails",
                column: "Employee_ProfileID",
                principalTable: "Employee_Profiles",
                principalColumn: "Employee_ProfileID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Profile_Phone_Numbers_Employee_Profiles_Employee_ProfileID",
                table: "Employee_Profile_Phone_Numbers",
                column: "Employee_ProfileID",
                principalTable: "Employee_Profiles",
                principalColumn: "Employee_ProfileID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_News_Items_News_Categories_CategoryID",
                table: "News_Items",
                column: "CategoryID",
                principalTable: "News_Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_News_News_Items_NewsID",
                table: "Photo_News",
                column: "NewsID",
                principalTable: "News_Items",
                principalColumn: "NewsID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_News_Photos_PhotoID",
                table: "Photo_News",
                column: "PhotoID",
                principalTable: "Photos",
                principalColumn: "PhotoID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Text_News_News_Items_NewsID",
                table: "Text_News",
                column: "NewsID",
                principalTable: "News_Items",
                principalColumn: "NewsID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Profile_Emails_Employee_Profiles_Employee_ProfileID",
                table: "Employee_Profile_Emails");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Profile_Phone_Numbers_Employee_Profiles_Employee_ProfileID",
                table: "Employee_Profile_Phone_Numbers");

            migrationBuilder.DropForeignKey(
                name: "FK_News_Items_News_Categories_CategoryID",
                table: "News_Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Photo_News_News_Items_NewsID",
                table: "Photo_News");

            migrationBuilder.DropForeignKey(
                name: "FK_Photo_News_Photos_PhotoID",
                table: "Photo_News");

            migrationBuilder.DropForeignKey(
                name: "FK_Text_News_News_Items_NewsID",
                table: "Text_News");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Product_Details");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Photos",
                table: "Photos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_News_Items",
                table: "News_Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_News_Categories",
                table: "News_Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee_Profile_Phone_Numbers",
                table: "Employee_Profile_Phone_Numbers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee_Profile_Emails",
                table: "Employee_Profile_Emails");

            migrationBuilder.RenameTable(
                name: "Photos",
                newName: "Photo");

            migrationBuilder.RenameTable(
                name: "News_Items",
                newName: "News_Item");

            migrationBuilder.RenameTable(
                name: "News_Categories",
                newName: "News_Category");

            migrationBuilder.RenameTable(
                name: "Employee_Profile_Phone_Numbers",
                newName: "Employee_Profile_Phone_Number");

            migrationBuilder.RenameTable(
                name: "Employee_Profile_Emails",
                newName: "Employee_Profile_Email");

            migrationBuilder.RenameIndex(
                name: "IX_News_Items_CategoryID",
                table: "News_Item",
                newName: "IX_News_Item_CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_Profile_Phone_Numbers_Employee_ProfileID",
                table: "Employee_Profile_Phone_Number",
                newName: "IX_Employee_Profile_Phone_Number_Employee_ProfileID");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_Profile_Emails_Employee_ProfileID",
                table: "Employee_Profile_Email",
                newName: "IX_Employee_Profile_Email_Employee_ProfileID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Photo",
                table: "Photo",
                column: "PhotoID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_News_Item",
                table: "News_Item",
                column: "NewsID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_News_Category",
                table: "News_Category",
                column: "CategoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee_Profile_Phone_Number",
                table: "Employee_Profile_Phone_Number",
                column: "Number");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee_Profile_Email",
                table: "Employee_Profile_Email",
                column: "Email");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Profile_Email_Employee_Profiles_Employee_ProfileID",
                table: "Employee_Profile_Email",
                column: "Employee_ProfileID",
                principalTable: "Employee_Profiles",
                principalColumn: "Employee_ProfileID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Profile_Phone_Number_Employee_Profiles_Employee_ProfileID",
                table: "Employee_Profile_Phone_Number",
                column: "Employee_ProfileID",
                principalTable: "Employee_Profiles",
                principalColumn: "Employee_ProfileID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_News_Item_News_Category_CategoryID",
                table: "News_Item",
                column: "CategoryID",
                principalTable: "News_Category",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_News_News_Item_NewsID",
                table: "Photo_News",
                column: "NewsID",
                principalTable: "News_Item",
                principalColumn: "NewsID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_News_Photo_PhotoID",
                table: "Photo_News",
                column: "PhotoID",
                principalTable: "Photo",
                principalColumn: "PhotoID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Text_News_News_Item_NewsID",
                table: "Text_News",
                column: "NewsID",
                principalTable: "News_Item",
                principalColumn: "NewsID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
