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
    public partial class SystemManageForm : DevExpress.XtraEditors.XtraForm
    {
        private SystemManageService smService;
        public SystemManageForm()
        {
            InitializeComponent();

            smService = SystemManageService.getInstance();
            comboBoxEdit_type.Properties.Items.AddRange(smService.getTypes().ToArray());
            //设置ComboBoxEdit下拉不可编辑
            comboBoxEdit_type.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;

            
            pageUpControl.MyControl = gridControl;
            pageUpControl.QueryService = smService;

            initData(formatWhere());
        }

        /// <summary>
        /// 格式化查询条件
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, object> formatWhere()
        {
            string username = textEdit_userName.Text;
            string name = textEdit_name.Text;
            string idCard = textEdit_IDCard.Text;
            string type = "";

            IDictionary<string, object> strWhere = new Dictionary<string, object>();

            if (comboBoxEdit_type.SelectedIndex != -1)
                type = comboBoxEdit_type.SelectedIndex.ToString();

            if (!String.IsNullOrEmpty(username))
            {
                strWhere.Add(SystemManage.USERNAME_COLUMN, " like '%" + username + "%'");
            }
            if (!String.IsNullOrEmpty(name))
            {
                strWhere.Add(SystemManage.NAME_COLUMN, " like '%" + name + "%'");
            }
            if (!String.IsNullOrEmpty(idCard))
            {
                strWhere.Add(SystemManage.IDCARD_COLUMN, " like '%" + idCard + "%'");
            }
            if (type != "0" && type != "")
            {
                strWhere.Add(SystemManage.TYPE_COLUMN, " = " + type);
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
            textEdit_userName.Text = "";
            textEdit_name.Text = "";
            textEdit_IDCard.Text = "";

            initData(formatWhere());
        }

        private void simpleButton_add_Click(object sender, EventArgs e)
        {
            SystemManageEditForm systemManageEditForm = new SystemManageEditForm();
            systemManageEditForm.ShowDialog();
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
            SystemManageEditForm systemManageEditForm = new SystemManageEditForm(Int32.Parse(dt.Rows[rowNums[0]][SystemManage.ID_COLUMN].ToString()));
            systemManageEditForm.ShowDialog();
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
                string deleteId = dt.Rows[rowNum][SystemManage.ID_COLUMN].ToString();
                smService.deleteRow(Int32.Parse(deleteId));
            }
            initData(formatWhere());
             
        }

    }
}