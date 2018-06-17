namespace HSPackTracker.DataAccess.Migrations
{
    using HSPackTracker.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HSPackTracker.DataAccess.HSPackTrackerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HSPackTracker.DataAccess.HSPackTrackerDbContext context)
        {
            context.Packs.AddOrUpdate(
                p => p.SetName,
                new Pack { SetName = "Classic" },
                new Pack { SetName = "Journey to Un'Goro" },
                new Pack { SetName = "Knights of the Frozen Throne" },
                new Pack { SetName = "Kobolds & Catacombs" },
                new Pack { SetName = "The Witchwood" }
                );
        }
    }
}
