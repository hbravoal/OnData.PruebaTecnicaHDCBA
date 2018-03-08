using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnData.PruebaTecnicaHDCBA.Context;
using OnData.PruebaTecnicaHDCBA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace OnData.PruebaTecnicaHDCBA
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StoreContext, Migrations.Configuration>());
            CreateRolesAndSuperuser();
        }
        private void CreateRolesAndSuperuser()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            CreateRoles(db);
            CreateSuperuser(db);
            AddPermisionsToSuperuser(db);
            db.Dispose();
        }

        private void CreateRoles(ApplicationDbContext db)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            if (!roleManager.RoleExists("User"))
            {
                var result = roleManager.Create(new IdentityRole("User"));
            }

            if (!roleManager.RoleExists("Admin"))
            {
                var result = roleManager.Create(new IdentityRole("Admin"));
            }

           
        }

        private void CreateSuperuser(ApplicationDbContext db)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = userManager.FindByName("hbravoal@gmail.com");
            if (user == null)
            {
                user = new ApplicationUser();
                user.UserName = "hbravoal@gmail.com";
                user.Email = "hbravoal@gmail.com";
                var result = userManager.Create(user, "25Junio1996.");
            }
        }

        private void AddPermisionsToSuperuser(ApplicationDbContext db)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            var user = userManager.FindByName("hbravoal@gmail.com");

            if (!userManager.IsInRole(user.Id, "Admin"))
            {
                userManager.AddToRole(user.Id, "Admin");
            }

           
        }


    }
}
