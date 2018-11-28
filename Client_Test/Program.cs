using lth.egmTest;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;

namespace Client_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            UDPSocket c = new UDPSocket();
            c.Client("127.0.0.1", 6789);
            //c.Send("42!");
            c.gpbSend(42, "The meaning of life, the universe, and everything is...");
        }
    }

    public class UDPSocket
    {
        private Socket _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        private const int bufSize = 8 * 1024;
        private State state = new State();
        private EndPoint epFrom = new IPEndPoint(IPAddress.Any, 0);
        private AsyncCallback recv = null;

        public class State
        {
            public byte[] buffer = new byte[bufSize];
        }

        public void Server(string address, int port)
        {
            _socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.ReuseAddress, true);
            _socket.Bind(new IPEndPoint(IPAddress.Parse(address), port));
            Receive();
        }

        public void Client(string address, int port)
        {
            _socket.Connect(IPAddress.Parse(address), port);
            Receive();
        }

        public void Send(string text)
        {
            byte[] data = Encoding.ASCII.GetBytes(text);
            _socket.BeginSend(data, 0, data.Length, SocketFlags.None, (ar) =>
            {
                State so = (State)ar.AsyncState;
                int bytes = _socket.EndSend(ar);
                Console.WriteLine("SEND: {0}, {1}", bytes, text);
            }, state);
        }

        public void gpbSend(Int32 sender, string message)
        {
            Packet.Builder packet = Packet.CreateBuilder();//is there a difference?
            Header.Builder header = new Header.Builder();//create builder or new builder?
            Body.Builder body = Body.CreateBuilder();// I dunno, let's find out :)
            header.SetSender(sender);
            body.SetMsg(message);
            packet.SetHeader(header);
            packet.SetBody(body);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                Packet dataPacket = packet.Build();
                dataPacket.WriteTo(memoryStream);
                _socket.BeginSend(memoryStream.ToArray(), 0, (int)memoryStream.Length, SocketFlags.None, (ar) =>
                {
                    State so = (State)ar.AsyncState;
                    int bytes = _socket.EndSend(ar);
                    Console.WriteLine("SEND: {0}", bytes);
                }, state);
            }
        }

        private void Receive()
        {
            _socket.BeginReceiveFrom(state.buffer, 0, bufSize, SocketFlags.None, ref epFrom, recv = (ar) =>
            {
                State so = (State)ar.AsyncState;
                int bytes = _socket.EndReceiveFrom(ar, ref epFrom);
                _socket.BeginReceiveFrom(so.buffer, 0, bufSize, SocketFlags.None, ref epFrom, recv, so);
                Console.WriteLine("RECV: {0}: {1}, {2}", epFrom.ToString(), bytes, Encoding.ASCII.GetString(so.buffer, 0, bytes));
            }, state);
        }
    }

}
