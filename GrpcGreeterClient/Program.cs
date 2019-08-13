namespace GrpcGreeterClient
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Grpc.Net.Client;
    using GrpcGreeter;

    class Program
    {
        static async Task Main(string[] args)
        {
            var url = "https://localhost:53157";

            var httpClient = new HttpClient
            {
                // The port number(5001) must match the port of the gRPC server.
                BaseAddress = new Uri(url)
            };

            var client = GrpcClient.Create<Greeter.GreeterClient>(httpClient);

            var reply = await client.SayHelloAsync(new HelloRequest { Name = "GreeterClient" });

            Console.WriteLine("Greeting: " + reply.Message);

            Console.WriteLine("Press any key to exit...");

            Console.ReadKey();
        }

        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Hello World!");
        //}
    }
}
