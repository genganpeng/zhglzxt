using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace zhuhai.service
{
   public  interface IQueryService
    {
        int GetRecordCount();

        DataTable GetListByPage(string strWhere, int startIndex, int endIndex);


    }


}
