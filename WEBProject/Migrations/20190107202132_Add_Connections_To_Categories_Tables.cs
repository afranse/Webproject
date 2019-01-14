using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WEBProject.Migrations
{
    public partial class Add_Connections_To_Categories_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NormalCategory_Products",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false),
                    ArticleNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NormalCategory_Products", x => new { x.CategoryID, x.ArticleNumber });
                    table.ForeignKey(
                        name: "FK_NormalCategory_Products_Products_ArticleNumber",
                        column: x => x.ArticleNumber,
                        principalTable: "Products",
                        principalColumn: "ArticleNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NormalCategory_Products_Normal_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Normal_Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product_Photos",
                columns: table => new
                {
                    ArticleNumber = table.Column<int>(nullable: false),
                    PhotoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Photos", x => new { x.ArticleNumber, x.PhotoID });
                    table.ForeignKey(
                        name: "FK_Product_Photos_Products_ArticleNumber",
                        column: x => x.ArticleNumber,
                        principalTable: "Products",
                        principalColumn: "ArticleNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Photos_Photos_PhotoID",
                        column: x => x.PhotoID,
                        principalTable: "Photos",
                        principalColumn: "PhotoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product_Texts",
                columns: table => new
                {
                    ArticleNumber = table.Column<int>(nullable: false),
                    TextID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Texts", x => new { x.TextID, x.ArticleNumber });
                    table.ForeignKey(
                        name: "FK_Product_Texts_Products_ArticleNumber",
                        column: x => x.ArticleNumber,
                        principalTable: "Products",
                        principalColumn: "ArticleNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Texts_Text_TextID",
                        column: x => x.TextID,
                        principalTable: "Text",
                        principalColumn: "TextID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    RecipeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.RecipeID);
                });

            migrationBuilder.CreateTable(
                name: "Recipe_Photos",
                columns: table => new
                {
                    RecipeID = table.Column<int>(nullable: false),
                    PhotoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe_Photos", x => new { x.PhotoID, x.RecipeID });
                    table.ForeignKey(
                        name: "FK_Recipe_Photos_Photos_PhotoID",
                        column: x => x.PhotoID,
                        principalTable: "Photos",
                        principalColumn: "PhotoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recipe_Photos_Recipes_RecipeID",
                        column: x => x.RecipeID,
                        principalTable: "Recipes",
                        principalColumn: "RecipeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recipe_Texts",
                columns: table => new
                {
                    RecipeID = table.Column<int>(nullable: false),
                    TextID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe_Texts", x => new { x.RecipeID, x.TextID });
                    table.ForeignKey(
                        name: "FK_Recipe_Texts_Recipes_RecipeID",
                        column: x => x.RecipeID,
                        principalTable: "Recipes",
                        principalColumn: "RecipeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recipe_Texts_Text_TextID",
                        column: x => x.TextID,
                        principalTable: "Text",
                        principalColumn: "TextID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypeCategory_Recipes",
                columns: table => new
                {
                    TypeID = table.Column<int>(nullable: false),
                    RecipeID = table.Column<int>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    Percent = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeCategory_Recipes", x => new { x.RecipeID, x.TypeID });
                    table.ForeignKey(
                        name: "FK_TypeCategory_Recipes_Recipes_RecipeID",
                        column: x => x.RecipeID,
                        principalTable: "Recipes",
                        principalColumn: "RecipeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TypeCategory_Recipes_Type_Categories_TypeID",
                        column: x => x.TypeID,
                        principalTable: "Type_Categories",
                        principalColumn: "TypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NormalCategory_Products_ArticleNumber",
                table: "NormalCategory_Products",
                column: "ArticleNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Photos_PhotoID",
                table: "Product_Photos",
                column: "PhotoID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Texts_ArticleNumber",
                table: "Product_Texts",
                column: "ArticleNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_Photos_RecipeID",
                table: "Recipe_Photos",
                column: "RecipeID");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_Texts_TextID",
                table: "Recipe_Texts",
                column: "TextID");

            migrationBuilder.CreateIndex(
                name: "IX_TypeCategory_Recipes_TypeID",
                table: "TypeCategory_Recipes",
                column: "TypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NormalCategory_Products");

            migrationBuilder.DropTable(
                name: "Product_Photos");

            migrationBuilder.DropTable(
                name: "Product_Texts");

            migrationBuilder.DropTable(
                name: "Recipe_Photos");

            migrationBuilder.DropTable(
                name: "Recipe_Texts");

            migrationBuilder.DropTable(
                name: "TypeCategory_Recipes");

            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
