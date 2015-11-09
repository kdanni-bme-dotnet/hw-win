using System.ServiceModel;
using System.ServiceModel.Channels;

namespace V37ZEN.DynamicEndpointUtils
{
    public static class DisposeCommunicationObject
    {
        public static void Dispose(this CommunicationObject communicationObject)
        {
            if (communicationObject == null)
            {
                return;
            }
            if (CommunicationState.Opened.Equals(communicationObject.State))
            {
                communicationObject.Close();
            }
            else
            {
                communicationObject.Abort();
            }
        }
    }
}
