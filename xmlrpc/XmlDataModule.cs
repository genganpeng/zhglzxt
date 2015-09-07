using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CookComputing.XmlRpc;

namespace zhuhai.xmlrpc
{
    public class XmlDataModule
    {
    }

    public class DBRPCResponse : RPCResponse
    {
        public int dbresult;
        public string dbreason;

        public override string ToString()
        {
            return String.Format(
                "error_code= {0}, error_msg= {1}, dbresult= {2},dbreason={3}",
                this.error_code, this.error_msg, this.dbresult, this.dbreason);
        }
    }

    public class TitleNumResponse : RPCResponse
    {
        public int titlenum;
    }
    public class ImageText_List_Response : RPCResponse
    {
        public ImageTextInfo[] listmodule;

        public override string ToString()
        {
            return String.Format("返回的数量是= {0:G}", listmodule.Length);
        }
    }

    public class Title_Response : RPCResponse
    {
        public TitleInfo[] titlelist;

        public override string ToString()
        {
            return String.Format("返回的数量是= {0:G}", titlelist.Length);
        }
    }

    public class TitleInfo
    {
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public int id;

        public string title;
        public string authod;
        public DateTime last_time;

    }
}
