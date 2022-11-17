using MakeExcel.Class.Interface;
using System.IO;
using System.Xml;

namespace MakeExcel.Class.XML
{
    class ReadXML : IUseFile
    {
        public string dir => Directory.GetCurrentDirectory();
        private string path = @"/../../Settings/SavingDirectory.xml";
        static ReadXML()
        {
        }

        public void ReadFile(out string [] filePath)
        {
            filePath = new string[1];
            XmlDocument xml = new XmlDocument();
            xml.Load(dir+path);
            XmlElement xRoot=xml.DocumentElement;
            if (xRoot != null)
                filePath[0] = xml.ChildNodes[1].InnerText;
        }

        public void WriteFile(in string newPath)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(dir + path);
            XmlElement xRoot=xml.DocumentElement;
            if(xRoot != null)
                xml.ChildNodes[1].InnerText = newPath;
            xml.Save(dir+path);
        }
    }
}
