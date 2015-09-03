using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zhuhai.xmlrpc;
using zhuhai.util;

namespace zhuhai
{
    public partial class HxswqhThresholdUpdateForm : Form
    {
        private ICustomsCMS server = null;

        private double biology = 38;
        private double chem = 10;

        public HxswqhThresholdUpdateForm(ICustomsCMS server)
        {
            InitializeComponent();
            this.server = server;

            //以下是获取原来的阈值，并显示出来
            SysTask task = new SysTask();
            task.target_gates = new int[] {AppConfig.hxswqhnum};
            try
            {
                TaskRPCResponse taskRPCResponse = server.getCurrentThreshold(AppConfig.hxswqhsensor, task);
                if (taskRPCResponse.error_code == 0)
                {
                    double biology = taskRPCResponse.task.biology;
                    double chem = taskRPCResponse.task.chem;
                    textEdit_biology.Text = biology.ToString();
                    textEdit_chem.Text = chem.ToString();
                }
                else
                {
                    MessageBox.Show("连接服务器错误：" + taskRPCResponse.error_msg);
                }
            }
            catch
            {
                textEdit_biology.Text = biology.ToString();
                textEdit_chem.Text = chem.ToString();
            }
        }

        private void simpleButton_modify_Click(object sender, EventArgs e)
        {
            if (this.textEdit_biology.Text == "" || this.textEdit_biology.Text.Trim() == "")
            {
                MessageBox.Show("请输入生物战剂阀值！");
                this.textEdit_biology.Focus();
                return;
            }
            else
            {
                try
                {
                    biology = double.Parse(this.textEdit_biology.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("请输入有效生物战剂值！");
                    this.textEdit_biology.Focus();
                    return;
                }
            }
            if (this.textEdit_chem.Text == "" || this.textEdit_chem.Text.Trim() == "")
            {
                MessageBox.Show("请输入化学战剂阀值！");
                this.textEdit_chem.Focus();
                return;
            }
            else
            {
                try
                {
                    chem = double.Parse(this.textEdit_chem.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("请输入化学战剂值！");
                    this.textEdit_chem.Focus();
                    return;
                }
            }

            SysTask task = new SysTask();
            task.type = (int)TaskType.UpdateThreshold;
            task.target_gates = new int[AppConfig.hxswqhnum];
            task.biology = biology;
            task.chem = chem;
            try
            {
                RPCResponse response = this.server.publishTask(AppConfig.hxswqhsensor, task);
                if (response.error_code == 0)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("修改阀值错误：" + response.error_msg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }

        private void simpleButton_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
