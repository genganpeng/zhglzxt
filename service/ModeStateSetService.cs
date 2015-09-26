using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zhuhai.xmlrpc;
using zhuhai.util;

namespace zhuhai.service
{
    public class ModeStateSetService
    {
        private static ModeStateSetService modeStateSetService;

        private ModeStateSetService()
        {
        }

        public static ModeStateSetService getInstance()
        {
            if (modeStateSetService == null)
            {
                modeStateSetService = new ModeStateSetService();
            }
            return modeStateSetService;
        }

        /// <summary>
        /// 更新闸机的通行模式
        /// </summary>
        /// <param name="mode">通行模式</param>
        /// <param name="gateNos">闸机编号</param>
        /// <returns></returns>
        public Boolean updateGateMode(int mode, int[] gateNos)
        {
            ICustomsCMS server = XmlRpcInstance.getInstance();
            SysTask task = new SysTask();
            task.type = (int)TaskType.ChangeMode;
            task.mode = mode;
            task.target_gates = gateNos;
            task.created_by = SystemManageService.currentUser.UserName;

            try
            {
                RPCResponse response = server.publishTask(AppConfig.gateSensor, task);
                if (response.error_code == 0)
                {
                    return true;
                }
                else
                {
                    throw new Exception("更改闸机运行模式错误：" + response.error_msg);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("错误：" + ex.Message);
            }
        }

        /// <summary>
        /// 更新闸机的状态
        /// </summary>
        /// <param name="state">状态</param>
        /// <param name="gateNos">闸机编号</param>
        /// <returns></returns>
        public Boolean updateGateState(int state, int[] gateNos)
        {
            ICustomsCMS server = XmlRpcInstance.getInstance();
            SysOrder sysOrder = new SysOrder();
            sysOrder.type = state;
            sysOrder.target_gates = gateNos;
            sysOrder.created_by = SystemManageService.currentUser.UserName;

            try
            {
                OrderRPCResponse response = server.publishSensorOrder(AppConfig.gateSensor, sysOrder);
                if (response.error_code == 0)
                {
                    return true;
                }
                else
                {
                    throw new Exception("更改闸机状态错误：" + response.error_msg);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("错误：" + ex.Message);
            }
        }
    }
}
