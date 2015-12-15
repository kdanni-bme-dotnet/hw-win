using ChatWindow.Logic;
using ChatWindow.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Windows;

namespace ChatWindow.ChatService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ChatService" in both code and config file together.
    public class ChatService : IChatService
    {

        public MeshLogic MeshLogic { get; set; }

        public ChatService()
        {
            var dc = Application.Current.MainWindow.DataContext;
            MeshLogic = ((ChatViewModel) dc).MeshLogic;

        }

        public void Chat(string message, string mac_hash)
        {
            if (MeshLogic == null)
                return;
            MeshLogic.handleChatMessage(message, mac_hash);
        }

        public void Hello(Uri address, string nick, string mac_hash)
        {
            if (MeshLogic == null)
                return;
            MeshLogic.registerPeer(address, nick, mac_hash);
        }

        public void Bye(string mac_hash)
        {
            if (MeshLogic == null)
                return;
            MeshLogic.removePeer(mac_hash);
        }
    }
}
