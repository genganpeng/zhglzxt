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
using zhuhai.util;

namespace zhuhai
{
    public partial class ShenbaoContentEditForm : DevExpress.XtraEditors.XtraForm
    {
        private ShenbaoContentService shenbaoContentService;
        private int id;
        public ShenbaoContentEditForm(ShenbaoContentService shenbaoContentService)
        {
            this.shenbaoContentService = shenbaoContentService;
            InitializeComponent();
        }

        public ShenbaoContentEditForm(int id, String content, ShenbaoContentService shenbaoContentService, Boolean readOnly = false)
        {
            InitializeComponent();
            this.shenbaoContentService = shenbaoContentService;
            this.id = id;
            textBox.Text = content;

            if (readOnly == true)
            {
                textBox.ReadOnly = true;
                button_ok.Visible = false;
            }
        }


        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            String content = textBox.Text.Trim();
            if (string.IsNullOrEmpty(content)) {
                MessageBox.Show("不能为空！");
                return ;
            }
            try {
                //保存
                if (id == 0 && shenbaoContentService.addRow(content) == true)
                {
                    MessageBox.Show("保存成功！", "提示");
                    LogService.getInstance().log("新增，内容为" + content, ModuleConstant.ShenbaoContent_MODULE);
                    this.Close();
                }
                //编辑
                else if (id != 0 && shenbaoContentService.modifyRow(id, content) == true)
                {
                    MessageBox.Show("保存成功！", "提示");
                    LogService.getInstance().log("修改，内容为" + content, ModuleConstant.ShenbaoContent_MODULE);
                    this.Close();
                }
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message, "错误");
            }
            
            
        }
    }
}