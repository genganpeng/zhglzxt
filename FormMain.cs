﻿using System;
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

namespace zhuhai
{
    public partial class FormMain : DevExpress.XtraEditors.XtraForm
    {
        public FormMain()
        {
            InitializeComponent();
            this.barStaticItem_currentUser.Caption = "当前用户：" + SystemManageService.currentUser.UserName;
        }

        private void barButtonItem_disposePlan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           DisposePlanManageForm disposePlanManageForm = new DisposePlanManageForm();

            disposePlanManageForm.ShowDialog(this);
        }

        private void navBarControl1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void barStaticItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

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

            //更新生化微小气候信息
            this.timer_updateSHWXQH.Interval = 10000;
            this.timer_updateSHWXQH.Tick += new System.EventHandler(this.timer_updateSHWXQH_Tick);
            this.timer_updateSHWXQH.Start();

            updateSHWXQH();
        }

        private void timer_updateSHWXQH_Tick(object sender, EventArgs e)
        {
            updateSHWXQH();
        }

        private void updateSHWXQH()
        {
            ChemicalToxic chemicalToxic = Shwxqhxy.getchemdata();
            if (chemicalToxic != null)
            {
                this.navBarItem_huaxue.Caption = chemicalToxic.gastype + "：" + chemicalToxic.reading;
            }
            else 
            {
                this.navBarItem_huaxue.Caption = "化学毒剂在线监测系统无法连接，请检查！";
            }

            Bioaerosol bioaerosol = Shwxqhxy.getbiodata();
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

            Microclimate microlimate = Shwxqhxy.getendata();
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
    }
}
