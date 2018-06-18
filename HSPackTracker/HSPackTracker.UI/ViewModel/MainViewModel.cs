using HSPackTracker.Model;
using HSPackTracker.UI.Data;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace HSPackTracker.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public INavigationViewModel NavigationViewModel { get; }
        public IPackDetailViewModel PackDetailViewModel { get; }

        public MainViewModel(INavigationViewModel navigationViewModel, IPackDetailViewModel packDetailViewModel)
        {
            NavigationViewModel = navigationViewModel;
            PackDetailViewModel = packDetailViewModel;
        }

        public async Task LoadAsync()
        {
            await NavigationViewModel.LoadAsync();
        }
    }
}
