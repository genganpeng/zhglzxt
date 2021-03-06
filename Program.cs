﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using zhuhai.xmlrpc;
using CookComputing.XmlRpc;
using zhuhai.service;

namespace zhuhai
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");

            //WorkRuleManageForm workRuleManageForm = new WorkRuleManageForm();
            //workRuleManageForm.ShowDialog();

            //JobGuideBookManageForm jobGuideBookManageForm = new JobGuideBookManageForm();
            //jobGuideBookManageForm.ShowDialog();

            //EpidemicInfoManageForm epidemicInfoManageForm = new EpidemicInfoManageForm();
            //epidemicInfoManageForm.ShowDialog();

            //DisposePlanManageForm disposePlanManageForm = new DisposePlanManageForm();
            //disposePlanManageForm.ShowDialog();

            //RichTextEditorForm richTextEditorForm = new RichTextEditorForm(WorkRuleService.getInstance());
            //richTextEditorForm.ShowDialog();

            //SystemManageForm smForm = new SystemManageForm();
            //smForm.ShowDialog();

            //ICustomsCMS server = XmlRpcProxyGen.Create<ICustomsCMS>();
            //GateThresholdUpdateForm gateThresholdUpdateForm = new GateThresholdUpdateForm(server, 100);
            //gateThresholdUpdateForm.ShowDialog();


            //ClearanceRecordForm clearanceRecordForm = new ClearanceRecordForm(100);
            //clearanceRecordForm.ShowDialog();

            //新建Login窗口
            LoginForm login = new LoginForm();

            //使用模式对话框方法显示FLogin
            login.ShowDialog();

            //DialogResult用来判断是否登录成功
            if (login.DialogResult == DialogResult.OK)
            {
                //在线程中打开主窗体
                Application.Run(new FormMain());
            }
        }
    }
}
