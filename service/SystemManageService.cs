using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using zhuhai.model;
using zhuhai.util;
using zhuhai.xmlrpc;

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

        /// <summary>
        /// 角色名
        /// </summary>
        public string Rolename
        {
            get;
            set;
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
        private static SystemManageService systemManageService = null;
        public static CurrentUser currentUser = new CurrentUser();

        private SystemManageService()
        {
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
            try
            {
                ICustomsCMS server = XmlRpcInstance.getInstance();
                NumResponse numResponse = server.findAllUserCount(strWhere[SystemManage.USERNAME_COLUMN].ToString());
                if (numResponse.error_code != 0)
                {
                    throw new Exception("连接服务器错误：" + numResponse.error_msg);
                }
                TotalNum = numResponse.all_num;

                UsercheckListRPCResponse response = server.findAllUserByUserid(strWhere[SystemManage.USERNAME_COLUMN].ToString(), startIndex, endIndex);
                Usercheck[] titlelist = response.listmodule;
                List<SystemManage> wrs = new List<SystemManage>();
                for (int i = 0; i < titlelist.Length; i++)
                {
                    string rolename = getRoleName(Int32.Parse(titlelist[i].rolename));
                    wrs.Add(new SystemManage(titlelist[i].id, titlelist[i].username, titlelist[i].password, Int32.Parse(titlelist[i].rolename), rolename, titlelist[i].realname, titlelist[i].idcard));
                }
                return wrs;
            }
            catch (Exception ex)
            {
                Console.WriteLine("错误：" + ex.Message);
                return null;
            }
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
            try
            {
                ICustomsCMS server = XmlRpcInstance.getInstance();
                DBRPCResponse dBRPCResponse = server.DeleteUser(id);
                if (dBRPCResponse.error_code != 0)
                {
                    throw new Exception("连接服务器错误：" + dBRPCResponse.error_msg);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("错误：" + ex.Message);
            }
        }

        public Boolean addRow(SystemManage systemManage)
        {
            try
            {
                ICustomsCMS server = XmlRpcInstance.getInstance();
                Usercheck usercheck = new Usercheck();
                usercheck.idcard = systemManage.IdCard;
                usercheck.password = systemManage.Password;
                usercheck.realname = systemManage.Name;
                usercheck.username = systemManage.UserName;
                usercheck.rolename = systemManage.Type.ToString();

                DBRPCResponse dBRPCResponse = server.AddUser(usercheck);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("错误：" + ex.Message);
            }
        }

        public Boolean modifyRow(SystemManage systemManage)
        {
            try
            {
                ICustomsCMS server = XmlRpcInstance.getInstance();
                Usercheck usercheck = new Usercheck();
                usercheck.idcard = systemManage.IdCard;
                usercheck.password = systemManage.Password;
                usercheck.realname = systemManage.Name;
                usercheck.username = systemManage.UserName;
                usercheck.rolename = systemManage.Type.ToString();
                usercheck.id = systemManage.Id;

                DBRPCResponse dBRPCResponse = server.ModifyUser(usercheck);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("错误：" + ex.Message);
            }
        }


        /// <summary>
        /// 根据id和用户名查询符合条件的记录
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="name">用户名</param>
        /// <returns></returns>
        public Boolean findRowByIdAndName(int id, string userName)
        {

            try
            {
                ICustomsCMS server = XmlRpcInstance.getInstance();
                UsercheckRPCResponse usercheckRPCResponse = server.findUser(userName);
                if (usercheckRPCResponse.id != 0 && usercheckRPCResponse.id != id) return true;
                return false;


            }
            catch (Exception ex)
            {
                throw new Exception("错误：" + ex.Message);
            }
            try
            {
                ICustomsCMS server = XmlRpcInstance.getInstance();

                UsercheckListRPCResponse response = server.findAllUserByUserid(userName, 1, 1);
                Usercheck[] titlelist = response.listmodule;
                
            }
            catch (Exception ex)
            {
                throw new Exception("错误：" + ex.Message);
            }
        }

        public List<DictionaryItem<int>> getTypes() {
            List<DictionaryItem<int>> dicList = new List<DictionaryItem<int>>();
            dicList.Add(new DictionaryItem<int>(0, "请选择"));
            dicList.Add(new DictionaryItem<int>(100, "系统管理员"));
            dicList.Add(new DictionaryItem<int>(200, "口岸系统管理员"));
            dicList.Add(new DictionaryItem<int>(300, "口岸监控员"));    

            return dicList;
        }

        public string getRoleName(int roleId)
        {
            switch (roleId)
            {
                case 100:
                    return "系统管理员";
                case 200:
                    return "口岸系统管理员";
                case 300:
                    return "口岸监控员";
            }
            return "";
        }

        public int getIndex(int roleId)
        {
            switch (roleId)
            {
                case 100:
                    return 1;
                case 200:
                    return 2;
                case 300:
                    return 3;
            }
            return 0;
        }

        /// <summary>
        /// 验证用户名和密码
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>验证是否正确</returns>
        public Boolean validateUserNameAndPassword(string username, string password)
        {
            try
            {
                ICustomsCMS server = XmlRpcInstance.getInstance();
                Usercheck usercheck = new Usercheck();
                usercheck.username = username;
                usercheck.password = password;
                UsercheckRPCResponse usercheckRPCResponse = server.checkUser(usercheck);
                if (usercheckRPCResponse.username != "")
                {
                    currentUser.UserName = usercheckRPCResponse.username;
                    currentUser.Rolename = usercheckRPCResponse.rolename;
                    return true;
                }
                else
                {
                    return false;
                }
               
                
            }
            catch (Exception ex)
            {
                throw new Exception("错误：" + ex.Message);
            }
        }
    }
}
