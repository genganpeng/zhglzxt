using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using zhuhai.model;
using zhuhai.util;
using System.IO;

namespace zhuhai.service
{
    /// <summary>
    /// 处置预案service
    /// </summary>
    class DisposePlanService : IQueryService,IOperateService<CommonText>
    {
        private List<DisposePlan> disposePlans = new List<DisposePlan>();
        private static DisposePlanService disposePlanService = null;

        private DisposePlanService()
        {
            disposePlans.Add(new DisposePlan(1, "处置预案"));
            disposePlans.Add(new DisposePlan(2, "处置预案1"));
            disposePlans.Add(new DisposePlan(3, "处置预案"));
            disposePlans.Add(new DisposePlan(4, "处置预案1"));
            disposePlans.Add(new DisposePlan(5, "处置预案"));
            disposePlans.Add(new DisposePlan(6, "处置预案1"));
            disposePlans.Add(new DisposePlan(7, "处置预案"));
            disposePlans.Add(new DisposePlan(8, "处置预案1"));
            disposePlans.Add(new DisposePlan(9, "处置预案"));
            disposePlans.Add(new DisposePlan(10, "处置预案1"));
            disposePlans.Add(new DisposePlan(11, "处置预案"));
            disposePlans.Add(new DisposePlan(12, "处置预案"));
            disposePlans.Add(new DisposePlan(13, "处置预案1"));
            disposePlans.Add(new DisposePlan(14, "处置预案1"));
        }

        public static DisposePlanService getInstance()
        {
            if (disposePlanService == null)
            {
                disposePlanService = new DisposePlanService();
            }

            return disposePlanService;
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

        public List<DisposePlan> InitDt(string strWhere, int startIndex, int endIndex)
        {
            //实现分页查询的方法， 使用strWhere,startIndex,endIndex, 同时需要返回Pager
            //记录总数量
            TotalNum = disposePlans.Count;

            startIndex = startIndex - 1;
            endIndex = endIndex - 1;
            //当前页需要显示的记录
            int count = endIndex < (TotalNum - 1) ? endIndex : (TotalNum - 1);
            List<DisposePlan> retLists = new List<DisposePlan>();
            for (int i = startIndex; i <= count; i++)
            {
                retLists.Add(disposePlans[i]);
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
        public DataTable GetListByPage(string strWhere, int startIndex, int endIndex)
        {
            DataTable dt = new ModelHandler<DisposePlan>().FillDataTable(InitDt(strWhere, startIndex, endIndex));
            return dt;
        }

        public Boolean deleteRow(int id)
        {
            foreach (DisposePlan disposePlan in disposePlans)
            {
                if (disposePlan.Id == id)
                {
                    disposePlans.Remove(disposePlan);
                    return true;
                }
            }

            return false;
        }

        public Boolean addRow(CommonText commonText)
        {
            DisposePlan disposePlan = new DisposePlan(15, commonText.Title);
            disposePlans.Add(disposePlan);

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
            for (int i = 0; i < disposePlans.Count; i++)
            {
                if (disposePlans[i].Id == commonText.Id)
                {
                    DisposePlan disposePlan = new DisposePlan(commonText.Id, commonText.Title);
                    disposePlans[i] = disposePlan;

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
            foreach (DisposePlan disposePlan in disposePlans)
            {
                if (disposePlan.Id == id)
                {
                    disposePlan.Bytes = StreamByteTransfer.FileToBytes("D:/tmp/tmp.rtf");
                    return disposePlan;
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
            foreach (DisposePlan disposePlan in disposePlans)
            {
                if (disposePlan.Title == title && disposePlan.Id != id)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
