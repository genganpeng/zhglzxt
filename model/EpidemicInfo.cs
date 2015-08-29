using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zhuhai.model
{
    /// <summary>
    /// 疫情信息
    /// </summary>
    public class EpidemicInfo : CommonText
    {

        public EpidemicInfo()
        {
            
        }

        public EpidemicInfo(int id, string title)
            : base(id, title)
        {
        }
    }
}
