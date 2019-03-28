using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace Morpion
{
    public class NetworkCommunication
    {
        private bool _running;
        private static IPAddress _myIp;
        private static TcpListener _server;
        private static TcpClient _client;
        private string _opponentIP;

        public NetworkCommunication()
        {
            //get ipv4 address and not ipv6
            _myIp = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
            _server = new TcpListener(_myIp, 8008);
            _client = default(TcpClient);
        }

        public void SocketSender(string serverIP, string message)
        {
            int port = 8008;
            TcpClient client = new TcpClient(serverIP, port);
            //on compte le nombre de charactères dans notre message
            int byteCount = Encoding.ASCII.GetByteCount(message);
            byte[] sendData = new byte[byteCount];

            //on converti le tout en utf8
            sendData = Encoding.UTF8.GetBytes(message);

            NetworkStream stream = client.GetStream();
            //on envoie le message
            stream.Write(sendData, 0, sendData.Length);

            stream.Close();
            client.Close();
        }
        public void SocketReader()
        {
            while (_running)
            {
                //on accept les requetes venant du serveur
                _client = _server.AcceptTcpClient();

                //byte contenant le buffer
                byte[] receivedBuffer = new byte[9999];
                NetworkStream stream = _client.GetStream();

                //on lis l'entièreté du message
                stream.Read(receivedBuffer, 0, receivedBuffer.Length);

                StringBuilder msg = new StringBuilder();
                foreach (byte b in receivedBuffer)
                {
                    if (b.Equals(00))
                    {
                        break;
                    }
                    else
                    {
                        msg.Append(Convert.ToChar(b).ToString());
                    }
                }
                //affichage du message, j'affiche le nombre de charactères à la fin pour vérifier que j'ai tout le message
                Console.WriteLine(msg);
            }
            _server.Stop();
        }
        public void StartServer()
        {
            _server.Start();
        }
        public void StopServer()
        {
            _server.Stop();
        }
        public string myIP
        {
            get
            {
                return _myIp.ToString();
            }
        }
        public string opponentIP
        {
            get
            {
                return _opponentIP;
            }
            set
            {
                _opponentIP = value;
            }
        }
        public bool running
        {
            get
            {
                return _running;
            }
            set
            {
                _running = value;
            }
        }
    }
}
