using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WEBProject.Migrations
{
    public partial class Add_Categories_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branch_Categories",
                columns: table => new
                {
                    BranchID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch_Categories", x => x.BranchID);
                });

            migrationBuilder.CreateTable(
                name: "Type_Categories",
                columns: table => new
                {
                    TypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    BranchID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type_Categories", x => x.TypeID);
                    table.ForeignKey(
                        name: "FK_Type_Categories_Branch_Categories_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branch_Categories",
                        principalColumn: "BranchID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Normal_Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    TypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Normal_Categories", x => x.CategoryID);
                    table.ForeignKey(
                        name: "FK_Normal_Categories_Type_Categories_TypeID",
                        column: x => x.TypeID,
                        principalTable: "Type_Categories",
                        principalColumn: "TypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Normal_Categories_TypeID",
                table: "Normal_Categories",
                column: "TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Type_Categories_BranchID",
                table: "Type_Categories",
                column: "BranchID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Normal_Categories");

            migrationBuilder.DropTable(
                name: "Type_Categories");

            migrationBuilder.DropTable(
                name: "Branch_Categories");
        }
    }
}
