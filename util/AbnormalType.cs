using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zhuhai.util
{
    public class AbnormalType
    {
        /// <summary>
        /// 获取所有异常类型的名称,包括全部
        /// </summary>
        /// <returns></returns>
        public static string[] getAllAbnormalTypeNames()
        {
            return new string[] { "全部", "无异常", "温度异常", "核素异常", "温度和核素异常", "生物异常", "化学异常", "申报异常" };
        }

        /// <summary>
        /// 根据异常名称获取值
        /// </summary>
        /// <param name="name">异常名称</param>
        /// <returns></returns>
        public static int getIndexByName(string name)
        {
            int type = 0;
            switch (name)
            {
                case "无异常":
                    type = 0;
                    break;
                case "核素异常":
                    type = 1;
                    break;
                case "体温异常":
                    type = 2;
                    break;
                case "温度和核素异常":
                    type = 2;
                    break;
                case "生物异常":
                    type = 4;
                    break;
                case "化学异常":
                    type = 5;
                    break;
                case "申报异常":
                    type = 6;
                    break;
            }
            return type;
        }
    }

    public class GateWorkState
    {
        /// <summary>
        /// 获取所有闸机工作状态的名字
        /// </summary>
        /// <returns></returns>
        public static string[] getAllGateWorkStateNames()
        {
            return new string[] { "申报通关", "刷卡通关", "自助通关", "紧急关闭" };
        }
    }
}
