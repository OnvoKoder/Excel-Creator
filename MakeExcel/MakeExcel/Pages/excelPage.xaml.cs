using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MakeExcel.Class.Excel;
namespace MakeExcel.Pages
{
    /// <summary>
    /// Interaction logic for excelPage.xaml
    /// </summary>
    public partial class excelPage : Page
    {
        public excelPage()
        {
            InitializeComponent();
        }

        private void tbxName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            btnSave.IsEnabled = true;
        }

        private void MakeExcel(object sender, RoutedEventArgs e)
        {
            spProgress.Visibility = Visibility.Visible;
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerAsync();
            Excel excel = new Excel();
            excel.CreateExcel(tbxName.Text);
        }
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                (sender as BackgroundWorker).ReportProgress(i);
                Thread.Sleep(100);
            }
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbMakeExcel.Value = e.ProgressPercentage;
            tbPercent.Text = pbMakeExcel.Value <= 25 ? "Сбор данных" : pbMakeExcel.Value <= 80 ? "Формирование" : pbMakeExcel.Value <= 99 ? "Сохранение" : "Сформирован";
        }
    }
}
