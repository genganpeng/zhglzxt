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
        public int dbresult;
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
        Camera_photo = 4 
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
        //public SysOrder order;

        public override string ToString()
        {
            return this.ToString();
        }
    }
}
