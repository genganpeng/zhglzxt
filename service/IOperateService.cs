using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zhuhai.service
{
    public interface IOperateService<T>
    {
        /// <summary>
        /// 添加对象，包含bytes
        /// </summary>
        /// <param name="t">对象</param>
        /// <returns></returns>
        Boolean addRow(T t);

        /// <summary>
        /// 修改对象，包含bytes
        /// </summary>
        /// <param name="t">对象</param>
        /// <returns></returns>
        Boolean modifyRow(T t);

        /// <summary>
        /// 根据id获取对象，里面包含bytes（图文）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T getRow(int id);

        /// <summary>
        /// 根据id和title查询，是否有符合要求的记录
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="title">标题</param>
        /// <returns></returns>
        Boolean findRowByIdAndTitle(int id, string title);
    }
}
