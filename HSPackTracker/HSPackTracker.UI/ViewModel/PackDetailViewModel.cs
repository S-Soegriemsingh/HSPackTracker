using HSPackTracker.Model;
using HSPackTracker.UI.Data;
using HSPackTracker.UI.Event;
using Prism.Events;
using System;
using System.Threading.Tasks;

namespace HSPackTracker.UI.ViewModel
{
    public class PackDetailViewModel : ViewModelBase, IPackDetailViewModel
    {
        private IPackDataService _dataService;
        private IEventAggregator _eventAggregator;

        private Pack _pack;
        public Pack Pack
        {
            get { return _pack; }
            set
            {
                _pack = value;
                OnPropertyChanged();
            }
        }

        public PackDetailViewModel(IPackDataService dataService, IEventAggregator eventAggregator)
        {
            _dataService = dataService;
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<OpenPackDetailViewEvent>()
                .Subscribe(OnOpenPackDetailView);
        }

        private async void OnOpenPackDetailView(int packId)
        {
            await LoadAsync(packId);
        }

        public async Task LoadAsync(int packId)
        {
            Pack = await _dataService.GetByIdAsync(packId);
        }
    }
}
