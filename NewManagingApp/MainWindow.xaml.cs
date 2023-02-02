using NewManagingApp.Pages;
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

namespace NewManagingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DashboardPage dashboardPage = new();
        IndeksPage indeksPage = new();
        RaportsPage raportsPage= new();
        MagazinesPage magazinesPage= new();
        FAQPage faqPage= new();
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content= dashboardPage;
        }

        private void LabelMinimalize_MouseDown(object sender, MouseButtonEventArgs e)
        {
            window.WindowState = WindowState.Minimized;
        }

        private void LabelFullWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (window.WindowState == WindowState.Normal)
            {
                window.WindowState = WindowState.Maximized;
            }
            else
            {
                window.WindowState = WindowState.Normal;
            }
        }

        private void LabelClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            window.Close();
        }

        private void DashboardLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = dashboardPage;
        }

        private void IndeksLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = indeksPage;
        }

        private void RaportsLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = raportsPage;
        }

        private void MagazinesLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = magazinesPage;
        }

        private void FAQLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = faqPage;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }
    }
}
