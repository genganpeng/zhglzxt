using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using zhuhai.web;
using zhuhai.service;
using CookComputing.XmlRpc;
using zhuhai.xmlrpc;
using zhuhai.util;
using zhuhai.monitorinfo;
using zhuhai.monitorinfo.h264;

namespace zhuhai
{
    public partial class FormMain : DevExpress.XtraEditors.XtraForm
    {
        private int gateTotal = 100;
        private List<zhuhai.monitorinfo.Monitor> monitorList = new List<zhuhai.monitorinfo.Monitor>();
        private List<RadioButton> monitorRadios = new List<RadioButton>();
        private zhuhai.monitorinfo.Monitor previewMonitor = null;
        private RadioButton previewMonitorRadio = null;
        private H264Controler previewControler = null;
        private static int channelNumsByPage = 9;

        public FormMain()
        {
            init();
            InitializeComponent();
            addUIMonitors();
            this.DoubleBuffered = true;
            UpdateStyles();
            //initMonitorControler();
            this.barStaticItem_currentUser.Caption = "当前用户：" + SystemManageService.currentUser.UserName;
        }

        /// <summary>
        /// 初始化总通道数
        /// </summary>
        public void init()
        {
            try
            {
                gateTotal = GateService.getInstance().getGateTotal();
                for (int i = 1; i <= gateTotal; i++)
                {
                    zhuhai.monitorinfo.Monitor monitor = new zhuhai.monitorinfo.Monitor();
                    monitor.gateNo = i;
                    this.monitorList.Add(monitor);
                }
            }
            catch (Exception ex)
            {
                /*********************************上线时去掉 start****************************************************/
                for (int i = 1; i <= gateTotal; i++)
                {
                    zhuhai.monitorinfo.Monitor monitor = new zhuhai.monitorinfo.Monitor();
                    monitor.gateNo = i;
                    this.monitorList.Add(monitor);
                }
                /*********************************上线时去掉 end****************************************************/
                if (MessageBox.Show(ex.Message + "\n是否退出系统？", "错误", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    System.Environment.Exit(0);
                }
            }
        }

        /// <summary>
        /// 显示通道按钮
        /// </summary>
        private void addUIMonitors()
        {
            object[] monitors = monitorList.ToArray();
            int[] intervals = { 149, 148, 149, 147, 149, 149, 147, 149, 148 };
            int left = 10;
            for (int i = 0; i < monitors.Length; i++)
            {
                Monitor monitor = (Monitor)monitors[i];
                System.Windows.Forms.RadioButton radioMonitor = new System.Windows.Forms.RadioButton();
                radioMonitor.Appearance = System.Windows.Forms.Appearance.Button;
                radioMonitor.BackgroundImage = zhuhai.Properties.Resources.channelblue;
                radioMonitor.FlatAppearance.BorderSize = 0;
                radioMonitor.Cursor = System.Windows.Forms.Cursors.Hand;
                radioMonitor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                radioMonitor.Image = ((System.Drawing.Image)(zhuhai.Properties.Resources.ResourceManager.GetObject("_" + (i + 1).ToString())));
                if (i % channelNumsByPage == 0)
                {
                    left = 10;
                }
                radioMonitor.Location = new System.Drawing.Point(left, 5);
                left = left + intervals[i % channelNumsByPage];
                radioMonitor.Name = "radioButton" + (i + 1);
                radioMonitor.Size = new System.Drawing.Size(145, 82);
                radioMonitor.TabIndex = 73 + i;
                radioMonitor.TabStop = true;
                radioMonitor.UseVisualStyleBackColor = true;
                if (i < 10)
                {
                    radioMonitor.Visible = true;
                }
                else
                {
                    radioMonitor.Visible = false;
                }


                radioMonitor.Click += new System.EventHandler(this.selectMonitorRadio);

                if (i == 0)
                {
                    previewMonitorRadio = radioMonitor;
                }
                this.monitorRadios.Add(radioMonitor);
                this.channelPanel.Controls.Add(radioMonitor);
            }
        }

        public void initMonitorControler()
        {
            ICustomsCMS server = XmlRpcInstance.getInstance();
            previewControler = new H264Controler(this.videoPlayWnd, server);
            previewControler.setToolStripStatusLabel(this.toolStripStatusLabel);
            bool isSuccess = previewControler.init();
            if (!isSuccess)
            {
                System.Environment.Exit(0);
            }
            previewMonitor = this.monitorList[0];
            previewControler.setMonitor(previewMonitor);
            isSuccess = previewControler.preview();
            if (isSuccess)
            {
                RadioButton radioMonitor = this.monitorRadios[0];
                radioMonitor.Checked = true;
                radioMonitor.BackgroundImage = global::zhuhai.Properties.Resources.channelyellow;
            }
            else
            {
                previewMonitor = null;
                previewMonitorRadio = null;
            }
        }


        //选中一个通道后预览
        private void selectMonitorRadio(object sender, EventArgs e)
        {
            this.groupBox5.Controls.Remove(this.videoPlayWnd);
            this.xtraTabPage_shipinMonitor.Controls.Add(this.videoPlayWnd);
            selectMonitor();
        }

        private void selectMonitor()
        {
            object[] radios = this.monitorRadios.ToArray();
            for (int i = 0; i < radios.Length; i++)
            {
                System.Windows.Forms.RadioButton radio = (System.Windows.Forms.RadioButton)radios[i];
                if (radio.Checked)
                {
                    if (previewMonitor != monitorList[i])
                    {
                        if (previewMonitorRadio != null)
                        {
                            previewMonitorRadio.BackgroundImage = global::zhuhai.Properties.Resources.channelblue;
                        }

                        previewControler.setMonitor(monitorList[i]);
                        bool isSuccess = previewControler.preview();

                        if (isSuccess)
                        {
                            radio.BackgroundImage = global::zhuhai.Properties.Resources.channelyellow;
                            previewMonitor = monitorList[i];
                            previewMonitorRadio = radio;
                        }
                        else
                        {
                            radio.Checked = false;
                            radio.BackgroundImage = global::zhuhai.Properties.Resources.channelblue;
                            previewMonitor = null;
                            previewMonitorRadio = null;
                        }
                    }
                    break;
                }
            }
        }

        private void barButtonItem_disposePlan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           DisposePlanManageForm disposePlanManageForm = new DisposePlanManageForm();
            disposePlanManageForm.ShowDialog(this);
        }

        private void barButtonItem_workRule_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            WorkRuleManageForm workRuleManageForm = new WorkRuleManageForm();

            workRuleManageForm.ShowDialog(this);
        }

        private void barButtonItem_jobGuideBook_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            JobGuideBookManageForm jobGuideBookManageForm = new JobGuideBookManageForm();

            jobGuideBookManageForm.ShowDialog(this);
        }

        private void barButtonItem_epidemicInfo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            EpidemicInfoManageForm epidemicInfoManageForm = new EpidemicInfoManageForm();

            epidemicInfoManageForm.ShowDialog(this);
        }

        private void barButtonItem_systemManage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SystemManageForm systemManageForm = new SystemManageForm();
            systemManageForm.ShowDialog(this);
        }

        private void barButtonItem_exitSystem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void timer_updateTime_Tick(object sender, EventArgs e)
        {
            this.barStaticItem_systemTime.Caption = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
        }

        private void form_load(object sender, EventArgs e)
        {
            //每隔1秒更新显示时间
            this.timer_updateTime.Interval = 1000;
            this.timer_updateTime.Tick += new System.EventHandler(this.timer_updateTime_Tick);
            this.timer_updateTime.Start();

            //更新生化微小气候信息,每10秒更新一次
            this.timer_updateSHWXQH.Interval = 10000;
            this.timer_updateSHWXQH.Tick += new System.EventHandler(this.timer_updateSHWXQH_Tick);
            this.timer_updateSHWXQH.Start();

            timer_updateSHWXQH_Tick(sender, e);

        }

        private void timer_updateSHWXQH_Tick(object sender, EventArgs e)
        {
            //开启一个新的线程执行耗时操作
            System.Threading.Thread objThread = new System.Threading.Thread(new System.Threading.ThreadStart(delegate
            {
                shwxqhRequest();
            }));
            objThread.Start();
            
        }

        /// <summary>
        /// 请求生化微小气候，比较耗时
        /// </summary>
        private void shwxqhRequest()
        {
            ChemicalToxic chemicalToxic = Shwxqhxy.getchemdata();
            Bioaerosol bioaerosol = Shwxqhxy.getbiodata();
            Microclimate microlimate = Shwxqhxy.getendata();

            if (!this.IsDisposed)
            {
                //使用异步UI线程更新
                this.BeginInvoke((MethodInvoker)delegate()
                {
                    updateSHWXQH(chemicalToxic, bioaerosol, microlimate);
                });
            }
            
           
        }

        private void updateSHWXQH(ChemicalToxic chemicalToxic, Bioaerosol bioaerosol, Microclimate microlimate)
        {
            
            if (chemicalToxic != null)
            {
                this.navBarItem_huaxue.Caption = chemicalToxic.gastype + "：" + chemicalToxic.reading;
            }
            else
            {
                this.navBarItem_huaxue.Caption = "化学毒剂在线监测系统无法连接，请检查！";
            }

            
            if (bioaerosol != null)
            {
                //超标
                if (!String.IsNullOrWhiteSpace(bioaerosol.error))
                {
                    MessageBox.Show("生物气溶剂超标了！-->是否需要关闭所有的闸机-->是否需要弹出应急预案", "超标");
                }
                this.navBarItem_shengwu.Caption = bioaerosol.Status + "    " + bioaerosol.reading;
            }
            else
            {
                this.navBarItem_shengwu.Caption = "生物气溶胶在线监测系统无法连接，请检查！";
            }

            
            if (microlimate != null)
            {
                this.navBarItem_weixiaoqihou.Caption =
                    microlimate.Temperature + "\n" + microlimate.Humidity + "\n"
                    + microlimate.Lux + "\n" + microlimate.Pm + "\n"
                    + microlimate.Pressure + "\n" + microlimate.Co + "\n"
                    + microlimate.Co2 + "\n" + microlimate.Ms + "\n"
                    + microlimate.Hcho + "\n" + microlimate.Db;
            }
            else
            {
                this.navBarItem_weixiaoqihou.Caption = "微小气候在线监测系统无法连接，请检查！";
            }
        }

        private void barButtonItem_publishMessage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PublishNoticeForm publishNoticeForm = new PublishNoticeForm(gateTotal);
            publishNoticeForm.ShowDialog(this);
        }

        private void barButtonItem_gateThreshold_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GateThresholdUpdateForm gateThresholdUpdateForm = new GateThresholdUpdateForm(gateTotal);
            gateThresholdUpdateForm.ShowDialog(this);
        }

        private void barButtonItem_hxswqhThreshold_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HxswqhThresholdUpdateForm hxswqhThresholdUpdateForm = new HxswqhThresholdUpdateForm();
            hxswqhThresholdUpdateForm.ShowDialog(this);
        }

        private void barButtonItem_gateThresholdErrorUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GateThresholdErrorUpdateForm gateThresholdErrorUpdateForm = new GateThresholdErrorUpdateForm(gateTotal);
            gateThresholdErrorUpdateForm.ShowDialog(this);
            
        }

        private void barButtonItem_modeset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ModeStateSetForm modeStateSetForm = new ModeStateSetForm(gateTotal);
            modeStateSetForm.ShowDialog(this);
            //改变闸机运行模式和状态后更新对应的通关监控页面
            this.xtraTabPage_tongguanMonitor.Refresh();
        }

        private void barButtonItem_ClearanceStatistics_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ClearanceStatisticsForm clearanceStatisticsForm = new ClearanceStatisticsForm(gateTotal);
            clearanceStatisticsForm.ShowDialog(this);
        }

        private void barButtonItem_clearanceRecord_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ClearanceRecordForm clearanceRecordForm = new ClearanceRecordForm(gateTotal);
            clearanceRecordForm.ShowDialog(this);
            
        }

       

        private void button_left_Click(object sender, EventArgs e)
        {
            if (radioMonitorStart - 1 >= 0)
            {
                refreshUIMonitors(-1);
            }
        }

        private void button_right_Click(object sender, EventArgs e)
        {
            if ((radioMonitorStart + 1) * channelNumsByPage < this.monitorList.Count())
            {
                refreshUIMonitors(1);
            }
        }

        int radioMonitorStart = 0;
        private void refreshUIMonitors(int addpage)
        {
            this.channelPanel.SuspendLayout();
            radioMonitorStart = radioMonitorStart + addpage;
            if (addpage > 0)
            {
                for (int i = this.monitorRadios.Count - 1; i >= 0; i--)
                {
                    System.Windows.Forms.RadioButton radioMonitor = this.monitorRadios[i];
                    if (i >= radioMonitorStart * channelNumsByPage && i < (radioMonitorStart + 1) * channelNumsByPage)
                    {
                        radioMonitor.Visible = true;
                    }
                    else
                    {
                        radioMonitor.Visible = false;
                    }
                }
            }
            else
            {
                for (int i = 0; i < this.monitorRadios.Count; i++)
                {
                    System.Windows.Forms.RadioButton radioMonitor = this.monitorRadios[i];
                    if (i >= radioMonitorStart * channelNumsByPage && i < (radioMonitorStart + 1) * channelNumsByPage)
                    {
                        radioMonitor.Visible = true;
                    }
                    else
                    {
                        radioMonitor.Visible = false;
                    }
                }
            }
            this.channelPanel.ResumeLayout();
        }

        private void xtraTabControl_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void xtraTabPage_tongguanMonitor_VisibleChanged(object sender, EventArgs e)
        {
            //页面可见时,初始化的时候调用了两次
            if (xtraTabPage_tongguanMonitor.Visible == true)
            {
                MessageBox.Show("1");
            }

        }

        private void xtraTabPage_zhajiMonitor_VisibleChanged(object sender, EventArgs e)
        {
            //页面可见时
            if (xtraTabPage_zhajiMonitor.Visible == true)
            {
                MessageBox.Show("2");
            }
        }

        private void xtraTabPage_shipinMonitor_VisibleChanged(object sender, EventArgs e)
        {
            //页面可见时
            if (xtraTabPage_shipinMonitor.Visible == true)
            {
                MessageBox.Show("3");
            }
        }
    }
}
