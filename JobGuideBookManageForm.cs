using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using zhuhai.service;
using DevExpress.XtraEditors.Controls;
using zhuhai.util;
using zhuhai.model;

namespace zhuhai
{
    /// <summary>
    /// 作业指导书Form
    /// </summary>
    public partial class JobGuideBookManageForm : DevExpress.XtraEditors.XtraForm
    {
        private JobGuideBookService jobGuideBookService;
        public JobGuideBookManageForm()
        {
            InitializeComponent();

            jobGuideBookService = JobGuideBookService.getInstance();
            
            pageUpControl.MyControl = gridControl;
            pageUpControl.QueryService = jobGuideBookService;

            initData(formatWhere());
        }

        /// <summary>
        /// 格式化查询条件
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, object> formatWhere()
        {
            string title = textEdit_title.Text;

            IDictionary<string, object> strWhere = new Dictionary<string, object>();
            if (!String.IsNullOrEmpty(title))
            {
                strWhere.Add(JobGuideBook.TITLE_COLOMUN, " like '%" + title + "%'");
            }
            return strWhere;

        }

        public void initData(IDictionary<string, object> strWhere)
        {
            //初始化实现的service，每页数量，开始页码
            pageUpControl.PageIndex = 1;
            pageUpControl.Pagesize = 10;
            pageUpControl.StrWhere = strWhere;
            pageUpControl.GetDataTable();
        }

        private void simpleButton_query_Click(object sender, EventArgs e)
        {
            initData(formatWhere());
        }

        private void simpleButton_reset_Click(object sender, EventArgs e)
        {
            textEdit_title.Text = "";

            initData(formatWhere());
        }

        private void simpleButton_add_Click(object sender, EventArgs e)
        {
            RichTextEditorForm richTextEditorForm = new RichTextEditorForm(jobGuideBookService);
            richTextEditorForm.ShowDialog();
            initData(formatWhere());
        }

        private void simpleButton_modify_Click(object sender, EventArgs e)
        {
            if (gridView.SelectedRowsCount != 1)
            {
                MessageBox.Show("请选择一条记录！","警告");
                return;
            }
            //获取选中的行的行号
            int[] rowNums = gridView.GetSelectedRows();
            DataTable dt = (DataTable)gridControl.DataSource;
            RichTextEditorForm richTextEditorForm = new RichTextEditorForm(Int32.Parse(dt.Rows[rowNums[0]][CommonText.ID_COLUMN].ToString()), jobGuideBookService);
            richTextEditorForm.ShowDialog();
            pageUpControl.GetDataTable();
        }

        private void simpleButton_delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要删除所选的记录吗？", "警告", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return ;
            }

            //获取选中的行的行号
            int[] rowNums = gridView.GetSelectedRows();

            DataTable dt = (DataTable)gridControl.DataSource;
            //循环删除行
            foreach (int rowNum in rowNums)
            {
                //要删除的id
                string deleteId = dt.Rows[rowNum][CommonText.ID_COLUMN].ToString();
                jobGuideBookService.deleteRow(Int32.Parse(deleteId));
            }
            initData(formatWhere());
             
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
            DataTable dt = (DataTable)gridControl.DataSource;
            RichTextEditorForm richTextEditorForm = new RichTextEditorForm(Int32.Parse(dt.Rows[rowNums[0]][CommonText.ID_COLUMN].ToString()), jobGuideBookService, true);
            richTextEditorForm.ShowDialog();
        }

    }
}