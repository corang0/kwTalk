using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packet
{
    [Serializable]
    public class Header
    {
        public int MSGTYPE { get; set; }
        public int BODYLEN { get; set; }
    }
}
