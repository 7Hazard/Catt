using System;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!Server.Start())
            {
                Console.WriteLine("\n Press any key to continue...");
                Console.ReadKey();
                return;
            }
            Commands.Get();
        }
    }
}