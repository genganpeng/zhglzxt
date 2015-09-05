using System;
using System.IO;
using System.Collections;
using CookComputing.XmlRpc;


/**
 * 用于与CustomsCMS Server通信的 client interface 以及相关 enum / class 的定义。
 *
 *
 * 注意:
 * 1) 命名方式上，为了与后端server以及数据库表中的字段保持一致，XMLRPC 接口的规定如下:
 * 	  a) Enum 字段采用大驼峰命名法，例如 ChangeMode
 * 	  b) 其它 struct 的属性字段，均采用下划线分隔的命名法，例如 error_code, thr_nuclear
 * 2) Enum 的处理上，传输时统一传输其 int 值; 其它地方进行判断时，建议使用 Enum 对象，
 *    而打印或者记录log时，应输出字符串格式。
 *
 **/
namespace zhuhai.xmlrpc
{
    public interface ICustomsCMS : IXmlRpcProxy
    {
        /// <summary>
        /// 获得总通道数
        /// </summary>
        /// <param name="controller_id">设备类型，闸机传感器为0， 口岸传感器为1</param>
        /// <returns></returns>
        [XmlRpcMethod("getGatesNumber")]
        GatesNumResponse getGatesNumber(int controller_id);

        /// <summary>
        /// 发布任务
        /// </summary>
        /// <param name="controller_id">设备类型，闸机传感器为0， 口岸传感器为1</param>
        /// <param name="task"></param>
        /// <returns></returns>
        [XmlRpcMethod("publishTask")]
        RPCResponse publishTask(int controller_id, SysTask task);

        /// <summary>
        /// 获得当前阈值，当修改阈值时，首先通过该接口先获取当前闸机或者口岸传感器的阈值是多少并展示给用户。
        /// </summary>
        /// <returns></returns>
        [XmlRpcMethod("getCurrentThreshold")]
        TaskRPCResponse getCurrentThreshold(int controller_id, SysTask task);

        // 获取一个闸机在一段时间内的通关人数，若 gate_id 为0，则返回所有闸机的通关总数
        [XmlRpcMethod("getGateRecordsNum")]
        GateRecordsNumResponse getGateRecordsNum(int controller_id, int gate_id,
            DateTime time_from, DateTime time_to);
    }

    /**
	 * Usage of TaskType:
	 *   1) construct Enum from string using Enum.Parse(Type, String, Boolean)
	 *   2) get string repr of Enum using Enum.GetName(Type, Object)
	 *   3) convert to int using directly casting
	 *   4) construct Enum from int using Enum.ToObject(Type, Int32) （or casting)
	 */
    public enum TaskType
    {
        Empty = 0,
        /// <summary>
        /// 更新阈值
        /// </summary>
        UpdateThreshold = 1,
        /// <summary>
        /// 改变闸机运行模式
        /// </summary>
        ChangeMode = 2,
        /// <summary>
        /// 发布消息
        /// </summary>
        PublishNotice = 3,
        /// <summary>
        /// 改变状态
        /// </summary>
        ChangeState = 4
    }

    public enum WorkMode
    {
        /// <summary>
        /// 自助通关
        /// </summary>
        Zizhu = 0,	
        /// <summary>
        /// 刷卡通关
        /// </summary>
        Shuaka = 1,
        /// <summary>
        /// 申报通关
        /// </summary>
        Shenbao = 2,
        /// <summary>
        /// 通关封闭
        /// </summary>
        Fengbi = 3
    }


    public enum WorkState
    {
        /// <summary>
        /// 闸机休眠
        /// </summary>
        Sleep = 0,
        /// <summary>
        /// 闸机重启
        /// </summary>
        Restart = 1,
        /// <summary>
        /// 闸机锁定
        /// </summary>
        Lock = 2,
        /// <summary>
        /// 闸机解锁
        /// </summary>
        Unlock = 3
    }

    public enum AbnormalType
    {
        /// <summary>
        /// 无异常
        /// </summary>
        No = 0,
        /// <summary>
        /// 体温异常
        /// </summary>
        Temperatare =1,
        /// <summary>
        /// 核素异常
        /// </summary>
        Nuclear = 2,
        /// <summary>
        /// 生物异常
        /// </summary>
        Biology = 3,
        /// <summary>
        /// 化学异常
        /// </summary>
        Chem = 4
    }

    /// <summary>
    /// 系统任务，根据任务类型的不同，对应的字段的有效性与类型保持一致。
    /// </summary>
    public class SysTask
    {
        public int type;  // enum TaskType
        public int[] target_gates;  // list of gate_id

        // properities for UpdateThreshold, optional
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public double thr_temperature;
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public double thr_nuclear;

        // properities for UpdateThreshold, optional
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public double biology;
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public double chem;

        // properities for ChangeMode, optional
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public int mode;

        // properities for PublishNotice, optional
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public string notice;

        public override string ToString()
        {
            return String.Format(
                "type= {0}, thrT= {1}, thrN= {2}, mode= {3}, notice= \"{4}\"",
                Enum.GetName(typeof(TaskType), this.type), this.thr_temperature, this.thr_nuclear,
                this.mode, this.notice);
        }
    }

    /**
	 * RPC server的返回数据
	 */
    public class RPCResponse
    {
        public int error_code;
        public string error_msg;
    }

    public class GatesNumResponse : RPCResponse
    {
        /// <summary>
        /// 总通道数
        /// </summary>
        public int all_num;
    }

    public class TaskRPCResponse : RPCResponse
    {
        public SysTask task;

        public override string ToString()
        {
            return this.task.ToString();
        }
    }

    public class GateRecordsNumResponse : RPCResponse
    {
        public int all_num;
        public int healthy_num;
        public int unhealthy_num;

        public override string ToString()
        {
            return String.Format(
                "all= {0}, healthy= {1}, unhealthy= {2}",
                this.all_num, this.healthy_num, this.unhealthy_num);
        }
    }
}