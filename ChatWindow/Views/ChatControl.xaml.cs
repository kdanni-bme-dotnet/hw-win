﻿using System.Collections.Specialized;
using System.Diagnostics;
using System.Windows.Controls;

namespace ChatWindow.Views
{
    /// <summary>
    /// Interaction logic for ChatControl.xaml
    /// </summary>
    public partial class ChatControl : UserControl
    {
        public ChatControl()
        {
            InitializeComponent();
              
        }

        public void MessageFlowChanged()
        {
            Debug.WriteLine("AutoScroll");
            messageFlowScroll.ScrollToBottom();
        }
    }
}
