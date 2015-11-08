using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

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

            if(this.Metadata != null && this.Metadata.Count > 0)
            { 
                StringBuilder str = new StringBuilder();
                str.AppendFormat("Datagram: [ Message = {0}, Timestamp = {1}, ", this.Message, this.Timestamp);
                str.Append("Metadata =[ ");
                foreach (var item in this.Metadata)
                {
                    str.AppendFormat("{0} = '{1}' ", item.Key, item.Value);
                }
                str.Append("]]");
                return str.ToString();
            }
            else{
                return string.Format("Datagram: [ Message = {0}, Timestamp = {1} ]"
                    , this.Message, this.Timestamp);
            }
        }
    }
}
