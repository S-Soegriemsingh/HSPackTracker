using HSPackTracker.Model;
using HSPackTracker.UI.Data;
using HSPackTracker.UI.Event;
using Prism.Events;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace HSPackTracker.UI.ViewModel
{
    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {
        private IPackLookupDataService _packLookupService;
        private IEventAggregator _eventAggregator;

        public ObservableCollection<LookupItem> Packs { get; }
        private LookupItem _selectedPack;

        public LookupItem SelectedPack
        {
            get { return _selectedPack; }
            set
            {
                _selectedPack = value;
                OnPropertyChanged();
                if (_selectedPack != null)
                {
                    _eventAggregator.GetEvent<OpenPackDetailViewEvent>()
                        .Publish(_selectedPack.Id);
                }
            }
        }


        public NavigationViewModel(IPackLookupDataService packLookupService, IEventAggregator eventAggregator)
        {
            _packLookupService = packLookupService;
            _eventAggregator = eventAggregator;

            Packs = new ObservableCollection<LookupItem>();
        }

        public async Task LoadAsync()
        {
            var lookup = await _packLookupService.GetPackLookupAsync();

            Packs.Clear();

            foreach (var item in lookup)
            {
                Packs.Add(item);
            }
        }
    }
}
