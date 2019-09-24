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
        /// 単語の見出し
        /// </summary>
        public string Caption { get; set; }
    }
}
