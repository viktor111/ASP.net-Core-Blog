using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace Blog.Services
{
    public interface ITools
    {
        string IpLookUp(string host);
        string WhatsMyIp();
    }
}
