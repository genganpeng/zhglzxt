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
    public partial class LogRecordForm : Form
    {
        private LogService logService;

        public LogRecordForm()
        {
            InitializeComponent();
            
            this.dateTimePicker_startTime.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker_startTime.Text = DateTime.Now.ToString();
            this.dateTimePicker_startTime_time.Text = DateTime.Now.ToString();
            this.dateTimePicker_endTime.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker_endTime.Text = DateTime.Now.ToString();
            this.dateTimePicker_endTime_time.Text = DateTime.Now.ToString();

            logService = LogService.getInstance();
            pageUpControl_query.MyControl = gridControl_query;
            pageUpControl_query.QueryService = logService;

        }

        /// <summary>
        /// 格式化查询条件
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, object> formatWhere()
        {
            IDictionary<string, object> strWhere = new Dictionary<string, object>();
            string name = textEdit_name.Text.Trim();
            strWhere.Add(LogColumn.operatePeople_column, name.Trim());


            DateTime dt = DateTime.Parse(dateTimePicker_startTime.Text + " " + dateTimePicker_startTime_time.Text);
            strWhere.Add(LogColumn.para_begin_column, dt);
            DateTime dt1 = DateTime.Parse(dateTimePicker_endTime.Text + " " + dateTimePicker_endTime_time.Text);
            strWhere.Add(LogColumn.para_end_column, dt1);

            return strWhere;

        }

        public void initData(IDictionary<string, object> strWhere)
        {
            //初始化实现的service，每页数量，开始页码
            pageUpControl_query.PageIndex = 1;
            //以后需要改
            pageUpControl_query.Pagesize = 20;
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

    }
}
