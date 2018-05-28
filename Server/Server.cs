using System;
using System.Collections.Generic;
using WebSocketSharp.Server;

namespace Server
{
    public static class Server
    {
        static WebSocketServer ws;

        // Startar websocket servern
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
            ws.AddWebSocketService<Chat>("/chat");
            ws.Start();

            Console.WriteLine($"Server started on {Config.Host}:{Config.Port}");
            return true;
        }

        // Stoppar websocket servern
        public static void Stop()
        {
            ws.Stop();
            Console.WriteLine("Server stopped");
        }

        // Startar om websocket servern
        public static void Restart()
        {
            Stop();
            Start();
        }
    }
}
