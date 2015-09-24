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
using DevExpress.XtraBars;

namespace zhuhai
{
    public partial class FormMain : DevExpress.XtraEditors.XtraForm
    {
        private int gateTotal = 100;
        private List<zhuhai.monitorinfo.Monitor> monitorList = new List<zhuhai.monitorinfo.Monitor>();
        private List<System.Windows.Forms.Panel> monitorPanels = new List<System.Windows.Forms.Panel>();
        private zhuhai.monitorinfo.Monitor previewMonitor = null;
        private zhuhai.monitorinfo.Monitor previewMonitor1 = null;
        private zhuhai.monitorinfo.Monitor previewMonitor2 = null;
        private Panel previewMonitorPanels = null;
        private H264Controler previewControler = null;
        private H264Controler previewControler1 = null;
        private H264Controler previewControler2 = null;

        public FormMain()
        {
            init();
            InitializeComponent();
            initPermission();
            addGateMonitors();
            this.DoubleBuffered = true;
            UpdateStyles();
            initMonitorControler();
            this.barStaticItem_currentUser.Caption = "当前用户：" + SystemManageService.currentUser.UserName;

            //以下初始化通道
            object[] items = new object[gateTotal];
            for (int i = 0; i < gateTotal; i++)
            {
                items[i] = (i + 1).ToString();
            }
            this.comboBox_shipin_1.Items.AddRange(items);
            this.comboBox_shipin_2.Items.AddRange(items);
            this.comboBox_shipin_3.Items.AddRange(items);
            this.comboBox_shipin_1.SelectedIndex = 0;
            this.comboBox_shipin_2.SelectedIndex = 1;
            this.comboBox_shipin_3.SelectedIndex = 2;


        }

        /// <summary>
        /// 根据角色初始化权限
        /// </summary>
        public void initPermission()
        {
            if (PermissionControl.IsAuthorized("barButtonItem_systemManage") == false)
                barButtonItem_systemManage.Visibility = BarItemVisibility.Never;
            if (PermissionControl.IsAuthorized("barButtonItem_title") == false)
                barButtonItem_title.Visibility = BarItemVisibility.Never;
            if (PermissionControl.IsAuthorized("barButtonItem_publishMessage") == false)
                barButtonItem_publishMessage.Visibility = BarItemVisibility.Never;
            if (PermissionControl.IsAuthorized("barButtonItem_gateThresholdErrorUpdate") == false)
                barButtonItem_gateThresholdErrorUpdate.Visibility = BarItemVisibility.Never;
            if (PermissionControl.IsAuthorized("barButtonItem_gateThreshold") == false)
                barButtonItem_gateThreshold.Visibility = BarItemVisibility.Never;
            if (PermissionControl.IsAuthorized("barButtonItem_hxswqhThreshold") == false)
                barButtonItem_hxswqhThreshold.Visibility = BarItemVisibility.Never;
            if (PermissionControl.IsAuthorized("barButtonItem_modeset") == false)
                barButtonItem_modeset.Visibility = BarItemVisibility.Never;
            if (PermissionControl.IsAuthorized("barButtonItem_shenbaocontent") == false)
                barButtonItem_shenbaocontent.Visibility = BarItemVisibility.Never;
            if (PermissionControl.IsAuthorized("barButtonItem_log") == false)
                barButtonItem_log.Visibility = BarItemVisibility.Never;

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

        private void receiveMessage(object obj)
        {
            while (true)
            {
                try
                {
                    ICustomsCMS server = XmlRpcInstance.getInstance();
                    GateRecordResponse gateRecordResponse = server.getAbnormalRecord(AppConfig.gateSensor);
                    if (gateRecordResponse.error_code == 0 && !this.IsDisposed)
                    {
                        gateRecordResponse.gate_record.nvr_begintime = gateRecordResponse.gate_record.nvr_begintime;
                        gateRecordResponse.gate_record.nvr_endtime = gateRecordResponse.gate_record.nvr_endtime;
                        this.Invoke(new Action<GateRecordResponse>(this.addAbnormalList), gateRecordResponse);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("获取异常人员出错：" + ex.Message, "错误");
                }
                finally
                {
                    System.Threading.Thread.Sleep(AppConfig.getMessageSecond);
                }
                
                
            }
        }

        private List<GateRecord> abnormalList = new List<GateRecord>();//检测异常人员集

        public void addAbnormalList(GateRecordResponse gateRecordResponse)
        {
            int gate_id = gateRecordResponse.gate_record.gate_id;
            abnormalList.Insert(0, gateRecordResponse.gate_record);
            //超过显示的数量则删除最后一条记录
            if (abnormalList.Count > AppConfig.personNo)
            {
                abnormalList.RemoveAt(abnormalList.Count - 1);
            }
            gridControl_abnormal.DataSource = abnormalList;
            gridControl_abnormal.RefreshDataSource();

            if (!this.IsDisposed)
            {
                //显示报警灯
                System.Windows.Forms.PictureBox pictureBox = (PictureBox)( monitorPanels[gate_id - 1].Controls.Find("pictureBox" + (gate_id).ToString() + "2", false)[0]);
                pictureBox.Visible = true;
                System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(this.channelBlinkThread), gate_id);
                ICustomsCMS server = XmlRpcInstance.getInstance();

                if (MessageBox.Show("检查到异常记录,是否切换到异常预案中？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    RichTextEditorForm richTextEditorForm = new RichTextEditorForm(0, "温度", DisposePlanService.getInstance(), true);
                    richTextEditorForm.ShowDialog();
                }
            }

        }



        
        /// <summary>
        /// 显示闸机监控
        /// </summary>
        private void addGateMonitors()
        {
            int x = 10;
            int y = 10;
            int panelWidth = 200;
            int panelHeight = 235;
            int interval = 10;//间隔
            for (int i = 0; i < gateTotal; i++)
            {

                System.Windows.Forms.PictureBox pictureBox10 = new System.Windows.Forms.PictureBox();
                System.Windows.Forms.PictureBox pictureBox11 = new System.Windows.Forms.PictureBox();
                System.Windows.Forms.Label label10 = new System.Windows.Forms.Label();
                System.Windows.Forms.Label label11 = new System.Windows.Forms.Label();
                System.Windows.Forms.Label label12 = new System.Windows.Forms.Label();
                System.Windows.Forms.Label label13 = new System.Windows.Forms.Label();
                System.Windows.Forms.Label label14 = new System.Windows.Forms.Label();
                System.Windows.Forms.Panel panel1 = new System.Windows.Forms.Panel();
                System.Windows.Forms.PictureBox pictureBox12 = new System.Windows.Forms.PictureBox();

                zhajipanel.Controls.Add(panel1);
                panel1.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(pictureBox10)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(pictureBox11)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(pictureBox12)).BeginInit();

                // 
                // panel1
                // 
                panel1.BackgroundImage = global::zhuhai.Properties.Resources.gate_normal;
                panel1.Controls.Add(pictureBox12);
                panel1.Controls.Add(label14);
                panel1.Controls.Add(label13);
                panel1.Controls.Add(label12);
                panel1.Controls.Add(label11);
                panel1.Controls.Add(label10);
                panel1.Controls.Add(pictureBox11);
                panel1.Controls.Add(pictureBox10);
                panel1.Location = new System.Drawing.Point(44, 12);
                panel1.Name = "panel" + (i + 1).ToString();
                panel1.Size = new System.Drawing.Size(panelWidth, panelHeight);
                panel1.TabIndex = 200 + i;
                panel1.Click += new System.EventHandler(this.monitorPanel_click);
                panel1.Cursor = Cursors.Hand;
                panel1.ContextMenuStrip = this.contextMenuStrip;

                Size size = this.zhajipanel.Size;
                if (x > size.Width - panelWidth)
                {
                    y += panelHeight;
                    //间隔
                    y += interval;
                    //x轴的起点
                    x = 10;
                }
                panel1.Location = new System.Drawing.Point(x, y);
                x += panelWidth + interval;

                // 
                // pictureBox10
                // 
                pictureBox10.BackColor = System.Drawing.Color.Transparent;
                pictureBox10.Image = global::zhuhai.Properties.Resources.kuaisutongguan;
                pictureBox10.Location = new System.Drawing.Point(2, 202);
                pictureBox10.Name = "pictureBox" + (i + 1).ToString()  + "0";
                pictureBox10.Size = new System.Drawing.Size(32, 32);
                pictureBox10.TabIndex = 300 + i;
                pictureBox10.TabStop = false;
                // 
                // pictureBox11
                // 
                pictureBox11.BackColor = System.Drawing.Color.Transparent;
                pictureBox11.Image = global::zhuhai.Properties.Resources.wuchatiaojie;
                pictureBox11.Location = new System.Drawing.Point(35, 202);
                pictureBox11.Name = "pictureBox" + (i + 1).ToString() + "1";
                pictureBox11.Size = new System.Drawing.Size(32, 32);
                pictureBox11.TabIndex = 400 + i;
                pictureBox11.TabStop = false;
                // 
                // label10
                // 
                label10.AutoSize = true;
                label10.BackColor = System.Drawing.Color.Transparent;
                label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                label10.ForeColor = System.Drawing.Color.White;
                label10.Location = new System.Drawing.Point(69, 213);
                label10.Name = "label" + (i + 1).ToString() + "0";
                label10.Size = new System.Drawing.Size(22, 14);
                label10.TabIndex = 500 + i;
                label10.Text = "核";
                // 
                // label11
                // 
                label11.AutoSize = true;
                label11.BackColor = System.Drawing.Color.Transparent;
                label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                label11.ForeColor = System.Drawing.Color.White;
                label11.Location = new System.Drawing.Point(142, 213);
                label11.Name = "label" + (i + 1).ToString() + "1";
                label11.Size = new System.Drawing.Size(22, 14);
                label11.TabIndex = 600 + i;
                label11.Text = "温";
                // 
                // label12
                // 
                label12.BackColor = System.Drawing.Color.Transparent;
                label12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                label12.ForeColor = System.Drawing.Color.White;
                label12.Location = new System.Drawing.Point(90, 212);
                label12.Margin = new System.Windows.Forms.Padding(0);
                label12.Name = "label" + (i + 1).ToString() + "2";
                label12.Size = new System.Drawing.Size(52, 16);
                label12.TabIndex = 700 + i;
                label12.Text = "250.0";
                label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label13
                // 
                label13.BackColor = System.Drawing.Color.Transparent;
                label13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                label13.ForeColor = System.Drawing.Color.White;
                label13.Location = new System.Drawing.Point(165, 212);
                label13.Margin = new System.Windows.Forms.Padding(0);
                label13.Name = "label" + (i + 1).ToString() + "3";
                label13.Size = new System.Drawing.Size(48, 16);
                label13.TabIndex = 800 + i;
                label13.Text = "38.0";
                label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label14
                // 
                label14.BackColor = System.Drawing.Color.Transparent;
                label14.Font = new System.Drawing.Font("宋体", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                label14.ForeColor = System.Drawing.Color.Blue;
                label14.Location = new System.Drawing.Point(3, 20);
                label14.Name = "label" + (i + 1).ToString() + "4";
                label14.Size = new System.Drawing.Size(194, 105);
                label14.TabIndex = 900 + i;
                label14.Text = (i + 1).ToString(); ;
                label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                // 
                // pictureBox12
                // 
                pictureBox12.BackColor = System.Drawing.Color.Transparent;
                pictureBox12.Image = global::zhuhai.Properties.Resources.baojingdeng;
                pictureBox12.Location = new System.Drawing.Point(125, 130);
                pictureBox12.Name = "pictureBox" + (i + 1).ToString() + "2";
                pictureBox12.Visible = false;
                pictureBox12.Size = new System.Drawing.Size(72, 66);
                pictureBox12.TabIndex = 1000 + i;
                pictureBox12.TabStop = false;
                
                panel1.ResumeLayout(false);
                panel1.PerformLayout();
                ((System.ComponentModel.ISupportInitialize)(pictureBox12)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(pictureBox11)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(pictureBox10)).EndInit();

                monitorPanels.Add(panel1);
            }
        }

        private void receiveGateState(object obj)
        {
            while (true && (!this.IsDisposed))
            {

                try
                {
                    ICustomsCMS server = XmlRpcInstance.getInstance();
                    List<int> gateIds = new List<int>();
                    for (int i = 1; i <= 100; i++)
                    {
                        gateIds.Add(i);
                    }

                    Gate_state_record_Response reportContent_Response = server.getGateAllInfo(AppConfig.gateSensor, gateIds.ToArray());
                    if (reportContent_Response.error_code == 0 && !this.IsDisposed)
                    {
                        this.Invoke(new Action<Gate_state_record_Response>(this.refreshGateMonitors), reportContent_Response);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("获取闸机状态出错：" + ex.Message, "错误");
                }
                finally
                {
                    System.Threading.Thread.Sleep(AppConfig.getGateSecond);
                }
                
            }
        }

        /// <summary>
        /// 刷新闸机监控
        /// </summary>
        private void refreshGateMonitors(Gate_state_record_Response reportContent_Response)
        {
            //从server中获取所有的状态，使用线程的方式
            Gate_state_record[] gate_state_recode = reportContent_Response.gate_state_recode;

            for (int i = 0; i < gate_state_recode.Length; i++)
            {
                Panel panel1 = monitorPanels[i];

                String display = "闸机状态：" + EnumName.getWorkStateName(gate_state_recode[i].working_state)
                    + "\n闸机模式：" + EnumName.getGateModeName(gate_state_recode[i].mode)
                    + "\n误差调节：核素误差 " + gate_state_recode[i].tiny_nuclear + "，温度误差 " + gate_state_recode[i].tiny_temper
                    + "\n核素报警阀值 "+ gate_state_recode[i].thr_nuclear+ "，温度报警阀值 " + gate_state_recode[i].thr_temper
                    + "\n报警状态：核素报警状态-";
                if (gate_state_recode[i].unnormal_type == (int)zhuhai.xmlrpc.AbnormalType.Nuclear || gate_state_recode[i].unnormal_type == (int)zhuhai.xmlrpc.AbnormalType.TemperatareNuclear)
                    display += "报警 " + gate_state_recode[i].temperature.ToString() + "，温度报警状态-";
                else {
                    display += "无报警，温度报警状态-";
                }

                if (gate_state_recode[i].unnormal_type == (int)zhuhai.xmlrpc.AbnormalType.Temperatare || gate_state_recode[i].unnormal_type == (int)zhuhai.xmlrpc.AbnormalType.TemperatareNuclear)
                    display += "报警 " + gate_state_recode[i].temperature.ToString();
                else {
                    display += "无报警";
                }
                toolTip.SetToolTip(panel1, display);
                //模式
                System.Windows.Forms.PictureBox pictureBox10 = (PictureBox)(panel1.Controls.Find("pictureBox" + (i + 1).ToString() + "0", false)[0]);
                
                if (gate_state_recode[i].mode == (int)WorkMode.Shenbao)
                    pictureBox10.Image = global::zhuhai.Properties.Resources.shenbaotongguan;
                else if (gate_state_recode[i].mode == (int)WorkMode.Zizhu)
                    pictureBox10.Image = global::zhuhai.Properties.Resources.kuaisutongguan;
                else if (gate_state_recode[i].mode == (int)WorkMode.Shuaka)
                    pictureBox10.Image = global::zhuhai.Properties.Resources.shuakatongguan;
                else if (gate_state_recode[i].mode == (int)WorkMode.Fengbi)
                    pictureBox10.Image = global::zhuhai.Properties.Resources.jinzhitongxing;

                //状态
                if (gate_state_recode[i].working_state == (int)WorkState.ShutDown || gate_state_recode[i].working_state == (int)WorkState.Sleep)
                    panel1.BackgroundImage = global::zhuhai.Properties.Resources.gate_shutdown;
                else if (gate_state_recode[i].working_state ==  (int)WorkState.Normal)
                    panel1.BackgroundImage = global::zhuhai.Properties.Resources.gate_normal;
                else
                    panel1.BackgroundImage = global::zhuhai.Properties.Resources.gate_abnormal;

                System.Windows.Forms.PictureBox pictureBox11 = (PictureBox)(panel1.Controls.Find("pictureBox" + (i + 1).ToString() + "1", false)[0]);
                //根据是否设置温度或者核素误差阈值显示该图片
                if (gate_state_recode[i].tiny_nuclear != 0 || gate_state_recode[i].tiny_temper != 0)
                {
                    pictureBox11.Visible = true;
                }
                else
                {
                    pictureBox11.Visible = false;
                }
                
                //显示当前核数阈值
                System.Windows.Forms.Label label12 = (Label)(panel1.Controls.Find("label" + (i + 1).ToString() + "2", false)[0]);
                label12.Text = gate_state_recode[i].nuclear.ToString();

                //显示当前温度阈值
                System.Windows.Forms.Label label13 = (Label)(panel1.Controls.Find("label" + (i + 1).ToString() + "3", false)[0]);
                label13.Text = gate_state_recode[i].temperature.ToString();

                
            }
        }

        public void initMonitorControler()
        {
            ICustomsCMS server = XmlRpcInstance.getInstance();

            previewControler1 = new H264Controler(this.videoPlayWnd_1, server);
            previewControler = new H264Controler(this.videoPlayWnd, server);
            
            previewControler2 = new H264Controler(this.videoPlayWnd_2, server);
            previewControler.setToolStripStatusLabel(this.toolStripStatusLabel);
            previewControler1.setToolStripStatusLabel(this.toolStripStatusLabel);
            previewControler2.setToolStripStatusLabel(this.toolStripStatusLabel);
            bool isSuccess = previewControler.init();
            isSuccess = previewControler1.init() || isSuccess;
            isSuccess = previewControler2.init() || isSuccess;
            if (!isSuccess)
            {
                System.Environment.Exit(0);
            }
            previewMonitor = this.monitorList[0];
            previewMonitor1 = this.monitorList[1];
            previewMonitor2 = this.monitorList[2];
            previewControler.setMonitor(previewMonitor);
            previewControler1.setMonitor(this.monitorList[1]);
            previewControler2.setMonitor(this.monitorList[2]);
            isSuccess = previewControler.preview();
            isSuccess = previewControler1.preview() || isSuccess;
            isSuccess = previewControler2.preview() || isSuccess;
            if (isSuccess)
            {
                Panel panel = this.monitorPanels[0];
                previewMonitorPanels = panel;
            }
            else
            {
                previewMonitor = null;
                previewMonitorPanels = null;
            }
        }


        //选中一个通道后预览
        private void monitorPanel_click(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            selectMonitor(panel);
        }

        private void selectMonitor(Panel panel)
        {
            string name = panel.Name;
            //name 由 panel + 闸机号构成
            string selectedGateNo = name.Substring(5);
            int gateNo = Int32.Parse(selectedGateNo);

            

            //不是上一次监控的闸机
            if (previewMonitor != monitorList[gateNo - 1])
            {
                previewControler.setMonitor(monitorList[gateNo - 1]);
                bool isSuccess = previewControler.preview();

                if (isSuccess)
                {
                    previewMonitor = monitorList[gateNo - 1];
                    previewMonitorPanels = panel;

                    xtraTabControl.SelectedTabPage = xtraTabPage_shipinMonitor;
                }
                else
                {
                    previewMonitor = null;
                    previewMonitorPanels = null;
                }

                //设置视频监控中选中的闸机
                comboBox_shipin_1.SelectedIndex = gateNo - 1;
            }
        }

        //几秒后红色消失
        private void channelBlinkThread(object gate_no)
        {
            System.Threading.Thread.Sleep(AppConfig.blinkSecond);
            if (!this.IsDisposed)
            {
                this.Invoke(new Action<int>(this.channelBlink), (int)gate_no);
            }
        }

        /// <summary>
        /// 停止闪烁
        /// </summary>
        /// <param name="gate_no"></param>
        private void channelBlink(int gate_no)
        {
            //显示报警灯
            System.Windows.Forms.PictureBox pictureBox = (PictureBox)(monitorPanels[gate_no - 1].Controls.Find("pictureBox" + (gate_no).ToString() + "2", false)[0]);
            pictureBox.Visible = false;
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
            if (previewControler != null && previewControler1 != null && previewControler2 != null)
            {
                previewControler.stopCurrentPreview();
                previewControler1.stopCurrentPreview();
                previewControler2.stopCurrentPreview();
            }
            if (previewControler != null && previewControler1 != null && previewControler2 != null)
            {
                previewControler.quit();
                previewControler1.quit();
                previewControler2.quit();
            }
            LogService.getInstance().log(ModuleConstant.LOGOUT_MODULE_CONTENT, ModuleConstant.LOGOUT_MODULE);
            Application.Exit();
        }

        private void timer_updateTime_Tick(object sender, EventArgs e)
        {
            this.barStaticItem_systemTime.Caption = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
        }

        //private void refreshVideoMonitor(object obj)
        //{
        //    while (true)
        //    {
        //        if (previewControler != null && previewMonitor != null)
        //        {
        //            previewControler.setMonitor(previewMonitor);
        //            previewControler.preview();
        //        }
        //        System.Threading.Thread.Sleep(30 * 60 * 1000);
        //    }
        //}

        private void form_load(object sender, EventArgs e)
        {
            System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(this.receiveMessage));
            //System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(this.refreshVideoMonitor));
            System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(this.receiveGateState));
            
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
                    if (!this.IsDisposed)
                    {
                        updateSHWXQH(chemicalToxic, bioaerosol, microlimate);
                    }
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

       


        private void xtraTabControl_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void xtraTabPage_tongguanMonitor_VisibleChanged(object sender, EventArgs e)
        {
        }

        private void xtraTabPage_zhajiMonitor_VisibleChanged(object sender, EventArgs e)
        {
            //页面可见时
            if (xtraTabPage_zhajiMonitor.Visible == true)
            {

            }
        }

        private void xtraTabPage_shipinMonitor_VisibleChanged(object sender, EventArgs e)
        {
            //页面可见时
            if (xtraTabPage_shipinMonitor.Visible == true)
            {
                this.xtraTabPage_tongguanMonitor.SuspendLayout();
                this.xtraTabPage_shipinMonitor.Controls.Add(this.videoPlayWnd);
                this.xtraTabPage_tongguanMonitor.ResumeLayout();
            }
            else
            {
                this.xtraTabPage_shipinMonitor.Controls.Remove(this.videoPlayWnd);
            }
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            
        }

        private void barButtonItem_videoReplay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            VideoReplayForm videoReplayForm = new VideoReplayForm();
            videoReplayForm.ShowDialog(this);
        }

        private void gridControl_abnormal_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (gridView_abnormal.SelectedRowsCount != 1)
            {
                MessageBox.Show("请选择一条记录！", "警告");
                return;
            }
            //获取选中的行的行号
            int[] rowNums = gridView_abnormal.GetSelectedRows();
            List<GateRecord> list = (List<GateRecord>)gridControl_abnormal.DataSource;
            DataRow dr = new ModelHandler<GateRecord>().FillDataRow(list[rowNums[0]]);

            ShowClearanceInfoForm showClearanceInfoForm = new ShowClearanceInfoForm(dr);
            showClearanceInfoForm.ShowDialog();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            LogService.getInstance().log(ModuleConstant.LOGOUT_MODULE_CONTENT, ModuleConstant.LOGOUT_MODULE);
        }

        private void barButtonItem_title_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetTitleForm form = new SetTitleForm();
            form.ShowDialog();
        }

        private void barButtonItem_shenbaocontent_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShenbaoContentForm shenbaoContentForm = new ShenbaoContentForm();
            shenbaoContentForm.ShowDialog();
        }

        private void barButtonItem_change_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (previewControler != null)
            {
                previewControler.stopCurrentPreview();
            }
            if (previewControler != null)
            {
                previewControler.quit();
            }
            LogService.getInstance().log(ModuleConstant.LOGOUT_MODULE_CONTENT, ModuleConstant.LOGOUT_MODULE);
            this.Visible = false;

            //新建Login窗口
            LoginForm login = new LoginForm();

            //使用模式对话框方法显示FLogin
            login.ShowDialog();

            //DialogResult用来判断是否登录成功
            if (login.DialogResult == DialogResult.OK)
            {
                this.Visible = true;
                initPermission();
            }
            else
            {
                Application.Exit();
            }
        }

        private int getSelectedGateNo(object sender)
        {
            Panel panel = selectedPanel;
            string name = panel.Name;
            //name 由 panel + 闸机号构成
            string selectedGateNo = name.Substring(5);
            int gateNo = Int32.Parse(selectedGateNo);
            return gateNo;
        }

        private void ToolStripMenuItem_restart_Click(object sender, EventArgs e)
        {
            changeGateState(getSelectedGateNo(sender), "闸机重启", (int)OrderType.Gate_Reboot);
        }

        /// <summary>
        /// 改变闸机状态
        /// </summary>
        /// <param name="modeStr">状态字符串</param>
        /// <param name="mode">状态</param>
        public void changeGateState(int gateNo, string stateStr, int state)
        {

            int[] gateIds = new int[] { gateNo };
            if (gateIds == null) return;
            if (MessageBox.Show("你确定要改变选中闸机" + gateNo.ToString() + "进行" + stateStr + "操作？", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            ModeStateSetService service = ModeStateSetService.getInstance();
            try
            {
                service.updateGateState(state, gateIds);
                LogService.getInstance().log(gateIds.ToString() + "闸机状态变为" + stateStr, ModuleConstant.ModeStateSet_MODULE);
                MessageBox.Show("操作闸机状态成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }

        private void ToolStripMenuItem_shutDown_Click(object sender, EventArgs e)
        {
            changeGateState(getSelectedGateNo(sender),  "闸机复位", (int)OrderType.Gate_Reset);
        }

        /// <summary>
        /// 改变闸机运行模式
        /// </summary>
        /// <param name="modeStr">模式字符串</param>
        /// <param name="mode">运行模式</param>
        private void changeGateMode(int gateNo, string modeStr, int mode)
        {

            int[] gateIds = new int[] { gateNo };
            if (gateIds == null) return;
            if (MessageBox.Show("你确定要改变选中闸机" + gateNo.ToString() + "的运行模式到" + modeStr + "模式？", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            ModeStateSetService service = ModeStateSetService.getInstance();
            try
            {
                service.updateGateMode(mode, gateIds);
                MessageBox.Show("修改闸机运行模式成功！");
                LogService.getInstance().log(gateIds.ToString() + "运行模式变为" + modeStr, ModuleConstant.GateMode_MODULE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }

        private void ToolStripMenuItem_kuaisutongguan_Click(object sender, EventArgs e)
        {
            changeGateMode(getSelectedGateNo(sender), "自助通关", (int)WorkMode.Zizhu);
        }

        private void ToolStripMenuItem_shuakatongguan_Click(object sender, EventArgs e)
        {
            changeGateMode(getSelectedGateNo(sender), "刷卡通关", (int)WorkMode.Shuaka);
        }

        private void ToolStripMenuItem_shenbaotongguan_Click(object sender, EventArgs e)
        {
            changeGateMode(getSelectedGateNo(sender), "申报通关", (int)WorkMode.Shenbao);
        }

        private void ToolStripMenuItem_jinjiguanbi_Click(object sender, EventArgs e)
        {
            changeGateMode(getSelectedGateNo(sender), "通关封闭", (int)WorkMode.Fengbi);
        }

        private void ToolStripMenuItem_nuclearThreshold_Click(object sender, EventArgs e)
        {
            SingleGateThresholdUpdateForm form = new SingleGateThresholdUpdateForm(getSelectedGateNo(sender));
            form.ShowDialog();
        }

        private void ToolStripMenuItem_nuclearThresholdError_Click(object sender, EventArgs e)
        {
            SingleGateThresholdErrorUpdateForm form = new SingleGateThresholdErrorUpdateForm(getSelectedGateNo(sender));
            form.ShowDialog();
        }

        private Panel selectedPanel = null;
        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            selectedPanel = ((ContextMenuStrip)sender).SourceControl as Panel;
        }

        private void barButtonItem_log_ItemClick(object sender, ItemClickEventArgs e)
        {
            LogRecordForm logRecordForm = new LogRecordForm();
            logRecordForm.ShowDialog();
        }

        private void comboBox_shipin_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int gateNo = comboBox_shipin_1.SelectedIndex + 1;
            //不是上一次监控的闸机
            if (previewMonitor != monitorList[gateNo -  1])
            {
                previewControler.setMonitor(monitorList[gateNo - 1]);
                bool isSuccess = previewControler.preview();

                if (isSuccess)
                {
                    previewMonitor = monitorList[gateNo - 1];
                    previewMonitorPanels = monitorPanels[gateNo - 1];
                }
                else
                {
                    previewMonitor = null;
                    previewMonitorPanels = null;
                }
            }
        }

        private void comboBox_shipin_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int gateNo = comboBox_shipin_2.SelectedIndex + 1;
            //不是上一次监控的闸机
            if (previewMonitor1 != monitorList[gateNo - 1])
            {
                previewControler1.setMonitor(monitorList[gateNo - 1]);
                bool isSuccess = previewControler1.preview();

                if (isSuccess)
                {
                    previewMonitor1 = monitorList[gateNo - 1];
                }
                else
                {
                    previewMonitor1 = null;
                }
            }
        }

        private void comboBox_shipin_3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int gateNo = comboBox_shipin_3.SelectedIndex + 1;
            //不是上一次监控的闸机
            if (previewMonitor1 != monitorList[gateNo - 1])
            {
                previewControler2.setMonitor(monitorList[gateNo - 1]);
                bool isSuccess = previewControler2.preview();

                if (isSuccess)
                {
                    previewMonitor2 = monitorList[gateNo - 1];
                }
                else
                {
                    previewMonitor2 = null;
                }
            }
        }
    }
}
