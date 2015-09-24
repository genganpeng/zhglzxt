using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zhuhai.util
{
    public class EnumName
    {
        

            public static string getWorkStateName(int index) {
                switch(index) {
                    case 0:
                        return "停机";
                    case 1:
                        return "停机";
                    case 2:
                        return "异常";
                    case 3:
                        return "正常";
                    case 4:
                         return "核素异常";
                    case 5:
                         return "红外设备异常";
                    case 6:
                         return "读卡设备异常";
                     case 7:
                         return "核素设备异常";
                }
                return "";
        }

        public static string getGateModeName(int index) {
             switch(index) {
                    case 0:
                        return "申报通关";
                    case 1:
                        return "刷卡通关";
                    case 2:
                        return "快速通关";
                    case 3:
                        return "紧急关闭";
             }
             return "";
        }

    }
}
