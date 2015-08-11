namespace MahotaApp.Web.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using MahotaApp.Data;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public partial class DataBaseDbContext : DbContext
    {
        public DataBaseDbContext()
            : base("name=Model1")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
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
