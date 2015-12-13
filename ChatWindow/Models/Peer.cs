using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWindow.Models
{

    class Peer
    {
        public string MAC_Hash { get; set; }

        public Uri Address { get; set; }

        public Chatter Chatter { get; set; }

    }
}
