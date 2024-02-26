using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Text;
using Projekt;
using System.Security.Cryptography;
using System.Threading;

namespace Program
{
    class Program
    {
        static void chat(object clientObj)
        {
            //dobivanje streama sa klijent strane i kreiranje objekta reader i writer za citanje i pisanje streamova
            TcpClient client = (TcpClient)clientObj;
            NetworkStream stream = client.GetStream();

            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream);

            try
            {
                while (true)
                {
                    //citanje streama ko je klijent poslao
                    string message = reader.ReadLine();
                    if (message == null) break;
                    
                    Console.WriteLine("Klijent: " + message);

                    string serverPoruka = Console.ReadLine();

                    //slanje streama klijentu koje je server napisao
                    writer.WriteLine(serverPoruka);
                    writer.Flush();                                   
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error s klijentom: " + ex.Message);
            }
            finally
            {
                reader.Close();
                writer.Close();
                client.Close();
            }
        }

        private const int ServerPort = 8080;

        static void Main(string[] args)
        {
            TcpListener server = null;
            //pokretanje TCP servera i spajanje s klijentom preko IP adrese i porta i počinje "slušati" šta klijent šalje
            try
            {
                IPAddress localAddres = IPAddress.Parse("192.168.1.73");
                server = new TcpListener(localAddres, ServerPort);
                server.Start();
                Console.WriteLine("Server pokrenut");

                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Klijent spojen: " + client.Client.RemoteEndPoint);

                    Thread clientThread = new Thread(chat);
                    clientThread.Start(client);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                server?.Stop();
            }
        }
    }
}



