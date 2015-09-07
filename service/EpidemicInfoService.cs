﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using zhuhai.model;
using zhuhai.util;
using System.IO;
using System.Collections;
using zhuhai.xmlrpc;

namespace zhuhai.service
{
    /// <summary>
    /// 疫情service
    /// </summary>
    class EpidemicInfoService : IQueryService,IOperateService<CommonText>
    {
        private static EpidemicInfoService epidemicInfoService = null;

        private EpidemicInfoService()
        {
        }

        public static EpidemicInfoService getInstance()
        {
            if (epidemicInfoService == null)
            {
                epidemicInfoService = new EpidemicInfoService();
            }

            return epidemicInfoService;
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

        public List<EpidemicInfo> InitDt(IDictionary<string, object> strWhere, int startIndex, int endIndex)
        {
            try
            {
                ICustomsCMS server = XmlRpcInstance.getInstance();
                TitleNumResponse titleNumResponse = server.findEpideInfoCount(strWhere[CommonText.TITLE_COLOMUN].ToString(), DateTime.Parse("0001-01-01"), DateTime.Parse("9999-12-30"));
                if (titleNumResponse.error_code != 0)
                {
                    throw new Exception("连接服务器错误：" + titleNumResponse.error_msg);
                }
                TotalNum = titleNumResponse.titlenum;

                Title_Response title_Response = server.findEpideInfoTitleList(strWhere[CommonText.TITLE_COLOMUN].ToString(), DateTime.Parse("0001-01-01"), DateTime.Parse("9999-12-30"), startIndex, endIndex);
                TitleInfo[] titlelist = title_Response.titlelist;
                List<EpidemicInfo> es = new List<EpidemicInfo>();
                for (int i = 0; i < titlelist.Length; i++)
                {
                    es.Add(new EpidemicInfo(titlelist[i].id, titlelist[i].title));
                }
                return es;
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
            DataTable dt = new ModelHandler<EpidemicInfo>().FillDataTable(InitDt(strWhere, startIndex, endIndex));
            return dt;
        }

        public Boolean deleteRow(int id)
        {
            try
            {
                ICustomsCMS server = XmlRpcInstance.getInstance();
                DBRPCResponse dBRPCResponse = server.deleteEpideInfo(id);
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
            try
            {
                ICustomsCMS server = XmlRpcInstance.getInstance();
                ImageTextInfo imageTextInfo = new ImageTextInfo();
                imageTextInfo.title = commonText.Title;
                imageTextInfo.content = commonText.Bytes;
                imageTextInfo.authod = SystemManageService.currentUser.UserName;
                DBRPCResponse dBRPCResponse = server.putEpideInfo(imageTextInfo);
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
                DBRPCResponse dBRPCResponse = server.modifyEpideInfo(imageTextInfo);
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
                ImageTextInfo imageTextInfo = server.findEpideInfobytitle(title);
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
                ImageTextInfo imageTextInfo = server.findEpideInfobytitle(title);
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
