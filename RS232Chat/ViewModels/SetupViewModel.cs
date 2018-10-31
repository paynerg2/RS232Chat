using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.ObjectModel;

namespace RS232Chat.ViewModels
{
    public class SetupViewModel : BindableBase
    {
        ObservableCollection<string> _ports;
        string _selectedPort;
        IRegionManager _regionManager;
        
        public DelegateCommand<string> StartCommand { get; private set; }

        public ObservableCollection<string> Ports
        {
            get { return _ports; }
            set { SetProperty(ref _ports, value); }
        }

        public string SelectedPort
        {
            get { return _selectedPort; }
            set
            {
                SetProperty(ref _selectedPort, value);
                StartCommand.RaiseCanExecuteChanged();
            }
        }

        public SetupViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            StartCommand = new DelegateCommand<string>(Start, CanStart);

            // Populate the serial port combobox
            Ports = new ObservableCollection<string> { "COM1" };
        }

        #region Commands
        private bool CanStart(string arg)
        {
            return !string.IsNullOrEmpty(_selectedPort);
        }

        private void Start(string obj)
        {
            var param = new NavigationParameters
            {
                { "port", _selectedPort }
            };
            _regionManager.RequestNavigate("ActiveRegion", "ChatView", param);
        }
        #endregion
    }
}
