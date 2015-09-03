using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace zhuhai.util
{
    public class AppConfig
    {
        /// <summary>
        /// 生物微小气候协议
        /// </summary>
        static public string swwxqhxy = ConfigurationManager.AppSettings["swwxqhxy"];

        /// <summary>
        /// cmsServer的接口地址
        /// </summary>
        static public string cmsServer = ConfigurationManager.AppSettings["cmsServer"];

        /// <summary>
        /// 闸机传感器
        /// </summary>
        static public int gateSensor = int.Parse(ConfigurationManager.AppSettings["gatesensor"]);

        /// <summary>
        /// 口岸传感器
        /// </summary>
        static public int hxswqhsensor = int.Parse(ConfigurationManager.AppSettings["hxswqhsensor"]);

        /// <summary>
        /// 口岸传感器编号
        /// </summary>
        static public int hxswqhnum = int.Parse(ConfigurationManager.AppSettings["hxswqhnum"]);
    }
}
