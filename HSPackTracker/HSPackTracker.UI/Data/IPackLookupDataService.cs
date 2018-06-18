using System.Collections.Generic;
using System.Threading.Tasks;
using HSPackTracker.Model;

namespace HSPackTracker.UI.Data
{
    public interface IPackLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetPackLookupAsync();
    }
}