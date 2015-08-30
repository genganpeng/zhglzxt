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
    }
}
