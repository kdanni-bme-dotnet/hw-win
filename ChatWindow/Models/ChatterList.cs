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
        public readonly ObservableCollection<Chatter> ObservableChatterList =
            new ObservableCollection<Chatter>();

        public readonly Chatter Self = new Chatter
        {
            Nick = Chatter.Anonymous,
            ThisIsMe = true
        };

        public ChatterList()
        {
            ObservableChatterList.Add(Self);
        }
    }
}
