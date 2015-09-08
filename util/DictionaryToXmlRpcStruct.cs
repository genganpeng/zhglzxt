using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CookComputing.XmlRpc;

namespace zhuhai.util
{
    public class DictionaryToXmlRpcStruct
    {
        public static XmlRpcStruct dictionaryToXmlRpcStruct(IDictionary<string, object> idic)
        {
            XmlRpcStruct s = new XmlRpcStruct();
            foreach (string key in idic.Keys) {
                s.Add(key, idic[key]);
            }
            return s;
        }
    }
}
