using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace zhuhai.monitorinfo
{
    /************************************************************************/
    /* genganpeng 监控摄像头数据结构*/
    /************************************************************************/
    public class Monitor
    {
        public NVRDevice nvrDevice = null;
        public int gateNo;//门号
        public int channel;//摄像头号
        public uint dwStreamType = 0;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
        public uint dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
        public bool bBlocked = true; //0- 非阻塞取流，1- 阻塞取流
        public int previewHandle = -1;

        public Monitor()
        {
        }

        public Monitor(NVRDevice nvrDev)
        {
            this.nvrDevice = nvrDev;
        }
        public Monitor(NVRDevice nvrDev,int lchannel)
        {
            this.nvrDevice = nvrDev;
            this.channel = lchannel;
        }

    }
}
