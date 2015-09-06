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

        //查询乘客异常信息，可根据姓名、通关时间、性别、出生日期等信息对历史通关的乘客进行查询，返回查询结果。
        [XmlRpcMethod("searchPassenger")]
        GateRecordsResponse searchPassenger(int controller_id, string passenger_name,
                                            XmlRpcStruct other_conditions);

        [XmlRpcMethod("getPassengerPhoto")]
        IDPhotoResponse getPassengerPhoto(int controller_id, int photo_id);
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

    public enum IDType
    {
        IDCard = 0,		// 目前用作回乡证
        Passport = 1,	// 护照
        HKMOPermits = 2	// 港澳通行证
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

    public class GateRecordsResponse : RPCResponse
    {
        public string query;  // 搜索的条件
        public int unique_passengers;  // 命中的不同的旅客的数量(每个人可能对应多条通关记录)
        public int records_num;  // 总的通关记录的数量
        public GateRecord[] records;  // the id_photo in it is empty but id_photo_id is valid

        public override string ToString()
        {
            return String.Format(
                "query= {0}, unique_passengers= {1}, records_num= {2}",
                this.query, this.unique_passengers, this.records_num);
        }
    }

    /**
	 * 通过海关闸机的记录，包含旅客个人信息以及过关时检疫检查结果
	 */
    public class GateRecord
    {
        // ID related infos
        public string name { get; set; }
        public string sex { get; set; }
        public int id_type { get; set; }
        public string id_code { get; set; }
        public string nationality { get; set; }
        public DateTime birth_date { get; set; }
        public string birth_place { get; set; }
        public string issue_place { get; set; }
        public DateTime issue_date { get; set; }
        public DateTime expire_date { get; set; }
        public string mrz_code { get; set; }
        public string mrz2_code { get; set; }

        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public byte[] id_photo { get; set; }  // ID 证件照文件的内容，发送时为必选项，接收时为可选项
        public string id_photo_ext { get; set; }	// 图片文件的后缀名，可以为 jpg / png / ico 等
        public int id_photo_id { get; set; }  // 证件照在数据库中的id，发送时忽略之，接收时总是有效的

        // Healthy check
        public double temperature { get; set; }
        public double nuclear { get; set; }
        public string nuclear_detail { get; set; }	// 检出的核素，以'|'分隔（分隔符数量固定），例如"铀|氡|||钋"
        public bool is_healthy { get; set; }
        public bool question_answer { get; set; }	//自助申报时的问题结果

        // Gate related
        public int gate_id { get; set; }
        public int gate_mode { get; set; }  //闸机的当前工作模式
        public DateTime nvr_begintime { get; set; }	// 该旅客触发闸机进行处理的时刻
        public DateTime nvr_endtime { get; set; }	// 填充为发送时的时刻，server会进一步修正
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public string discharged_by { get; set; }	// 放行的工作人员，闸机不发送此信息，保持为空即可

        public override string ToString()
        {
            return String.Format(
                "name= {0}, id= {1}, id_type= {2}, temp= {3}, nuclear= {4}, healthy= {5}, photo_id= {6}",
                this.name, this.id_code, (IDType)this.id_type, this.temperature, this.nuclear,
                this.is_healthy, this.id_photo_id);
        }
    }

    public class IDPhotoResponse : RPCResponse
    {
        public int photo_id;
        public string filename;
        public byte[] content;
    }
}