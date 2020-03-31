using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Blog.Services
{
    public class Tools : ITools
    {
        public string IpLookUp(string host)
        {           
            IPHostEntry hostEntry = Dns.GetHostEntry(host);

            return hostEntry.AddressList[0].ToString();
        }

        public string WhatsMyIp()
        {
            string localIP;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address.ToString();
            }
            return localIP;
        }
    }
}
