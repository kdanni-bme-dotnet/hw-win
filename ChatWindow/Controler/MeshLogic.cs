using ChatWindow.Models;
using ChatWindow.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatWindow.Logic
{
    class MeshLogic
    {
        public Mesh Mesh { get; set; }

        public ChatViewModel ChatViewModel { get; set; }

        private readonly BackgroundWorker startupWorker = new BackgroundWorker();

        public MeshLogic(ChatViewModel chatViewModel)
        {
            ChatViewModel = chatViewModel;
            Mesh = new Mesh();

            Mesh.Self.Chatter = ChatViewModel.Self;
            //Mesh.Self.MAC_Hash = generateMAC_Hash();

            Mesh.Self.MAC_Hash = generateMAC_Hash() + Guid.NewGuid().ToString();

            startupWorker.DoWork += startupWorkerDoWork;
            startupWorker.RunWorkerCompleted += startupWorkerCompleted;


        }

        public void startupAsync()
        {
            startupWorker.RunWorkerAsync();
        }

        private void startupWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            int i = 10;
            while (true)
            {
                Debug.WriteLine("Worker is working...");
                
                Thread.Sleep(2000);
                i--;

                if(i < 1)
                {
                    break;
                }
            }
        }

        private void startupWorkerCompleted(object sender,
                                               RunWorkerCompletedEventArgs e)
        {
            Debug.WriteLine("Worker is completed.");
            ChatViewModel.MessageFlow.Add(
                new Message
                {
                    TextMessage = "Worker is completed."
                }
                );
        }

        public static string generateMAC_Hash()
        {

            IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

            string concatenatedMACs = "";

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
