using HSPackTracker.DataAccess;
using HSPackTracker.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace HSPackTracker.UI.Data
{
    public class PackDataService : IPackDataService
    {
        private Func<HSPackTrackerDbContext> _contextCreator;

        public PackDataService(Func<HSPackTrackerDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }
        public async Task<Pack> GetByIdAsync(int packId)
        {
            using(var ctx = _contextCreator())
            {
                return await ctx.Packs.AsNoTracking().SingleAsync(p => p.Id == packId);
            }
        }

        public async Task SaveAsync(Pack pack)
        {
            using (var ctx = _contextCreator())
            {
                ctx.Packs.Attach(pack);
                ctx.Entry(pack).State = EntityState.Modified;
                await ctx.SaveChangesAsync();
            }
        }
    }
}
