﻿using System;
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
    /// 处置预案Form
    /// </summary>
    public partial class DisposePlanManageForm : DevExpress.XtraEditors.XtraForm
    {
        private DisposePlanService disposePlanService;
        public DisposePlanManageForm()
        {
            InitializeComponent();
            initPermission();
            disposePlanService = DisposePlanService.getInstance();
            
            pageUpControl.MyControl = gridControl;
            pageUpControl.QueryService = disposePlanService;

            initData(formatWhere());
        }

        public void initPermission()
        {
            if (PermissionControl.IsAuthorized("simpleButton_delete") == false)
            {
                simpleButton_delete.Visible = false;
            }
            if (PermissionControl.IsAuthorized("simpleButton_modify") == false)
            {
                simpleButton_modify.Visible = false;
            }
            if (PermissionControl.IsAuthorized("simpleButton_add") == false)
            {
                simpleButton_add.Visible = false;
            }
        }

        /// <summary>
        /// 格式化查询条件
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, object> formatWhere()
        {
            string title = textEdit_title.Text;

            IDictionary<string, object> strWhere = new Dictionary<string, object>();
            strWhere.Add(DisposePlan.TITLE_COLOMUN, title);
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
            RichTextEditorForm richTextEditorForm = new RichTextEditorForm(disposePlanService);
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
            RichTextEditorForm richTextEditorForm = new RichTextEditorForm(Int32.Parse(dt.Rows[rowNums[0]][CommonText.ID_COLUMN].ToString()), dt.Rows[rowNums[0]][CommonText.TITLE_COLOMUN].ToString(), disposePlanService);
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
                disposePlanService.deleteRow(Int32.Parse(deleteId));

                LogService.getInstance().log("删除，标题为" + dt.Rows[rowNum][CommonText.TITLE_COLOMUN].ToString(), ModuleConstant.DisposePlan_MODULE);
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
            RichTextEditorForm richTextEditorForm = new RichTextEditorForm(Int32.Parse(dt.Rows[rowNums[0]][CommonText.ID_COLUMN].ToString()), dt.Rows[rowNums[0]][CommonText.TITLE_COLOMUN].ToString(), disposePlanService, true);
            richTextEditorForm.ShowDialog();
        }

    }
}