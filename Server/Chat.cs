using System;
using System.Collections.Generic;
using System.Text;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Server
{
    public class Chat : WebSocketBehavior
    {
        // När en klient har anslutits
        protected override void OnOpen()
        {
            Console.WriteLine($"{Context.Host} connected ({ID})");

            // Meddela till alla
            Sessions.Broadcast($"userconnect {Context.Host}");
        }

        // När en klient skickar ett meddelande
        protected override void OnMessage(MessageEventArgs e)
        {

        }
    }
}
