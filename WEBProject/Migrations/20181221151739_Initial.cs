using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WEBProject.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee_Profiles",
                columns: table => new
                {
                    Employee_ProfileID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Job = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee_Profiles", x => x.Employee_ProfileID);
                });

            migrationBuilder.CreateTable(
                name: "News_Category",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Category = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News_Category", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    PhotoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PhotoPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.PhotoID);
                });

            migrationBuilder.CreateTable(
                name: "Subscribers",
                columns: table => new
                {
                    SubscriberID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribers", x => x.SubscriberID);
                });

            migrationBuilder.CreateTable(
                name: "Text",
                columns: table => new
                {
                    TextID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Text", x => x.TextID);
                });

            migrationBuilder.CreateTable(
                name: "Employee_Profile_Email",
                columns: table => new
                {
                    Email = table.Column<string>(nullable: false),
                    ProfileID = table.Column<int>(nullable: false),
                    Employee_ProfileID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee_Profile_Email", x => x.Email);
                    table.ForeignKey(
                        name: "FK_Employee_Profile_Email_Employee_Profiles_Employee_ProfileID",
                        column: x => x.Employee_ProfileID,
                        principalTable: "Employee_Profiles",
                        principalColumn: "Employee_ProfileID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee_Profile_Phone_Number",
                columns: table => new
                {
                    Number = table.Column<string>(nullable: false),
                    ProfileID = table.Column<int>(nullable: true),
                    Employee_ProfileID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee_Profile_Phone_Number", x => x.Number);
                    table.ForeignKey(
                        name: "FK_Employee_Profile_Phone_Number_Employee_Profiles_Employee_ProfileID",
                        column: x => x.Employee_ProfileID,
                        principalTable: "Employee_Profiles",
                        principalColumn: "Employee_ProfileID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "News_Item",
                columns: table => new
                {
                    NewsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Event_Date = table.Column<DateTime>(nullable: false),
                    Last_Modified_Date = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News_Item", x => x.NewsID);
                    table.ForeignKey(
                        name: "FK_News_Item_News_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "News_Category",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photo_News",
                columns: table => new
                {
                    NewsID = table.Column<int>(nullable: false),
                    PhotoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo_News", x => new { x.NewsID, x.PhotoID });
                    table.ForeignKey(
                        name: "FK_Photo_News_News_Item_NewsID",
                        column: x => x.NewsID,
                        principalTable: "News_Item",
                        principalColumn: "NewsID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Photo_News_Photo_PhotoID",
                        column: x => x.PhotoID,
                        principalTable: "Photo",
                        principalColumn: "PhotoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Text_News",
                columns: table => new
                {
                    NewsID = table.Column<int>(nullable: false),
                    TextID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Text_News", x => new { x.NewsID, x.TextID });
                    table.ForeignKey(
                        name: "FK_Text_News_News_Item_NewsID",
                        column: x => x.NewsID,
                        principalTable: "News_Item",
                        principalColumn: "NewsID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Text_News_Text_TextID",
                        column: x => x.TextID,
                        principalTable: "Text",
                        principalColumn: "TextID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Profile_Email_Employee_ProfileID",
                table: "Employee_Profile_Email",
                column: "Employee_ProfileID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Profile_Phone_Number_Employee_ProfileID",
                table: "Employee_Profile_Phone_Number",
                column: "Employee_ProfileID");

            migrationBuilder.CreateIndex(
                name: "IX_News_Item_CategoryID",
                table: "News_Item",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_News_PhotoID",
                table: "Photo_News",
                column: "PhotoID");

            migrationBuilder.CreateIndex(
                name: "IX_Text_News_TextID",
                table: "Text_News",
                column: "TextID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee_Profile_Email");

            migrationBuilder.DropTable(
                name: "Employee_Profile_Phone_Number");

            migrationBuilder.DropTable(
                name: "Photo_News");

            migrationBuilder.DropTable(
                name: "Subscribers");

            migrationBuilder.DropTable(
                name: "Text_News");

            migrationBuilder.DropTable(
                name: "Employee_Profiles");

            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropTable(
                name: "News_Item");

            migrationBuilder.DropTable(
                name: "Text");

            migrationBuilder.DropTable(
                name: "News_Category");
        }
    }
}
