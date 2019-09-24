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
            var words = ReadDataFile(filepath);

            foreach (var word in words.WordList)
            {
                Console.WriteLine(word.Caption);
            }
        }

        /// <summary>
        /// 単語データファイルを読み込む
        /// </summary>
        /// <param name="filepath">単語データのファイルパス</param>
        /// <returns>単語リストのデータ</returns>
        private static Model.Words ReadDataFile(string filepath)
        {
            using (var fileStream = new FileStream(filepath, FileMode.Open, FileAccess.Read))
            {
                return Model.Words.Load(fileStream);
            }
        }
    }
}
