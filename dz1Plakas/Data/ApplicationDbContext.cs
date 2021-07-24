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



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }
}
