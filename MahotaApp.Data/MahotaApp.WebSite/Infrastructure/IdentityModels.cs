using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MahotaApp.Data;

namespace MahotaApp.WebSite.Models
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