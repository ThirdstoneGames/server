using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerCore
{
    class Program
    {
        static void Main(string[] args) 
        {
            // DNS
            string host = Dns.GetHostName();
            IPHostEntry ipHost = Dns.GetHostEntry(host);
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint endPoint = new IPEndPoint(ipAddr, 7000);
            
            Socket listenSocket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            listenSocket.Bind(endPoint);

            listenSocket.Listen(10);

            while(true)
            {
                Console.WriteLine("Listening...");
                Socket clientSocket = listenSocket.Accept();

                byte[] recvBuff = new byte[1024];
                int recvBytes;
                recvBytes = clientSocket.Receive(recvBuff);
                string recvData = Encoding.UTF8.GetString(recvBuff, 0, recvBytes ); // 0: redcvBuff 의 시작 인덱스
                Console.WriteLine($"[From Client] {recvData}");

                byte[] sendBuff = Encoding.UTF8.GetBytes("Welcome to MMORPG Server !");
            }
        }
    }
}