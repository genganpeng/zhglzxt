using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zhuhai.util
{
    public class DictionaryItem<TKey>
    {
        private TKey key;
        public TKey Key
        {
            get { return key; }
            set { key = value; }
        }
        private string val;
        public string Val
        {
            get { return val; }
            set { val = value; }
        }

        public override string ToString()
        {
            return Val;
        }

        public DictionaryItem()
        {
        }

        public DictionaryItem(TKey k, string v)
        {
            Key = k;
            Val = v;
        }

    }
}
