using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.IO.Ports;

namespace RS232Chat.ViewModels
{
    public class SetupViewModel : BindableBase
    {
        ObservableCollection<string> _ports;
        string _selectedPort;

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
                //Port initialization goes here
            }
        }

        public SetupViewModel()
        {
            // Populate the serial port combobox
            Ports = new ObservableCollection<string>(SerialPort.GetPortNames());
        }

    }
}
