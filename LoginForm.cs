using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace zhuhai
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
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

    }
}