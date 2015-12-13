using ChatWindow.Logic;
using ChatWindow.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWindow.ViewModels
{
    class ChatViewModel
    {

        public bool IsReady { get; set; }

        public MeshLogic MeshLogic { get; set; }

        public ObservableCollection<Chatter> ChatterList { get; set; }

        public ObservableCollection<Message> MessageFlow { get; set; }

        public readonly Chatter Self = new Chatter
        {
            Nick = Chatter.Anonymous,
            ThisIsMe = true
        };

        public readonly Chatter Application = new Chatter
        {
            Nick = "",
            ThisIsMe = false
        };

        public ChatViewModel()
        {
            ChatterList = new ObservableCollection<Chatter>();
            MessageFlow = new ObservableCollection<Message>();
            
            ChatterList.Add(Self);
            MeshLogic = new MeshLogic(this);

            foreach (Message m in GetWelcomeMessage()) { 
                MessageFlow.Add(m);
            }
        }

        public bool CanSend()
        {
            return IsReady;
        }

        public void SendMessage(String text)
        {
            var m = new Message()
            {
                Chatter = Self,
                TextMessage = text,
                Timestamp = DateTime.UtcNow,    
                Type = MessageType.Public
            };

            this.MessageFlow.Add(m);


        }

        public List<Message> GetWelcomeMessage()
        {
            var theList = new List<Message>();

            theList.Add(
                new Message
                {
                    Chatter = Application,
                    Timestamp = DateTime.UtcNow,
                    TextMessage = "Welcome " + Self.Nick + "!",
                    Type = MessageType.Meta
                });

            theList.Add(
                new Message
                {
                    Chatter = Application,
                    Timestamp = DateTime.UtcNow,
                    TextMessage = "Type /help for help.",
                    Type = MessageType.Meta
                });


            return theList;
        }
    }
}
