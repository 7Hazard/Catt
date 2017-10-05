using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    internal class CConsole
    {
        internal static void GetCommand()
        {
            string command = Console.ReadLine().ToLower();
            switch (command)
            {
                case "exit":
                    return;
                case "quit":
                    return;
                case "restart":
                    SocketServer.Restart();
                    break;
                default:
                    Console.WriteLine("Command not found!");
                    break;
            }
            GetCommand();
        }
    }
}
