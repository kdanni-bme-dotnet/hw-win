using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Discovery;

namespace V37ZEN.DynamicEndpointUtils
{
    public static class BehaviorUtil
    {
        public static ServiceMetadataBehavior GetServiceMetadataBehavior(this Uri uri)
        {
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            if ("https".Equals(uri.Scheme))
            {
                smb.HttpsGetEnabled = true;
                smb.HttpsGetUrl = uri;
            }
            else
            {
                smb.HttpGetEnabled = true;
                smb.HttpGetUrl = uri;
            }
            return smb;
        }

        public static ServiceHost EnableServiceMetadataBehavior(this ServiceHost serviceHost, Uri uri)
        {
            serviceHost.Description.Behaviors.Add(uri.GetServiceMetadataBehavior());
            return serviceHost;
        }

        public static ServiceHost EnableDiscovery( this ServiceHost serviceHost)
        {
            serviceHost.Description.Behaviors.Add(new ServiceDiscoveryBehavior());
            serviceHost.AddServiceEndpoint(new UdpDiscoveryEndpoint());

            return serviceHost;
        }
    }
}
