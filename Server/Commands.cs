using System;

namespace Server
{
    internal class Commands
    {
        internal static void Get()
        {
            string command = Console.ReadLine().ToLower();
            switch (command)
            {
                case "exit":
                    return;
                case "quit":
                    return;
                case "start":
                    Server.Start();
                    break;
                case "stop":
                    Server.Stop();
                    break;
                case "restart":
                    Server.Restart();
                    break;
                default:
                    Console.WriteLine("Command not found!");
                    break;
            }
            Get();
        }
    }
}
