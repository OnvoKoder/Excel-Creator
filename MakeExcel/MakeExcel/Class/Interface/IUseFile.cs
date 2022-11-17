namespace MakeExcel.Class.Interface
{
    interface IUseFile
    {
       void ReadFile(out string [] pathFiles);
       void WriteFile(in string newPath);
       string dir { get; }

    }
}
