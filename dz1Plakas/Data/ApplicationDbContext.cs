using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace dz1Plakas.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Models.CarColor> carColor { get; set; }
        public DbSet<Models.CarMark> carMark { get; set; }
        public DbSet<Models.Page> pages { get; set; }
        public DbSet<Models.ContactForm> contactForms { get; set; }
        public DbSet<Models.Brend> brends { get; set; }
        public DbSet<Models.Product> products { get; set; }
        public DbSet<Models.Color> colors { get; set; }
        public DbSet<Models.ColorProducts> colorProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.ColorProducts>()
                .HasKey(cp => new { cp.colorid,cp.productid });

            modelBuilder.Entity<Models.ColorProducts>()
                .HasOne<Models.Color>(cp => cp.color)
                .WithMany(p => p.colorProducts)
                .HasForeignKey(cp => cp.colorid);

            modelBuilder.Entity<Models.ColorProducts>()
               .HasOne<Models.Product>(cp => cp.product)
               .WithMany(p => p.colorProducts)
               .HasForeignKey(cp => cp.productid);

        }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }
}
