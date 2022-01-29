using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace NetworkChat
{
    public class Server : Communicator
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

            await base.Run();
        }
    }
}
