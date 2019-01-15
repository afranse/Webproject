﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WEBProject.Data;

namespace WEBProject.Migrations
{
    [DbContext(typeof(WebsiteContext))]
    partial class WebsiteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WEBProject.Models.Branch_Category", b =>
                {
                    b.Property<int>("BranchID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("BranchID");

                    b.ToTable("Branch_Categories");
                });

            modelBuilder.Entity("WEBProject.Models.Employee_Profile", b =>
                {
                    b.Property<int>("Employee_ProfileID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Job");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Employee_ProfileID");

                    b.ToTable("Employee_Profiles");
                });

            modelBuilder.Entity("WEBProject.Models.Employee_Profile_Email", b =>
                {
                    b.Property<string>("Email")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Employee_ProfileID");

                    b.Property<int>("ProfileID");

                    b.HasKey("Email");

                    b.HasIndex("Employee_ProfileID");

                    b.ToTable("Employee_Profile_Emails");
                });

            modelBuilder.Entity("WEBProject.Models.Employee_Profile_Phone_Number", b =>
                {
                    b.Property<string>("Number")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Employee_ProfileID");

                    b.Property<int?>("ProfileID");

                    b.HasKey("Number");

                    b.HasIndex("Employee_ProfileID");

                    b.ToTable("Employee_Profile_Phone_Numbers");
                });

            modelBuilder.Entity("WEBProject.Models.Language", b =>
                {
                    b.Property<int>("LangID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LangTag")
                        .IsRequired()
                        .HasMaxLength(4);

                    b.HasKey("LangID");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("WEBProject.Models.News_Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category");

                    b.HasKey("CategoryID");

                    b.ToTable("News_Categories");
                });

            modelBuilder.Entity("WEBProject.Models.News_Item", b =>
                {
                    b.Property<int>("NewsID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryID");

                    b.Property<DateTime>("Event_Date");

                    b.Property<DateTime>("Last_Modified_Date");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("NewsID");

                    b.HasIndex("CategoryID");

                    b.ToTable("News_Items");
                });

            modelBuilder.Entity("WEBProject.Models.Normal_Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("TypeID");

                    b.HasKey("CategoryID");

                    b.HasIndex("TypeID");

                    b.ToTable("Normal_Categories");
                });

            modelBuilder.Entity("WEBProject.Models.NormalCategory_Product", b =>
                {
                    b.Property<int>("CategoryID");

                    b.Property<int>("ArticleNumber");

                    b.HasKey("CategoryID", "ArticleNumber");

                    b.HasIndex("ArticleNumber");

                    b.ToTable("NormalCategory_Products");
                });

            modelBuilder.Entity("WEBProject.Models.Photo", b =>
                {
                    b.Property<int>("PhotoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PhotoPath");

                    b.HasKey("PhotoID");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("WEBProject.Models.Photo_News", b =>
                {
                    b.Property<int>("NewsID");

                    b.Property<int>("PhotoID");

                    b.HasKey("NewsID", "PhotoID");

                    b.HasIndex("PhotoID");

                    b.ToTable("Photo_News");
                });

            modelBuilder.Entity("WEBProject.Models.Product", b =>
                {
                    b.Property<int>("ArticleNumber")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contents");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ArticleNumber");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WEBProject.Models.Product_Details", b =>
                {
                    b.Property<int>("DetailID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArticleNumber");

                    b.Property<string>("ProductDetails")
                        .IsRequired();

                    b.HasKey("DetailID");

                    b.HasIndex("ArticleNumber");

                    b.ToTable("Product_Details");
                });

            modelBuilder.Entity("WEBProject.Models.Product_Photo", b =>
                {
                    b.Property<int>("ArticleNumber");

                    b.Property<int>("PhotoID");

                    b.HasKey("ArticleNumber", "PhotoID");

                    b.HasIndex("PhotoID");

                    b.ToTable("Product_Photos");
                });

            modelBuilder.Entity("WEBProject.Models.Product_Text", b =>
                {
                    b.Property<int>("TextID");

                    b.Property<int>("ArticleNumber");

                    b.HasKey("TextID", "ArticleNumber");

                    b.HasIndex("ArticleNumber");

                    b.ToTable("Product_Texts");
                });

            modelBuilder.Entity("WEBProject.Models.Recipe", b =>
                {
                    b.Property<int>("RecipeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("RecipeID");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("WEBProject.Models.Recipe_Photo", b =>
                {
                    b.Property<int>("PhotoID");

                    b.Property<int>("RecipeID");

                    b.HasKey("PhotoID", "RecipeID");

                    b.HasIndex("RecipeID");

                    b.ToTable("Recipe_Photos");
                });

            modelBuilder.Entity("WEBProject.Models.Recipe_Text", b =>
                {
                    b.Property<int>("RecipeID");

                    b.Property<int>("TextID");

                    b.HasKey("RecipeID", "TextID");

                    b.HasIndex("TextID");

                    b.ToTable("Recipe_Texts");
                });

            modelBuilder.Entity("WEBProject.Models.Subscriber", b =>
                {
                    b.Property<int>("SubscriberID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.HasKey("SubscriberID");

                    b.ToTable("Subscribers");
                });

            modelBuilder.Entity("WEBProject.Models.Text", b =>
                {
                    b.Property<int>("TextID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<int>("LangID");

                    b.HasKey("TextID");

                    b.HasIndex("LangID");

                    b.ToTable("Text");
                });

            modelBuilder.Entity("WEBProject.Models.Text_News", b =>
                {
                    b.Property<int>("NewsID");

                    b.Property<int>("TextID");

                    b.HasKey("NewsID", "TextID");

                    b.HasIndex("TextID");

                    b.ToTable("Text_News");
                });

            modelBuilder.Entity("WEBProject.Models.Type_Category", b =>
                {
                    b.Property<int>("TypeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BranchID");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("TypeID");

                    b.HasIndex("BranchID");

                    b.ToTable("Type_Categories");
                });

            modelBuilder.Entity("WEBProject.Models.TypeCategory_Recipe", b =>
                {
                    b.Property<int>("RecipeID");

                    b.Property<int>("TypeID");

                    b.Property<int>("Percent");

                    b.Property<double>("Weight");

                    b.HasKey("RecipeID", "TypeID");

                    b.HasIndex("TypeID");

                    b.ToTable("TypeCategory_Recipes");
                });

            modelBuilder.Entity("WEBProject.Models.Employee_Profile_Email", b =>
                {
                    b.HasOne("WEBProject.Models.Employee_Profile", "Employee")
                        .WithMany("Emails")
                        .HasForeignKey("Employee_ProfileID");
                });

            modelBuilder.Entity("WEBProject.Models.Employee_Profile_Phone_Number", b =>
                {
                    b.HasOne("WEBProject.Models.Employee_Profile", "Employee")
                        .WithMany("Phone_Numbers")
                        .HasForeignKey("Employee_ProfileID");
                });

            modelBuilder.Entity("WEBProject.Models.News_Item", b =>
                {
                    b.HasOne("WEBProject.Models.News_Category", "News_Category")
                        .WithMany("Items")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WEBProject.Models.Normal_Category", b =>
                {
                    b.HasOne("WEBProject.Models.Type_Category", "TypeCategory")
                        .WithMany("NormalCategory")
                        .HasForeignKey("TypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WEBProject.Models.NormalCategory_Product", b =>
                {
                    b.HasOne("WEBProject.Models.Product", "Product")
                        .WithMany("NormalCategory")
                        .HasForeignKey("ArticleNumber")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WEBProject.Models.Normal_Category", "Normal_Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WEBProject.Models.Photo_News", b =>
                {
                    b.HasOne("WEBProject.Models.News_Item", "News")
                        .WithMany("PhotoNews")
                        .HasForeignKey("NewsID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WEBProject.Models.Photo", "Photo")
                        .WithMany("PhotoNews")
                        .HasForeignKey("PhotoID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WEBProject.Models.Product_Details", b =>
                {
                    b.HasOne("WEBProject.Models.Product", "Product")
                        .WithMany("Details")
                        .HasForeignKey("ArticleNumber")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WEBProject.Models.Product_Photo", b =>
                {
                    b.HasOne("WEBProject.Models.Product", "Product")
                        .WithMany("ProductPhoto")
                        .HasForeignKey("ArticleNumber")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WEBProject.Models.Photo", "Photo")
                        .WithMany("PhotoProducts")
                        .HasForeignKey("PhotoID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WEBProject.Models.Product_Text", b =>
                {
                    b.HasOne("WEBProject.Models.Product", "Product")
                        .WithMany("ProductText")
                        .HasForeignKey("ArticleNumber")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WEBProject.Models.Text", "Text")
                        .WithMany("TextProducts")
                        .HasForeignKey("TextID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WEBProject.Models.Recipe_Photo", b =>
                {
                    b.HasOne("WEBProject.Models.Photo", "Photo")
                        .WithMany("PhotoRecipes")
                        .HasForeignKey("PhotoID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WEBProject.Models.Recipe", "Recipe")
                        .WithMany("RecipePhotos")
                        .HasForeignKey("RecipeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WEBProject.Models.Recipe_Text", b =>
                {
                    b.HasOne("WEBProject.Models.Recipe", "Recipe")
                        .WithMany("RecipeTexts")
                        .HasForeignKey("RecipeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WEBProject.Models.Text", "Text")
                        .WithMany("TextRecipes")
                        .HasForeignKey("TextID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WEBProject.Models.Text", b =>
                {
                    b.HasOne("WEBProject.Models.Language", "Language")
                        .WithMany("Texts")
                        .HasForeignKey("LangID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WEBProject.Models.Text_News", b =>
                {
                    b.HasOne("WEBProject.Models.News_Item", "News")
                        .WithMany("TextNews")
                        .HasForeignKey("NewsID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WEBProject.Models.Text", "Text")
                        .WithMany("TextNews")
                        .HasForeignKey("TextID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WEBProject.Models.Type_Category", b =>
                {
                    b.HasOne("WEBProject.Models.Branch_Category", "BranchCategory")
                        .WithMany("TypeCategory")
                        .HasForeignKey("BranchID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WEBProject.Models.TypeCategory_Recipe", b =>
                {
                    b.HasOne("WEBProject.Models.Recipe", "Recipe")
                        .WithMany("TypeCategories")
                        .HasForeignKey("RecipeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WEBProject.Models.Type_Category", "Type_Category")
                        .WithMany("Recipes")
                        .HasForeignKey("TypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
