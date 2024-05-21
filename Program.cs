using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpListener serverSocet = new TcpListener(IPAddress.Any, 7000);
            serverSocet.Start();
            Console.WriteLine("Server started");

            TcpClient clientSocet = serverSocet.AcceptTcpClient();
            NetworkStream stream = clientSocet.GetStream();

            string message = "<h1>Hello !<h1>\n";
            byte[] bytes = Encoding.ASCII.GetBytes(message);
            //Encoding.ASCII.GetBytes(message);

            stream.Write(bytes, 0, bytes.Length);
            stream.Flush();

            clientSocet.Close();
            serverSocet.Stop();
            Console.WriteLine("Server stopped");

            Console.ReadKey();
        }
    }
}
