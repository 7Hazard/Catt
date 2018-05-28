using System;

namespace Server
{
    internal class Commands
    {
        // Rekursiv funktion för kommandon
        internal static void Get()
        {
            string command = Console.ReadLine().ToLower();
            switch (command)
            {
                case "exit": // Stänger av programmet
                    return;
                case "quit": // Stänger av programmet
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
                default: // Okänt kommando
                    Console.WriteLine($"Unrecognized command {command}\n");
                    break;
            }
            Get(); // Vänta för inmatning igen
        }
    }
}
