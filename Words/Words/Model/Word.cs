using System;
using System.IO;
using System.Xml.Serialization;

namespace Words.Model
{
    /// <summary>
    /// 単語のデータモデル
    /// </summary>
    [Serializable]
    public class Word
    {
        /// <summary>
        /// 無効な単語ID
        /// </summary>
        public const int INVALID_ID = 0;

        /// <summary>
        /// 単語のID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 単語の見出し
        /// </summary>
        public string Caption { get; set; }
    }
}
