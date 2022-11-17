using System;
using OfficeOpenXml;
using System.IO;
using MakeExcel.Class.Log;
using MakeExcel.Class.XML;
using System.Collections.Generic;
using OfficeOpenXml.Style;

namespace MakeExcel.Class.Excel
{
    class Excel
    {
        private Logs log;
        private static List<string> list;
        private string[] arrayHeader;
        private static List<ExcelFile> excelData = new List<ExcelFile>();
        private static int[] countRows;
        internal Excel()
        {
            CloseExcel close = new CloseExcel();
            close.Close();
            log = new Logs();
            list = new List<string>();
            ReadExcel();
        }
        private void ReadExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ReadXML xml = new ReadXML();
            xml.ReadFile(out string[] filePath);
            bool existExcel = CheckFiles(filePath[0]);
            if (existExcel == true)
            {
                countRows = new int[list.Count];
                for(int i = 0; i < list.Count; i++)
                {
                    using (ExcelPackage excel = new ExcelPackage(list[i]))
                    {
                        ExcelWorksheet worksheet = excel.Workbook.Worksheets[0];
                        int rows = worksheet.Dimension.Rows;
                        int columns = worksheet.Dimension.Columns;
                        arrayHeader = new string[columns];
                        string[,] arrayData = new string[rows, columns];
                        for(int j = 1; j <= rows; j++)
                        {
                            for(int k = 1; k <= columns; k++)
                            {
                                if (j == 1)
                                    arrayHeader[k - 1] = worksheet.Cells[j, k].Value.ToString();
                                else
                                    arrayData[j-2, k-1] = worksheet.Cells[j, k].Value.ToString();
                            }
                        }
                        AddList( ref arrayData);
                        countRows[i] = rows;
                    }
                }
                log.WriteFile("|INFO| Поиск и сбор данных из других файлов Excel успешен");
            }
            else
                log.WriteFile("|ERR| Excel нет в данной папке");
        }
        private void AddList(ref string [,] array)
        {
            for(int i = 0; i < array.GetLength(1); i++)
            { 
                excelData.Add(new ExcelFile(array[i,0],Convert.ToDouble(array[i, 1]),Convert.ToInt32(array[i,2]),array[i,3]));
            }
        }
        private bool CheckFiles(in string path)
        {
            if (Directory.Exists(path))
            {
                string [] files = Directory.GetFiles(path);
                for(int i = 0; i < files.Length; i++)
                {
                    if (files[i].EndsWith(".xlsx"))
                        list.Add(files[i]);
                }
                if(list.Count>0)
                    return true;
            }
            return false;
        }
        internal void CreateExcel(string nameFile)
        {
            ReadXML xml = new ReadXML();
            xml.ReadFile(out string[] filePath);
            string path = filePath[0] + @"\"+nameFile+".xlsx";
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using(ExcelPackage excel=new ExcelPackage(path))
            {
                excel.Workbook.Worksheets.Add("Выбор всех");
                var worksheet = excel.Workbook.Worksheets[0];
                worksheet.Cells[1, 1].Value = "таблица - заказ";
                worksheet.Cells[1, 1, 1, 4].Merge = true;
                worksheet.Cells[1, 1, 1, 4].Style.HorizontalAlignment=ExcelHorizontalAlignment.Center;
                worksheet.Cells[1, 1, 1, 4].Style.Font.Size = 16;
                for (int i = 0; i < arrayHeader.Length; i++)
                {
                    worksheet.Cells[2, i + 1].LoadFromText(arrayHeader[i]);
                    worksheet.Cells[8, i + 1].LoadFromText(arrayHeader[i]);
                }
                worksheet.Cells[2, 2].LoadFromCollection(excelData);
                for (int i = 0; i < excelData.Count; i++)
                {
                    worksheet.Cells[i + 3, 1].LoadFromText(excelData[i].NameItems);
                    worksheet.Cells[i + 3, 2].LoadFromText(excelData[i].Price.ToString());
                    worksheet.Cells[i + 3, 3].LoadFromText(excelData[i].Count.ToString());
                    worksheet.Cells[i + 3, 4].LoadFromText(excelData[i].DevileryPoint);
                }
                excel.SaveAs(path);
            }
            log.WriteFile($"|INFO| Сформированы {nameFile}. Расположен {filePath[0]}");
        }
    }
}
