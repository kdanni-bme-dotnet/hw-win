using ChatWindow.ChatService;
using ChatWindow.Models;
using ChatWindow.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Discovery;
using System.Text;

namespace ChatWindow.Logic
{
    public class MeshLogic
    {
        protected ServiceHost ServiceHost { get; set; }

        public readonly Dictionary<string, Peer> Mesh =
            new Dictionary<string, Peer>();

        public readonly Peer Self = new Peer { };

        public ChatViewModel ChatViewModel { get; set; }

        private readonly BackgroundWorker startupWorker = new BackgroundWorker();

        public MeshLogic(ChatViewModel chatViewModel)
        {
            ChatViewModel = chatViewModel;

            Self.Chatter = ChatViewModel.Self;
            
            startupWorker.DoWork += startupWorkerDoWork;
            startupWorker.RunWorkerCompleted += startupWorkerCompleted;
            
        }

        public void registerPeer(Uri address, string nick, string mac_hash)
        {
            var peer = new Peer()
            {
                Address = address,
                MAC_Hash = mac_hash,
                Chatter = new Chatter(nick)
            };

            Mesh.Add(mac_hash,peer);

            ChatViewModel.ChatterList.Add(peer.Chatter);

        }

        public void handleChatMessage(string message, string mac_hash)
        {
            if ( message == null || mac_hash == null)
                return;

            var peer = Mesh[mac_hash];

            if (peer == null)
                return;

            var messageObject = new Message()
            {
                Chatter = peer.Chatter,
                TextMessage = message,
                Type = MessageType.Public,
                UtcTimestamp = DateTime.UtcNow
            };

            ChatViewModel.MessageFlow.Add(messageObject);

        }

        public void removePeer(string mac_hash)
        {
            if (mac_hash == null)
                return;

            var peer = Mesh[mac_hash];

            if (peer == null)
                return;

            ChatViewModel.ChatterList.Remove(peer.Chatter);
            Mesh.Remove(mac_hash);
        }

        public void openServiceHost()
        {
            if (Self.Address == null)
                return;

            ServiceHost = new ServiceHost(typeof(ChatService.ChatService), Self.Address);
            
            ServiceHost.AddServiceEndpoint(typeof(IChatService), new BasicHttpBinding(), Self.Address);

            ServiceHost.Description.Behaviors.Add(new ServiceDiscoveryBehavior());
            ServiceHost.AddServiceEndpoint(new UdpDiscoveryEndpoint());

            ServiceHost.Open();
        }

        public void closeServiceHost()
        {
            ServiceHost.Close();
        }

        public void startupAsync()
        {
            startupWorker.RunWorkerAsync();
        }

        private void startupWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string address = ConfigurationManager.AppSettings["local.address"];

                var uri = new Uri(address);

                Debug.WriteLine(uri);

                Self.Address = uri;
                Self.MAC_Hash = generateMAC_Hash(uri.ToString());

                Mesh.Add(Self.MAC_Hash, Self);

                openServiceHost();
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex);
            }
        }

        private void startupWorkerCompleted(object sender,
                                               RunWorkerCompletedEventArgs e)
        {
            
        }

        public static string generateMAC_Hash(string salt)
        {

            IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();


            string concatenatedMACs = (salt==null)?"":salt;

            foreach (NetworkInterface adapter in nics)
            {
                PhysicalAddress address = adapter.GetPhysicalAddress();
                concatenatedMACs += address.ToString();
            }

            Debug.WriteLine(concatenatedMACs);

            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.Unicode.GetBytes(concatenatedMACs);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            Debug.WriteLine(sb.ToString());

            return sb.ToString();

        }
    }
}
