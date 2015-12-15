using ChatWindow.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ChatWindow.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void ChatControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                var viewModel = (ChatViewModel)DataContext;

                viewModel.MessageFlow.CollectionChanged +=
                    new NotifyCollectionChangedEventHandler(MessageFlowChanged);

            }
            catch (Exception ex)
            {
                //No auto scroll if something wrong, but it's not fatal.
                Debug.WriteLine(ex);
            }
        }

        private void MessageFlowChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            ChatControl.MessageFlowChanged();
        }
    }
}
