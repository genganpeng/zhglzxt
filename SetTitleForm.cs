using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using zhuhai.xmlrpc;
using zhuhai.service;
using zhuhai.util;

namespace zhuhai
{
    public partial class SetTitleForm : DevExpress.XtraEditors.XtraForm
    {
        private TitleService titleService;
        public SetTitleForm()
        {
            InitializeComponent();
            titleService = TitleService.getInstance();
            try
            {
                textBox_title.Text = titleService.getTitle();
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_title.Text.Trim())) {
                MessageBox.Show("为空不能保存");
                return;
            }
            try
            {
                if (titleService.setTitle(textBox_title.Text.Trim()) == true)
                {
                    MessageBox.Show("保存成功！");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}