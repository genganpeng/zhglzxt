using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using zhuhai.util;
using zhuhai.service;

namespace zhuhai
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        private string checkCode = "";
        public LoginForm()
        {
            InitializeComponent();
            try
            {
                label.Text = TitleService.getInstance().getTitle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
            
            new RandomCodeGenerator().CodeImage(ref checkCode, pictureBox_checkCode);
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (checkCode.ToLower() != txt_verificationCode.Text.ToLower())
            {
                MessageBox.Show("验证码错误，请重新输入！", "提示");
                return;
            }

            //从数据库取，然后验证
            if (SystemManageService.getInstance().validateUserNameAndPassword(txt_user.Text, txt_passwd.Text))
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                LogService.getInstance().log(ModuleConstant.LOGIN_MODULE_CONTENT, ModuleConstant.LOGIN_MODULE);
                this.Close();
            }
            else
            {
                MessageBox.Show("用户名或者密码错误！","提示");
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            txt_user.Text = "";
            txt_passwd.Text = "";
            txt_verificationCode.Text = "";
        }

        private void pictureBox_checkCode_Click(object sender, EventArgs e)
        {
            checkCode = "";
            //刷新验证码
            new RandomCodeGenerator().CodeImage(ref checkCode, pictureBox_checkCode);
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

    }
}