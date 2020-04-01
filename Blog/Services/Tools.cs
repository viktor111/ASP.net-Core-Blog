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

        //public string PortScan(string website)
        //{
        //    Dictionary<int, string> portsDb = new Dictionary<int, string>();
        //    portsDb.Add(80, "HTTP");
        //    portsDb.Add(311, "MacOS");
        //    portsDb.Add(443, "HTTPS");
        //    portsDb.Add(8080, "HTTP");
        //    portsDb.Add(20, "FTP Data Transferer");
        //    portsDb.Add(21, "FTP Control Command");
        //    portsDb.Add(22, "SSH");
        //    portsDb.Add(23, "Telenet");
        //    portsDb.Add(3306, "MsSql");

          
        //    int[] ports =
        //        {
        //        80,                               
        //        8080,
        //        443,
        //        21,
        //        22,
        //        3306,
        //    };

            
        //}

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
