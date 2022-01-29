using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace NetworkChat
{
    public class Client : ICommunicator
    {
        private readonly TcpClient _client;
        private NetworkStream _stream;

        public Client(string hostname, int port)
        {
            _client = new TcpClient(hostname, port);
        }

        public override async Task Run()
        {
            _stream = _client.GetStream();
            Console.WriteLine("Chat partner (Client) is launched.");

            GetMessage();
            await SendMessage();
        }
    }
}