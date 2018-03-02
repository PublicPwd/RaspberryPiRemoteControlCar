using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace ControllingEnd
{
    public partial class MainWindow : Window
    {
        UdpClient udpClient = null;
        IPEndPoint remote = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Open_Click(object sender, RoutedEventArgs e)
        {
            udpClient = new UdpClient(0);
            remote = new IPEndPoint(IPAddress.Parse("192.168.1.1"), 10000);
            byte[] buffer = Encoding.Default.GetBytes("i");
            udpClient.Send(buffer, buffer.Length, remote);

            Button_Open.IsEnabled = false;
            Button_Go.IsEnabled = true;
            Button_Left.IsEnabled = true;
            Button_Right.IsEnabled = true;
            Button_Back.IsEnabled = true;
            Button_Close.IsEnabled = true;
            Button_Go.Focus();
        }

        private void Button_Go_Click(object sender, RoutedEventArgs e)
        {
            byte[] buffer = Encoding.Default.GetBytes("g");
            udpClient.Send(buffer, buffer.Length, remote);
        }

        private void Button_Left_Click(object sender, RoutedEventArgs e)
        {
            byte[] buffer = Encoding.Default.GetBytes("l");
            udpClient.Send(buffer, buffer.Length, remote);
        }

        private void Button_Right_Click(object sender, RoutedEventArgs e)
        {
            byte[] buffer = Encoding.Default.GetBytes("r");
            udpClient.Send(buffer, buffer.Length, remote);
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            byte[] buffer = Encoding.Default.GetBytes("b");
            udpClient.Send(buffer, buffer.Length, remote);
        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            byte[] buffer = Encoding.Default.GetBytes("s");
            udpClient.Send(buffer, buffer.Length, remote);
            udpClient.Close();

            Button_Open.IsEnabled = true;
            Button_Go.IsEnabled = false;
            Button_Left.IsEnabled = false;
            Button_Right.IsEnabled = false;
            Button_Back.IsEnabled = false;
            Button_Close.IsEnabled = false;
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (Button_Open.IsEnabled)
            {
                return;
            }
            if (e.Key == Key.Up)
            {
                Button_Go_Click(null, null);
            }
            else if (e.Key == Key.Left)
            {
                Button_Left_Click(null, null);
            }
            else if (e.Key == Key.Right)
            {
                Button_Right_Click(null, null);
            }
            else if (e.Key == Key.Down)
            {
                Button_Back_Click(null, null);
            }
            Thread.Sleep(175);
        }
    }
}
