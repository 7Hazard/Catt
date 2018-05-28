using System;

namespace Server
{
    internal class Commands
    {
        // Recursive function for commands
        internal static void Get()
        {
            string command = Console.ReadLine().ToLower();
            switch (command)
            {
                case "exit": // Shuts down the program
                case "quit":
                    Server.Stop();
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
                default: // Unrecognized command
                    Console.WriteLine($"Unrecognized command {command}\n");
                    break;
            }
            Get(); // Repeat
        }
    }
}
