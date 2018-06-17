using HSPackTracker.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HSPackTracker.DataAccess
{
    public class HSPackTrackerDbContext : DbContext
    {
        public DbSet<Pack> Packs { get; set; }

        public HSPackTrackerDbContext() : base("HSPackTrackerDb")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
