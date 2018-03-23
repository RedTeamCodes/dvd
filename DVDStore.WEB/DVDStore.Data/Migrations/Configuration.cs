namespace DVDStore.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DVDStore.Data.Models.DVDStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "DVDStore.Data.Models.DVDStoreContext";

        }

        protected override void Seed(DVDStore.Data.Models.DVDStoreContext context)
        {
          //  context.DVD.AddOrUpdate(i => i.Title,
          //     new Models.DVD
          //     {
          //         Title = "When Harry Met Sally",
          //         ReleaseDate = DateTime.Parse("1989-1-11"),
          //         Price = 7.99M,
               
          //    }
          //);
        }
    }
}
