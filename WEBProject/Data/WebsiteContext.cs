using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WEBProject.Models;

namespace WEBProject.Data
{
    public class WebsiteContext : DbContext
    {
        public DbSet<Models.Branch_Category> Branch_Categories { get; set; }
        public DbSet<Models.Employee_Profile> Employee_Profiles { get; set; }
        public DbSet<Models.Employee_Profile_Email> Employee_Profile_Emails { get; set; }
        public DbSet<Models.Employee_Profile_Phone_Number> Employee_Profile_Phone_Numbers { get; set; }
        public DbSet<Models.Language> Languages { get; set; }
        public DbSet<Models.News_Category> News_Categories { get; set; }
        public DbSet<Models.News_Item> News_Items { get; set; }
        public DbSet<Models.Normal_Category> Normal_Categories { get; set; }
        public DbSet<Models.NormalCategory_Product> NormalCategory_Products { get; set; }
        public DbSet<Models.Photo> Photos { get; set; }
        public DbSet<Models.Photo_News> Photo_News { get; set; }
        public DbSet<Models.Product> Products { get; set; }
        public DbSet<Models.Product_Details> Product_Details { get; set; }
        public DbSet<Models.Product_Photo> Product_Photos { get; set; }
        public DbSet<Models.Product_Text> Product_Texts { get; set; }
        public DbSet<Models.Recipe> Recipes { get; set; }
        public DbSet<Models.Recipe_Photo> Recipe_Photos { get; set; }
        public DbSet<Models.Recipe_Text> Recipe_Texts { get; set; }
        public DbSet<Models.Subscriber> Subscribers { get; set; }
        public DbSet<Models.Text> Text { get; set; }
        public DbSet<Models.Text_News> Text_News { get; set; }
        public DbSet<Models.Type_Category> Type_Categories { get; set; }
        public DbSet<Models.TypeCategory_Recipe> TypeCategory_Recipes { get; set; }


        public WebsiteContext(DbContextOptions<WebsiteContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Text_News>()
                .HasKey(tn => new { tn.NewsID, tn.TextID });

            modelBuilder.Entity<Text_News>()
                .HasOne(tn => tn.Text)
                .WithMany(t => t.TextNews)
                .HasForeignKey(tn => tn.TextID);

            modelBuilder.Entity<Text_News>()
                .HasOne(tn => tn.News)
                .WithMany(n => n.TextNews)
                .HasForeignKey(tn => tn.NewsID);

            modelBuilder.Entity<Photo_News>()
                .HasKey(pn => new { pn.NewsID, pn.PhotoID });

            modelBuilder.Entity<Photo_News>()
                .HasOne(pn => pn.Photo)
                .WithMany(p => p.PhotoNews)
                .HasForeignKey(pn => pn.PhotoID);

            modelBuilder.Entity<Photo_News>()
                .HasOne(pn => pn.News)
                .WithMany(n => n.PhotoNews)
                .HasForeignKey(pn => pn.NewsID);

            modelBuilder.Entity<Recipe_Photo>()
                .HasKey(rp => new { rp.PhotoID, rp.RecipeID });

            modelBuilder.Entity<Recipe_Photo>()
                .HasOne(rp => rp.Recipe)
                .WithMany(r => r.RecipePhotos)
                .HasForeignKey(rp => rp.RecipeID);

            modelBuilder.Entity<Recipe_Photo>()
                .HasOne(rp => rp.Photo)
                .WithMany(p => p.PhotoRecipes)
                .HasForeignKey(rp => rp.PhotoID);

            modelBuilder.Entity<Product_Photo>()
                .HasKey(PrPh => new { PrPh.ArticleNumber, PrPh.PhotoID });

            modelBuilder.Entity<Product_Photo>()
                .HasOne(PrPh => PrPh.Photo)
                .WithMany(Ph => Ph.PhotoProducts)
                .HasForeignKey(PrPh => PrPh.PhotoID);

            modelBuilder.Entity<Product_Photo>()
                .HasOne(PrPh => PrPh.Product)
                .WithMany(Pr => Pr.ProductPhoto)
                .HasForeignKey(PrPh => PrPh.ArticleNumber);

            modelBuilder.Entity<Recipe_Text>()
                .HasKey(rt => new { rt.RecipeID, rt.TextID });

            modelBuilder.Entity<Recipe_Text>()
                .HasOne(rt => rt.Recipe)
                .WithMany(r => r.RecipeTexts)
                .HasForeignKey(rt => rt.RecipeID);

            modelBuilder.Entity<Recipe_Text>()
                .HasOne(rt => rt.Text)
                .WithMany(t => t.TextRecipes)
                .HasForeignKey(rt => rt.TextID);

            modelBuilder.Entity<Product_Text>()
                .HasKey(pt => new { pt.TextID, pt.ArticleNumber });

            modelBuilder.Entity<Product_Text>()
                .HasOne(pt => pt.Product)
                .WithMany(p => p.ProductText)
                .HasForeignKey(pt => pt.ArticleNumber);

            modelBuilder.Entity<Product_Text>()
                .HasOne(pt => pt.Text)
                .WithMany(t => t.TextProducts)
                .HasForeignKey(pt => pt.TextID);

            modelBuilder.Entity<TypeCategory_Recipe>()
                .HasKey(tr => new { tr.RecipeID, tr.TypeID });

            modelBuilder.Entity<TypeCategory_Recipe>()
                .HasOne(tr => tr.Recipe)
                .WithMany(r => r.TypeCategories)
                .HasForeignKey(tr => tr.RecipeID);

            modelBuilder.Entity<TypeCategory_Recipe>()
                .HasOne(tr => tr.Type_Category)
                .WithMany(t => t.Recipes)
                .HasForeignKey(tr => tr.TypeID);

            modelBuilder.Entity<NormalCategory_Product>()
                .HasKey(np => new { np.CategoryID, np.ArticleNumber });

            modelBuilder.Entity<NormalCategory_Product>()
                .HasOne(np => np.Product)
                .WithMany(p => p.NormalCategory)
                .HasForeignKey(np => np.ArticleNumber);

            modelBuilder.Entity<NormalCategory_Product>()
                .HasOne(np => np.Normal_Category)
                .WithMany(n => n.Products)
                .HasForeignKey(np => np.CategoryID);
        }
    }
}
