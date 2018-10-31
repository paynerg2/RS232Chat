using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using RS232Chat.Models;
using System;

namespace RS232Chat.ViewModels
{
    public class ChatViewModel : BindableBase, INavigationAware
    {
        private string _port;
        private string _sendText;
        private string _receivedText;
        private ISerialPort _serialPort;

        public DelegateCommand<string> SendChatCommand { get; private set; }
        public DelegateCommand CloseCommand { get; private set; }
        
        public string Port
        {
            get { return _port; }
            set
            {
                SetProperty(ref _port, value);
                InitializeSerialPort();
            }
        }
        public string SendText
        {
            get { return _sendText; }
            set
            {
                SetProperty(ref _sendText, value);
                SendChatCommand.RaiseCanExecuteChanged();
            }
        }

        public string ReceivedText
        {
            get { return _receivedText; }
            set { SetProperty(ref _receivedText, value); }
        }
        
        public ChatViewModel()
        {
            SendChatCommand = new DelegateCommand<string>(Send, CanSend);
            CloseCommand = new DelegateCommand(Close);
        }

        private void InitializeSerialPort()
        {
            _serialPort = new SerialDevice(_port);
            _serialPort.Initialize();
        }
        #region Commands
        private async void Close()
        {
            await _serialPort.ClosePort();
        }

        private async void Send(string text)
        {
            _serialPort.Write(text);
            ReceivedText += await _serialPort.ReadAsync() + Environment.NewLine;
            SendText = string.Empty;
        }

        private bool CanSend(string arg)
        {
            return !String.IsNullOrEmpty(_sendText) 
                && _serialPort != null;
        }
        #endregion

        #region INavigationAware Implementation
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            // Should maintain the same instance of the view
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Port = navigationContext.Parameters["port"] as string;
        }
        #endregion
    }
}
