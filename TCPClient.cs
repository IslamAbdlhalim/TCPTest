using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPTest
{
    
    public static class Client
    {
        private static string _ipAddress = "127.0.0.1"; //IP Address to connect to
        private static IPAddress _ip = IPAddress.Parse(_ipAddress); //Parses the IP address and converts it to Big Endian format
        private static IPEndPoint _endPoint = new IPEndPoint(_ip, 1975);//End point specifies the IP address and port
        static TcpClient _client = new TcpClient(_endPoint);
        static string _message = "This message is sent over TCP";
        static byte[] _dataBuffer = ASCIIEncoding.ASCII.GetBytes(_message);


        public static void ConnectToSever()
        {
            try
            {
                _client.Connect(Server.EndPoint);
                Console.WriteLine("Client Connected");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void SendMessageStream()
        {
            try
            {
                NetworkStream netStream = _client.GetStream();
                BinaryWriter writer = new BinaryWriter(netStream, Encoding.Default, true);
                writer.Write(_dataBuffer, 0, _dataBuffer.Length);
                Console.WriteLine(netStream.CanWrite);
                Console.WriteLine($"Data is available to be read: {netStream.DataAvailable}");
                try
                {
                    Console.WriteLine(netStream.Seek(0, 0));
                }
                catch { }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        
    }
}
