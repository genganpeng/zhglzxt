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
using zhuhai.model;

namespace zhuhai
{
    public partial class ClearanceStatisticsForm : Form
    {
        public ClearanceStatisticsForm(int gateTotal)
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

            this.dateTimePicker_startTime.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker_startTime.Text = DateTime.Now.ToString();
            this.dateTimePicker_startTime_time.Text = DateTime.Now.ToString();
            this.dateTimePicker_endTime.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker_endTime.Text = DateTime.Now.ToString();
            this.dateTimePicker_endTime_time.Text = DateTime.Now.ToString();
        }

        private void simpleButton_query_Click(object sender, EventArgs e)
        {
            IDictionary<string, object> strWhere = new Dictionary<string, object>();
            string name = textEdit_name.Text.Trim();

            string country = textEdit_country.Text;
            if (country != "" && country.Trim() != "")
            {
                strWhere.Add(ClearanceRecord.NATIONALITY_COLUMN, country.Trim());
            }

            if (comboBox_sex.Text != "" && comboBox_sex.Text != "全部" && comboBox_sex.Text.Trim() != "")
            {
                if (comboBox_sex.Text.Trim().Equals("男"))
                {
                    strWhere.Add(ClearanceRecord.IS_MALE_COLUMN, true);
                }
                else
                {
                    strWhere.Add(ClearanceRecord.IS_MALE_COLUMN, false);
                }
            }

            DateTime dt = DateTime.Parse(dateTimePicker_startTime.Text + " " + dateTimePicker_startTime_time.Text);
            strWhere.Add(ClearanceRecord.NVR_STARTTIME_COLUMN, dt);
            DateTime dt1 = DateTime.Parse(dateTimePicker_endTime.Text + " " + dateTimePicker_endTime_time.Text);
            strWhere.Add(ClearanceRecord.NVR_ENDTIME_COLUMN, dt1);

            string abnormal = comboBox_abnormal.Text;
            int abnormalType = -1;
            if (abnormal != "全部")
            {
                abnormalType = zhuhai.util.AbnormalType.getIndexByName(abnormal);
                strWhere.Add(ClearanceRecord.ABNORMAL_TYPE_COLUMN, abnormalType);
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
                strWhere.Add(ClearanceRecord.GATE_ID_COLUMN, gateNo);
            }


            try
            {
                MessageBox.Show(GateService.getInstance().getGateRecordsNum(name, strWhere), "提示");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked == true)
            {
                groupControl_adavance.Visible = true;
            }
            else
            {
                groupControl_adavance.Visible = false;
            }
        }
    }
}
