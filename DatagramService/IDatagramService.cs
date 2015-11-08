using System.ServiceModel;

namespace V37ZEN.DatagramService
{
    [ServiceContract]
    public interface IDatagramService
    {
        [OperationContract(IsOneWay = true)]
        void ProcessDatagram(Datagram datagram);
    }
}
