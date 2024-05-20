using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpListener serverSocet = new TcpListener(7000);
            Console.WriteLine("Server started");
            TcpClient clientSocet = serverSocet.AcceptTcpClient();

            clientSocet.Close();
            serverSocet.Stop();
            Console.WriteLine("Server stopped");

            Console.ReadKey();
        }
    }
}
