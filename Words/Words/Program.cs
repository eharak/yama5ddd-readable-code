using System;
using System.IO;

namespace Words
{
    class Program
    {
        static void Main(string[] args)
        {
            Model.Word word;
            using (var fileStream = new FileStream(args[0], FileMode.Open, FileAccess.Read))
            {
                word = Model.Word.Load(fileStream);
            }
            Console.WriteLine(word.Caption);
        }
    }
}
