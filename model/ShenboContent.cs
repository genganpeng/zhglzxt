using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zhuhai.model
{
    /// <summary>
    /// 申报内容
    /// </summary>
    public class ShenboContent
    {

        public ShenboContent()
        {
            
        }

         /// <summary>
        /// id
        /// </summary>
        private int id;

        public static string ID_COLUMN="id";

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// 内容
        /// </summary>
        private string content;
        public static string CONTENT_COLOMUN = "content";
        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        /// <summary>
        /// 内容
        /// </summary>
        private string content_en;
        public static string CONTENT_EN_COLOMUN = "content_en";
        public string Content_en
        {
            get { return content_en; }
            set { content_en = value; }
        }

        public static string LOGICID_COLUMN = "logicid";
        private int logicid;
        public int Logicid
        {
            get;
            set;
        }


        public ShenboContent(int id, int logicid, string content, string content_en)
        {
            Id = id;
            Content = content;
            Content_en = content_en;
            Logicid = logicid;
        }


    }
}
