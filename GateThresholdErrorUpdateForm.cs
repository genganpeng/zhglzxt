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
using zhuhai.service;

namespace zhuhai
{
    public partial class GateThresholdErrorUpdateForm : Form
    {
        private int gateTotal = 100;
        private double temperature_error = 0;
        private double nuclear_error = 0;
        private double temperature_error_default = 0;
        private double nuclear_error_default = 0;
        /// <summary>
        /// 用于表示是否由于点击全选按钮而导致的按钮选中
        /// </summary>
        private Boolean selectedAllButton = false;

        public GateThresholdErrorUpdateForm(int gateTotal)
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
                //点击全选按钮后，选中最后一个重置标示
                if (i == checkedListBoxControl_gate.Items.Count - 1)
                {
                    selectedAllButton = false;
                }
                this.checkedListBoxControl_gate.SetItemChecked(i, check);
            }

        }

        private void simpleButton_modify_Click(object sender, EventArgs e)
        {
            if (this.checkedListBoxControl_gate.CheckedItems.Count == 0)
            {
                MessageBox.Show("请选择通道！");
                return;
            }

            if (this.textEdit_temperatureError.Text == "" || this.textEdit_temperatureError.Text.Trim() == "")
            {
                MessageBox.Show("请输入温度误差值（比如+0.1,-0.1）！");
                this.textEdit_temperatureError.Focus();
                return;
            }
            else
            {
                try
                {
                    temperature_error = double.Parse(this.textEdit_temperatureError.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("请输入有效温度误差值（比如+0.1,-0.1）！");
                    this.textEdit_temperatureError.Focus();
                    return;
                }
            }
            if (this.textEdit_nuclearError.Text == "" || this.textEdit_nuclearError.Text.Trim() == "")
            {
                MessageBox.Show("请输入核素误差值（比如+0.1,-0.1）！");
                this.textEdit_nuclearError.Focus();
                return;
            }
            else
            {
                try
                {
                    nuclear_error = double.Parse(this.textEdit_nuclearError.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("请输入有效核素误差值（比如+0.1,-0.1）！");
                    this.textEdit_nuclearError.Focus();
                    return;
                }
            }

            int[] gateIds = new int[this.checkedListBoxControl_gate.CheckedItems.Count];
            for (int i = 0; i < this.checkedListBoxControl_gate.CheckedItems.Count; i++)
            {
                object obj = this.checkedListBoxControl_gate.CheckedItems[i];
                gateIds[i] = (int)obj;
            }

            try
            {
                UpdateThresholdService.getInstance().updateGateThreshold(temperature_error, nuclear_error, gateIds);
                MessageBox.Show("修改闸机误差值成功！");
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
        /// 手动选中每个值后，查找对应的闸机的阈值误差并显示
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
                GateThresholdErrorValue gateThresholdErrorValue = GateService.getInstance().getGateThresholdError(index + 1);
                //为空就是默认值
                if (gateThresholdErrorValue == null)
                {
                    textEdit_nuclearError.Text = nuclear_error_default.ToString();
                    textEdit_temperatureError.Text = temperature_error_default.ToString();
                }
                else
                {
                    textEdit_nuclearError.Text = gateThresholdErrorValue.nuclear_error.ToString();
                    textEdit_temperatureError.Text = gateThresholdErrorValue.temperature_error.ToString();
                }
            }
        }
    }
}
