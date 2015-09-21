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
    /// 工作规程service
    /// </summary>
    class WorkRuleService : IQueryService,IOperateService<CommonText>
    {
        private static WorkRuleService workRuleService = null;

        private WorkRuleService()
        {
        }

        public static WorkRuleService getInstance()
        {
            if (workRuleService == null)
            {
                workRuleService = new WorkRuleService();
            }

            return workRuleService;
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

        public List<WorkRule> InitDt(IDictionary<string, object> strWhere, int startIndex, int endIndex)
        {
            try
            {
                ICustomsCMS server = XmlRpcInstance.getInstance();
                TitleNumResponse titleNumResponse = server.findWorkRuleCount(strWhere[WorkRule.TITLE_COLOMUN].ToString(), DateTime.Parse("0001-01-01"), DateTime.Parse("9999-12-30"));
                if (titleNumResponse.error_code != 0)
                {
                    throw new Exception("连接服务器错误：" + titleNumResponse.error_msg);
                }
                TotalNum = titleNumResponse.titlenum;

                Title_Response title_Response = server.findWorkRuleTitleList(strWhere[WorkRule.TITLE_COLOMUN].ToString(), DateTime.Parse("0001-01-01"), DateTime.Parse("9999-12-30"), startIndex, endIndex);
                TitleInfo[] titlelist = title_Response.titlelist;
                List<WorkRule> wrs = new List<WorkRule>();
                for (int i = 0; i < titlelist.Length; i++ )
                {
                    wrs.Add(new WorkRule(titlelist[i].id, titlelist[i].title, titlelist[i].authod));
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
            DataTable dt = new ModelHandler<WorkRule>().FillDataTable(InitDt(strWhere, startIndex, endIndex));
            return dt;
        }

        public Boolean deleteRow(int id)
        {
            try
            {
                ICustomsCMS server = XmlRpcInstance.getInstance();
                DBRPCResponse dBRPCResponse = server.deleteWorkRule(id);
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

        public Boolean addRow(CommonText commonText)
        {
            ////以下删掉
            ////实例化一个文件流--->与写入文件相关联  
            //FileStream fo = new FileStream("D:/tmp/tmp.rtf", FileMode.Create);
            ////实例化BinaryWriter
            //BinaryWriter bw = new BinaryWriter(fo);
            //bw.Write(commonText.Bytes);
            ////清空缓冲区  
            //bw.Flush();
            ////关闭流  
            //bw.Close();
            //fo.Close(); 

            try
            {
                ICustomsCMS server = XmlRpcInstance.getInstance();
                ImageTextInfo imageTextInfo = new ImageTextInfo();
                imageTextInfo.title = commonText.Title;
                imageTextInfo.content = commonText.Bytes;
                imageTextInfo.authod = SystemManageService.currentUser.UserName;
                DBRPCResponse dBRPCResponse = server.putWorkRule(imageTextInfo);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("错误：" + ex.Message);
            }
            
        }

        public Boolean modifyRow(CommonText commonText)
        {
            try
            {
                ICustomsCMS server = XmlRpcInstance.getInstance();
                ImageTextInfo imageTextInfo = new ImageTextInfo();
                imageTextInfo.id = commonText.Id;
                imageTextInfo.title = commonText.Title;
                imageTextInfo.content = commonText.Bytes;
                imageTextInfo.authod = SystemManageService.currentUser.UserName;
                DBRPCResponse dBRPCResponse = server.modifyWorkRule(imageTextInfo);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("错误：" + ex.Message);
            }

        }

        public CommonText getRow(int id, string title)
        {
            try
            {
                ICustomsCMS server = XmlRpcInstance.getInstance();
                ImageTextInfo imageTextInfo = server.findWorkRulebytitle(title);
                CommonText commonText = new CommonText(imageTextInfo.id, imageTextInfo.title);
                commonText.Bytes = imageTextInfo.content;
                return commonText;
            }
            catch (Exception ex)
            {
                throw new Exception("错误：" + ex.Message);
            }
        }

        /// <summary>
        /// 根据id和标题查询符合条件的记录
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="title">标题</param>
        /// <returns></returns>
        public Boolean findRowByIdAndTitle(int id, string title)
        {
            try
            {
                ICustomsCMS server = XmlRpcInstance.getInstance();
                ImageTextInfo imageTextInfo = server.findWorkRulebytitle(title);
                //查询出结果，同时id不和本身相同
                if (imageTextInfo.id != 0 && imageTextInfo.id != id)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("错误：" + ex.Message);
            }
        }
    }
}
