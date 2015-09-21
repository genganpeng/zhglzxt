using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zhuhai.model
{
    /// <summary>
    /// 作业指导书
    /// </summary>
    public class JobGuideBook : CommonText
    {

        public JobGuideBook()
        {
            
        }

        public JobGuideBook(int id, string title)
            : base(id, title)
        {
        }

        public JobGuideBook(int id, string title, string operatePeople) : base(id, title, operatePeople)
        {
        }
    }
}
