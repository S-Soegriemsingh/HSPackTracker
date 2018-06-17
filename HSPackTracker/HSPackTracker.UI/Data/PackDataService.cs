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
        public async Task<List<Pack>> GetAllAsync()
        {
            using(var ctx = _contextCreator())
            {
                return await ctx.Packs.ToListAsync();
            }
        }
    }
}
