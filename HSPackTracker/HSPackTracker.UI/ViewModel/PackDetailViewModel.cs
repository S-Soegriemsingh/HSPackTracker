using HSPackTracker.Model;
using HSPackTracker.UI.Data;
using HSPackTracker.UI.Event;
using Prism.Commands;
using Prism.Events;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HSPackTracker.UI.ViewModel
{
    public class PackDetailViewModel : ViewModelBase, IPackDetailViewModel
    {
        private IPackDataService _dataService;
        private IEventAggregator _eventAggregator;
        public ICommand SaveCommand { get; }

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

            SaveCommand = new DelegateCommand(OnSaveCommand, OnCanSaveCommand);
        }

        private async void OnSaveCommand()
        {
            await _dataService.SaveAsync(Pack);
            OnOpenPackDetailView(Pack.Id);
        }

        private bool OnCanSaveCommand()
        {
            return true;
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
