using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zhuhai.xmlrpc;
using zhuhai.util;

namespace zhuhai.service
{
    public class PublishNoticeService
    {
        private static PublishNoticeService publishNoticeService;

        private PublishNoticeService()
        {
        }

        public static PublishNoticeService getInstance()
        {
            if (publishNoticeService == null)
            {
                publishNoticeService = new PublishNoticeService();
            }
            return publishNoticeService;
        }

        public Boolean publishTask(string mesage, int[] gates)
        {
            ICustomsCMS server = XmlRpcInstance.getInstance();
            SysTask task = new SysTask();
            task.type = (int)TaskType.PublishNotice;
            task.notice = mesage.Trim();
            task.target_gates = gates;

            try
            {
                RPCResponse response = server.publishTask(AppConfig.gateSensor, task);
                if (response.error_code == 0)
                {
                    return true;
                }
                else
                {
                    throw new Exception("发布消息错误：" + response.error_msg);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("错误：" + ex.Message);
            }
        }


    }
}
