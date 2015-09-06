using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using zhuhai.model;
using zhuhai.util;
using System.IO;
using System.Collections;

namespace zhuhai.service
{
    /// <summary>
    /// 疫情service
    /// </summary>
    class EpidemicInfoService : IQueryService,IOperateService<CommonText>
    {
        private List<EpidemicInfo> epidemicInfos = new List<EpidemicInfo>();
        private static EpidemicInfoService epidemicInfoService = null;

        private EpidemicInfoService()
        {
            epidemicInfos.Add(new EpidemicInfo(1, "疫情"));
            epidemicInfos.Add(new EpidemicInfo(2, "疫情1"));
            epidemicInfos.Add(new EpidemicInfo(3, "疫情"));
            epidemicInfos.Add(new EpidemicInfo(4, "疫情1"));
            epidemicInfos.Add(new EpidemicInfo(5, "疫情"));
            epidemicInfos.Add(new EpidemicInfo(6, "疫情1"));
            epidemicInfos.Add(new EpidemicInfo(7, "疫情"));
            epidemicInfos.Add(new EpidemicInfo(8, "疫情1"));
            epidemicInfos.Add(new EpidemicInfo(9, "疫情"));
            epidemicInfos.Add(new EpidemicInfo(10, "疫情1"));
            epidemicInfos.Add(new EpidemicInfo(11, "疫情"));
            epidemicInfos.Add(new EpidemicInfo(12, "疫情"));
            epidemicInfos.Add(new EpidemicInfo(13, "疫情1"));
            epidemicInfos.Add(new EpidemicInfo(14, "疫情1"));
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
            //实现分页查询的方法， 使用strWhere,startIndex,endIndex, 同时需要返回Pager
            //记录总数量
            TotalNum = epidemicInfos.Count;

            startIndex = startIndex - 1;
            endIndex = endIndex - 1;
            //当前页需要显示的记录
            int count = endIndex < (TotalNum - 1) ? endIndex : (TotalNum - 1);
            List<EpidemicInfo> retLists = new List<EpidemicInfo>();
            for (int i = startIndex; i <= count; i++)
            {
                retLists.Add(epidemicInfos[i]);
            }
            return retLists;
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
            DataTable dt = new ModelHandler<EpidemicInfo>().FillDataTable(InitDt(strWhere, startIndex, endIndex));
            return dt;
        }

        public Boolean deleteRow(int id)
        {
            foreach (EpidemicInfo epidemicInfo in epidemicInfos)
            {
                if (epidemicInfo.Id == id)
                {
                    epidemicInfos.Remove(epidemicInfo);
                    return true;
                }
            }

            return false;
        }

        public Boolean addRow(CommonText commonText)
        {
            EpidemicInfo epidemicInfo = new EpidemicInfo(15, commonText.Title);
            epidemicInfos.Add(epidemicInfo);

            //以下删掉
            //实例化一个文件流--->与写入文件相关联  
            FileStream fo = new FileStream("D:/tmp/tmp.rtf", FileMode.Create);
            //实例化BinaryWriter
            BinaryWriter bw = new BinaryWriter(fo);
            bw.Write(commonText.Bytes);
            //清空缓冲区  
            bw.Flush();
            //关闭流  
            bw.Close();
            fo.Close(); 

            return true;
        }

        public Boolean modifyRow(CommonText commonText)
        {
            for (int i = 0; i < epidemicInfos.Count; i++)
            {
                if (epidemicInfos[i].Id == commonText.Id)
                {
                    EpidemicInfo epidemicInfo = new EpidemicInfo(commonText.Id, commonText.Title);
                    epidemicInfos[i] = epidemicInfo;

                    //以下删掉
                    //实例化一个文件流--->与写入文件相关联  
                    FileStream fo = new FileStream("D:/tmp/tmp.rtf", FileMode.Create);
                    //实例化BinaryWriter
                    BinaryWriter bw = new BinaryWriter(fo);
                    bw.Write(commonText.Bytes);
                    //清空缓冲区  
                    bw.Flush();
                    //关闭流  
                    bw.Close();
                    fo.Close(); 

                    return true;
                }

            }
            return false;
        }

        public CommonText getRow(int id)
        {
            foreach (EpidemicInfo epidemicInfo in epidemicInfos)
            {
                if (epidemicInfo.Id == id)
                {
                    epidemicInfo.Bytes = StreamByteTransfer.FileToBytes("D:/tmp/tmp.rtf");
                    return epidemicInfo;
                }
            }
            return null;
        }

        /// <summary>
        /// 根据id和标题查询符合条件的记录
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="title">标题</param>
        /// <returns></returns>
        public Boolean findRowByIdAndTitle(int id, string title)
        {
            //根据id和标题查询数据库，全匹配
            foreach (EpidemicInfo epidemicInfo in epidemicInfos)
            {
                if (epidemicInfo.Title == title && epidemicInfo.Id != id)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
