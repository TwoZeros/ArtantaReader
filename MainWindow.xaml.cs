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
using System.IO.Ports;
namespace ComPortApplication
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string Massege;
        byte[] Data;
        public MainWindow()
        {
            
            InitializeComponent();
            ListPort.ItemsSource = SerialPort.GetPortNames();
            SpeedPort.ItemsSource = new string[] { "2400", "4800", "19200" };
            ClosePort.IsEnabled = false;
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            Massege= InputBox.Text;
           Data=MyPort.codder(Massege);
            MyPort.SendMessege(Data);
           Status_Controller.Text=MyPort.answer();
        }

        private void ClosePort_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListPort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void OpenPort_Click(object sender, RoutedEventArgs e)
        {
            int IndexSpeed = SpeedPort.SelectedIndex;
            string namePort = ListPort.SelectedItem.ToString();
            MyPort GoPort = new MyPort(namePort, IndexSpeed);
            GoPort.OpenPort();
            OpenPort.IsEnabled = false;
            ClosePort.IsEnabled = true;
        }
    }
}
