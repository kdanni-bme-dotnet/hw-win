using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWindow.Models
{
    class ChatterList
    {
        public static readonly ObservableCollection<Chatter> ObservableChatterList =
            new ObservableCollection<Chatter>();


    }
}
