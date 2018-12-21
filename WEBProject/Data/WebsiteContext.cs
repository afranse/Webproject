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
        public DbSet<Subscriber> Subscribers { get; set; } 
        public DbSet<Employee_Profile> Employee_Profiles { get; set; }


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
        }
    }
}
