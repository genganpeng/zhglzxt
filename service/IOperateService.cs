using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zhuhai.service
{
    public interface IOperateService<T>
    {
        Boolean addRow(T t);

        Boolean modifyRow(T t);

        T getRow(int id);

        Boolean findRowByIdAndTitle(int id, string title);
    }
}
