using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Collections.Generic
{
    public static class DictionaryExtension
    {


        public static void Add<TKey, TValue>(this Dictionary<TKey, TValue> dic, params KeyValuePair<TKey, TValue>[] kep)
        {
            foreach (var item in kep)
            {
                dic.Add(item.Key, item.Value);
            }
        }
    }
}
