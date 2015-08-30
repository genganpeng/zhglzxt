using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using zhuhai.util;
using Newtonsoft.Json;

namespace zhuhai.web
{
    /// <summary>
    /// 生化微小气候协议的访问接口
    /// </summary>
    public class Shwxqhxy
    {
        /// <summary>
        /// 微小气候
        /// </summary>
        /// <returns></returns>
        public static Microclimate getendata()
        {
            string url = AppConfig.swwxqhxy + "/getendata";
            string data = GetResponseData(url);
            if (data == null)
                return null;
            Microclimate microclimate = JsonConvert.DeserializeObject(data, typeof(Microclimate)) as Microclimate;
            return microclimate;
        }

        /// <summary>
        /// 化学毒剂
        /// </summary>
        /// <returns></returns>
        public static ChemicalToxic getchemdata()
        {
            string url = AppConfig.swwxqhxy + "/getchemdata";
            string data = GetResponseData(url);
            if (data == null)
                return null;
            ChemicalToxic chemicalToxic = JsonConvert.DeserializeObject(data, typeof(ChemicalToxic)) as ChemicalToxic;
            return chemicalToxic;
        }

        /// <summary>
        /// 生物气溶剂
        /// </summary>
        /// <returns></returns>
        public static Bioaerosol getbiodata()
        {
            string url = AppConfig.swwxqhxy + "/getbiodata";
            string data = GetResponseData(url);
            if (data == null)
                return null;
            Bioaerosol bioaerosol = JsonConvert.DeserializeObject(data, typeof(Bioaerosol)) as Bioaerosol;
            return bioaerosol;
        }

        /// <summary>
        /// 返回JSon数据
        /// </summary>
        /// <param name="Url">要提交的URL</param>
        /// <returns>返回的JSON处理字符串</returns>
        public static string GetResponseData(string Url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                request.Method = "POST";
                request.ContentType = "text/xml;charset=UTF-8";
                //声明一个HttpWebRequest请求
                request.Timeout = 9000;
                //设置连接超时时间
                request.Headers.Set("Pragma", "no-cache");

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream streamReceive = response.GetResponseStream();
                Encoding encoding = Encoding.UTF8;
                StreamReader streamReader = new StreamReader(streamReceive, encoding);
                string strResult = streamReader.ReadToEnd();
                streamReceive.Dispose();
                streamReader.Dispose();

                return strResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}", ex.Message);
                return null;
            }
        }

        public static void Main1()
        {
            Console.WriteLine("{0}", getendata());
            Console.WriteLine("{0}", getchemdata());
            Console.WriteLine("{0}", getbiodata());
            Console.ReadLine();
        }
    }
}
