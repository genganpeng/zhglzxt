using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using zhuhai.model;
using zhuhai.service;
using DevExpress.XtraEditors.Controls;
using zhuhai.util;

namespace zhuhai
{
    public partial class SystemManageEditForm : DevExpress.XtraEditors.XtraForm
    {
        private int id = 0;
        public int Id {
            get {return id;}
            set {id = value;}
        }
        private SystemManageService smService;
        public SystemManageEditForm()
        {
            InitializeComponent();
            init();
        }

        public SystemManageEditForm(int id)
        {
            InitializeComponent();
            init();
            Id = id;
            SystemManage sm = smService.getRow(Id);
            //编辑，根据id取出原来的数据，显示出来
            textEdit_userName.Text = sm.UserName;
            textEdit_password.Text = sm.Password ;
            textEdit_name.Text = sm.Name;
            textEdit_IDCard.Text = sm.IdCard;
            comboBoxEdit_type.SelectedIndex = sm.Type;
            //不可修改用户名
            textEdit_userName.Properties.ReadOnly = true;
        }

        public void init()
        {
            smService = SystemManageService.getInstance();
            comboBoxEdit_type.Properties.Items.AddRange(smService.getTypes().ToArray());
            //设置ComboBoxEdit下拉不可编辑
            comboBoxEdit_type.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
        }

        private void simpleButton_add_Click(object sender, EventArgs e)
        {
            
            SystemManage sm = new SystemManage();
            sm.UserName = textEdit_userName.Text;
            sm.Password = textEdit_password.Text;
            sm.Name = textEdit_name.Text;
            sm.IdCard = textEdit_IDCard.Text;

            if (String.IsNullOrEmpty(sm.UserName))
            {
                MessageBox.Show("用户名不能为空！", "提示");
                return;
            }

            if (smService.findRowByIdAndName(id, sm.UserName))
            {
                MessageBox.Show("用户名已重复！", "提示");
                return;
            }

            if (String.IsNullOrEmpty(sm.Password))
            {
                MessageBox.Show("密码不能为空！", "提示");
                return;
            }
            if (String.IsNullOrEmpty(sm.Name))
            {
                MessageBox.Show("姓名不能为空！", "提示");
                return;
            }

            

            if (String.IsNullOrEmpty(sm.IdCard))
            {
                MessageBox.Show("证件号不能为空！", "提示");
                return;
            }

            if (comboBoxEdit_type.SelectedIndex == -1 || comboBoxEdit_type.SelectedIndex  == 0) 
            {
                MessageBox.Show("请选择类型！", "提示");
                return;
            }

            sm.Type = comboBoxEdit_type.SelectedIndex;
            sm.Id = Id;

            //保存
            if (Id == 0 && smService.addRow(sm) == true)
            {
                MessageBox.Show("保存成功！", "提示");
                LogService.getInstance().log("新增，用户名为" + sm.UserName, ModuleConstant.SystemManage_MODULE);
                this.Close();
            }
            //编辑
            else if (Id != 0 && smService.modifyRow(sm) == true)
            {
                MessageBox.Show("保存成功！", "提示");
                LogService.getInstance().log("修改，用户名为" + sm.UserName, ModuleConstant.SystemManage_MODULE);
                this.Close();
            }
            else
            {
                MessageBox.Show("保存失败！", "提示");
            }

        }

        private void simpleButton_cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要退出吗？", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}