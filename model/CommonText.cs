using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zhuhai.model
{
    public class CommonText
    {
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
        /// 标题
        /// </summary>
        private string title;
        public static string TITLE_COLOMUN = "title";
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        /// <summary>
        /// 内容
        /// </summary>
        private byte[] bytes;
        public byte[] Bytes 
        {
            get { return bytes; }
            set { bytes = value; }
        }

        public CommonText()
        {
        }

        public CommonText(int id, string title)
        {
            Id = id;
            Title = title;
        }


        

    }
}
