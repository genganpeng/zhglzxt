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
    public partial class SingleGateThresholdErrorUpdateForm : Form
    {
        private int gateNo;
        private double temperature_error_default = 0;
        private double nuclear_error_default = 0;
        public SingleGateThresholdErrorUpdateForm(int gateNo)
        {
            InitializeComponent();
            this.gateNo = gateNo;

            labelControl_gate.Text = gateNo.ToString();
            GateThresholdErrorValue gateThresholdErrorValue = GateService.getInstance().getGateThresholdError(gateNo);
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


        private void simpleButton_modify_Click(object sender, EventArgs e)
        {
            double temperature_error,nuclear_error;
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

            int[] gateIds = new int[]{gateNo};
            try
            {
                UpdateThresholdService.getInstance().updateGateThresholdError(temperature_error, nuclear_error, gateIds);
                MessageBox.Show("修改闸机误差值成功！");

                LogService.getInstance().log("更新闸机" + gateNo + "的阈值误差", ModuleConstant.GateThresholdUpdateError_MODULE);
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
