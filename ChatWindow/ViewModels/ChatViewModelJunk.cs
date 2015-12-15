using ChatWindow.Models;
using MVVMExample.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace ChatWindow.ViewModels
{
    partial class ChatViewModel
    {
        private string _text;
        public string MessageText { get { return _text; } set { _text = value; OnPropertyChanged(); } }

        private GridLength _sendbuttonWidth;
        public GridLength SendbuttonWidth
        {
            get { return _sendbuttonWidth; }
            set { _sendbuttonWidth = value; OnPropertyChanged(); }
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
                    TextMessage = "/exit\tClose the application.",
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
        
        #region sendCommand
        private RelayCommand _sendCommand;

        public ICommand SendCommand
        {
            get
            {
                if (_sendCommand == null)
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
