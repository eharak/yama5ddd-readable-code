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

        /// <summary>
        /// データモデルの読込(デシリアライズ)
        /// </summary>
        /// <param name="stream">読込元のストリーム</param>
        /// <returns><see cref="Word"/>のデータモデル</returns>
        public static Word Load(Stream stream)
        {
            var serializer = new XmlSerializer(typeof(Word));
            var word = (Word)serializer.Deserialize(stream);
            return word;
        }

        /// <summary>
        /// データモデルの書込(シリアライズ)
        /// </summary>
        /// <param name="stream">書込先のストリーム</param>
        /// <param name="words"><see cref="Word"/>のデータモデル</param>
        public static void Save(Stream stream, Word word)
        {
            var serializer = new XmlSerializer(typeof(Word));
            serializer.Serialize(stream, word);
        }
    }
}
