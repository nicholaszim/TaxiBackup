namespace DAL.Migrations
{
    using Model;
    using Model.DB;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

	internal sealed class Configuration : DbMigrationsConfiguration<DAL.MainContext> 
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.MainContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
			var roles = new List<Role> 
			{
				new Role() { Name = "Driver", Description = "Driver" },
				new Role() { Name = "Operator", Description = "Operator" },
				new Role() { Name = "Client", Description = "Client" },
				new Role() { Name = "ReportViewer", Description = "Report Viewer" },
				new Role() { Name = "Administrator", Description = "Administrator" } 
			};

			roles.ForEach(s => context.Roles.AddOrUpdate(p => p.Name, s));

			context.SaveChanges();

			if (context.Users.Where(x=>x.UserName=="admin").FirstOrDefault()==null)
			context.Users.AddOrUpdate(
				new User() 
				{
					UserName = "admin",
					Password = "password",
					Email = "admin@gmail.com",
					RoleId = 5
				}
			);
            if (!context.Tarifes.Any(x => x.Name == "Standart"))
                context.Tarifes.Add(new Tarif() { Name = "Standart", MinimalPrice = 12.50M, OneMinuteCost = 1M, StartPrice = 5M, WaitingCost = 0.5M });


			context.SaveChanges();
    
        }
    }
}
