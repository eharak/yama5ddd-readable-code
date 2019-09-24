using System;
using System.IO;

namespace Words
{
    class Program
    {
        static void Main(string[] args)
        {
            PutWords(args[0]);
        }

        /// <summary>
        /// 単語をコンソールに出力する
        /// </summary>
        /// <param name="filepath">単語データのファイルパス</param>
        static void PutWords(string filepath)
        {
            Model.Words words;
            using (var fileStream = new FileStream(filepath, FileMode.Open, FileAccess.Read))
            {
                words = Model.Words.Load(fileStream);
            }

            foreach (var word in words.WordList)
            {
                Console.WriteLine(word.Caption);
            }
        }
    }
}
