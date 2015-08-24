using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using zhuhai.vo;
using zhuhai.util;

namespace zhuhai.service
{
    class SystemManageService : IQueryService
    {
        private DataTable dt = new DataTable();
        private static SystemManageService systemManageService = null;

        private SystemManageService()
        {
            dt.Columns.Add(SystemManage.ID_COLUMN, typeof(int));
            dt.Columns.Add(SystemManage.USERNAME_COLUMN, typeof(string));
            dt.Columns.Add(SystemManage.PASSWORD_COLUMN, typeof(string));
            dt.Columns.Add(SystemManage.TYPE_COLUMN, typeof(string));
            dt.Columns.Add("typeName", typeof(string));
            dt.Columns.Add(SystemManage.NAME_COLUMN, typeof(string));
            dt.Columns.Add(SystemManage.IDCARD_COLUMN, typeof(string));
            dt.Rows.Add(new object[] { 1, "张三", "123", "1", "系统管理员", "张老三", "12343445" });
            dt.Rows.Add(new object[] { 2, "张三1", "123", "2", "口岸系统管理员", "张老三1", "12343446" });
            dt.Rows.Add(new object[] { 3, "张三", "123", "3", "口岸监控员", "张老三", "12343445" });
            dt.Rows.Add(new object[] { 4, "张三1", "123", "1", "系统管理员", "张老三1", "12343445" });
            dt.Rows.Add(new object[] { 5, "张三", "123", "2", "口岸系统管理员", "张老三", "12343445" });
            dt.Rows.Add(new object[] { 6, "张三1", "123", "3", "口岸监控员", "张老三1", "12343445" });
            dt.Rows.Add(new object[] { 7, "张三", "123", "1", "系统管理员", "张老三", "12343445" });
            dt.Rows.Add(new object[] { 8, "张三1", "123", "2", "口岸系统管理员", "张老三1", "12343445" });
            dt.Rows.Add(new object[] { 9, "张三", "123", "3", "口岸监控员", "张老三", "12343445" });
            dt.Rows.Add(new object[] { 10, "张三1", "123", "1", "系统管理员", "张老三1", "12343445" });
            dt.Rows.Add(new object[] { 11, "张三", "123", "2", "口岸系统管理员", "张老三", "12343445" });
            dt.Rows.Add(new object[] { 12, "张三", "123", "3", "口岸监控员", "张老三", "12343445" });
            dt.Rows.Add(new object[] { 13, "张三1", "123", "1", "系统管理员", "张老三1", "12343445" });
            dt.Rows.Add(new object[] { 14, "张三1", "123", "2", "口岸系统管理员", "张老三1", "12343445" });
        }

        public static SystemManageService getInstance()
        {
            if (systemManageService == null)
            {
                systemManageService = new SystemManageService();
            }

            return systemManageService;
        }

        private string strWhere;
        public string StrWhere
        {
            get { return strWhere; }
            set { strWhere = value; }
        }

        /// <summary>
        /// 符合条件的总记录数量
        /// </summary>
        private int totalNum = 0;
        public int TotalNum
        {
            get { return totalNum; }
            set { totalNum = value; }
        }

        /// <summary>
        /// 返回数据的总数量
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetRecordCount()
        {
            return TotalNum;
        }

        public DataTable InitDt()
        {
            return dt;
        }

        /// <summary>
        /// 根据数据库查询，并返回数据，strWhere是条件
        /// </summary>
        /// <param name="startIndex">从1开始</param>
        /// <param name="endIndex">到这为止</param>
        /// <returns></returns>
        public DataTable GetListByPage(int startIndex, int endIndex)
        {
            //实现分页查询的方法， 使用strWhere, 同时需要返回记录总数
            DataTable dt = InitDt();
            DataRow[] rows = dt.Select(StrWhere);
            //记录总数量
            TotalNum = rows.Length;

            startIndex = startIndex - 1;
            endIndex = endIndex - 1;

            DataTable NewTable = dt.Clone();
            //当前页需要显示的记录
            int count = endIndex < (rows.Length - 1) ? endIndex : (rows.Length - 1);
            for (int i = startIndex; i <= count; i++)
            {
                NewTable.ImportRow((DataRow)rows[i]);
            }

            return NewTable;
        }

        public Boolean deleteRow(string id)
        {
            foreach (DataRow row in dt.Rows)
            {
                if (row[SystemManage.ID_COLUMN].ToString() == id)
                {
                    dt.Rows.Remove(row);
                    return true;
                }
            }

            return false;
        }

        public Boolean addRow(SystemManage systemManage)
        {
            dt.Rows.Add(new object[] { 15, systemManage.UserName, systemManage.Password, systemManage.Type, systemManage.Type, systemManage.Name, systemManage.IdCard });
            return true;
        }

        public Boolean modifyRow(SystemManage systemManage)
        {
            foreach (DataRow row in dt.Rows)
            {
                if (row[SystemManage.ID_COLUMN].ToString() == systemManage.Id)
                {
                    row[SystemManage.USERNAME_COLUMN] = systemManage.UserName;
                    row[SystemManage.PASSWORD_COLUMN] = systemManage.Password;
                    row[SystemManage.TYPE_COLUMN] = systemManage.Type;
                    row[SystemManage.NAME_COLUMN] = systemManage.Name;
                    row[SystemManage.IDCARD_COLUMN] = systemManage.IdCard;
                    return true;
                }
            }
            return true;
        }

        public SystemManage getRow(string id)
        {
            foreach (DataRow row in dt.Rows)
            {
                if (row[SystemManage.ID_COLUMN].ToString() == id)
                {
                    SystemManage sm = new SystemManage(row[SystemManage.ID_COLUMN].ToString(),
                        row[SystemManage.USERNAME_COLUMN].ToString(), row[SystemManage.PASSWORD_COLUMN].ToString(),
                        row[SystemManage.TYPE_COLUMN].ToString(), row[SystemManage.NAME_COLUMN].ToString(),
                        row[SystemManage.IDCARD_COLUMN].ToString());
                    return sm;
                }
            }
            return null;
        }

        public List<DictionaryItem<string>> getTypes() {
            List<DictionaryItem<string>> dicList = new List<DictionaryItem<string>>();
            dicList.Add(new DictionaryItem<string>("0", "请选择"));
            dicList.Add(new DictionaryItem<string>("1", "系统管理员"));
            dicList.Add(new DictionaryItem<string>("2", "口岸系统管理员"));
            dicList.Add(new DictionaryItem<string>("3", "口岸监控员"));    

            return dicList;
        }
    }
}
