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

        private static void OnClientConnected(Client client)
        {
            Console.WriteLine("NIGGER");
        }
    }
}