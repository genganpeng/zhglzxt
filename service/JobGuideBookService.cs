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
    /// 作业指导书service
    /// </summary>
    class JobGuideBookService : IQueryService,IOperateService<CommonText>
    {
        private List<JobGuideBook> jobGuideBooks = new List<JobGuideBook>();
        private static JobGuideBookService jobGuideBookService = null;

        private JobGuideBookService()
        {
            jobGuideBooks.Add(new JobGuideBook(1, "作业指导书"));
            jobGuideBooks.Add(new JobGuideBook(2, "作业指导书1"));
            jobGuideBooks.Add(new JobGuideBook(3, "作业指导书"));
            jobGuideBooks.Add(new JobGuideBook(4, "作业指导书1"));
            jobGuideBooks.Add(new JobGuideBook(5, "作业指导书"));
            jobGuideBooks.Add(new JobGuideBook(6, "作业指导书1"));
            jobGuideBooks.Add(new JobGuideBook(7, "作业指导书"));
            jobGuideBooks.Add(new JobGuideBook(8, "作业指导书1"));
            jobGuideBooks.Add(new JobGuideBook(9, "作业指导书"));
            jobGuideBooks.Add(new JobGuideBook(10, "作业指导书1"));
            jobGuideBooks.Add(new JobGuideBook(11, "作业指导书"));
            jobGuideBooks.Add(new JobGuideBook(12, "作业指导书"));
            jobGuideBooks.Add(new JobGuideBook(13, "作业指导书1"));
            jobGuideBooks.Add(new JobGuideBook(14, "作业指导书1"));
        }

        public static JobGuideBookService getInstance()
        {
            if (jobGuideBookService == null)
            {
                jobGuideBookService = new JobGuideBookService();
            }

            return jobGuideBookService;
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

        public List<JobGuideBook> InitDt(IDictionary<string, object> strWhere, int startIndex, int endIndex)
        {
            //实现分页查询的方法， 使用strWhere,startIndex,endIndex, 同时需要返回Pager
            //记录总数量
            TotalNum = jobGuideBooks.Count;

            startIndex = startIndex - 1;
            endIndex = endIndex - 1;
            //当前页需要显示的记录
            int count = endIndex < (TotalNum - 1) ? endIndex : (TotalNum - 1);
            List<JobGuideBook> retLists = new List<JobGuideBook>();
            for (int i = startIndex; i <= count; i++)
            {
                retLists.Add(jobGuideBooks[i]);
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
            DataTable dt = new ModelHandler<JobGuideBook>().FillDataTable(InitDt(strWhere, startIndex, endIndex));
            return dt;
        }

        public Boolean deleteRow(int id)
        {
            foreach (JobGuideBook jobGuideBook in jobGuideBooks)
            {
                if (jobGuideBook.Id == id)
                {
                    jobGuideBooks.Remove(jobGuideBook);
                    return true;
                }
            }

            return false;
        }

        public Boolean addRow(CommonText commonText)
        {
            JobGuideBook jobGuideBook = new JobGuideBook(15, commonText.Title);
            jobGuideBooks.Add(jobGuideBook);

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
            for (int i = 0; i < jobGuideBooks.Count; i++)
            {
                if (jobGuideBooks[i].Id == commonText.Id)
                {
                    JobGuideBook jobGuideBook = new JobGuideBook(commonText.Id, commonText.Title);
                    jobGuideBooks[i] = jobGuideBook;

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
            foreach (JobGuideBook jobGuideBook in jobGuideBooks)
            {
                if (jobGuideBook.Id == id)
                {
                    jobGuideBook.Bytes = StreamByteTransfer.FileToBytes("D:/tmp/tmp.rtf");
                    return jobGuideBook;
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
            foreach (JobGuideBook jobGuideBook in jobGuideBooks)
            {
                if (jobGuideBook.Title == title && jobGuideBook.Id != id)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
