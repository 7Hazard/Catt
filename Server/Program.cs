using SocketIo;
using SocketIo.SocketTypes;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var socket = Io.Create("127.0.0.1", 6969, 6969, SocketHandlerType.Udp);

            socket.On("connect", () =>
            {
                
            });
        }
    }
}