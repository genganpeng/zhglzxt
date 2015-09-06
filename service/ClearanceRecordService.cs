using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using zhuhai.model;
using zhuhai.util;
using zhuhai.xmlrpc;
using CookComputing.XmlRpc;

namespace zhuhai.service
{
    public class ClearanceRecordService : IQueryService
    {
        private static ClearanceRecordService clearanceRecordService = null;

        private ClearanceRecordService()
        {
        }

        public static ClearanceRecordService getInstance()
        {
            if (clearanceRecordService == null)
            {
                clearanceRecordService = new ClearanceRecordService();
            }

            return clearanceRecordService;
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

        /// <summary>
        /// 返回数据的总数量
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetRecordCount()
        {
            return TotalNum;
        }

        public List<GateRecord> InitDt(IDictionary<string, object> strWhere, int startIndex, int endIndex)
        {
            //实现分页查询的方法， 使用strWhere,startIndex,endIndex, 同时需要返回Pager
            //记录总数量
            TotalNum = 100;

            ICustomsCMS server = XmlRpcInstance.getInstance();

            try
            {
                GateRecordsResponse res = server.searchPassenger(AppConfig.gateSensor, strWhere[ClearanceRecord.NAME_COLUMN].ToString(), new XmlRpcStruct());
                TotalNum = res.records_num;
                if (res.error_code == 0)
                {
                    startIndex = startIndex - 1;
                    endIndex = endIndex - 1;
                    //当前页需要显示的记录
                    int count = endIndex < (TotalNum - 1) ? endIndex : (TotalNum - 1);
                    List<GateRecord> gateRecords = new List<GateRecord>(res.records);
                    return gateRecords;
                }
                else
                {
                    Console.WriteLine("ClearanceRecordService - InitDt" + res.error_msg);
                }
            }
            catch(Exception ex) {
                Console.WriteLine("ClearanceRecordService - InitDt" + ex.Message);
            }

            return null;
           
        }

        /// <summary>
        /// 根据数据库查询，并返回数据，strWhere是条件
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="startIndex">从1开始</param>
        /// <param name="endIndex">到这为止</param>
        /// <returns></returns>
        public DataTable GetListByPage(IDictionary<string, object> strWhere, int startIndex, int endIndex)
        {
            DataTable dt = new ModelHandler<GateRecord>().FillDataTable(InitDt(strWhere, startIndex, endIndex));
            return dt;
        }

    }
}
