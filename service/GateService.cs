﻿using System;
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
            try
            {
                ICustomsCMS server = XmlRpcInstance.getInstance();
                TaskRPCResponse taskRPCResponse = server.getCurrentThreshold(gateNo);
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
            try
            {
                ICustomsCMS server = XmlRpcInstance.getInstance();
                TaskRPCResponse taskRPCResponse = server.getCurrentThreshold(AppConfig.hxswqhnum);
                if (taskRPCResponse.error_code == 0)
                {
                    return new HxswqhThresholdValue(taskRPCResponse.task.bio_port, taskRPCResponse.task.chem_port);
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
            try
            {
                ICustomsCMS server = XmlRpcInstance.getInstance();
                TaskRPCResponse taskRPCResponse = server.getCurrentThreshold(gateNo);
                if (taskRPCResponse.error_code == 0)
                {
                    return new GateThresholdErrorValue(taskRPCResponse.task.tiny_temperature, taskRPCResponse.task.tiny_nuclear);
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

        /// <summary>
        /// 根据条件查询通关记录人数
        /// </summary>
        /// <param name="name">姓名</param>
        /// <returns></returns>
        public string getGateRecordsNum(string name, IDictionary<string, object> strWhere)
        {
            try
            {
                ICustomsCMS server = XmlRpcInstance.getInstance();
                GateRecordsNumResponse gateRecordsNumResponse = server.getGateRecordsNum(name, DictionaryToXmlRpcStruct.dictionaryToXmlRpcStruct(strWhere));

                if (gateRecordsNumResponse.error_code == 0)
                {
                    return "过关总人数：" + gateRecordsNumResponse.all_num +
                        "！正常过关人数：" + gateRecordsNumResponse.healthy_num + "！异常过关人数：" + gateRecordsNumResponse.unhealthy_num;
                }
                else
                {
                    throw new Exception("错误：" + gateRecordsNumResponse.error_msg);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("错误：" + ex.Message);
            }
            
        }

        /// <summary>
        /// 根据Id获取照片
        /// </summary>
        /// <param name="photo_id">照片id</param>
        /// <returns></returns>
        public byte[] getPassengerPhoto(int photo_id)
        {
            try
            {
                ICustomsCMS server = XmlRpcInstance.getInstance();
                IDPhotoResponse photoResponse = server.getPassengerPhoto(AppConfig.gateSensor, photo_id);

                if (photoResponse.error_code == 0)
                {
                    return photoResponse.content;
                }
                else
                {
                    throw new Exception("错误：" + photoResponse.error_msg);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("错误：" + ex.Message);
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
