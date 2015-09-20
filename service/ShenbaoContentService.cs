using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using zhuhai.model;
using zhuhai.util;
using System.IO;
using zhuhai.xmlrpc;

namespace zhuhai.service
{
    /// <summary>
    /// 申报内容service
    /// </summary>
    public class ShenbaoContentService : IQueryService
    {
        private static ShenbaoContentService shenbaoContentService = null;

        private ShenbaoContentService()
        {
        }

        public static ShenbaoContentService getInstance()
        {
            if (shenbaoContentService == null)
            {
                shenbaoContentService = new ShenbaoContentService();
            }

            return shenbaoContentService;
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

        public List<ShenboContent> InitDt(IDictionary<string, object> strWhere, int startIndex, int endIndex)
        {
            try
            {
                ICustomsCMS server = XmlRpcInstance.getInstance();
                TitleNumResponse titleNumResponse = server.findReportContenCount(strWhere[ShenboContent.TITLE_COLOMUN].ToString());
                if (titleNumResponse.error_code != 0)
                {
                    throw new Exception("连接服务器错误：" + titleNumResponse.error_msg);
                }
                TotalNum = titleNumResponse.titlenum;

                ReportContent_Response response = server.findReportContentList(strWhere[ShenboContent.TITLE_COLOMUN].ToString(), startIndex, endIndex);
                ReportContent[] titlelist = response.reportcontentlist;
                List<ShenboContent> wrs = new List<ShenboContent>();
                for (int i = 0; i < titlelist.Length; i++ )
                {
                    wrs.Add(new ShenboContent(titlelist[i].id, titlelist[i].content));
                }
                return wrs;
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
            DataTable dt = new ModelHandler<ShenboContent>().FillDataTable(InitDt(strWhere, startIndex, endIndex));
            return dt;
        }

        public Boolean deleteRow(int id)
        {
            try
            {
                ICustomsCMS server = XmlRpcInstance.getInstance();
                DBRPCResponse dBRPCResponse = server.deleteReportContent(id);
                if (dBRPCResponse.error_code != 0)
                {
                    throw new Exception("连接服务器错误：" + dBRPCResponse.error_msg);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("错误：" + ex.Message);
            }

        }

        public Boolean addRow(string content)
        {
            try
            {
                ICustomsCMS server = XmlRpcInstance.getInstance();
                ReportContent reportContent = new ReportContent();
                reportContent.content = content;
                reportContent.operatePeople = SystemManageService.currentUser.UserName;
                DBRPCResponse dBRPCResponse = server.addReportContent(reportContent);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("错误：" + ex.Message);
            }
            
        }

        public Boolean modifyRow(int id, string content)
        {
            try
            {
                ICustomsCMS server = XmlRpcInstance.getInstance();
                ReportContent reportContent = new ReportContent();
                reportContent.id = id;
                reportContent.content = content;
                reportContent.operatePeople = SystemManageService.currentUser.UserName;
                DBRPCResponse dBRPCResponse = server.modifyReportContent(reportContent);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("错误：" + ex.Message);
            }

        }


    }
}
