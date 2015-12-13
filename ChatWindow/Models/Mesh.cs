using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWindow.Models
{
    class Mesh
    {
        public readonly ObservableCollection<Peer> ObservablePeerList =
            new ObservableCollection<Peer>();

        public readonly Peer Self = new Peer {};

    }
}
