using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace V37ZEN.DatagramService
{

    [DataContract]
    public class Datagram
    {
        [DataMember(IsRequired = true)]
        public string Message
        {
            get; set;
        }

        [DataMember]
        public Dictionary<string, string> Metadata
        {
            get; set;
        }

        [DataMember(IsRequired = true)]
        public DateTime Timestamp
        {
            get; set;
        }

        public override string ToString()
        {
            return string.Format("Datagram: [Message={0}, Timestamp={1}, Metadata={2}]"
                , this.Message, this.Timestamp, this.Metadata.ToString());
        }
    }
}
