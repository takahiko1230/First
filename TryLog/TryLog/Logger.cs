using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TryLog
{
    /// <summary>
    /// アプリケーション独自デバッグ用ログクラス
    /// </summary>
    class Logger
    {
        private static System.IO.StreamWriter _sw = null;

        /// <summary>
        /// ファイル書き出しを開始
        /// </summary>
        public static void Start(XDocument xml)
        {
            XElement pro = xml.Element("Program");
            var path=pro.Element("Path");
            var pat = path.Value;

            Logger._sw = new System.IO.StreamWriter(
                    pat + "App.log", false);

        }

        /// <summary>
        /// ファイル書き出しを終了
        /// </summary>
        public static void Close()
        {
            Logger._sw.Close();
        }

        /// <summary>
        /// 書き込み
        /// </summary>
        /// <param name="value">書き込む値</param>
        public static void WriteLine(object value)
        {
            DateTime dt = DateTime.Now;
            // TODO もしだったら、型を調べて配列やリストの展開を行ったり
            _sw.WriteLine("[{0}]{1}",dt,value);
        }
    }
}