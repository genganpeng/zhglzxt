using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zhuhai.xmlrpc;
using zhuhai.util;

namespace zhuhai.service
{
    public class UpdateThresholdService
    {
        private static UpdateThresholdService updateThresholdService;

        private UpdateThresholdService()
        {
        }

        public static UpdateThresholdService getInstance()
        {
            if (updateThresholdService == null)
            {
                updateThresholdService = new UpdateThresholdService();
            }
            return updateThresholdService;
        }

        public Boolean updateGateThreshold(double temperature, double nuclear, int[] gates)
        {
            ICustomsCMS server = XmlRpcInstance.getInstance();
            SysTask task = new SysTask();
            task.type = (int)TaskType.UpdateThreshold;
            task.target_gates = gates;
            task.thr_temperature = temperature;
            task.thr_nuclear = nuclear;

            try
            {
                RPCResponse response = server.publishTask(AppConfig.gateSensor, task);
                if (response.error_code == 0)
                {
                    return true;
                }
                else
                {
                    throw new Exception("修改闸机阀值错误：" + response.error_msg);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("错误：" + ex.Message);
            }
        }

        public Boolean updateHxswqhThreshold(double biology, double chem)
        {
            SysTask task = new SysTask();
            task.type = (int)TaskType.bio_port;
            task.target_gates = new int[] { AppConfig.hxswqhnum };
            task.bio_port = biology;
            
            try
            {
                ICustomsCMS server = XmlRpcInstance.getInstance();
                RPCResponse response = server.publishTask(AppConfig.hxswqhsensor, task);

                task.type = (int)TaskType.chem_port;
                task.chem_port = chem;
                response = server.publishTask(AppConfig.hxswqhsensor, task);
                if (response.error_code == 0)
                {
                    return true;
                }
                else
                {
                    throw new Exception("修改口岸阀值错误：" + response.error_msg);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("错误"  + ex.Message);
            }
        }

        /// <summary>
        /// 温度和核素阈值误差更新
        /// </summary>
        /// <param name="temperature_error"></param>
        /// <param name="nuclear"></param>
        /// <param name="gates"></param>
        /// <returns></returns>
        public Boolean updateGateThresholdError(double temperature_error, double nuclear_error, int[] gates)
        {
            ICustomsCMS server = XmlRpcInstance.getInstance();
            SysTask task = new SysTask();
            task.type = (int)TaskType.gateThresholdErrorUpdate;
            task.target_gates = gates;
            task.thr_temperature = temperature_error;
            task.thr_nuclear = nuclear_error;

            try
            {
                RPCResponse response = server.publishTask(AppConfig.gateSensor, task);
                if (response.error_code == 0)
                {
                    return true;
                }
                else
                {
                    throw new Exception("修改闸机阀值误差错误：" + response.error_msg);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("错误：" + ex.Message);
            }
        }

    }
}
