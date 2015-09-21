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
using zhuhai.monitorinfo.h264;
using zhuhai.monitorinfo;

namespace zhuhai
{
    public partial class VideoReplayForm : Form
    {
        private ClearanceRecordService clearanceRecordService;
        private H264Controler playbackControler = null;

        public VideoReplayForm()
        {
            InitializeComponent();

            ICustomsCMS server = XmlRpcInstance.getInstance();
            playbackControler = new H264Controler(this.searchVideoPlayWnd, server);
            playbackControler.setToolStripStatusLabel(this.toolStripStatusLabel);
            bool isSuccess = playbackControler.init();
            if (!isSuccess)
            {
                System.Environment.Exit(0);
            }

            clearanceRecordService = ClearanceRecordService.getInstance();
            pageUpControl_query.MyControl = gridControl_query;
            pageUpControl_query.QueryService = clearanceRecordService;

            this.comboBox_sex.SelectedIndex = 0;

            this.dateTimePicker_startTime.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker_startTime.Text = DateTime.Now.ToString();
            this.dateTimePicker_startTime_time.Text = DateTime.Now.ToString();
            this.dateTimePicker_endTime.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker_endTime.Text = DateTime.Now.ToString();
            this.dateTimePicker_endTime_time.Text = DateTime.Now.ToString();

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
            
            if (strWhere.Count == 0 || name == "")
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
            pageUpControl_query.Pagesize = 10;
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
            if (gridView.SelectedRowsCount != 1)
            {
                MessageBox.Show("请选择一条记录！", "警告");
                return;
            }
            //获取选中的行的行号
            int[] rowNums = gridView.GetSelectedRows();
            DataTable dt = (DataTable)gridControl_query.DataSource;
            DataRow dr = dt.Rows[rowNums[0]];

            ShowClearanceInfoForm showClearanceInfoForm = new ShowClearanceInfoForm(dr);
            showClearanceInfoForm.ShowDialog();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            int nSelected = this.gridView.SelectedRowsCount;
            if (nSelected == 0)
            {
                MessageBox.Show("请选择一个异常情况！");
                return;
            }
            //获取选中的行的行号
            int[] rowNums = gridView.GetSelectedRows();
            DataTable dt = (DataTable)gridControl_query.DataSource;

            GateRecord gateRecord = new ModelHandler<GateRecord>().FillModel(dt.Rows[rowNums[0]]);
            Monitor monitor = new Monitor();
            monitor.gateNo = gateRecord.gate_id;
            playbackControler.setMonitor(monitor);
            playbackControler.play(gateRecord);
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            this.playbackControler.pause();
        }

        private void btnSlow_Click(object sender, EventArgs e)
        {
            this.playbackControler.slow();
        }

        private void btnFast_Click(object sender, EventArgs e)
        {
            this.playbackControler.fast();
        }

        private void btnFrame_Click(object sender, EventArgs e)
        {
            this.playbackControler.pause();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.playbackControler.stop();
        }

        private void VideoReplayForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (playbackControler != null)
            {
                playbackControler.stop();
            }

            this.Close();
        }

        private GateRecord selectGateRecord = null;
        private void gridControl_query_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //获取选中的行的行号
            int[] rowNums = gridView.GetSelectedRows();
            DataTable dt = (DataTable)gridControl_query.DataSource;

            GateRecord gateRecord = new ModelHandler<GateRecord>().FillModel(dt.Rows[rowNums[0]]);
            if (selectGateRecord != gateRecord)
            {
                Monitor monitor = new Monitor();
                monitor.gateNo = gateRecord.gate_id;
                playbackControler.setMonitor(monitor);
                playbackControler.play(gateRecord);
                selectGateRecord = gateRecord;
            }
        }

        private void dateTimePicker_startTime_ValueChanged(object sender, EventArgs e)
        {
            (sender as DateTimePicker).CustomFormat = "yyyy年M月d日";
        }
    }
}
