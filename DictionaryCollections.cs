
using System;
using System.Collections;
using System.Runtime.Serialization;

namespace NetSpell.SpellChecker
{
    #region "'DictionaryCollection' strongly typed collection class"

    [Serializable()]
    public class DictionaryCollection : System.Collections.CollectionBase
    {
        public DictionaryCollection()
        {
        }


        public DictionaryCollection(Dictionary[] dicValue)
        {
            this.AddRange(dicValue);
        }

        public DictionaryCollection(DictionaryCollection dicValue)
        {
            this.AddRange(dicValue);
        }


        public int Add(Dictionary dicValue)
        {
            return List.Add(dicValue);
        }


        public void AddRange(Dictionary[] dicValue)
        {
            for (int intCounter = 0; (intCounter < dicValue.Length); intCounter = (intCounter + 1))
            {
                this.Add(dicValue[intCounter]);
            }
        }

  
        public void AddRange(DictionaryCollection dicValue)
        {
            for (int intCounter = 0; (intCounter < dicValue.Count); intCounter = (intCounter + 1))
            {
                this.Add(dicValue[intCounter]);
            }
        }


        public bool Contains(Dictionary dicValue)
        {
            return List.Contains(dicValue);
        }

       
        public void CopyTo(Dictionary[] dicArray, int intIndex)
        {
            List.CopyTo(dicArray, intIndex);
        }

       
        public new DictionaryEnumerator GetEnumerator()
        {
            return new DictionaryEnumerator(this);
        }

       
        public int IndexOf(Dictionary dicValue)
        {
            return List.IndexOf(dicValue);
        }

       
        public void Insert(int intIndex, Dictionary dicValue)
        {
            List.Insert(intIndex, dicValue);
        }

        
        public void Remove(Dictionary dicValue)
        {
            List.Remove(dicValue);
        }

       
        public Dictionary this[int intIndex]
        {
            get
            {
                return ((Dictionary)(List[intIndex]));
            }
            set
            {
                List[intIndex] = value;
            }
        }

       
        public class DictionaryEnumerator : object, System.Collections.IEnumerator
        {

            private System.Collections.IEnumerator iEnBase;

            private System.Collections.IEnumerable iEnLocal;

            
            public DictionaryEnumerator(DictionaryCollection dicMappings)
            {
                this.iEnLocal = ((System.Collections.IEnumerable)(dicMappings));
                this.iEnBase = iEnLocal.GetEnumerator();
            }

           
            bool System.Collections.IEnumerator.MoveNext()
            {
                return iEnBase.MoveNext();
            }

           
            void System.Collections.IEnumerator.Reset()
            {
                iEnBase.Reset();
            }

           
            public bool MoveNext()
            {
                return iEnBase.MoveNext();
            }

           
            public void Reset()
            {
                iEnBase.Reset();
            }

          
            object System.Collections.IEnumerator.Current
            {
                get
                {
                    return iEnBase.Current;
                }
            }

          
            public Dictionary Current
            {
                get
                {
                    return ((Dictionary)(iEnBase.Current));
                }
            }
        }
    }

    #endregion //('DictionaryCollection' strongly typed collection class)
}
