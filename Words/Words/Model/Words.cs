using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Words.Model
{
    /// <summary>
    /// 単語リストのデータモデル
    /// </summary>
    [Serializable]
    public class Words
    {
        /// <summary>
        /// 単語リスト
        /// </summary>
        public List<Word> WordList { get; set; }

        /// <summary>
        /// データモデルの読込(デシリアライズ)
        /// </summary>
        /// <param name="stream">読込元のストリーム</param>
        /// <returns><see cref="Words"/>のデータモデル</returns>
        public static Words Load(Stream stream)
        {
            var serializer = new XmlSerializer(typeof(Words));
            var words = (Words)serializer.Deserialize(stream);
            return words;
        }

        /// <summary>
        /// データモデルの書込(シリアライズ)
        /// </summary>
        /// <param name="stream">書込先のストリーム</param>
        /// <param name="words"><see cref="Words"/>のデータモデル</param>
        public static void Save(Stream stream, Words words)
        {
            var serializer = new XmlSerializer(typeof(Words));
            serializer.Serialize(stream, words);
        }
    }
}
