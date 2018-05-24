using System;
using System.Collections.Generic;
using WebSocketSharp.Server;

namespace Server
{
    public static class Server
    {
        static WebSocketServer ws = new WebSocketServer("ws://localhost:6969");

        public static bool Start()
        {
            ws.AddWebSocketService<Chat>("/chat");
            ws.Start();

            Console.WriteLine("Server started");
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
