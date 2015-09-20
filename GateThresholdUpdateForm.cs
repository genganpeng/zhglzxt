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
    public partial class GateThresholdUpdateForm : Form
    {
        private int gateTotal = 100;
        private double temperature_default = 38;
        private double nuclear_default = 10;
        private double temperature = 38;
        private double nuclear = 10;
        /// <summary>
        /// 用于表示是否由于点击全选按钮而导致的按钮选中
        /// </summary>
        private Boolean selectedAllButton = false;

        public GateThresholdUpdateForm(int gateTotal)
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

            try
            {
                UpdateThresholdService.getInstance().updateGateThreshold(temperature, nuclear, gateIds);
                MessageBox.Show("修改闸机阈值成功！");

                LogService.getInstance().log(ModuleConstant.HxswqhThresholod_MODULE, ModuleConstant.HxswqhThresholod_MODULE);
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
                GateThresholdValue gateThresholdValue = GateService.getInstance().getGateThreshold(index + 1);
                //为空就是默认值
                if (gateThresholdValue == null)
                {
                    textEdit_nuclear.Text = nuclear_default.ToString();
                    textEdit_temperature.Text = temperature_default.ToString();
                }
                else
                {
                    textEdit_nuclear.Text = gateThresholdValue.nuclear.ToString();
                    textEdit_temperature.Text = gateThresholdValue.temperature.ToString();
                }
            }

        }
    }
}
