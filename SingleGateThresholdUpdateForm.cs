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
    public partial class SingleGateThresholdUpdateForm : Form
    {
        private int gateNo = 0;
        private double temperature_default = 38;
        private double nuclear_default = 10;
        public SingleGateThresholdUpdateForm(int gateNo)
        {
            InitializeComponent();
            label_gateNo.Text = gateNo.ToString();
            this.gateNo = gateNo;

            GateThresholdValue gateThresholdValue = GateService.getInstance().getGateThreshold(gateNo);
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


        private void simpleButton_modify_Click(object sender, EventArgs e)
        {
            double temperature;
            double nuclear;
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
                    temperature = double.Parse(this.textEdit_temperature.Text.Trim());
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

            int[] gateIds = new int[] { gateNo };

            try
            {
                UpdateThresholdService.getInstance().updateGateThreshold(temperature, nuclear, gateIds);
                MessageBox.Show("修改闸机阈值成功！");

                LogService.getInstance().log("更新闸机" + gateNo + "的阈值", ModuleConstant.GateThresholdUpdate_MODULE);
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
