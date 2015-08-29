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
    class WorkRuleService : IQueryService,IOperateService<CommonText>
    {
        private List<WorkRule> wrs = new List<WorkRule>();
        private static WorkRuleService workRuleService = null;

        private WorkRuleService()
        {
            wrs.Add(new WorkRule(1, "张三"));
            wrs.Add(new WorkRule(2, "张三1"));
            wrs.Add(new WorkRule(3, "张三"));
            wrs.Add(new WorkRule(4, "张三1"));
            wrs.Add(new WorkRule(5, "张三"));
            wrs.Add(new WorkRule(6, "张三1"));
            wrs.Add(new WorkRule(7, "张三"));
            wrs.Add(new WorkRule(8, "张三1"));
            wrs.Add(new WorkRule(9, "张三"));
            wrs.Add(new WorkRule(10, "张三1"));
            wrs.Add(new WorkRule(11, "张三"));
            wrs.Add(new WorkRule(12, "张三"));
            wrs.Add(new WorkRule(13, "张三1"));
            wrs.Add(new WorkRule(14, "张三1"));
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

        public List<WorkRule> InitDt(string strWhere, int startIndex, int endIndex)
        {
            //实现分页查询的方法， 使用strWhere,startIndex,endIndex, 同时需要返回Pager
            //记录总数量
            TotalNum = wrs.Count;

            startIndex = startIndex - 1;
            endIndex = endIndex - 1;
            //当前页需要显示的记录
            int count = endIndex < (TotalNum - 1) ? endIndex : (TotalNum - 1);
            List<WorkRule> retLists = new List<WorkRule>();
            for (int i = startIndex; i <= count; i++)
            {
                retLists.Add(wrs[i]);
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
            DataTable dt = new ModelHandler<WorkRule>().FillDataTable(InitDt(strWhere, startIndex, endIndex));
            return dt;
        }

        public Boolean deleteRow(int id)
        {
            foreach (WorkRule wr in wrs)
            {
                if (wr.Id == id)
                {
                    wrs.Remove(wr);
                    return true;
                }
            }

            return false;
        }

        public Boolean addRow(CommonText commonText)
        {
            WorkRule wr = new WorkRule(15, commonText.Title);
            wrs.Add(wr);

            //实例化一个文件流--->与写入文件相关联  
            FileStream fo = new FileStream("D:/tmp/tmp.doc", FileMode.Create);
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
            for (int i = 0; i < wrs.Count; i++)
            {
                if (wrs[i].Id == commonText.Id)
                {
                    WorkRule wr = new WorkRule(commonText.Id, commonText.Title);
                    wrs[i] = wr;

                    //实例化一个文件流--->与写入文件相关联  
                    FileStream fo = new FileStream("D:/tmp/tmp.doc", FileMode.Create);
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
            foreach (WorkRule wr in wrs)
            {
                if (wr.Id == id)
                {
                    FileStream fs = new FileStream("1.zip", FileMode.Open);
                    //获取文件大小
                    long size = fs.Length;
                    byte[] array = new byte[size];
                    //将文件读到byte数组中
                    fs.Read(array, 0, array.Length);
                    fs.Close();
                    wr.Bytes = array;

                    return wr;
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
            foreach (WorkRule wr in wrs)
            {
                if (wr.Title == title && wr.Id != id)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
