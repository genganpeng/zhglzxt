using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zhuhai.xmlrpc;

namespace zhuhai.monitorinfo
{
    //genganpeng
    //NVR录像机的控制接口
    interface NVRControler
    {
        Monitor getMonitor();
        NVRDevice getDevice();
        PictureBox getPictureBox();
        bool login(NVRDevice nvrdevice);
        bool closeSound();

        bool init(NVRDevice nvrdevice, PictureBox pb);

        bool logout(NVRDevice nvrdevice);

        void preview(Monitor themonitor);

        void play(GateRecord gateRecord);
        void stop();
        void pause();
        void fast();
        void slow();
    }
}
