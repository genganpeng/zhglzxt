using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zhuhai.model
{
    /// <summary>
    /// 申报内容
    /// </summary>
    public class ShenboContent : CommonText
    {

        public ShenboContent()
        {
            
        }

        public ShenboContent(int id, string title)
            : base(id, title)
        {
        }
    }
}
