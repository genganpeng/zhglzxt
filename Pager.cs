using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zhuhai.util
{
    public class Pager<T>
    {
        /// <summary>
        /// 记录总数
        /// </summary>
        private int totalNum;

        public int TotalNum
        {
            get { return totalNum; }
            set { totalNum = value; }
        }

        /// <summary>
        /// 符合条件的记录
        /// </summary>
        private List<T> lists;
        public List<T> Lists
        {
            get { return lists; }
            set { lists = value; }
        }

    }
}
