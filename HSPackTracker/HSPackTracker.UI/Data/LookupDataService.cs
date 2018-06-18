using HSPackTracker.DataAccess;
using HSPackTracker.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace HSPackTracker.UI.Data
{
    public class LookupDataService : IPackLookupDataService
    {
        private Func<HSPackTrackerDbContext> _contextCreator;

        public LookupDataService(Func<HSPackTrackerDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }

        public async Task<IEnumerable<LookupItem>> GetPackLookupAsync()
        {
            using (var ctx = _contextCreator())
            {
                return await ctx.Packs.AsNoTracking()
                    .Select(p => new LookupItem
                    {
                        Id = p.Id,
                        DisplayMember = p.Id + ". " + p.SetName
                    })
                    .ToListAsync();
            }
        }
    }
}
