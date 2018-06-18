using HSPackTracker.Model;
using HSPackTracker.UI.Data;
using HSPackTracker.UI.Event;
using Prism.Commands;
using Prism.Events;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HSPackTracker.UI.ViewModel
{
    public class PackDetailViewModel : ViewModelBase, IPackDetailViewModel
    {
        private FileSystemWatcher watcher = new FileSystemWatcher();
        private int SecondCall = 1;

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

            Watch();
        }

        public async void OnSaveCommand()
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

        private void Watch()
        {
            //TODO: Path to Achievement.txt
            string filePath = "C:\\Users\\Sheik Soegriemsingh\\Downloads";
            string fileName = "Test.txt";

            watcher.Path = filePath;
            watcher.Filter = fileName;
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.EnableRaisingEvents = true;
            

            watcher.Changed += new FileSystemEventHandler(OnChange);
        }

        private void OnChange(object sender, FileSystemEventArgs e)
        {
            if (watcher.EnableRaisingEvents == true && SecondCall == 1)
            {
                watcher.EnableRaisingEvents = false;

                // TODO: Method for checking content of the Archievement.txt
                Pack.EpicCount += 1;

                OnSaveCommand();
                ResetState();
            }
            else
            {
                SecondCall += 1;
            }
        }

        private void ResetState()
        {
            SecondCall = 0;
            watcher.EnableRaisingEvents = true;
        }
    }
}
