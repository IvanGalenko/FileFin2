using System.Drawing;
using System.Reflection.Metadata.Ecma335;

namespace FileFin2
{
    internal class Program
    {
        static long size = 0;
        static void Main(string[] args)
        {
            Console.Write("Введите путь до папки: ");
            string path = Console.ReadLine();
            DirFileSize(path);
            Console.WriteLine("Конечный размер: " + size);
        }
        static void DirFileSize(string dirName)
        {
            if (Directory.Exists(dirName))
            {
                try
                {
                    string[] dirs = Directory.GetDirectories(dirName);
                    foreach (string d in dirs)
                    {
                        DirFileSize(d);
                    }
                    string[] files = Directory.GetFiles(dirName);
                    foreach (string s in files)
                    {
                        var fileinfo = new FileInfo(s);
                        long filesize = fileinfo.Length;
                        Console.WriteLine(s + " размер: " + filesize);
                        size += filesize;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex}");
                }
            }
        }
    }
}