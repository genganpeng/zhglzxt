using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zhuhai.util;
using zhuhai.service;
using zhuhai.xmlrpc;
using zhuhai.model;
using zhuhai.monitorinfo.h264;
using zhuhai.monitorinfo;

namespace zhuhai
{
    public partial class ClearanceVideoReplayForm : Form
    {
        private H264Controler playbackControler = null;
        private GateRecord gateRecord;
        public ClearanceVideoReplayForm(DataRow dr)
        {
            InitializeComponent();

            ICustomsCMS server = XmlRpcInstance.getInstance();
            playbackControler = new H264Controler(this.searchVideoPlayWnd, server);
            playbackControler.setToolStripStatusLabel(this.toolStripStatusLabel);
            bool isSuccess = playbackControler.init();
            if (!isSuccess)
            {
                System.Environment.Exit(0);
            }

            GateRecord gateRecord = new ModelHandler<GateRecord>().FillModel(dr);
            Monitor monitor = new Monitor();
            monitor.gateNo = gateRecord.gate_id;
            playbackControler.setMonitor(monitor);
            
        }


        private void btnPlay_Click(object sender, EventArgs e)
        {
            playbackControler.play(gateRecord);
            
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            this.playbackControler.pause();
        }

        private void btnSlow_Click(object sender, EventArgs e)
        {
            this.playbackControler.slow();
        }

        private void btnFast_Click(object sender, EventArgs e)
        {
            this.playbackControler.fast();
        }

        private void btnFrame_Click(object sender, EventArgs e)
        {
            this.playbackControler.pause();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.playbackControler.stop();
        }

        private void VideoReplayForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (playbackControler != null)
            {
                playbackControler.stop();
            }

            this.Close();
        }

    }
}
