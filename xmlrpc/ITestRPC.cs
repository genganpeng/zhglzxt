using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CookComputing.XmlRpc;
using System.IO;

namespace zhuhai.xmlrpc
{
    public interface ITestRPC
    {
        [XmlRpcMethod("test")]
        string test();

        [XmlRpcMethod("save")]
        byte[] filesave(string file, byte[] bytes);
    }

    class TestingClass {
        public static void Main1(string[] args) {
            ITestRPC server = XmlRpcProxyGen.Create<ITestRPC>();
            XmlRpcClientProtocol protocol;
            protocol = (XmlRpcClientProtocol)server;
            protocol.Url = "http://localhost:8000";
            string a = server.test();
            Console.WriteLine ("{0}", a);

            FileStream fs = new FileStream("1.zip", FileMode.Open);
            //获取文件大小
            long size = fs.Length;
            byte[] array = new byte[size];
            //将文件读到byte数组中
            fs.Read(array, 0, array.Length);
            fs.Close();

            byte[] bytes = server.filesave("2.zip", array);
            //实例化一个文件流--->与写入文件相关联  
            FileStream fo=new FileStream("333.zip", FileMode.Create);
            //实例化BinaryWriter  
            BinaryWriter bw = new BinaryWriter(fo);
            bw.Write(bytes);
            //清空缓冲区  
            bw.Flush();
            //关闭流  
            bw.Close();
            fo.Close();  
            Console.ReadLine();
            Console.ReadLine();
        }
    }
}
