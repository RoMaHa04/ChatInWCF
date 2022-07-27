using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChatClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ChatServise.IChatServiceCallback
    {
        bool isConected = false;
        ChatServise.ChatServiceClient client;
        int ID;
        public MainWindow()
        {
            InitializeComponent();
        }

        void ConectUser()
        {
            if (!isConected)
            {
                client = new ChatServise.ChatServiceClient(new System.ServiceModel.InstanceContext(this));
                ID = client.Connect(tbUserName.Text);
                tbUserName.IsEnabled = false;
                BConDiscon.Content = "Disconect";
                isConected = true;
            }
        }
        void DisconectUser()
        {
            if (isConected)
            {
                client.Disconnect(ID);
                client = null;
                tbUserName.IsEnabled = true;
                BConDiscon.Content = "Conect";
                isConected = false;
            }
        }

        public void MsgCallback(string msg)
        {
            lbChat.Items.Add(msg);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DisconectUser();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isConected) DisconectUser();
            else ConectUser();
        }

        private void thMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (client != null) 
                { 
                    client.SendMessage(tbMessage.Text, ID); 
                    tbMessage.Text = String.Empty;
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        
    }
}
