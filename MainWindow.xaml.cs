using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestUI
{
    public partial class MainWindow : Window
    {
        private bool isDragging;
        private Point clickPosition;

        public MainWindow()
        {
            InitializeComponent(); 
            fContainer.Navigate(new System.Uri("Pages/Dashboard.xaml", UriKind.RelativeOrAbsolute));
        }

        // Start: Button Close | Restore | Minimize 
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        // End: Button Close | Restore | Minimize

        private void btnDashboard_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("Pages/Dashboard.xaml", UriKind.RelativeOrAbsolute));
        }

        private void MainGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDragging = true;
            clickPosition = e.GetPosition(this);
            Mouse.Capture((UIElement)sender);
        }

        private void MainGrid_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentPosition = e.GetPosition(this);
                double offsetLeft = currentPosition.X - clickPosition.X;
                double offsetTop = currentPosition.Y - clickPosition.Y;

                this.Left += offsetLeft;
                this.Top += offsetTop;
            }
        }

        private void MainGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
            Mouse.Capture(null);
        }

        private void ChannelButton_Click(object sender, RoutedEventArgs e)
        {
            if(ChannelList.Visibility == Visibility.Visible)
            {
                ChannelList.Visibility = Visibility.Collapsed;
            }
            else
            {
                ChannelList.Visibility = Visibility.Visible;
            }
        }

        private void MessagesButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessagesList.Visibility == Visibility.Visible)
            {
                MessagesList.Visibility = Visibility.Collapsed;
            }
            else
            {
                MessagesList.Visibility = Visibility.Visible;
            }
        }

        private void Path_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }
    }
}
