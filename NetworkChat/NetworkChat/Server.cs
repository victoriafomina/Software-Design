using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace NetworkChat
{
    public class Server : ICommunicator
    {
        private readonly TcpListener _listener;

        public Server(int port)
        {
            _listener = new TcpListener(IPAddress.Any, port);
        }

        public override async Task Run()
        {
            _listener.Start();
            Console.WriteLine("Server is launched. Waiting for client.");

            _client = await _listener.AcceptTcpClientAsync();
            _stream = _client.GetStream();
            Console.WriteLine("Chat partner (Client) connected.");


            GetMessage();
            await SendMessage();
        }
    }
}
