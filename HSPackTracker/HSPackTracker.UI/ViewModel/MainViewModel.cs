using HSPackTracker.Model;
using HSPackTracker.UI.Data;
using System.Collections.ObjectModel;

namespace HSPackTracker.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private IPackDataService _packDataService;
        private Pack _selectedPack;

        public ObservableCollection<Pack> Packs { get; set; }
        public Pack SelectedPack
        {
            get { return _selectedPack; }
            set
            {
                _selectedPack = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel(IPackDataService packDataService)
        {
            Packs = new ObservableCollection<Pack>();
            _packDataService = packDataService;
        }

        public void Load()
        {
            var packs = _packDataService.GetAll();

            // Clear the list to avoid duplicates if function is called twice.
            Packs.Clear();

            foreach (var pack in packs)
            {
                Packs.Add(pack);
            }
        }
    }
}
