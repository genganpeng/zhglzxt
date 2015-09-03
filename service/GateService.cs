using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zhuhai.xmlrpc;
using zhuhai.util;

namespace zhuhai.service
{
    public class GateService
    {
        private static GateService gateService;

        private GateService()
        {
        }

        public static GateService getInstance()
        {
            if (gateService == null)
            {
                gateService = new GateService();
            }
            return gateService;
        }

        public int getGateTotal()
        {
            try
            {
                ICustomsCMS server = XmlRpcInstance.getInstance();
                GatesNumResponse gatesNumResponse = server.getGatesNumber(AppConfig.gateSensor);
                if (gatesNumResponse.error_code != 0)
                {
                    throw new Exception("连接服务器错误：" + gatesNumResponse.error_msg);
                }
                return gatesNumResponse.all_num;
            }
            catch (Exception ex)
            {
                throw new Exception("错误：" + ex.Message);
            }
            
        }

        /// <summary>
        /// 获取闸机的阈值
        /// </summary>
        /// <param name="gateNo">闸机号</param>
        /// <returns></returns>
        public GateThresholdValue getGateThreshold(int gateNo)
        {
            SysTask task = new SysTask();
            task.target_gates = new int[] { gateNo };
            try
            {
                ICustomsCMS server = XmlRpcInstance.getInstance();
                TaskRPCResponse taskRPCResponse = server.getCurrentThreshold(AppConfig.gateSensor, task);
                if (taskRPCResponse.error_code == 0)
                {
                    return new GateThresholdValue(taskRPCResponse.task.thr_temperature, taskRPCResponse.task.thr_nuclear);
                }
                else
                {
                    Console.WriteLine("连接服务器错误：" + taskRPCResponse.error_msg);
                    return null;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("错误：" + ex.Message);
                return null;
            }
        }

        public HxswqhThresholdValue getHxswqhThreshold()
        {

            //以下是获取原来的阈值，并显示出来
            SysTask task = new SysTask();
            task.target_gates = new int[] { AppConfig.hxswqhnum };
            try
            {
                ICustomsCMS server = XmlRpcInstance.getInstance();
                TaskRPCResponse taskRPCResponse = server.getCurrentThreshold(AppConfig.hxswqhsensor, task);
                if (taskRPCResponse.error_code == 0)
                {
                    return new HxswqhThresholdValue(taskRPCResponse.task.biology, taskRPCResponse.task.chem);
                }
                else
                {
                    Console.WriteLine("连接服务器错误：" + taskRPCResponse.error_msg);
                    return null;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("错误：" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 获取闸机阈值误差
        /// </summary>
        /// <param name="gateNo">闸机号</param>
        /// <returns></returns>
        public GateThresholdErrorValue getGateThresholdError(int gateNo)
        {
            SysTask task = new SysTask();
            task.target_gates = new int[] { gateNo };
            try
            {
                ICustomsCMS server = XmlRpcInstance.getInstance();
                TaskRPCResponse taskRPCResponse = server.getCurrentThreshold(AppConfig.gateSensor, task);
                if (taskRPCResponse.error_code == 0)
                {
                    return new GateThresholdErrorValue(taskRPCResponse.task.thr_temperature, taskRPCResponse.task.thr_nuclear);
                }
                else
                {
                    Console.WriteLine("连接服务器错误：" + taskRPCResponse.error_msg);
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("错误：" + ex.Message);
                return null;
            }
        }

    }

    /// <summary>
    /// 闸机阈值
    /// </summary>
    public class GateThresholdValue
    {
        public double temperature { get; set; }
        public double nuclear { get; set; }

        public GateThresholdValue(double temperature, double nuclear)
        {
            this.nuclear = nuclear;
            this.temperature = temperature;
        }
    }

    /// <summary>
    /// 化学生物阈值
    /// </summary>
    public class HxswqhThresholdValue
    {
        public double biology { get; set; }
        public double chem { get; set; }

        public HxswqhThresholdValue(double biology, double chem)
        {
            this.biology = biology;
            this.chem = chem;
        }
    }

    /// <summary>
    /// 闸机阈值误差
    /// </summary>
    public class GateThresholdErrorValue
    {
        public double temperature_error { get; set; }
        public double nuclear_error { get; set; }

        public GateThresholdErrorValue(double temperature_error, double nuclear_error)
        {
            this.nuclear_error = nuclear_error;
            this.temperature_error = temperature_error;
        }
    }
}
