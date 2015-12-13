using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWindow.Models
{
    enum MessageType
    {
        Public,
        Private,
        Meta
    }

    class Message
    {
        public Chatter Chatter { get; set; }

        public string TextMessage { get; set; }

        public MessageType Type { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
