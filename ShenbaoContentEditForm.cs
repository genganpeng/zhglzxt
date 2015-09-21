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

        public ShenbaoContentEditForm(int id, int logicid, String content, string content_en, ShenbaoContentService shenbaoContentService, Boolean readOnly = false)
        {
            InitializeComponent();
            this.shenbaoContentService = shenbaoContentService;
            this.id = id;
            textBox.Text = content;
            textBox_en.Text = content_en;
            textBox_logicId.Text = logicid.ToString();

            if (readOnly == true)
            {
                textBox.ReadOnly = true;
                textBox_en.ReadOnly = true;
                textBox_logicId.ReadOnly = true;
                button_ok.Visible = false;

            }
        }


        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            

            try
            {
                String logicid = textBox_logicId.Text.Trim();
                int logicid_int = Int32.Parse(logicid);
                if (logicid_int == 1 || logicid_int == 2 || logicid_int == 3)
                {
                    MessageBox.Show("逻辑编号只能是1,2,3！");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("逻辑编号不能为空,并且只能是1,2,3！");
                return;
            }

            String content = textBox.Text.Trim();
            if (string.IsNullOrEmpty(content))
            {
                MessageBox.Show("内容不能为空！");
                return;
            }

            String content_en = textBox_en.Text.Trim();
            if (string.IsNullOrEmpty(content))
            {
                MessageBox.Show("英文不能为空！");
                return;
            }

            try {
                //保存
                if (id == 0 && shenbaoContentService.addRow(content, content_en,Int32.Parse(textBox_logicId.Text.Trim()))  == true)
                {
                    MessageBox.Show("保存成功！", "提示");
                    LogService.getInstance().log("新增，内容为" + content, ModuleConstant.ShenbaoContent_MODULE);
                    this.Close();
                }
                //编辑
                else if (id != 0 && shenbaoContentService.modifyRow(id, content, content_en, Int32.Parse(textBox_logicId.Text.Trim())) == true)
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