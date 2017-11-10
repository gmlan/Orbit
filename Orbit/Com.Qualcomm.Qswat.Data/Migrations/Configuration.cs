using Com.Qualcomm.Qswat.Data.Initializer;

namespace Com.Qualcomm.Qswat.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Com.Qualcomm.Qswat.Data.Context.EfContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Com.Qualcomm.Qswat.Data.Context.EfContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var seed = new DataSeeds(context);
            seed.SeedAll();
        }
    }
}
