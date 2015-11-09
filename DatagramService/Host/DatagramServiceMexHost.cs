using V37ZEN.DynamicEndpointUtils;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace V37ZEN.DatagramService.Host
{
    public class DatagramServiceMexHost : IDisposable
    {
        private ServiceHost Host;
        private Uri _address;

        public Uri Address {
            get { return _address; }
            internal set { _address = value; }
        }

        public DatagramServiceMexHost(Uri address)
        {
            Address = address;
        }

        public void ChangeAddress(Uri address)
        {
            Close();
            Address = address;
            Open();
        }

        public void Open()
        {
            Host = DebugServiceHost.GetDebugServiceHost(typeof(EchoDatagramService),
                typeof(IDatagramService), Address);
            Host.Open();
        }

        public void Close()
        {
            if(Host != null && CommunicationState.Opened.Equals(Host.State))
                Host.Close();
        }

        public ServiceMetadataBehavior GetServiceMetadataBehavior()
        {
            return Address.GetServiceMetadataBehavior();
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
                Host.Dispose();
            }
            // Free any unmanaged objects here.
            //
            disposed = true;
        }
        #endregion
    }
}
