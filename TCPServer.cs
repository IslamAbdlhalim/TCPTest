using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPTest
{
    public static class Server
    {
        private static string _ipAddress = "127.0.0.1"; //IP Address to connect to
        private static IPAddress _ip = IPAddress.Parse(_ipAddress); //Parses the IP address and converts it to Big Endian format
        private static IPEndPoint _endPoint = new IPEndPoint(_ip, 1976);//End point specifies the IP address and port
        private static TcpListener _server = new TcpListener(_endPoint);
        private static TcpClient? _serverClient;

        public static IPEndPoint EndPoint => _endPoint;

        public static void StartListening()
        {
            try
            {
                _server.Start();
                Console.WriteLine("Server Started");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void AcceptConnection()
        {
            try
            {
                _serverClient = _server.AcceptTcpClient();
                Console.WriteLine("Connection Accepted");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public static void ReadMessageStream()
        {
            byte[] dataRead = new byte[500];
            NetworkStream netStream = _serverClient.GetStream();
            try
            {
                netStream.Position = 0;
            }
            catch (Exception e) {}
            Console.WriteLine($"Data is available to be read: {netStream.DataAvailable}");
            netStream.Read(dataRead, 0, 29);
            Console.WriteLine("Message Read");
            string messageRecieved = Encoding.ASCII.GetString(dataRead);
            Console.WriteLine(messageRecieved);
        }
    }
}

