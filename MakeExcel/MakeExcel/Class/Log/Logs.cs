using System;
using System.IO;
using System.Linq;
using MakeExcel.Class.Interface;

namespace MakeExcel.Class.Log
{
    internal class Logs : IUseFile
    {
        public string dir => Directory.GetCurrentDirectory();
        private string path = @"/../../Logs/log.log";
        public void ReadFile(out string [] logs)
        {
            logs = new string[10];
            if (!File.Exists(dir + path))
                logs[0] = "Нет логов";
            else
            {
                for (int i = File.ReadLines(dir + path).Count() - 1; i > -1; i--)
                    logs[(File.ReadLines(dir + path).Count() - 1) - i] = File.ReadLines(dir + path).ElementAt(i).Trim();
            }
        }
        public void WriteFile(in string message)
        {
            if(!File.Exists(dir+path))
                File.Create(dir+path).Close();
            using(StreamWriter writer=new StreamWriter(dir + path,true))
            {
                writer.WriteLine(DateTime.Now+" "+message);
            }
        }
    }
}
