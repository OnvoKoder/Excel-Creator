using System.Windows.Controls;
using MakeExcel.Class.Log;

namespace MakeExcel.Pages
{
    /// <summary>
    /// Interaction logic for logPage.xaml
    /// </summary>
    public partial class logPage : Page
    {
        public logPage()
        {
            InitializeComponent();
            Logs log = new Logs();
            log.ReadFile(out string [] stringLog);
            for (int i = 0; i < stringLog.Length; i++)
                lbLogs.Items.Add(stringLog[i]);
        }
    }
}
