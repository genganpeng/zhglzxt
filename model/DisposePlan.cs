using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zhuhai.model
{
    /// <summary>
    /// 处置预案
    /// </summary>
    public class DisposePlan : CommonText
    {

        public DisposePlan()
        {
            
        }

        public DisposePlan(int id, string title, string operatePeople)
            : base(id, title, operatePeople)
        {
        }

        public DisposePlan(int id, string title)
            : base(id, title)
        {
        }
    }
}
