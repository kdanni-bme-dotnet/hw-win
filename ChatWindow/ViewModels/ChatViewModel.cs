using ChatWindow.Logic;
using ChatWindow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWindow.ViewModels
{
    class ChatViewModel
    {

        public ChatterList ChatterList { get; set; }

        public MeshLogic MeshLogic { get; set; }

        public ChatViewModel()
        {
            ChatterList = new ChatterList();
            MeshLogic = new MeshLogic(this);
        }

        public List<Message> GetWelcomeMessage()
        {
            var theList = new List<Message>();

            theList.Add(
                new Message
                {
                    Chatter = ChatterList.Self,
                    Timestamp = DateTime.Now,
                    TextMessage = "Welcome Anonymous!" ,
                    Type = MessageType.Meta
                });

            return theList;
        }
    }
}
