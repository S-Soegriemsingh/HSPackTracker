using System.Threading.Tasks;
using HSPackTracker.Model;

namespace HSPackTracker.UI.Data
{
    public interface IPackDataService
    {
        Task<Pack> GetByIdAsync(int packId);
        Task SaveAsync(Pack pack);
    }
}