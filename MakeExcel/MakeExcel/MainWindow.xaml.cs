using System;
using System.Windows;
using MakeExcel.Class.Manage;
using MakeExcel.Pages;

namespace MakeExcel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new mainPage());
            Manager.mainFrame=MainFrame;
        }
        private void Back(object sender, RoutedEventArgs e)=>Manager.mainFrame.GoBack();
        private void Frame_ContentRendered(object sender, EventArgs e)
        {
            if(MainFrame.CanGoBack)
                btnBack.Visibility = Visibility.Visible;
            else
                btnBack.Visibility = Visibility.Hidden;
        }
    }
}
