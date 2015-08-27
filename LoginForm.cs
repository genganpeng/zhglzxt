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

namespace zhuhai
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        private string checkCode = "";
        public LoginForm()
        {
            InitializeComponent();
            new RandomCodeGenerator().CodeImage(ref checkCode, pictureBox_checkCode);
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (checkCode.ToLower() != txt_verificationCode.Text.ToLower())
            {
                MessageBox.Show("验证码错误，请重新输入！", "提示");
                return;
            }

            if ((txt_user.Text == "123") && (txt_passwd.Text=="123"))
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
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

    }
}