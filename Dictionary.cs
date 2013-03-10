using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;
using System.Collections;

namespace NetSpell.SpellChecker
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    #region Dictionary Object

    public class Dictionary
    {
        private string _FileName;
        private ArrayList _WordList = new ArrayList();


        public Dictionary()
        {
        }


        public Dictionary(string fileName)
        {
            this.FileName = fileName;
            this.Load();
        }


        public void AddWord(string word)
        {
            DoubleMetaphone meta = new DoubleMetaphone(word);
            _WordList.Add(word + "|" + meta.PrimaryCode + "|" + meta.SecondaryCode + "|");
        }


        public void Load()
        {
            if (_FileName.Length > 0)
            {
                FileStream fs = new FileStream(_FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                StreamReader sr = new StreamReader(fs, Encoding.UTF8);

                _WordList.AddRange(sr.ReadToEnd().Split());

                sr.Close();
                fs.Close();
            }
        }


        public void Load(string fileName)
        {
            this.FileName = fileName;
            this.Load();
        }

        /// <summary>
        ///     Saves the Dictionary Word List to a file
        /// </summary>
        public void Save()
        {
            //sorting the word list for binary search
            _WordList.Sort();

            FileStream fs = new FileStream(_FileName, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

            sw.Write(string.Join("\n", (string[])_WordList.ToArray(typeof(string))));

            sw.Close();
            fs.Close();
        }

        
        public void Save(string fileName)
        {
            this.FileName = fileName;
            this.Save();
        }

       
        public string FileName
        {
            get { return _FileName; }
            set { _FileName = value; }
        }

        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ArrayList WordList
        {
            get { return _WordList; }
        }

    }

    #endregion //Dictionary Object
}
