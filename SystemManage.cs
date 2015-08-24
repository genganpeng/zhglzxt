using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zhuhai.vo
{
    public class SystemManage
    {
        /// <summary>
        /// id
        /// </summary>
        private int id;

        public static string ID_COLUMN="id";

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// 用户名
        /// </summary>
        private string userName;
        public static string USERNAME_COLUMN = "userName";

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        /// <summary>
        /// 密码
        /// </summary>
        private string password;
        public static string PASSWORD_COLUMN = "password";

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        /// <summary>
        /// 类型
        /// </summary>
        private int type;
        public static string TYPE_COLUMN = "type";

        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        /// <summary>
        /// 类型名称
        /// </summary>
        private string typeName;
        public static string TYPENAME_COLUMN = "typeName";

        public string TypeName
        {
            get { return typeName; }
            set { typeName = value; }
        }

        /// <summary>
        /// 姓名
        /// </summary>
        private string name;
        public static string NAME_COLUMN = "name";

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// 证件号
        /// </summary>
        private string idCard;
        public static string IDCARD_COLUMN = "idCard";

        public string IdCard
        {
            get { return idCard; }
            set { idCard = value; }
        }

        public SystemManage()
        {
        }

        public SystemManage(int id, string userName, string password, int type, string typeName, string name, string idCard)
        {
            Id = id;
            UserName = userName;
            Password = password;
            Type = type;
            TypeName = typeName;
            Name = name;
            IdCard = idCard;
        }

    }
}
