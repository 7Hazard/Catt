using System;
using System.Collections.Generic;
using WebSocketSharp.Server;

namespace Server
{
    public static class Server
    {
        static WebSocketServer ws;
        
        public static bool Start()
        {
            try
            {
                ws = new WebSocketServer($"ws://{Config.Host}:{Config.Port}");
            } catch (Exception e)
            {
                Console.WriteLine("Exception when starting server: \n" + e.Message);
                return false;
            }

            // Adds overloaded WebSocketBehaviour server via generics
            ws.AddWebSocketService<Chat>("/chat");

            // Starts the websocket server
            ws.Start();

            Console.WriteLine($"Server started on {Config.Host}:{Config.Port}");
            return true;
        }
        
        public static void Stop()
        {
            ws.Stop();
            Console.WriteLine("Server stopped");
        }
        
        public static void Restart()
        {
            Stop();
            Start();
        }
    }
}
