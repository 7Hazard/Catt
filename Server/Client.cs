using System.Net.Sockets;

namespace Server
{
    public class Client
    {
        TcpClient client;


        public Client(TcpClient client)
        {
            this.client = client;
        }

        public void Send(params string[] messages)
        {

        }
    }
}
