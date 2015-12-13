using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWindow.Models
{
    class MessageFlow
    {
        public readonly ObservableCollection<Message> ObservableMessageFlow =
            new ObservableCollection<Message>();

    }
}
