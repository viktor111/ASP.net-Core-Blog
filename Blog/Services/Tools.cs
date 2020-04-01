using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Blog.Services
{
    public class Tools : ITools
    {
        private HttpClient _client;

        public Tools(HttpClient client)
        {
            _client = client;
        }

        public string IpLookUp(string host)
        {           
            IPHostEntry hostEntry = Dns.GetHostEntry(host);

            return hostEntry.AddressList[0].ToString();
        }

        public async Task<List<string>> PortScanAsync(string website)
        {
            var values = new Dictionary<string, string>
            {
              { "target", "testphp.vulnweb.com" },
            };

            var content = new FormUrlEncodedContent(values);
            try
            {
                var response = await _client.PostAsync("http://localhost:3000/api/scan", content);

                // "80|HTTP;443|HTTPS;80|HTTP;"
                var responseString = await response.Content.ReadAsStringAsync();

                var res = responseString.Split(";");

                return res.ToList();
            }
            catch (Exception e)
            {

                return new List<string>() 
                { 
                    e.Message
                };
            }           
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
