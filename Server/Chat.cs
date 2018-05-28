using System;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Server
{
    public class Chat : WebSocketBehavior
    {
        string name;

        // The client attempts to connect
        protected override void OnOpen()
        {
            // Timestamp
            var time = GetTimestamp();

            // Get name from query string
            name = Context.QueryString["name"];

            // Output to console
            Console.WriteLine($"[{time}] {name} connected ({Context.Host}, {ID})");

            // Message all clients
            Sessions.Broadcast($"userconnect {time} {name}");
        }

        // Client disconnected
        protected override void OnClose(CloseEventArgs e)
        {
            // Timestamp
            var time = GetTimestamp();

            // Message all clients
            Sessions.Broadcast($"userdisconnect {time} {name}");
        }

        // When a client connectes
        protected override void OnMessage(MessageEventArgs e)
        {
            var time = GetTimestamp();
            Console.WriteLine($"[{time}] {name}: {e.Data}");
            
            // Send the message to the client 
            // with name and timestamp of recieval
            Sessions.Broadcast($"message {time} {name} {e.Data}");
        }

        string GetTimestamp()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
