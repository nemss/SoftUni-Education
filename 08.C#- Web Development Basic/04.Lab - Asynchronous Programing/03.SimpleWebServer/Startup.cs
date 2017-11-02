namespace _03.SimpleWebServer
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var address = IPAddress.Parse("127.0.0.1");
            var port = 1337;
            var listener = new TcpListener(address, port);
            listener.Start();

            Console.WriteLine("Server started.");
            Console.WriteLine($"Listening to TCP clients at 127.0.0.1: {port}");

            Task
                .Run(async () =>
                {
                    await Connect(listener);
                })
                .GetAwaiter()
                .GetResult();
        }

        public static async Task Connect(TcpListener listener)
        {
            while (true)
            {
                Console.WriteLine("Waiting for client...");
                var client = await listener.AcceptTcpClientAsync();

                Console.WriteLine("Client connected.");

                var buffer = new byte[1024];
                await client.GetStream().ReadAsync(buffer, 0, buffer.Length);

                var clienMessage = Encoding.UTF8.GetString(buffer);
                Console.WriteLine(clienMessage.TrimEnd('\0'));

                var responseMessage = "HTTP/1.1 200 OK\nContent-Type: text/plain\n\nHello from my server!";
                var data = Encoding.UTF8.GetBytes(responseMessage);
                await client.GetStream().WriteAsync(data, 0, data.Length);

                client.GetStream().Dispose();
            }
        }
    }
}