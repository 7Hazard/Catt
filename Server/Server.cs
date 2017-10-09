using System;
using System.Net.Sockets;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Server
{
    public static class Server
    {
        // Events
        public delegate void OnClientConnectedHandler(Client client);
        public static event OnClientConnectedHandler OnClientConnected = delegate { };

        static TcpListener server = new TcpListener(IPAddress.Any, 6969);
        
        public static bool Start()
        {
            server.Start();

            HandleClients();

            Console.WriteLine("Server started");
            return true;
        }

        public static void Stop()
        {
            server.Stop();
            Console.WriteLine("Server stopped");
        }

        public static void Restart()
        {
            Stop();
            Start();
        }

        // Clients
        static List<Client> clients = new List<Client>();
        static IReadOnlyList<Client> ConnectedClients = clients;

        static void HandleClients()
        {
            Action task = null;
            Task.Run(task = async () =>
            {
                Client client = new Client(await server.AcceptTcpClientAsync());
                clients.Add(client);
                OnClientConnected(client);
                task.Invoke();
            });
        }
    }
}
