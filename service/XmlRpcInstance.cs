using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CookComputing.XmlRpc;
using zhuhai.xmlrpc;
using zhuhai.util;

namespace zhuhai.service
{
    public class XmlRpcInstance
    {
        private static ICustomsCMS server = null;

        private XmlRpcInstance()
        {
        }

        public static ICustomsCMS getInstance()
        {
            if (server == null) {
                server = XmlRpcProxyGen.Create<ICustomsCMS>();
                XmlRpcClientProtocol protocol;
                protocol = (XmlRpcClientProtocol)server;
                protocol.Url = "http://" + AppConfig.cmsServer + "/apixmlrpc";
            }

            return server;
        }
    }
}
