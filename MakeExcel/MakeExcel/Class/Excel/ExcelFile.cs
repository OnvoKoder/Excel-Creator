namespace MakeExcel.Class.Excel
{
    class ExcelFile
    {
        internal string NameItems { get; set; }
        internal double Price { get; set; }
        internal int Count { get; set; }
        internal string DevileryPoint { get; set; }
        internal ExcelFile(string name, double price, int count, string devilery)
        {
            NameItems = name;
            Price = price;
            Count = count;
            DevileryPoint = devilery;
        }
    }
}
