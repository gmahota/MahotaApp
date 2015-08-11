
using MahotaApp.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MahotaApp.Web.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Ref_Tooling_Types> Ref_tooling_Types { get; set; }
        public DbSet<Locations> Locations { get; set; }
        public DbSet<Equipment_Iventory> Equipment_Iventory { get; set; }

        public DbSet<Daily_Iventory_Levels> Daily_Iventory_Levels { get; set; }
        public DbSet<Product_Types> Product_Types { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Orders_Items> Orders_Items { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Customers> Customers { get; set; }

    }
}