using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace zhuhai.monitorinfo
{
    class HCControler
    {
        NVRDevice device;

        public bool login()
        {
            CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();

            //登录设备 Login the device
            device.userID = CHCNetSDK.NET_DVR_Login_V30(device.IP, device.port, device.username, device.password, ref DeviceInfo);
            if (device.userID < 0)
            {
                uint iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                string str = "NET_DVR_Login_V30 failed, error code= " + iLastErr + "！登录失败，请检查配置参数，并重新启动！"; //登录失败，输出错误号
                MessageBox.Show(str);
                return false;
            }
            return true;
        }
        public bool init()
        {
            bool m_bInitSDK = CHCNetSDK.NET_DVR_Init();
            if (m_bInitSDK == false)
            {
                MessageBox.Show("NET_DVR_Init error!配置参数错误，请检查配置文件，并重新启动！");
                return false;
            }
            else
            {
                //保存SDK日志
                CHCNetSDK.NET_DVR_SetLogToFile(3, "C:\\SdkLog\\", true);
                return this.login();
            }
        }
        public void logout()
        {
            //注销登录 Logout the device
            //todo by dyl
            /*if (m_lRealHandle >= 0)
            {
                MessageBox.Show("Please stop live view firstly");
                return;
            }*/
            if (device.userID >= 0)
            {
                if (!CHCNetSDK.NET_DVR_Logout(device.userID))
                {
                    uint iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    string str = "NET_DVR_Logout failed, error code= " + iLastErr;
                    MessageBox.Show(str);
                    return;
                }
            }
            device.userID = -1;
        }
        public void quit()
        {
            this.logout();
            CHCNetSDK.NET_DVR_Cleanup();
        }
    }
}
