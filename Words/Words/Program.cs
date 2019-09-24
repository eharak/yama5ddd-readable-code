using System;
using System.IO;

namespace Words
{
    class Program
    {
        static void Main(string[] args)
        {
            Model.Words words;
            using (var fileStream = new FileStream(args[0], FileMode.Open, FileAccess.Read))
            {
                words = Model.Words.Load(fileStream);
            }

            foreach(var word in words.WordList)
            {
                Console.WriteLine(word.Caption);
            }
        }
    }
}
