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

            while (true)
            {
                TcpClient clientSocet = serverSocet.AcceptTcpClient();
                NetworkStream stream = clientSocet.GetStream();

                
                byte[] buffer = new byte[256];
                int length = stream.Read(buffer, 0, buffer.Length);
                string request = Encoding.ASCII.GetString(buffer, 0, length);
                Console.WriteLine("Got request: " + request);


                string message = "Length of uour request: " + request + " = " + request.Length;
                byte[] bytes = Encoding.ASCII.GetBytes(message);
                stream.Write(bytes, 0, bytes.Length);
                stream.Flush();

                Console.WriteLine("Sent message " + message);
                clientSocet.Close();
            }
            

            
            //serverSocet.Stop();
            //Console.WriteLine("Server stopped");

            //Console.ReadKey();
        }
    }
}
