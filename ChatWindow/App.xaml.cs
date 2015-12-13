using ChatWindow.ViewModels;
using ChatWindow.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ChatWindow
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            var view = new MainView();
            var viewmodel = new ChatViewModel();
            view.DataContext = viewmodel;

            view.Show();
            viewmodel.IsReady = true;
                       
            foreach (var m in viewmodel.MessageFlow)
            {
                Debug.WriteLine("[{0}] {1} - {2}", m.Timestamp.ToString(), m.Chatter.Nick, m.TextMessage);
            } 
        }
    }
}
