using System;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace NetworkChat
{
    public abstract class Communicator
    {
        protected TcpClient _client = new();
        protected NetworkStream _stream;

        public virtual async Task Run()
        {
            _stream = _client.GetStream();
            Console.WriteLine("Chat partner is launched.");

            GetMessage();
            await SendMessage();
        }

        protected async Task SendMessage()
        {
            while (true)
            {
                var writer = new StreamWriter(_stream);
                var data = Console.ReadLine();
                await writer.WriteLineAsync(data);
                await writer.FlushAsync();

                if (data == "exit")
                {
                    Shutdown();
                    break;
                }
            }
        }


        protected void GetMessage()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    var reader = new StreamReader(_stream);
                    var data = await reader.ReadLineAsync();
                    Console.WriteLine(data);

                    if (data == "exit")
                    {
                        Shutdown();
                        break;
                    }
                }
            });
        }

        private void Shutdown()
        {
            _stream.Close();
            _client.Close();
            Environment.Exit(0);
        }
    }
}