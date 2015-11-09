using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace DynamicEndpointUtils
{
    public class ServiceMetadataBehaviorUtil
    {
        public static ServiceMetadataBehavior getServiceMetadataBehavior(Uri address)
        {
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            if (Uri.UriSchemeHttps.Equals(address.Scheme))
            {
                smb.HttpsGetEnabled = true;
                smb.HttpsGetUrl = address;
            }
            else
            {
                smb.HttpGetEnabled = true;
                smb.HttpGetUrl = address;
            }
            return smb;
        }

        public static ServiceHost DebugServiceHost(Type serviceType, Uri endPointAddress)
        {
            var host = new ServiceHost(serviceType, endPointAddress);

            if (Uri.UriSchemeHttps.Equals(endPointAddress.Scheme))
            {
                var wsb = new WSHttpBinding();
                wsb.Security.Mode = SecurityMode.Transport;
                host.AddServiceEndpoint(serviceType,
                    wsb, endPointAddress);
            }
            else
            {
                host.AddServiceEndpoint(serviceType,
                    new BasicHttpBinding(), endPointAddress);
            }

            host.Description.Behaviors.Add(getServiceMetadataBehavior(endPointAddress));

            return host;
        }
    }
}
