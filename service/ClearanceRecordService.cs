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
            
            ICustomsCMS server = XmlRpcInstance.getInstance();

            try
            {
                NumResponse numResponse = server.searchPassengerCount(strWhere[ClearanceRecord.NAME_COLUMN].ToString(), DictionaryToXmlRpcStruct.dictionaryToXmlRpcStruct(strWhere)); ;
                strWhere.Add("start", startIndex);
                strWhere.Add("limit", endIndex);
                GateRecordsResponse res = server.searchPassenger( strWhere[ClearanceRecord.NAME_COLUMN].ToString(), DictionaryToXmlRpcStruct.dictionaryToXmlRpcStruct(strWhere));
                TotalNum = numResponse.all_num;

                 List<GateRecord> gateRecords = new List<GateRecord>(res.records);
                 for (int i = 0; i < gateRecords.Count; i++)
                 {
                     gateRecords[i].unnormal_type_name = zhuhai.util.AbnormalType.getAllAbnormalTypeNames()[gateRecords[i].unnormal_type + 1];
                     gateRecords[i].gate_mode_name = zhuhai.util.GateWorkState.getAllGateWorkStateNames()[gateRecords[i].gate_mode];
                    
                 }
                 return gateRecords;
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
