using System;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            // Subscribe to events
            Server.OnClientConnected += OnClientConnected;

            Server.Start();

            CConsole.GetCommand();
        }

        private async static void OnClientConnected(Client client)
        {
            await client.Send("connect", "Connected to Server");
            Console.WriteLine(client.IP+" connected!");
        }
    }
}