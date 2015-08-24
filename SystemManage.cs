using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zhuhai.vo
{
    public class SystemManage
    {
        private string id;

        public static string ID_COLUMN="id";

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string userName;
        public static string USERNAME_COLUMN = "userName";

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private string password;
        public static string PASSWORD_COLUMN = "password";

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private string type;
        public static string TYPE_COLUMN = "type";

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        private string typeName;

        public string TypeName
        {
            get { return typeName; }
            set { typeName = value; }
        }
        private string name;
        public static string NAME_COLUMN = "name";

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
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

        public SystemManage(string id, string userName, string password, string type, string name, string idCard)
        {
            Id = id;
            UserName = userName;
            Password = password;
            Type = type;
            Name = name;
            IdCard = idCard;
        }

    }
}
