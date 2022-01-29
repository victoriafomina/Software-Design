using System.Net.Sockets;

namespace NetworkChat
{
    public class Client : Communicator
    {
        public Client(string hostname, int port)
        {
            _client = new TcpClient(hostname, port);
        }
    }
}