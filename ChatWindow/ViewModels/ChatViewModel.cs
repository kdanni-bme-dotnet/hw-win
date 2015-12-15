using ChatWindow.Logic;
using ChatWindow.Models;
using MVVMExample.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ChatWindow.ViewModels
{
    class ChatViewModel : INotifyPropertyChanged
    {

        public bool IsReady { get; set; }

        public MeshLogic MeshLogic { get; set; }

        public ObservableCollection<Chatter> ChatterList { get; set; }

        public ObservableCollection<Message> MessageFlow { get; set; }

        private string _text;
        public string MessageText { get { return _text; } set { _text = value; OnPropertyChanged(); }}

        private GridLength _sendbuttonWidth;
        public GridLength SendbuttonWidth { get { return _sendbuttonWidth; }
            set { _sendbuttonWidth = value; OnPropertyChanged(); }}

        public readonly Chatter Self = new Chatter { Nick = Chatter.Anonymous, ThisIsMe = true };

        public readonly Chatter Application = new Chatter { Nick = "", ThisIsMe = false };

        public ChatViewModel()
        {
            ChatterList = new ObservableCollection<Chatter>();
            MessageFlow = new ObservableCollection<Message>();
            
            ChatterList.Add(Self);
            MeshLogic = new MeshLogic(this);
            MeshLogic.startupAsync();

            MessageText = "";
            SendbuttonWidth = new GridLength(0, GridUnitType.Star);
            foreach (Message m in GetWelcomeMessage()) { 
                MessageFlow.Add(m);
            }
        }

        #region sendCommand
        private RelayCommand _sendCommand;

        public ICommand SendCommand
        {
            get
            {
                if(_sendCommand == null)
                {
                    _sendCommand = new RelayCommand(
                        l => SendMessage(), l => CanSend());
                }
                return _sendCommand;
            }
        }

        private bool CanSend()
        {
            return IsReady;
        }
        #endregion

        private void SendMessage()
        {
            if (MessageText != null && MessageText.StartsWith("/"))
            {
                HandleChatCommand();
            }
            else
            {
                var m = new Message()
                {
                    Chatter = Self,
                    TextMessage = MessageText,
                    Timestamp = DateTime.UtcNow,
                    Type = MessageType.Public
                };

                this.MessageFlow.Add(m);
            }
            MessageText = "";
        }

        private void HandleChatCommand()
        {
            if ("/help".Equals(MessageText))
            {
                foreach (Message m in GetHelpMessage())
                {
                    MessageFlow.Add(m);
                }
                return;
                    
            }
            if ("/ea".Equals(MessageText))
            {
                if(SendbuttonWidth.Value == 0)
                {
                    SendbuttonWidth = new GridLength(1, GridUnitType.Star);
                } else
                {
                    SendbuttonWidth = new GridLength(0, GridUnitType.Star);
                }
            }
        }

        #region messages
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

        public List<Message> GetHelpMessage()
        {
            var theList = new List<Message>();

            theList.Add(
                new Message
                {
                    Chatter = Application,
                    Timestamp = DateTime.UtcNow,
                    TextMessage = "/help\tDisplay this help.",
                    Type = MessageType.Meta
                });
            theList.Add(
                new Message
                {
                    Chatter = Application,
                    Timestamp = DateTime.UtcNow,
                    TextMessage = "/ea\tEasy access.",
                    Type = MessageType.Meta
                });

            return theList;
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
