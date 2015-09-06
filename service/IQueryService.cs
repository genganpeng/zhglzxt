using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

namespace zhuhai.service
{
   public  interface IQueryService
    {
        int GetRecordCount();

        DataTable GetListByPage(IDictionary<string, object> strWhere, int startIndex, int endIndex);


    }


}
