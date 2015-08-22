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
    public partial class RichTextEditorForm : DevExpress.XtraEditors.XtraForm
    {
        public RichTextEditorForm()
        {
            InitializeComponent();
        }

        private void simpleButton_cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要退出吗？你还没有保存标题和内容呢？", "退出系统", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void simpleButton_save_Click(object sender, EventArgs e)
        {
            MessageBox.Show(richEditControl_context.WordMLText);
            MessageBox.Show(textEdit_title.Text);
            MessageBox.Show("保存成功！", "提示");
            this.Close();
        }
    }
}