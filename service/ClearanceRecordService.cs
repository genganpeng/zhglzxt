using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using zhuhai.model;
using zhuhai.util;
using zhuhai.xmlrpc;

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

            startIndex = startIndex - 1;
            endIndex = endIndex - 1;
            //当前页需要显示的记录
            int count = endIndex < (TotalNum - 1) ? endIndex : (TotalNum - 1);
            List<GateRecord> gateRecords = new List<GateRecord>();

            for (int i = startIndex; i <= count; i++)
            {
                GateRecord gateRecord = new GateRecord();
                gateRecord.name = "测试" + i;
                gateRecord.gate_id = i;
                gateRecord.nvr_begintime = new DateTime();
                gateRecord.temperature = 30 + i;
                gateRecord.nuclear = 20 + i;
                gateRecord.nuclear_detail = "铱";
                gateRecord.nationality = "中国";
                gateRecord.sex = "男";
                gateRecord.birth_date = new DateTime(1988, 11,15);
                gateRecord.id_type = 1;
                gateRecord.id_code = "12121212121212";
                gateRecord.issue_date = new DateTime();
                gateRecord.expire_date = new DateTime();
                gateRecord.id_photo_id = i;
                gateRecords.Add(gateRecord);

            }
            return gateRecords;
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
