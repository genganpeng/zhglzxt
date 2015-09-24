using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zhuhai.service;

namespace zhuhai.util
{
    public class PermissionControl
    {
        public static Boolean IsAuthorized(string controlName) {
            //系统管理员
            if (SystemManageService.currentUser.Rolename == "100")
            {
            }
            //口岸系统管理员
            else if (SystemManageService.currentUser.Rolename == "200")
            {
                if ("barButtonItem_systemManage" == controlName)
                {
                    return false;
                }
                else if ("barButtonItem_title" == controlName)
                {
                    return false;
                }
                else if ("simpleButton_delete" == controlName)
                {
                    return false;
                }
                else if ("barButtonItem_log" == controlName)
                {
                    return false;
                }
            }
            //口岸监控员
            else if (SystemManageService.currentUser.Rolename == "300")
            {
                if ("barButtonItem_systemManage" == controlName)
                {
                    return false;
                }
                else if ("barButtonItem_title" == controlName)
                {
                    return false;
                }
                else if ("barButtonItem_publishMessage" == controlName)
                {
                    return false;
                }
                else if ("barButtonItem_gateThresholdErrorUpdate" == controlName)
                {
                    return false;
                }
                else if ("barButtonItem_gateThreshold" == controlName)
                {
                    return false;
                }
                else if ("barButtonItem_hxswqhThreshold" == controlName)
                {
                    return false;
                }
                else if ("barButtonItem_modeset" == controlName)
                {
                    return false;
                }
                else if ("barButtonItem_shenbaocontent" == controlName)
                {
                    return false;
                }
                else if ("simpleButton_delete" == controlName)
                {
                    return false;
                }
                else if ("simpleButton_add" == controlName)
                {
                    return false;
                }
                else if ("simpleButton_modify" == controlName)
                {
                    return false;
                }
                else if ("barButtonItem_log" == controlName)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
