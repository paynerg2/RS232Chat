using System.Threading.Tasks;

namespace RS232Chat.Models
{
    public interface ISerialPort
    {
        void Initialize();
        Task<string> ReadAsync();
        void Write(string data);
        Task ClosePort();
    }
}