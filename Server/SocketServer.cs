using System;
using SocketIo;
using SocketIo.SocketTypes;

namespace Server
{
    internal static class SocketServer
    {
        static SocketIo.SocketIo socket;

        internal static bool Start()
        {
            try
            {
                socket = Io.Create("127.0.0.1", 6969, 6969, SocketHandlerType.Tcp);

                socket.On("connect", () =>
                {
                    Console.WriteLine("USER CONNECTED");
                });

                socket.On("message", (string msg) =>
                {
                    Console.WriteLine(msg);
                });
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            Console.WriteLine("Socket server started");
            return true;
        }

        internal static void Restart()
        {
            socket.Restart();
        }
    }
}
