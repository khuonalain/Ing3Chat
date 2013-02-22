using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Ing3ChatServeur
{
    class ComClient
    {
        private string pseudo;

        public string Pseudo
        {
            get { return pseudo; }
            set { pseudo = value; }
        }

        private Socket socketCom;

        public Socket SocketCom
        {
            get { return socketCom; }
            set { socketCom = value; }
        }

        public ComClient(Socket s)
        {
            this.socketCom = s;
        }

        public void Recevoir()
        {

        }

        public void Envoyer(string message)
        {

        }
    }
}
