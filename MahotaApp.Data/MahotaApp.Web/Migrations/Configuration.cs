namespace MahotaApp.Web.Migrations
{
    using MahotaApp.Data;
    using MahotaApp.Web.Infrastructure;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MahotaApp.Web.Infrastructure.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MahotaApp.Web.Infrastructure.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
 
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
 
 
            var user = new ApplicationUser()
            {
                UserName = "gmahota",
                Email = "guimaraesmahota@gmail.com",
                EmailConfirmed = true,
                FirstName = "Guimarães",
                LastName = "Mahota",
                Level = 1,
                JoinDate = DateTime.Now.AddYears(-3)
            };

            manager.Create(user, "Accsys2011!");

            if (roleManager.Roles.Count() == 0)
            {
                roleManager.Create(new IdentityRole { Name = "SuperAdmin" });
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            var adminUser = manager.FindByName("gmahota");

            manager.AddToRoles(adminUser.Id, new string[] { "SuperAdmin", "Admin" });
                        
        }
    }
}
