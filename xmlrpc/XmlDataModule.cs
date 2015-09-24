using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CookComputing.XmlRpc;

namespace zhuhai.xmlrpc
{
    public class XmlDataModule
    {
    }

    public class DBRPCResponse : RPCResponse
    {
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public int dbresult;
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public string dbreason;

        public override string ToString()
        {
            return String.Format(
                "error_code= {0}, error_msg= {1}, dbresult= {2},dbreason={3}",
                this.error_code, this.error_msg, this.dbresult, this.dbreason);
        }
    }

    public class TitleNumResponse : RPCResponse
    {
        public int titlenum;
    }

    public class NumResponse : RPCResponse
    {
        public int all_num;
    }
    public class ImageText_List_Response : RPCResponse
    {
        public ImageTextInfo[] listmodule;

        public override string ToString()
        {
            return String.Format("返回的数量是= {0:G}", listmodule.Length);
        }
    }

    public class Title_Response : RPCResponse
    {
        public TitleInfo[] titlelist;

        public override string ToString()
        {
            return String.Format("返回的数量是= {0:G}", titlelist.Length);
        }
    }

    public class TitleInfo
    {
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public int id;

        public string title;
        public string authod;
        public DateTime last_time;

    }

    public class GateRecordResponse : RPCResponse
    {
        public GateRecord gate_record;  // the id_photo in it is empty but id_photo_id is valid
    }

    /**
   *   闸机命令类型，包括四种任务类型
   *  used by    publishSensorOrder   and   getSensorOrder  
   **/
    public enum OrderType
    {
        /// <summary>
        /// 闸机重启
        /// </summary>
        Gate_Reboot = 0,
        /// <summary>
        /// 闸机休眠
        /// </summary>
        Gate_Sleep = 1,
        /// <summary>
        /// 闸机锁定
        /// </summary>
        Gate_Lock = 2, 
        /// <summary>
        /// 闸机解锁
        /// </summary>
        Gate_Unlock = 3,
        /// <summary>
        /// 摄像头拍照
        /// </summary>
        Camera_photo = 4,
        /// <summary>
        /// 闸机复位
        /// </summary>
        Gate_Reset = 5
    }

    public class SysOrder
    {
        public int type;  // enum OrderType
        public int[] target_gates;  // list of gate_id

        public override string ToString()
        {
            return String.Format(
                "type= {0}, target_gates={1}",
                Enum.GetName(typeof(OrderType), this.type), this.target_gates);
        }
    }

    public class OrderRPCResponse : RPCResponse
    {
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public SysOrder order;

        public override string ToString()
        {
            return this.ToString();
        }
    }

    public class TitleNameRPCResponse : RPCResponse
    {
        public string name;

        public string value;

        public int type;

        public string rolename;

        public override string ToString()
        {
            return value.ToString();
        }
    }

    public class Log
    {
        public string operateContent;
        public string operateModule;
        public string operatePeople;
    }

    public class LogRecord
    {
        public string operateContent {get; set;}
        public string operateModule {get; set;}
        public string operatePeople {get; set;}
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public string operateTime {get; set;}
    }

    public class LogListRPCResponse : RPCResponse
    {
        public LogRecord[] loglists;
    }

    public class ReportContent
    {
        public int id;
        public int logicid;
        public string operatePeople;
        public string content;
        public string content_en;
    }

    public class ReportContent_Response : RPCResponse
    {
        public ReportContent[] reportcontentlist;
    }

    public class Gate_state_record
    {
        //闸机号
        public int gateid;
        //模式
        public int mode;
        //状态
        public int working_state;
        //核素阈值
        public double thr_nuclear;
        //温度阈值
        public double thr_temper;
        //核素误差
        public double tiny_nuclear;
        //温度误差
        public double tiny_temper;

        /// <summary>
        /// 通关人员异常类型
        /// 0就是正常，1是核素异常，2，温度异常， 3是温度和核素都有异常
        /// </summary>
        public int unnormal_type;
        //通关人员的核素值
        public double nuclear;
        //通关人员的温度
        public double temperature;
    }

    public class Gate_state_record_Response : RPCResponse
    {
        public Gate_state_record[] gate_state_recode;

    }

    /// <summary>
    /// 用户管理
    /// </summary>
    public class Usercheck
    {
        public int id;
        public string username;
        public string password;
         [XmlRpcMissingMapping(MappingAction.Ignore)]
        public string rolename;
         [XmlRpcMissingMapping(MappingAction.Ignore)]
        public string realname;
         [XmlRpcMissingMapping(MappingAction.Ignore)]
         public string idcard;
    }

    /// <summary>
    /// 用户
    /// </summary>
    public class UsercheckRPCResponse : RPCResponse
    {
        public int id;
        public string username;
        public string password;
        public string rolename;
        public string realname;
        public string idcard;
        public int state;
    }

    public class UsercheckListRPCResponse : RPCResponse
    {
        public Usercheck[] listmodule;

    }


}
