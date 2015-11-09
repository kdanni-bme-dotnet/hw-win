using DynamicEndpointUtils;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace V37ZEN.DatagramService.Host
{
    class DatagramServiceMexHost :IDisposable
    {
        private ServiceHost host;

        public Uri Address { get; set; }

        public ServiceMetadataBehavior getServiceMetadataBehavior()
        {
            return ServiceMetadataBehaviorUtil.getServiceMetadataBehavior(this.Address);
        }

        public void Open()
        {
            this.host = ServiceMetadataBehaviorUtil.DebugServiceHost(typeof(EchoDatagramService),this.Address);
            this.host.Open();
        }

        public void Close()
        {
            this.host.Close();
        }

        #region Disposable
        // Flag: Has Dispose already been called?
        bool disposed = false;

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }
            if (disposing)
            {
                // Free any other managed objects here.
                //
                this.host.Close();
            }
            // Free any unmanaged objects here.
            //
            disposed = true;
        }
        #endregion
    }
}
