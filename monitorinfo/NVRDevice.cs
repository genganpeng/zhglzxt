using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace zhuhai.monitorinfo
{
    public class NVRDevice
    {
        public string IP;//NVR设备的ip地址
        public int port;//NVR设备的端口号
        public string username;//登录NVR设备的用户名
        public string password;//登录NVR设备的密码
        public int userID=-1;
        public int channelno = 8;//NVR设备的连接的通道数量
        public NVRDevice()
        {
            IP = "localhost";
            port = 8080;
            username = "admin";
            password = "123456";
        }
        
    }
}
