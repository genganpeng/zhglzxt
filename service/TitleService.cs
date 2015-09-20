using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zhuhai.xmlrpc;
using zhuhai.util;

namespace zhuhai.service
{
    public class TitleService
    {
        private static TitleService titleService;

        private TitleService()
        {
        }

        public static TitleService getInstance()
        {
            if (titleService == null)
            {
                titleService = new TitleService();
            }
            return titleService;
        }

        public string getTitle()
        {
            try
            {
                ICustomsCMS server = XmlRpcInstance.getInstance();
                TitleNameRPCResponse r = server.getTitle("100");
                if (r.error_code != 0)
                {
                    throw new Exception("连接服务器错误：" + r.error_msg);
                }
                return r.value;
            }
            catch (Exception ex)
            {
                throw new Exception("错误：" + ex.Message);
            }
            
        }


        public Boolean setTitle(string titleName) 
        {
            try
            {
                ICustomsCMS server = XmlRpcInstance.getInstance();
                RPCResponse rPCResponse = server.setTitle("100", titleName);
                if (rPCResponse.error_code != 0)
                {
                    throw new Exception("连接服务器错误：" + rPCResponse.error_msg);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("错误：" + ex.Message);
            }
        }
    }
}
