using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using MakeExcel.Class.XML;
using MakeExcel.Class.Log;

namespace MakeExcel.Pages
{
    /// <summary>
    /// Interaction logic for xmlPage.xaml
    /// </summary>
    public partial class xmlPage : Page
    {
        public xmlPage()
        {
            InitializeComponent();
            ReadXML xml = new ReadXML();
            xml.ReadFile(out string [] folder);
            if (folder[0] != "")
            {
                if (folder[0].Length < 40)
                    tbText.Text = "Путь к файлам: " + folder[0];
                else
                    tbText.Text = "Путь к файлам: " + Environment.NewLine + folder[0];
            }              
            else
            {
                tbText.Text = "Укажите путь к файлам";
                tbText.Foreground = new SolidColorBrush(Colors.Red); ;
            }
        }

        private void ChooseFolder(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            string folder = dialog.SelectedPath;
            ReadXML xml = new ReadXML();
            xml.WriteFile(folder);
            tbText.Text = "Путь к файлам: " + folder;
            if (tbText.Text.Length > 40)
                tbText.Text = "Путь к файлам: " + Environment.NewLine + folder;
            tbText.Foreground= new SolidColorBrush(Colors.Black);
            Logs logs = new Logs();
            logs.WriteFile($"|INFO| было изменено место, откуда надо брать файлы. Новое место: {folder}");
        }
    }
}
