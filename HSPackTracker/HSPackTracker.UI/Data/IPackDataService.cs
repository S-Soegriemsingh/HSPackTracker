using System.Collections.Generic;
using System.Threading.Tasks;
using HSPackTracker.Model;

namespace HSPackTracker.UI.Data
{
    public interface IPackDataService
    {
        Task<List<Pack>> GetAllAsync();
    }
}