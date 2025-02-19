﻿using System;
using System.Diagnostics;
using System.IO;

namespace Words
{
    class Program
    {
        /// <summary>
        /// アプリケーションエントリーポイント
        /// </summary>
        /// <param name="args">コマンドライン引数</param>
        static void Main(string[] args)
        {
            if (args.Length <= 0)
            {
                PrintUsage();
                return;
            }

            int targetID = Model.Word.INVALID_ID;

            if (args.Length >= 2)
            {
                int.TryParse(args[1], out targetID);
            }

            try
            {
                PutWords(args[0], targetID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// プログラムの使い方を表示する
        /// TODO：将来的には切り出してユーティリティクラス化するのが良さそう
        /// TODO：文字列のリソース化
        /// </summary>
        private static void PrintUsage()
        {
            var appFilePath = Process.GetCurrentProcess().MainModule.FileName;
            var appFileName = Path.GetFileName(appFilePath);
            var errorMessage = string.Format("使い方 : {0} データファイル名のフルパス [出力する単語ID (オプション)]", appFileName);

            Console.WriteLine(errorMessage);
        }

        /// <summary>
        /// 単語をコンソールに出力する
        /// </summary>
        /// <param name="filepath">単語データのファイルパス</param>
        /// <param name="targetID">出力する単語ID</param>
        static void PutWords(string filepath, int targetID)
        {
            var words = ReadDataFile(filepath);

            InitWordsID(words);
            PrintWords(words, targetID);
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

        /// <summary>
        /// 各単語にIDを割り振る
        /// </summary>
        /// <param name="words">単語リストのデータ</param>
        private static void InitWordsID(Model.Words words)
        {
            int id = 1;

            foreach (var word in words.WordList)
            {
                word.ID = id;
                id++;
            }
        }

        /// <summary>
        /// 単語データを画面出力する
        /// </summary>
        /// <param name="words">単語リストのデータ</param>
        /// <param name="targetID">出力する単語ID</param>
        private static void PrintWords(Model.Words words, int targetID)
        {
            bool mustPrint = (targetID == Model.Word.INVALID_ID);

            foreach (var word in words.WordList)
            {
                if (mustPrint || (word.ID == targetID))
                {
                    Console.WriteLine(string.Format("{0}: {1}", word.ID, word.Caption));
                }
            }
        }
    }
}
