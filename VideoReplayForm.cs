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
    public partial class VideoReplayForm : Form
    {
        private H264Controler playbackControler = null;

        public VideoReplayForm(int gateTotal)
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

            this.dateTimePicker_startTime.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker_startTime.Text = DateTime.Now.ToString();
            this.dateTimePicker_startTime_time.Text = DateTime.Now.ToString();
            this.dateTimePicker_endTime.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker_endTime.Text = DateTime.Now.ToString();
            this.dateTimePicker_endTime_time.Text = DateTime.Now.ToString();

            //以下初始化通道
            object[] items = new object[gateTotal];
            for (int i = 0; i < gateTotal; i++)
            {
                items[i] = (i + 1).ToString();
            }
            this.comboBox__channel.Items.AddRange(items);
            this.comboBox__channel.SelectedIndex = 0;
        }


        private void btnPlay_Click(object sender, EventArgs e)
        {
            viewVideo();
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


        private void simpleButton_view_Click(object sender, EventArgs e)
        {
            viewVideo();
        }

        public void viewVideo()
        {
            Monitor monitor = new Monitor();
            monitor.gateNo = comboBox__channel.SelectedIndex + 1;
            playbackControler.setMonitor(monitor);
            GateRecord gateRecord = new GateRecord();
            DateTime dt = DateTime.Parse(dateTimePicker_startTime.Text + " " + dateTimePicker_startTime_time.Text);
            DateTime dt1 = DateTime.Parse(dateTimePicker_endTime.Text + " " + dateTimePicker_endTime_time.Text);
            gateRecord.nvr_begintime = dt;
            gateRecord.nvr_endtime = dt1;
            playbackControler.play(gateRecord);
        }

    }
}
