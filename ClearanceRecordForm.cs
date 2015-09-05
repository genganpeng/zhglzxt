using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zhuhai.util;
using zhuhai.service;

namespace zhuhai
{
    public partial class ClearanceRecordForm : Form
    {
        public ClearanceRecordForm(int gateTotal)
        {
            InitializeComponent();

            this.comboBox_sex.SelectedIndex = 0;

            //以下初始化通道
            object[] items = new object[gateTotal + 1];
            items[0] = "全部";
            for (int i = 1; i < gateTotal + 1; i++)
            {
                items[i] = i.ToString();
            }
            this.comboBox__channel.Items.AddRange(items);
            this.comboBox__channel.SelectedIndex = 0;

            //异常类型
            this.comboBox_abnormal.Items.AddRange(AbnormalType.getAllAbnormalTypeNames());
            this.comboBox_abnormal.SelectedIndex = 0;
        }

        private void simpleButton_query_Click(object sender, EventArgs e)
        {
            string name = textEdit_name.Text;
            string country = textEdit_country.Text;
            string sex = comboBox_sex.Text;
            if (sex == "全部")
            {
                sex = null;
            }

            DateTime startTime = dateTimePicker_startTime.Value;
            DateTime endTime = dateTimePicker_endTime.Value;
            endTime = endTime.AddDays(1);

            string abnormal = comboBox_abnormal.Text;
            int abnormalType = -1;
            if (abnormal != "全部")
            {
                abnormalType = AbnormalType.getIndexByName(abnormal);
            }

            string channel = comboBox__channel.Text;
            int gateNo = 0;
            if (channel == "全部")
            {
                gateNo = 0;
            }
            else
            {
                gateNo = int.Parse(channel);
            }

            try
            {
                MessageBox.Show(GateService.getInstance().getGateRecordsNum(name, country, sex, startTime, endTime, abnormalType, gateNo), "提示");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }
    }
}
