using System;
using System.Threading.Tasks;

namespace NetworkChat
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var server = new Server(8000);
            await server.Run();
        }
    }
}
