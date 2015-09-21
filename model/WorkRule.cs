using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zhuhai.model
{
    /// <summary>
    /// 工作规程
    /// </summary>
    public class WorkRule : CommonText
    {

        public WorkRule()
        {
            
        }

        public WorkRule(int id, string title) : base(id, title)
        {
        }

        public WorkRule(int id, string title, string operatePeople) : base(id, title, operatePeople)
        {
        }
    }
}
