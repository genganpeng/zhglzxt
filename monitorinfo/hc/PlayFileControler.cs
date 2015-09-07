using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace zhuhai.monitorinfo
{
    class PlayFileControler
    {
        public NVRDevice nvrDevice;
        public System.Windows.Forms.Button btnPause;
        public System.Windows.Forms.Button btnStop;
        public System.Windows.Forms.Label labelPause;
        public System.Windows.Forms.TrackBar progressBar;
        public System.Windows.Forms.PictureBox videoPlayWnd;
        private int m_lPlayHandle = -1;
        private bool m_bPause = false;
        public PlayFileControler()
        {
        }
        public PlayFileControler(NVRDevice nvr)
        {
            nvrDevice = nvr;
        }
        private string fileDir = "E:/movie/";
        public void playfile(string sPlayBackFileName)
        {
            if (sPlayBackFileName == null)
            {
                MessageBox.Show("Please select one file firstly!");//先选择回放的文件
                return;
            }

            if (m_lPlayHandle >= 0)
            {
                //如果已经正在回放，先停止回放
                if (!CHCNetSDK.NET_DVR_StopPlayBack(m_lPlayHandle))
                {
                    uint iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    string str = "NET_DVR_StopPlayBack failed, error code= " + iLastErr; //停止回放失败，输出错误号
                    MessageBox.Show(str);
                    return;
                }

                m_bPause = false;
                btnPause.Text = "||";
                labelPause.Text = "暂停";

                m_lPlayHandle = -1;
                progressBar.Value = 0;
            }

            //按文件名回放
            m_lPlayHandle = CHCNetSDK.NET_DVR_PlayBackByName(this.nvrDevice.userID, fileDir+sPlayBackFileName, videoPlayWnd.Handle);
            if (m_lPlayHandle < 0)
            {
                uint iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                string str = "NET_DVR_PlayBackByName failed, error code= " + iLastErr;
                MessageBox.Show(str);
                return;
            }

            uint iOutValue = 0;
            if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(m_lPlayHandle, CHCNetSDK.NET_DVR_PLAYSTART, IntPtr.Zero, 0, IntPtr.Zero, ref iOutValue))
            {
                uint iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                string str = "NET_DVR_PLAYSTART failed, error code= " + iLastErr; //回放控制失败，输出错误号
                MessageBox.Show(str);
                return;
            }
            btnStop.Enabled = true;
        }
        public void pause()
        {
            uint iOutValue = 0;

            if (!m_bPause)
            {
                if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(m_lPlayHandle, CHCNetSDK.NET_DVR_PLAYPAUSE, IntPtr.Zero, 0, IntPtr.Zero, ref iOutValue))
                {
                    uint iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    string str = "NET_DVR_PLAYPAUSE failed, error code= " + iLastErr; //回放控制失败，输出错误号
                    MessageBox.Show(str);
                    return;
                }
                m_bPause = true;
                btnPause.Text = ">";
                labelPause.Text = "播放";
            }
            else
            {
                if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(m_lPlayHandle, CHCNetSDK.NET_DVR_PLAYRESTART, IntPtr.Zero, 0, IntPtr.Zero, ref iOutValue))
                {
                    uint iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    string str = "NET_DVR_PLAYRESTART failed, error code= " + iLastErr; //回放控制失败，输出错误号
                    MessageBox.Show(str);
                    return;
                }
                m_bPause = false;
                btnPause.Text = "||";
                labelPause.Text = "暂停";
            }
        }
        public void stop()
        {
            if (m_lPlayHandle < 0)
            {
                return;
            }

            //停止回放
            if (!CHCNetSDK.NET_DVR_StopPlayBack(m_lPlayHandle))
            {
                uint iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                string str = "NET_DVR_StopPlayBack failed, error code= " + iLastErr;
                MessageBox.Show(str);
                return;
            }

            progressBar.Value = 0;

            m_bPause = false;
            btnPause.Text = "||";
            labelPause.Text = "暂停";

            m_lPlayHandle = -1;
            videoPlayWnd.Invalidate();//刷新窗口    
            btnStop.Enabled = false;
        }
        public void slow()
        {
            uint iOutValue = 0;

            if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(m_lPlayHandle, CHCNetSDK.NET_DVR_PLAYSLOW, IntPtr.Zero, 0, IntPtr.Zero, ref iOutValue))
            {
                uint iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                string str = "NET_DVR_PLAYSLOW failed, error code= " + iLastErr; //回放控制失败，输出错误号
                MessageBox.Show(str);
                return;
            }
        }
        public void fast()
        {
            uint iOutValue = 0;

            if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(m_lPlayHandle, CHCNetSDK.NET_DVR_PLAYFAST, IntPtr.Zero, 0, IntPtr.Zero, ref iOutValue))
            {
                uint iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                string str = "NET_DVR_PLAYFAST failed, error code= " + iLastErr; //回放控制失败，输出错误号
                MessageBox.Show(str);
                return;
            }
        }
        public void normalSpeed()
        {
            uint iOutValue = 0;

            if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(m_lPlayHandle, CHCNetSDK.NET_DVR_PLAYNORMAL, IntPtr.Zero, 0, IntPtr.Zero, ref iOutValue))
            {
                uint iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                string str = "NET_DVR_PLAYNORMAL failed, error code= " + iLastErr; //回放控制失败，输出错误号
                MessageBox.Show(str);
                return;
            }
        }

    }
}
