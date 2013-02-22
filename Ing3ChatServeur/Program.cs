using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Ing3ChatServeur
{
    class Program
    {
        private static List<ComClient> clients = new List<ComClient>();

        static void Main(string[] args)
        {
            Console.WriteLine("Démarrage du serveur");
            //AddressFamily.InterNetwork = IPV4
            //SocketType.Stream = type de donnée à recevoir, ici c'est que de la data (envoi de donnée apres acceptation de la demande), pour se connecter à un serveur web, on utilise le raw (envoi de donnée en meme tant que la demande)
            Socket sockServeur = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPHostEntry cartes = Dns.GetHostEntry("127.0.0.1");
            foreach (IPAddress ip in cartes.AddressList)
            {
                Console.WriteLine(ip.ToString()+"\n");
            }

            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2013);

            Console.ReadLine();
        }
    }
}
