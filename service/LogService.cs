using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zhuhai.xmlrpc;

namespace zhuhai.service
{
    public  class LogService
    {
         private static LogService logService;

         private LogService()
        {
        }

        public static LogService getInstance()
        {
            if (logService == null)
            {
                logService = new LogService();
            }
            return logService;
        }

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="operateContent">操作内容</param>
        /// <param name="operateModule">操作模块</param>
        public void log(string operateContent, string operateModule)
        {
            string operatePeople = SystemManageService.currentUser.UserName;
            try
            {
                ICustomsCMS server = XmlRpcInstance.getInstance();
                Log log = new Log();
                log.operateContent = operateContent;
                log.operateModule = operateModule;
                log.operatePeople = operatePeople;
                RPCResponse rPCResponse = server.log(log);
                if (rPCResponse.error_code != 0)
                {
                    Console.WriteLine("连接服务器错误：" + rPCResponse.error_msg);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("错误：" + ex.Message);
            }


        }
    }
}
