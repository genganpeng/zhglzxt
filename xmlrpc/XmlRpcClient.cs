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
        TaskRPCResponse getCurrentThreshold(int gateNo);

        // 获取一个闸机在一段时间内的通关人数，若 gate_id 为0，则返回所有闸机的通关总数
        [XmlRpcMethod("getGateRecordsNum")]
        GateRecordsNumResponse getGateRecordsNum(string passenger_name,
                                            XmlRpcStruct other_conditions);

        //查询乘客异常信息，可根据姓名、通关时间、性别、出生日期等信息对历史通关的乘客进行查询，返回查询结果。
        [XmlRpcMethod("searchPassenger")]
        GateRecordsResponse searchPassenger(string passenger_name,
                                            XmlRpcStruct other_conditions);

        //查询乘客异常信息，可根据姓名、通关时间、性别、出生日期等信息对历史通关的乘客进行查询，返回查询结果总数。
        [XmlRpcMethod("searchPassengerCount")]
        NumResponse searchPassengerCount(string passenger_name,
                                            XmlRpcStruct other_conditions);

        //获得旅客通过时的异常记录
        [XmlRpcMethod("getAbnormalRecord")]
        GateRecordResponse getAbnormalRecord(int controller_id);

        [XmlRpcMethod("getPassengerPhoto")]
        IDPhotoResponse getPassengerPhoto(int controller_id, int photo_id);

        [XmlRpcMethod("getGateInfo")]
        GateInfoResponse getGateInfo(int controller_id, int gate_id);

        //管理子系统发布命令，包括闸机重启，休眠等
        [XmlRpcMethod("publishSensorOrder")]
        OrderRPCResponse publishSensorOrder(int controller_id, SysOrder sys_ord);

        //新增工作规程
        [XmlRpcMethod("putWorkRule")]
        DBRPCResponse putWorkRule(ImageTextInfo textinfo);

        //修改工作规程
        [XmlRpcMethod("modifyWorkRule")]
        DBRPCResponse modifyWorkRule(ImageTextInfo textinfo);


        //删除工作规程
        [XmlRpcMethod("deleteWorkRule")]
        DBRPCResponse deleteWorkRule(int id);

        //根据标题查询规程内容
        [XmlRpcMethod("findWorkRulebytitle")]
        ImageTextInfo findWorkRulebytitle(String textinfo);


        //查询所有工作规程，这个可以暂时考虑不用！！！！！！
        [XmlRpcMethod("findWorkRuleList")]
        ImageText_List_Response findWorkRuleList();

        //查询指定时间段内工作规程的标题数量，注意这个地方不返回内容。支持分页
        //titlelike:根据标题模糊查询
        //begintime 开始时间
        //endtime 结束时间
        //startline:页码数，从1开始
        //limit：每页的容量
        [XmlRpcMethod("findWorkRuleTitleList")]
        Title_Response findWorkRuleTitleList(String titlelike, DateTime begintime, DateTime endtime, int startline, int limit);

        //查询指定时间段内工作规程的数量，用于计算总数
        //titlelike:根据标题模糊查询
        //begintime 开始时间
        //endtime 结束时间
        [XmlRpcMethod("findWorkRuleCount")]
        TitleNumResponse findWorkRuleCount(String titlelike, DateTime begintime, DateTime endtime);


        //新增作业指导书
        [XmlRpcMethod("putJobInstruct")]
        DBRPCResponse putJobInstruct(ImageTextInfo textinfo);

        //修改作业指导书
        [XmlRpcMethod("modifyJobInstruct")]
        DBRPCResponse modifyJobInstruct(ImageTextInfo textinfo);


        //删除作业指导书
        [XmlRpcMethod("deleteJobInstruct")]
        DBRPCResponse deleteJobInstruct(int id);

        //根据标题查询规程内容
        [XmlRpcMethod("findJobInstructbytitle")]
        ImageTextInfo findJobInstructbytitle(String textinfo);


        //查询所有工作规程，这个可以暂时考虑不用！！！！！！
        [XmlRpcMethod("findJobInstructList")]
        ImageText_List_Response findJobInstructList();

        //查询指定时间段内工作规程的标题数量，注意这个地方不返回内容。支持分页
        //titlelike:根据标题模糊查询
        //begintime 开始时间
        //endtime 结束时间
        //startline:页码数，从1开始
        //limit：每页的容量
        [XmlRpcMethod("findJobInstructTitleList")]
        Title_Response findJobInstructTitleList(String titlelike, DateTime begintime, DateTime endtime, int startline, int limit);

        //查询指定时间段内作业指导书的数量，用于计算总数
        //titlelike:根据标题模糊查询
        //begintime 开始时间
        //endtime 结束时间
        [XmlRpcMethod("findJobInstructCount")]
        TitleNumResponse findJobInstructCount(String titlelike, DateTime begintime, DateTime endtime);



        //新增疫情信息
        [XmlRpcMethod("putEpideInfo")]
        DBRPCResponse putEpideInfo(ImageTextInfo textinfo);

        //修改疫情信息
        [XmlRpcMethod("modifyEpideInfo")]
        DBRPCResponse modifyEpideInfo(ImageTextInfo textinfo);


        //删除疫情信息
        [XmlRpcMethod("deleteEpideInfo")]
        DBRPCResponse deleteEpideInfo(int id);

        //根据标题查询规程内容
        [XmlRpcMethod("findEpideInfobytitle")]
        ImageTextInfo findEpideInfobytitle(String textinfo);


        //查询所有工作规程，这个可以暂时考虑不用！！！！！！
        [XmlRpcMethod("findEpideInfoList")]
        ImageText_List_Response findEpideInfoList();

        //查询指定时间段内工作规程的标题数量，注意这个地方不返回内容。支持分页
        //titlelike:根据标题模糊查询
        //begintime 开始时间
        //endtime 结束时间
        //startline:页码数，从1开始
        //limit：每页的容量
        [XmlRpcMethod("findEpideInfoTitleList")]
        Title_Response findEpideInfoTitleList(String titlelike, DateTime begintime, DateTime endtime, int startline, int limit);

        //查询指定时间段内疫情信息的数量，用于计算总数
        //titlelike:根据标题模糊查询
        //begintime 开始时间
        //endtime 结束时间
        [XmlRpcMethod("findEpideInfoCount")]
        TitleNumResponse findEpideInfoCount(String titlelike, DateTime begintime, DateTime endtime);



        //新增应急预案
        [XmlRpcMethod("putEmerPlan")]
        DBRPCResponse putEmerPlan(ImageTextInfo textinfo);

        //修改应急预案
        [XmlRpcMethod("modifyEmerPlan")]
        DBRPCResponse modifyEmerPlan(ImageTextInfo textinfo);


        //删除应急预案
        [XmlRpcMethod("deleteEmerPlan")]
        DBRPCResponse deleteEmerPlan(int id);

        //根据标题查询规程内容
        [XmlRpcMethod("findEmerPlanbytitle")]
        ImageTextInfo findEmerPlanbytitle(String textinfo);


        //查询所有工作规程，这个可以暂时考虑不用！！！！！！
        [XmlRpcMethod("findEmerPlanList")]
        ImageText_List_Response findEmerPlanList();

        //查询指定时间段内工作规程的标题数量，注意这个地方不返回内容。支持分页
        //titlelike:根据标题模糊查询
        //begintime 开始时间
        //endtime 结束时间
        //startline:页码数，从1开始
        //limit：每页的容量
        [XmlRpcMethod("findEmerPlanTitleList")]
        Title_Response findEmerPlanTitleList(String titlelike, DateTime begintime, DateTime endtime, int startline, int limit);

        //查询指定时间段内应急预案的数量，用于计算总数
        //titlelike:根据标题模糊查询
        //begintime 开始时间
        //endtime 结束时间
        [XmlRpcMethod("findEmerPlanCount")]
        TitleNumResponse findEmerPlanCount(String titlelike, DateTime begintime, DateTime endtime);

        /// <summary>
        /// 设置口岸标题
        /// </summary>
        /// <param name="titileName"></param>
        /// <returns></returns>
        [XmlRpcMethod("setTitle")]
        RPCResponse setTitle(string rolename, string value);

        /// <summary>
        /// 获取口岸标题
        /// </summary>
        /// <returns></returns>
        [XmlRpcMethod("getTitle")]
        TitleNameRPCResponse getTitle(string rolename);

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="operateContent"></param>
        /// <param name="operateModule"></param>
        /// <param name="operatePeople"></param>
        /// <param name="dateTime"></param>
        /// <returns></returns>
         [XmlRpcMethod("insertlog")]
        RPCResponse log(Log log);

         [XmlRpcMethod("getlog")]
         LogListRPCResponse getLog(DateTime para_begin, DateTime para_end, string operatePeople, string operateModule, string operatecontent, int start, int limit);


         [XmlRpcMethod("getlogCount")]
         NumResponse getLogCount(DateTime para_begin, DateTime para_end, string operatePeople, string operateModule, string operatecontent);

         //新增申报内容
         [XmlRpcMethod("addReportContent")]
         DBRPCResponse addReportContent(ReportContent reportContent);

         //修改申报内容
         [XmlRpcMethod("modifyReportContent")]
         DBRPCResponse modifyReportContent(ReportContent reportContent);


         //删除申报内容
         [XmlRpcMethod("deleteReportContent")]
         DBRPCResponse deleteReportContent(int id);

         //查询申报内容的数量。支持分页
         //titlelike:根据标题模糊查询
         //startline:页码数，从1开始
         //limit：每页的容量
         [XmlRpcMethod("findReportContent")]
         ReportContent_Response findReportContentList(String content, int startline, int limit);

         //查询申报内容的数量，用于计算总数
         //titlelike:根据标题模糊查询
         [XmlRpcMethod("findReportContentCount")]
         TitleNumResponse findReportContenCount(String content);

        /// <summary>
        /// 获取所有闸机的信息
        /// </summary>
        /// <param name="control_id"></param>
        /// <param name="target_gates"></param>
        /// <returns></returns>
        [XmlRpcMethod("getGateAllInfo")]
         Gate_state_record_Response getGateAllInfo(int control_id, int[] target_gates);

        /// <summary>
        /// 获取闸机状态
        /// </summary>
        /// <param name="gateid"></param>
        /// <returns></returns>
        [XmlRpcMethod("getSensorOrder")]
        OrderRPCResponse getSensorOrder(int gateid);

        /// <summary>
        /// 检测用户名和密码
        /// </summary>
        /// <param name="usercheck"></param>
        /// <returns></returns>
        [XmlRpcMethod("checkUser")]
        UsercheckRPCResponse checkUser(Usercheck usercheck);

        /// <summary>
        /// 根据用户名查询用户，用户判断用户名是否存在
        /// </summary>
        /// <param name="usercheck"></param>
        /// <returns></returns>
        [XmlRpcMethod("findUser")]
        UsercheckRPCResponse findUser(string userName);

        [XmlRpcMethod("AddUser")]
        DBRPCResponse AddUser(Usercheck usercheck);

        [XmlRpcMethod("ModifyUser")]
        DBRPCResponse ModifyUser(Usercheck usercheck);

        [XmlRpcMethod("DeleteUser")]
        DBRPCResponse DeleteUser(int userid);

        [XmlRpcMethod("findAllUserCount")]
        NumResponse findAllUserCount(string username);

        [XmlRpcMethod("findAllUserByUserid")]
        UsercheckListRPCResponse findAllUserByUserid(string username, int start, int limit);
        
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
        /// 生物战剂阈值更新
        /// </summary>
        bio_port = 4,
        /// <summary>
        /// 化学战剂阈值更新
        /// </summary>
        chem_port = 5,
        /// <summary>
        /// 更新误差阈值
        /// </summary>
        gateThresholdErrorUpdate = 6
    }

    /// <summary>
    /// 工作模式
    /// </summary>
    public enum WorkMode
    {
        /// <summary>
        /// 自助通关
        /// </summary>
        Zizhu = 2,	
        /// <summary>
        /// 刷卡通关
        /// </summary>
        Shuaka = 1,
        /// <summary>
        /// 申报通关
        /// </summary>
        Shenbao = 0,
        /// <summary>
        /// 通关封闭
        /// </summary>
        Fengbi = 3
    }

    /// <summary>
    /// 工作状态
    /// </summary>
    public enum WorkState
    {
        /// <summary>
        /// 正常
        /// </summary>
        Normal = 3,
        /// <summary>
        /// 休眠
        /// </summary>
        Sleep = 0,
        /// <summary>
        /// 关机
        /// </summary>
        ShutDown = 1,
        /// <summary>
        /// 异常
        /// </summary>
        Abnormal = 2,
        /// <summary>
        /// 核素异常
        /// </summary>
        HesuAbnormal = 4,
        /// <summary>
        /// 温度异常
        /// </summary>
        WenduAbnormal = 5,
        /// <summary>
        /// 扫描仪异常
        /// </summary>
        SaomiaoyiAbnormal = 6,
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
        /// 温度和核素异常
        /// </summary>
        TemperatareNuclear = 3,
        /// <summary>
        /// 生物异常
        /// </summary>
        Biology = 4,
        /// <summary>
        /// 化学异常
        /// </summary>
        Chem = 5
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
        public double bio_port;
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public double chem_port;

        // properities for UpdateThreshold, optional
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public double tiny_temperature;
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public double tiny_nuclear;

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
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public string report_content { get; set; }

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

    public class GateInfoResponse : RPCResponse
    {
        public int gate_id;
        public string nvr_ip;
        public int nvr_port;
        public string nvr_username;
        public string nvr_passwd;
        public int nvr_channel;

        public override string ToString()
        {
            return String.Format(
                "gate_id= {0}, nvr_ip= {1}, nvr_channel= {2}",
                this.gate_id, this.nvr_ip, this.nvr_channel);
        }
    }

    /**
        * 
        * 添加图文消息的通用接口，可以被工作规程，作业指导书等通用
        * 
       **/
    public class ImageTextInfo
    {
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public int id;
        //标题
        public string title;

        //内容，这个地方只需要是byte[]就可以，解码也是返回的byte[]，需要管理客户端根据自己的编码规则进行转化和还原。
        public byte[] content;

        //作者
        public string authod;

        public override string ToString()
        {
            return String.Format(
                "authod= {0}, title={1}",
                this.authod, this.title);
        }
    }
}