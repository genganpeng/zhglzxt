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
    public partial class ShenbaoContentForm : DevExpress.XtraEditors.XtraForm
    {
        private ShenbaoContentService shenbaoContentService;
        public ShenbaoContentForm()
        {
            InitializeComponent();

            shenbaoContentService = ShenbaoContentService.getInstance();
            
            pageUpControl.MyControl = gridControl;
            pageUpControl.QueryService = shenbaoContentService;

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
            strWhere.Add(ShenboContent.CONTENT_COLOMUN, title);
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
            ShenbaoContentEditForm form = new ShenbaoContentEditForm(shenbaoContentService);
            form.ShowDialog();
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
            ShenbaoContentEditForm form = new ShenbaoContentEditForm(Int32.Parse(dt.Rows[rowNums[0]][ShenboContent.ID_COLUMN].ToString()), Int32.Parse(dt.Rows[rowNums[0]][ShenboContent.LOGICID_COLUMN].ToString()), dt.Rows[rowNums[0]][ShenboContent.CONTENT_COLOMUN].ToString(), dt.Rows[rowNums[0]][ShenboContent.CONTENT_EN_COLOMUN].ToString(), shenbaoContentService);
            form.ShowDialog();
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
                shenbaoContentService.deleteRow(Int32.Parse(deleteId));

                LogService.getInstance().log("删除，内容为" + dt.Rows[rowNum][ShenboContent.CONTENT_COLOMUN].ToString(), ModuleConstant.ShenbaoContent_MODULE);
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
            ShenbaoContentEditForm form = new ShenbaoContentEditForm(Int32.Parse(dt.Rows[rowNums[0]][ShenboContent.ID_COLUMN].ToString()), Int32.Parse(dt.Rows[rowNums[0]][ShenboContent.LOGICID_COLUMN].ToString()), dt.Rows[rowNums[0]][ShenboContent.CONTENT_COLOMUN].ToString(), dt.Rows[rowNums[0]][ShenboContent.CONTENT_EN_COLOMUN].ToString(), shenbaoContentService, true);
            form.ShowDialog();
        }

    }
}