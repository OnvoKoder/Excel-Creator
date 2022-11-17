using System.Diagnostics;

namespace MakeExcel.Class.Excel
{
    class CloseExcel
    {
        internal void Close()
        {
            Process[] process;
            process = Process.GetProcessesByName("EXCEL");
            foreach (Process proc in process)
                proc.Kill();
        }
    }
}
