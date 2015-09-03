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
    public partial class PublishNoticeForm : Form
    {
        private ICustomsCMS server = null;

        private int gateTotal = 10;

        public PublishNoticeForm(ICustomsCMS server, int gateTotal)
        {
            InitializeComponent();
            this.gateTotal = gateTotal;
            object[] checkListItems = new object[gateTotal];
            for (int i = 0; i < gateTotal; i++)
            {
                checkListItems[i] = i + 1;
            }
            this.checkedListBoxControl_gate.Items.Clear();
            this.checkedListBoxControl_gate.Items.AddRange(checkListItems);
            this.server = server;
        }

        private void simpleButton_allChecked_Click(object sender, EventArgs e)
        {
            checkAllState(true);
        }

        private void simpleButton_cancelChecked_Click(object sender, EventArgs e)
        {
            checkAllState(false);
        }

        private void checkAllState(bool check)
        {
            for (int i = 0; i < this.checkedListBoxControl_gate.Items.Count; i++)
            {
                this.checkedListBoxControl_gate.SetItemChecked(i, check);
            }
        }

        private void simpleButton_publish_Click(object sender, EventArgs e)
        {
            if (this.checkedListBoxControl_gate.CheckedItems.Count == 0)
            {
                MessageBox.Show("请选择通道！");
                return;
            }

            if (this.textBox_message.Text == "" || this.textBox_message.Text.Trim() == "")
            {
                MessageBox.Show("请输入消息文字！");
                this.textBox_message.Focus();
                return;
            }

            int[] gateIds = new int[this.checkedListBoxControl_gate.CheckedItems.Count];
            for (int i = 0; i < this.checkedListBoxControl_gate.CheckedItems.Count; i++)
            {
                object obj = this.checkedListBoxControl_gate.CheckedItems[i];
                gateIds[i] = (int)obj;
            }
            SysTask task = new SysTask();
            task.type = (int)TaskType.PublishNotice;
            task.notice = this.textBox_message.Text.Trim();
            task.target_gates = gateIds;
            try
            {
                RPCResponse response = server.publishTask(AppConfig.gateSensor, task);
                if (response.error_code == 0)
                {
                    MessageBox.Show("发布消息成功！");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("发布消息错误：" + response.error_msg);
                }
            }
            catch(Exception ex)
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
