using System.Threading.Tasks;

namespace HSPackTracker.UI.ViewModel
{
    public interface IPackDetailViewModel
    {
        Task LoadAsync(int packId);
    }
}