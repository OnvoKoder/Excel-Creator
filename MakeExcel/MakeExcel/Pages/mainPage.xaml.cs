using System.Windows;
using System.Windows.Controls;
using MakeExcel.Class.Manage;

namespace MakeExcel.Pages
{
    /// <summary>
    /// Interaction logic for mainPage.xaml
    /// </summary>
    public partial class mainPage : Page
    {
        public mainPage()
        {
            InitializeComponent();
        }

        private void MakeExcel(object sender, RoutedEventArgs e) => Manager.mainFrame.Navigate(new excelPage());

        private void EditPath(object sender, RoutedEventArgs e)=>Manager.mainFrame.Navigate(new xmlPage());

        private void ShowLog(object sender, RoutedEventArgs e) => Manager.mainFrame.Navigate(new logPage());
    }
}
