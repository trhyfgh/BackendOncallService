namespace BackendOncallService.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BackendOncallService.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<BackendOncallService.Models.BackendOncallServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BackendOncallService.Models.BackendOncallServiceContext context)
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
            context.OncallCells.AddOrUpdate(x => x.Id,
                new OncallCell() { Id = 1, OncallName = "Sayid.xiong", OncallShift = 1, OncallDate = Convert.ToDateTime("2015-06-01") }
                );
        }
    }
}
