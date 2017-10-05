using SocketIo;
using SocketIo.SocketTypes;
using System;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            SocketServer.Start();

            CConsole.GetCommand();
        }
    }
}