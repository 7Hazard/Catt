using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Client
    {
        public Socket socket;
        public IPAddress IP;

        TcpClient client;
        public Client(TcpClient client)
        {
            this.client = client;
            socket = client.Client;
            IP = ((IPEndPoint)socket.RemoteEndPoint).Address;
        }

        Task Send(Socket socket, byte[] buffer, int offset, int size, int timeout)
        {
            return Task.Run(()=>
            {
                int startTickCount = Environment.TickCount;
                int sent = 0;
                do
                {
                    if (Environment.TickCount > startTickCount + timeout)
                        throw new Exception("Timeout.");
                    try
                    {
                        sent += socket.Send(buffer, offset + sent, size - sent, SocketFlags.None);
                    }
                    catch (SocketException ex)
                    {
                        if (ex.SocketErrorCode == SocketError.WouldBlock ||
                            ex.SocketErrorCode == SocketError.IOPending ||
                            ex.SocketErrorCode == SocketError.NoBufferSpaceAvailable)
                        {
                            Task.Delay(30);
                        }
                        else
                            throw ex;
                    }
                } while (sent < size);
            });
        }

        public Task Send(string message)
        {
            return Send(socket, Encoding.UTF8.GetBytes(message), 0, message.Length, 10000);
        }

        public Task Send(string eventname, string message)
        {
            return Send(socket, Encoding.UTF8.GetBytes(eventname+" "+message), 0, message.Length, 10000);
        }

        public Task Send(string eventname, string message, int msTimeout)
        {
            return Send(socket, Encoding.UTF8.GetBytes(message), 0, message.Length, msTimeout);
        }

        public Task Send(string eventname, params string[] messages)
        {
            return Task.Run(async () =>
            {
                using (StreamWriter writer = new StreamWriter(client.GetStream(), Encoding.UTF8))
                {
                    foreach (string message in messages)
                    {
                        await writer.WriteAsync(message);
                    }
                    await writer.FlushAsync();
                }
            });
        }
    }
}
