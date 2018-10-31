using System;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Threading.Tasks;

namespace RS232Chat.Models
{
    public class SerialDevice : ISerialPort
    {
        private SerialPort _serialPort;

        public SerialDevice(string portName)
        {
            try
            {
                if (_serialPort == null)
                    _serialPort = new SerialPort(portName, 9600, Parity.None, 8, StopBits.One);
            }
            catch (Exception)
            {
                ClosePort();
            }
        }
        
        public void Initialize()
        {
            _serialPort.Open();
        }

        public async Task<string> ReadAsync()
        {
            byte[] buffer = new byte[4096];
            Task<int> readStringTask = 
                _serialPort.BaseStream.ReadAsync(buffer, 0, 100);

            int bytesRead = await readStringTask;

            return Encoding.ASCII.GetString(buffer, 0, bytesRead);
        }

        public void Write(string data)
        {
            if (_serialPort.IsOpen)
                _serialPort.Write(data);
        }

        public Task ClosePort()
        {
            Task closeTask = new Task(() =>
            {
                try
                {
                    _serialPort.Close();
                }
                catch (IOException)
                {
                    throw;
                }
            });
            closeTask.Start();

            return closeTask;
        }
    }
}
