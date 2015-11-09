using System;
using System.ServiceModel;

namespace V37ZEN.DynamicEndpointUtils
{
    public static class ServiceHostUtil
    {

        public static ServiceHost AddBasicHttpEndpoint(this ServiceHost serviceHost, Type contractType, Uri endPointAddress)
        {
            if (endPointAddress == null)
                return serviceHost;

            if ("http".Equals(endPointAddress.Scheme))
            {
                serviceHost.AddServiceEndpoint(contractType,
                    new BasicHttpBinding(), endPointAddress);
            }

            return serviceHost;
        }

        public static ServiceHost AddHttpsEndpoint(this ServiceHost serviceHost, Type contractType, Uri endPointAddress)
        {
            if (endPointAddress == null)
                return serviceHost;

            if ("https".Equals(endPointAddress.Scheme))
            {
                var wsb = new WSHttpBinding();
                wsb.Security.Mode = SecurityMode.Transport;
                serviceHost.AddServiceEndpoint(contractType,
                    wsb, endPointAddress);
            }

            return serviceHost;
        }
    }
}
