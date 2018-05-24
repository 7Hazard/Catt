using System;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Server
{
    public class Chat : WebSocketBehavior
    {
        // När en klient har anslutits
        protected override void OnOpen()
        {
            var time = DateTime.Now.ToString("HH:mm:ss");
            Console.WriteLine($"[{time}] {Context.Host} connected ({ID})");

            // Meddela till alla
            Sessions.Broadcast($"userconnect {time} {Context.Host}");
        }

        // När en klient skickar ett meddelande
        protected override void OnMessage(MessageEventArgs e)
        {
            var time = DateTime.Now.ToString("HH:mm:ss");
            Console.WriteLine($"[{time}] {Context.Host}: {e.Data}");

            Sessions.Broadcast($"message {time} {Context.Host} {e.Data}");
        }
    }
}
