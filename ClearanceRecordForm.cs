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
using zhuhai.xmlrpc;
using zhuhai.model;

namespace zhuhai
{
    public partial class ClearanceRecordForm : Form
    {
        private ClearanceRecordService clearanceRecordService;

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
            this.comboBox_abnormal.Items.AddRange(zhuhai.util.AbnormalType.getAllAbnormalTypeNames());
            this.comboBox_abnormal.SelectedIndex = 0;

            this.dateTimePicker_startTime.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker_startTime.Text = DateTime.Now.ToString();
            this.dateTimePicker_startTime_time.Text = DateTime.Now.ToString();
            this.dateTimePicker_endTime.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker_endTime.Text = DateTime.Now.ToString();
            this.dateTimePicker_endTime_time.Text = DateTime.Now.ToString();

            clearanceRecordService = ClearanceRecordService.getInstance();
            pageUpControl_query.MyControl = gridControl_query;
            pageUpControl_query.QueryService = clearanceRecordService;

        }

        /// <summary>
        /// 格式化查询条件
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, object> formatWhere()
        {
            IDictionary<string, object> strWhere = new Dictionary<string, object>();
            string name = textEdit_name.Text.Trim();
            strWhere.Add(ClearanceRecord.NAME_COLUMN, name.Trim());

            string country = textEdit_country.Text;
            if (country != "" && country.Trim() != "")
            {
                strWhere.Add(ClearanceRecord.NATIONALITY_COLUMN_QUERY, country.Trim());
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
            strWhere.Add(ClearanceRecord.NVR_STARTTIME_COLUMN_QUERY, dt);
            DateTime dt1 = DateTime.Parse(dateTimePicker_endTime.Text + " " + dateTimePicker_endTime_time.Text);
            strWhere.Add(ClearanceRecord.NVR_ENDTIME_COLUMN_QUERY, dt1);

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
            
            if (name == "")
            {
                MessageBox.Show("请输入查询条件，至少要包括姓名!");
                textEdit_name.Focus();
                return null;
            }

            return strWhere;

        }

        public void initData(IDictionary<string, object> strWhere)
        {
            //初始化实现的service，每页数量，开始页码
            pageUpControl_query.PageIndex = 1;
            //以后需要改
            pageUpControl_query.Pagesize = 1;
            pageUpControl_query.StrWhere = strWhere;
            pageUpControl_query.GetDataTable();
        }

        private void simpleButton_query_Click(object sender, EventArgs e)
        {
            if (formatWhere() != null)
            {
                //查询
                initData(formatWhere());
            }
            
        }

        private void simpleButton_view_Click(object sender, EventArgs e)
        {
            if (gridView_query.SelectedRowsCount != 1)
            {
                MessageBox.Show("请选择一条记录！", "警告");
                return;
            }
            //获取选中的行的行号
            int[] rowNums = gridView_query.GetSelectedRows();
            DataTable dt = (DataTable)gridControl_query.DataSource;
            DataRow dr = dt.Rows[rowNums[0]];


            ShowClearanceInfoForm showClearanceInfoForm = new ShowClearanceInfoForm(dr);
            showClearanceInfoForm.ShowDialog();
        }

        private void gridView_query_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //int hand = e.RowHandle;
            //if (hand < 0) return;
            //DataRow dr = this.gridView_query.GetDataRow(hand);
            //if (dr == null) return;
            //if (Int32.Parse(dr[ClearanceRecord.Unnormal_type_COLUMN].ToString()) != (int)zhuhai.xmlrpc.AbnormalType.No)
            //{
            //    e.Appearance.BackColor = Color.Red;
            //}
        }
    }
}
