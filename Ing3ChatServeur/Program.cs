using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

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

            //permet de faire la liaison entre la socket et le point de terminaison
            sockServeur.Bind(iep);

            //socket à l'écoute
            sockServeur.Listen(10);
            Console.WriteLine("Socket à l'écoute");

            //Pour tester: telnet 127.0.0.1 2013
            while (true)
            {
                Console.WriteLine("En attente d'une nouvelle connexion");
                //Sockserveur est un socket qui ne fait qu'écouter
                //sockServeur.Accept();
                Socket socketNouveauClient = sockServeur.Accept();
                Console.WriteLine("Client connecté");
                ComClient client = new ComClient(socketNouveauClient);
                lock (client)
                {
                    clients.Add(client);
                }
                Thread th = new Thread(new ThreadStart(client.Recevoir));
                th.Start();
            }
            Console.ReadLine();
        }

        public static void EnvoyerATous(object message)
        {
            //le fait de faire lock permet de proteger la variable clients pendant le foreach
            lock (clients)
            {
                foreach (ComClient ce in clients)
                {
                    ce.Envoyer((string)message);
                }
            }
        }
    }
}
