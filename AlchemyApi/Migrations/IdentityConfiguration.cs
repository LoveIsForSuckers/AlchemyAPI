namespace AlchemyApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Configuration;
    using System.Linq;
    using AlchemyApi.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class IdentityConfiguration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public IdentityConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "AlchemyApi.Models.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var user = new ApplicationUser()
            {
                UserName = ConfigurationManager.AppSettings["DefaultUser"]
            };
            manager.Create(user, ConfigurationManager.AppSettings["DefaultPassword"]);
        }
    }
}