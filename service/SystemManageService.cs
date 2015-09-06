﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using zhuhai.model;
using zhuhai.util;

namespace zhuhai.service
{
    public class CurrentUser
    {
        
        private string userName;
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private List<string> permissions;
        /// <summary>
        /// 权限列表
        /// </summary>
        public List<string> Permissions {
            get { return permissions; }
            set { permissions = value;}
        }
    }


    public class SystemManageService : IQueryService
    {
        private List<SystemManage> sms = new List<SystemManage>();
        private static SystemManageService systemManageService = null;
        public static CurrentUser currentUser = new CurrentUser();

        private SystemManageService()
        {
            sms.Add(new SystemManage( 1, "123", "123", 1, "系统管理员", "张老三", "12343445" ));
            sms.Add(new SystemManage( 2, "张三1", "123", 2, "口岸系统管理员", "张老三1", "12343446"));
            sms.Add(new SystemManage( 3, "张三", "123", 3, "口岸监控员", "张老三", "12343445"));
            sms.Add(new SystemManage( 4, "张三1", "123", 1, "系统管理员", "张老三1", "12343445"));
            sms.Add(new SystemManage( 5, "张三", "123", 2, "口岸系统管理员", "张老三", "12343445"));
            sms.Add(new SystemManage( 6, "张三1", "123", 3, "口岸监控员", "张老三1", "12343445"));
            sms.Add(new SystemManage( 7, "张三", "123", 1, "系统管理员", "张老三", "12343445"));
            sms.Add(new SystemManage( 8, "张三1", "123", 2, "口岸系统管理员", "张老三1", "12343445"));
            sms.Add(new SystemManage( 9, "张三", "123", 3, "口岸监控员", "张老三", "12343445"));
            sms.Add(new SystemManage( 10, "张三1", "123", 1, "系统管理员", "张老三1", "12343445"));
            sms.Add(new SystemManage( 11, "张三", "123", 2, "口岸系统管理员", "张老三", "12343445"));
            sms.Add(new SystemManage( 12, "张三", "123", 3, "口岸监控员", "张老三", "12343445"));
            sms.Add(new SystemManage( 13, "张三1", "123", 1, "系统管理员", "张老三1", "12343445"));
            sms.Add(new SystemManage( 14, "张三1", "123", 2, "口岸系统管理员", "张老三1", "12343445"));
        }

        public static SystemManageService getInstance()
        {
            if (systemManageService == null)
            {
                systemManageService = new SystemManageService();
            }

            return systemManageService;
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

        public List<SystemManage> InitDt(IDictionary<string, object> strWhere, int startIndex, int endIndex)
        {
            //实现分页查询的方法， 使用strWhere,startIndex,endIndex, 同时需要返回Pager
            //记录总数量
            TotalNum = sms.Count;

            startIndex = startIndex - 1;
            endIndex = endIndex - 1;
            //当前页需要显示的记录
            int count = endIndex < (TotalNum - 1) ? endIndex : (TotalNum - 1);
            List<SystemManage> retLists = new List<SystemManage>();
            for (int i = startIndex; i <= count; i++)
            {
                retLists.Add(sms[i]);
            }
            return retLists;
        }

        /// <summary>
        /// 根据数据库查询，并返回数据，strWhere是条件
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="startIndex">从1开始</param>
        /// <param name="endIndex">到这为止</param>
        /// <returns></returns>
        public DataTable GetListByPage(IDictionary<string, object> strWhere, int startIndex, int endIndex)
        {
            DataTable dt = new ModelHandler<SystemManage>().FillDataTable(InitDt(strWhere, startIndex, endIndex));
            return dt;
        }

        public Boolean deleteRow(int id)
        {
            foreach (SystemManage sm in sms)
            {
                if (sm.Id == id)
                {
                    sms.Remove(sm);
                    return true;
                }
            }

            return false;
        }

        public Boolean addRow(SystemManage systemManage)
        {
            systemManage.Id = 15;
            sms.Add(systemManage);
            return true;
        }

        public Boolean modifyRow(SystemManage systemManage)
        {
            for (int i = 0; i < sms.Count; i++)
            {
                if (sms[i].Id == systemManage.Id)
                {
                    sms[i] = systemManage;
                    return true;
                }
                    
            }
            return false;
        }

        public SystemManage getRow(int id)
        {
            foreach (SystemManage sm in sms)
            {
                if (sm.Id == id)
                {
                    return sm;
                }
            }
            return null;
        }

        /// <summary>
        /// 根据id和用户名查询符合条件的记录
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="name">用户名</param>
        /// <returns></returns>
        public Boolean findRowByIdAndName(int id, string userName)
        {
            //根据id和姓名查询数据库，全匹配
            foreach (SystemManage sm in sms)
            {
                if (sm.UserName == userName && sm.Id != id)
                {
                    return true;
                }
            }

            return false;
        }

        public List<DictionaryItem<int>> getTypes() {
            List<DictionaryItem<int>> dicList = new List<DictionaryItem<int>>();
            dicList.Add(new DictionaryItem<int>(0, "请选择"));
            dicList.Add(new DictionaryItem<int>(1, "系统管理员"));
            dicList.Add(new DictionaryItem<int>(2, "口岸系统管理员"));
            dicList.Add(new DictionaryItem<int>(3, "口岸监控员"));    

            return dicList;
        }

        /// <summary>
        /// 验证用户名和密码
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>验证是否正确</returns>
        public Boolean validateUserNameAndPassword(string username, string password)
        {
            //赋值当前的用户
            foreach (SystemManage sm in sms)
            {
                if (sm.UserName == username && sm.Password == password)
                {

                    currentUser.UserName = username;
                    currentUser.Permissions = new List<String>() { "abc" };
                    return true;
                }
            }
            return false;
        }
    }
}
