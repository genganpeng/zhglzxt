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
    public partial class GateThresholdUpdateForm : Form
    {
        private ICustomsCMS server = null;

        private int gateTotal = 10;
        private double temperature = 38;
        private double nuclear = 10;
        /// <summary>
        /// 用于表示是否由于点击全选按钮而导致的按钮选中
        /// </summary>
        private Boolean selectedAllButton = false;

        public GateThresholdUpdateForm(ICustomsCMS server, int gateTotal)
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
            selectedAllButton = true;
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
                //点击全选按钮后，选中最后一个重置标示
                if (i == checkedListBoxControl_gate.Items.Count - 1)
                {
                    selectedAllButton = false;
                }
            }

        }

        private void simpleButton_modify_Click(object sender, EventArgs e)
        {
            if (this.checkedListBoxControl_gate.CheckedItems.Count == 0)
            {
                MessageBox.Show("请选择通道！");
                return;
            }

            if (this.textEdit_temperature.Text == "" || this.textEdit_temperature.Text.Trim() == "")
            {
                MessageBox.Show("请输入温度阀值！");
                this.textEdit_temperature.Focus();
                return;
            }
            else
            {
                try
                {
                    temperature=double.Parse(this.textEdit_temperature.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("请输入有效温度值(整数)！");
                    this.textEdit_temperature.Focus();
                    return;
                }
            }
            if (this.textEdit_nuclear.Text == "" || this.textEdit_nuclear.Text.Trim() == "")
            {
                MessageBox.Show("请输入核素阀值！");
                this.textEdit_nuclear.Focus();
                return;
            }
            else
            {
                try
                {
                    nuclear = double.Parse(this.textEdit_nuclear.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("请输入有效核素值(小数)！");
                    this.textEdit_nuclear.Focus();
                    return;
                }
            }

            int[] gateIds = new int[this.checkedListBoxControl_gate.CheckedItems.Count];
            for (int i = 0; i < this.checkedListBoxControl_gate.CheckedItems.Count; i++)
            {
                object obj = this.checkedListBoxControl_gate.CheckedItems[i];
                gateIds[i] = (int)obj;
            }

            SysTask task = new SysTask();
            task.type = (int)TaskType.UpdateThreshold;
            task.target_gates = gateIds;
            task.thr_temperature = temperature;
            task.thr_nuclear = nuclear;
            try
            {
                RPCResponse response = this.server.publishTask(AppConfig.gateSensor, task);
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

        /// <summary>
        /// 手动选中每个值后，查找对应的闸机的阈值并显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkedListBoxControl_gate_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            int index = e.Index;
            CheckState checkState = e.State;
            //如果是当前项被选中，则获取该闸机的阈值显示出来
            if (selectedAllButton == false && checkState == CheckState.Checked)
            {
                SysTask task = new SysTask();
                task.target_gates = new int[]{index + 1};
                try
                {
                    TaskRPCResponse taskRPCResponse = server.getCurrentThreshold(AppConfig.gateSensor, task);
                    if (taskRPCResponse.error_code == 0)
                    {
                        double temperature = taskRPCResponse.task.thr_temperature;
                        double nuclear = taskRPCResponse.task.thr_nuclear;
                        textEdit_nuclear.Text = nuclear.ToString();
                        textEdit_temperature.Text = temperature.ToString();
                    }
                    else
                    {
                        MessageBox.Show("连接服务器错误：" + taskRPCResponse.error_msg);
                    }
                }
                catch
                {
                    textEdit_nuclear.Text = nuclear.ToString();
                    textEdit_temperature.Text = temperature.ToString();
                }
                
            }

        }
    }
}
