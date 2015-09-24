using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zhuhai.xmlrpc;
using zhuhai.model;
using zhuhai.util;
using System.Data;

namespace zhuhai.service
{
    public  class LogService :  IQueryService
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

        /// <summary>
        /// 返回数据的总数量
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetRecordCount()
        {
            return TotalNum;
        }

        /// <summary>
        /// 符合条件的总记录数量
        /// </summary>
        private int totalNum = 0;
        public int TotalNum
        {
            get { return totalNum; }
            set { totalNum = value; }
        }


        public List<LogRecord> InitDt(IDictionary<string, object> strWhere, int startIndex, int endIndex)
        {
            try
            {
                ICustomsCMS server = XmlRpcInstance.getInstance();

                NumResponse num = server.getLogCount((DateTime)strWhere[LogColumn.para_begin_column], (DateTime)strWhere[LogColumn.para_end_column], strWhere[LogColumn.operatePeople_column].ToString(), "", ""); ;
                TotalNum = num.all_num;

                LogListRPCResponse logListRPCResponse = server.getLog((DateTime)strWhere[LogColumn.para_begin_column], (DateTime)strWhere[LogColumn.para_end_column], strWhere[LogColumn.operatePeople_column].ToString(), "", "", startIndex, endIndex);

                LogRecord[] list = logListRPCResponse.loglists;

              

                List<LogRecord> logs = new List<LogRecord>();
                for (int i = 0; i < list.Length; i++)
                {
                    logs.Add(list[i]);
                }
                return logs;
            }
            catch (Exception ex)
            {
                throw new Exception("错误：" + ex.Message);
            }
        }

        /// <summary>
        /// 根据数据库查询，并返回数据，strWhere是条件
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="startIndex">从1开始，页码</param>
        /// <param name="endIndex">每页的数量</param>
        /// <returns></returns>
        public DataTable GetListByPage(IDictionary<string, object> strWhere, int startIndex, int endIndex)
        {
            DataTable dt = new ModelHandler<LogRecord>().FillDataTable(InitDt(strWhere, startIndex, endIndex));
            return dt;
        }
    }
}
