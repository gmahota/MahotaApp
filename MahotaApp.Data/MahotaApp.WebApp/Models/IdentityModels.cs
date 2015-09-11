using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Framework.OptionsModel;


namespace MahotaApp.WebApp.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    //public class ApplicationUser : IdentityUser
    //{
    //}

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }

    //public DbSet<Ref_Tooling_Types> Ref_tooling_Types { get; set; }
    //public DbSet<Locations> Locations { get; set; }
    //public DbSet<Equipment_Iventory> Equipment_Iventory { get; set; }

    //public DbSet<Daily_Iventory_Levels> Daily_Iventory_Levels { get; set; }
    //public DbSet<Product_Types> Product_Types { get; set; }
    //public DbSet<Products> Products { get; set; }
    //public DbSet<Orders_Items> Orders_Items { get; set; }
    //public DbSet<Orders> Orders { get; set; }
    //public DbSet<Customers> Customers { get; set; }
}
