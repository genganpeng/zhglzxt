using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zhuhai.xmlrpc;
using zhuhai.util;
using System.Threading;

namespace zhuhai.monitorinfo.h264
{
    class H264Controler
    {
        private PictureBox pictureBox;
        private Monitor monitor;
        private ICustomsCMS server;
        private ToolStripStatusLabel toolStripStatusLabel;
        public H264Controler(ICustomsCMS server)
        {
            this.server = server;
        }
        public H264Controler(PictureBox pb, ICustomsCMS server)
        {
            this.pictureBox = pb;
            this.server = server;
        }
        public void setToolStripStatusLabel(ToolStripStatusLabel toolStripStatusLabel)
        {
            this.toolStripStatusLabel = toolStripStatusLabel;
        }
      
        public Monitor getMonitor()
        {
            return this.monitor;
        }
        public void setMonitor(Monitor theMonitor)
        {
            GateInfoResponse gateInfoResponse = new GateInfoResponse();
            try {
                gateInfoResponse = server.getGateInfo(AppConfig.gateSensor, theMonitor.gateNo);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            
            if (gateInfoResponse.error_code != 0)
            {
                MessageBox.Show("获取监控信息失败：" + gateInfoResponse.error_msg);
                toolStripStatusLabel.Text = "获取监控信息失败：" + gateInfoResponse.error_msg;
            }
            else
            {
                NVRDevice device = new NVRDevice();
                device.IP = gateInfoResponse.nvr_ip;
                device.password = gateInfoResponse.nvr_passwd;
                device.port = gateInfoResponse.nvr_port;
                device.username = gateInfoResponse.nvr_username;
                theMonitor.nvrDevice = device;
                theMonitor.channel = gateInfoResponse.nvr_channel;
                if (this.monitor != null)
                {
                    if (this.monitor.gateNo != theMonitor.gateNo)
                    {
                        toolStripStatusLabel.Text = "正在关闭现有视频!";
                        stopCurrentPreview();
                        
                        if (this.monitor.nvrDevice != null && this.monitor.nvrDevice.IP != theMonitor.nvrDevice.IP)
                        {
                            //新监控和原监控的nvr不同，需要logout原nvr
                            toolStripStatusLabel.Text = "正在注销当前NVR!";
                            this.logout(this.monitor.nvrDevice);
                        }
                        toolStripStatusLabel.Text = "就绪!";
                    }
                    stop();
                }
                
                this.monitor = theMonitor;
            }
        }
        public PictureBox getPictureBox()
        {
            return this.pictureBox;
        }
        public void setPictureBox(PictureBox pb)
        {
            this.pictureBox=pb;
        }

        public bool login()
        {
            if(this.monitor==null){
                MessageBox.Show("未指定监控器！");
                return false;
            }
            toolStripStatusLabel.Text = "正在登陆监控控制器!";
            H264_DVR_DEVICEINFO dvrdevInfo = new H264_DVR_DEVICEINFO();
            int nError;
            int nLoginID = XMSDK.H264_DVR_Login(monitor.nvrDevice.IP, (ushort)monitor.nvrDevice.port, monitor.nvrDevice.username, monitor.nvrDevice.password, out dvrdevInfo, out nError, SocketStyle.TCPSOCKET);

            if (nLoginID <= 0)
            {
                int iLastErr = XMSDK.H264_DVR_GetLastError();
                string str = "H264_DVR_Login failed, error code= " + iLastErr + "！登录失败，请检查配置参数，并重新启动！"; //登录失败，输出错误号
                toolStripStatusLabel.Text = "H264_DVR_Login failed, error code= " + iLastErr + "！登录失败，请检查配置参数，并重新启动！";
                MessageBox.Show(str);
                return false;
            }
            this.monitor.nvrDevice.userID = nLoginID;
            XMSDK.H264_DVR_SetupAlarmChan(nLoginID);
            toolStripStatusLabel.Text = "就绪!";
            return true;
        }

        public bool stopCurrentPreview()
        {
            if (m_iPlayhandle > 0)
            {
                XMSDK.H264_DVR_StopRealPlay(m_iPlayhandle, (uint)this.pictureBox.Handle);
                m_iPlayhandle = -1;
            }
            
            if (m_bSound)
            {
                closeSound();
            }
            return true;
        }
        public void logout(NVRDevice device)
        {
            if (device.userID > 0)
            {
                XMSDK.H264_DVR_Logout(device.userID);
                device.userID = -1;
            }
        }

        private XMSDK.fDisConnect disCallback;

        private XMSDK.fMessCallBack msgcallback;
        bool MessCallBack(int lLoginID, string pBuf, uint dwBufLen, IntPtr dwUser)
        {
            //消息回调函数，todo by dyl
            return true;
        }
        void DisConnectBackCallFunc(int lLoginID, string pchDVRIP, int nDVRPort, IntPtr dwUser)
        {
            logout(this.monitor.nvrDevice);
        }
        public bool closeSound()
        {
            if (XMSDK.H264_DVR_CloseSound(m_iPlayhandle))
            {
                m_bSound = false;
                return true;
            }
            return false;
        }
        public bool init()
        {
            //initialize
            disCallback = new XMSDK.fDisConnect(DisConnectBackCallFunc);
            GC.KeepAlive(disCallback);
            int bResult = XMSDK.H264_DVR_Init(disCallback, pictureBox.Handle);

            //he messages received in SDK from DVR which need to upload， such as alarm information，diary information，may do through callback function
            msgcallback = new XMSDK.fMessCallBack(MessCallBack);
            XMSDK.H264_DVR_SetDVRMessCallBack(msgcallback, pictureBox.Handle);

            //XMSDK.H264_DVR_SetConnectTime(5000, 3);
            XMSDK.H264_DVR_SetConnectTime(1000, 1);

            if (bResult <= 0)
            {
                MessageBox.Show("H264_DVR_Init error!配置参数错误，请检查配置文件！");
                return false;
            }
            return true;
        }

        public bool quit()
        {
            return XMSDK.H264_DVR_Cleanup();
        }

        private int m_iPlayhandle = -1;//当前播放的handle
        private bool m_bSound = false;//声音
        public bool preview()
        {
            if (this.monitor == null)
            {
                MessageBox.Show("未指定监控器！");
                return false;
            }
            //if device did not login,login first
            if (this.monitor.nvrDevice.userID <= 0)
            {
                bool loginSuccess=this.login();
                if (!loginSuccess)
                {
                    return false;
                }
            }
            if (this.monitor.nvrDevice.userID > 0)
            {
                if (m_iPlayhandle != -1)
                {
                    string thead = Thread.CurrentThread.Name;
                    if (0 != XMSDK.H264_DVR_StopRealPlay(m_iPlayhandle, (uint)this.pictureBox.Handle))
                    {
                        //TRACE("H264_DVR_StopRealPlay fail m_iPlayhandle = %d", m_iPlayhandle);
                    }
                    if (m_bSound)
                    {
                        closeSound();
                    }
                }

                H264_DVR_CLIENTINFO playstru = new H264_DVR_CLIENTINFO();

                playstru.nChannel = this.monitor.channel;
                playstru.nStream = 0;
                playstru.nMode = 0;
                playstru.hWnd = this.pictureBox.Handle;
                m_iPlayhandle = XMSDK.H264_DVR_RealPlay(this.monitor.nvrDevice.userID, ref playstru);
                if (m_iPlayhandle <= 0)
                {
                    Int32 dwErr = XMSDK.H264_DVR_GetLastError();
                    StringBuilder sTemp = new StringBuilder("");
                    sTemp.AppendFormat("登录 {0} 通道{1} 失败, 错误码 = {2}", this.monitor.nvrDevice.IP, this.monitor.channel, dwErr);
                    MessageBox.Show(sTemp.ToString());
                    return false;
                }
                else
                {
                    XMSDK.H264_DVR_MakeKeyFrame(this.monitor.nvrDevice.userID, this.monitor.channel, 0);
                }
            }
            return true;
        }

        private int m_nNetPlayHandle=0;
        private bool m_bPauseNetPlay = false;
        private int m_nFastTypeNet = 0;
        private int m_nSlowTypeNet = 0;
        public bool play(GateRecord gateRecord)
        {
            //if device did not login,login first
            if (this.monitor != null && this.monitor.nvrDevice!=null&&this.monitor.nvrDevice.userID <= 0)
            {
                bool loginSuccess = this.login();
                if (!loginSuccess)
                {
                    return false;
                }
            }
            if (m_nNetPlayHandle == 0)
            {
                H264_DVR_FINDINFO info = new H264_DVR_FINDINFO();

                //test by dyl
                info.nChannelN0 = monitor.channel;	//channel No.
                info.nFileType = 0;		//file type
                DateTime nvr_begintime=gateRecord.nvr_begintime;
                //DateTime nvr_begintime = DateTime.Parse("2014-12-30 21:30:00");
                info.startTime.dwYear = nvr_begintime.Year;
                info.startTime.dwMonth = nvr_begintime.Month;
                info.startTime.dwDay = nvr_begintime.Day;
                info.startTime.dwHour = nvr_begintime.Hour;
                info.startTime.dwMinute = nvr_begintime.Minute;
                info.startTime.dwSecond = nvr_begintime.Second;

                DateTime nvr_endtime = gateRecord.nvr_endtime;
                //DateTime nvr_endtime = DateTime.Parse("2014-12-30 22:30:00");
                info.endTime.dwYear = nvr_endtime.Year;
                info.endTime.dwMonth = nvr_endtime.Month;
                info.endTime.dwDay = nvr_endtime.Day;
                info.endTime.dwHour = nvr_endtime.Hour;
                info.endTime.dwMinute = nvr_endtime.Minute;
                info.endTime.dwSecond = nvr_endtime.Second;
                info.hWnd = (uint)this.pictureBox.Handle;

                XMSDK.fDownLoadPosCallBack DownloadCallback = new XMSDK.fDownLoadPosCallBack(DownLoadPosCallback);
                XMSDK.fRealDataCallBack realDataCallBack = new XMSDK.fRealDataCallBack(RealDataCallBack);

                m_nNetPlayHandle = XMSDK.H264_DVR_PlayBackByTimeEx(monitor.nvrDevice.userID, ref info, null, this.pictureBox.Handle.ToInt32(),
                    null, this.pictureBox.Handle.ToInt32());

                if (m_nNetPlayHandle <= 0)
                {
                    int iLastErr = XMSDK.H264_DVR_GetLastError();
                    string str = "H264_DVR_PlayBackByTimeEx failed, 错误号= " + iLastErr + "！播放失败！"; //播放失败
                    MessageBox.Show(str);
                    m_nNetPlayHandle = 0;
                    return false;
                }
            }else
            {
                if (m_bPauseNetPlay)
                {
                    XMSDK.H264_DVR_PlayBackControl(m_nNetPlayHandle, (int)PlayBackAction.SDK_PLAY_BACK_CONTINUE, 0);
                    m_bPauseNetPlay = !m_bPauseNetPlay;
                }
                XMSDK.H264_DVR_PlayBackControl(m_nNetPlayHandle, (int)PlayBackAction.SDK_PLAY_BACK_FAST, 0);
                m_nFastTypeNet = 0;
                m_nSlowTypeNet = 0;
            }
            return true;
        }
        private void DownLoadPosCallback(int lPlayHandle,
                                                           int lTotalSize,
                                                           int lDownLoadSize,
                                                           int dwUser)
        {
            if (0xfffffff == lDownLoadSize)
            {
                this.pictureBox.Refresh();
                //progressBarDownloadPos.Value = 0;
            }
        }
        enum PlayBackAction
        {
            SDK_PLAY_BACK_PAUSE,		/*<! 暂停回放*/
            SDK_PLAY_BACK_CONTINUE,		/*<! 继续回放*/
            SDK_PLAY_BACK_SEEK,			/*<! 回放定位，时间s为单位 */
            SDK_PLAY_BACK_FAST,	        /*<! 加速回放 */
            SDK_PLAY_BACK_SLOW,	        /*<! 减速回放 */
            SDK_PLAY_BACK_SEEK_PERCENT, /*<! 回放定位百分比 */
        };

        private int RealDataCallBack(int lRealHandle, int dwDataType, string strBuf, int lbufsize, int dwUser)
        {
            m_nNetPlayHandle = 0;
            return 0;
        }
        public void stop()
        {
            if (m_nNetPlayHandle > 0)
            {
                if (m_nNetPlayHandle >= 0)
                {
                    XMSDK.H264_DVR_StopPlayBack(m_nNetPlayHandle);
                    m_nNetPlayHandle = 0;
                }
                m_bPauseNetPlay = false;
                m_nFastTypeNet = 0;
                m_nSlowTypeNet = 0;
            }
           
        }
        public void pause()
        {
            if (m_nNetPlayHandle > 0)
            {
                if (!m_bPauseNetPlay)
                    XMSDK.H264_DVR_PlayBackControl(m_nNetPlayHandle, (int)PlayBackAction.SDK_PLAY_BACK_PAUSE, 0);
                else
                    XMSDK.H264_DVR_PlayBackControl(m_nNetPlayHandle, (int)PlayBackAction.SDK_PLAY_BACK_CONTINUE, 0);
                m_bPauseNetPlay = !m_bPauseNetPlay;
            }
            else
            {
                MessageBox.Show("未播放！");
            }
            
        }
        public void fast()
        {
            if (m_nNetPlayHandle > 0)
            {
                if (++m_nFastTypeNet > 4)
                {
                    m_nFastTypeNet = 1;
                }
                m_nSlowTypeNet = 0;
                XMSDK.H264_DVR_PlayBackControl(m_nNetPlayHandle, (int)PlayBackAction.SDK_PLAY_BACK_FAST, m_nFastTypeNet);
            }
            else
            {
                MessageBox.Show("未播放！");
            }
            
        }
        public void slow()
        {
            if (m_nNetPlayHandle > 0)
            {
                if (++m_nSlowTypeNet > 4)
                {
                    m_nSlowTypeNet = 1;
                }
                m_nFastTypeNet = 0;
                XMSDK.H264_DVR_PlayBackControl(m_nNetPlayHandle, (int)PlayBackAction.SDK_PLAY_BACK_SLOW, m_nSlowTypeNet);
            }
            else
            {
                MessageBox.Show("未播放！");
            }
            
        }
    }
}
