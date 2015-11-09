using System;

namespace V37ZEN.DatagramService
{
    public class EchoDatagramService : IDatagramService
    {

        public void ProcessDatagram(Datagram datagram)
        {
            Console.WriteLine(datagram.ToString());
        }
    }
}
