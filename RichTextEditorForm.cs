using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit;
using zhuhai.service;
using zhuhai.model;
using System.IO;
using zhuhai.util;

namespace zhuhai
{
    public partial class RichTextEditorForm : DevExpress.XtraEditors.XtraForm
    {
        private int id = 0;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private IOperateService<CommonText> operateService;

        public RichTextEditorForm(IOperateService<CommonText> operateService)
        {
            InitializeComponent();
            this.operateService = operateService;
        }

        public RichTextEditorForm(int id, IOperateService<CommonText> operateService)
        {
            InitializeComponent();
            this.operateService = operateService;
            Id = id;
            //根据id获取内容
            CommonText ct = operateService.getRow(id);
            textEdit_title.Text = ct.Title;
            //加载内容
            richEditControl_context.Document.LoadDocument(StreamByteTransfer.BytesToStream(operateService.getRow(id).Bytes), DocumentFormat.Rtf);
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
            

            if (String.IsNullOrEmpty(textEdit_title.Text))
            {
                MessageBox.Show("标题不能为空！", "提示");
                return;
            }
            if (operateService.findRowByIdAndTitle(id, textEdit_title.Text))
            {
                MessageBox.Show("标题不能重复！", "提示");
                return;
            }
            CommonText ct = new CommonText();
            ct.Title = textEdit_title.Text;
            MessageBox.Show(System.IO.Path.GetTempPath());
            //保存到一个临时文件中,AppData\Local\Temp
            string filePath = System.IO.Path.GetTempPath() + "/zxt.rtf";
            richEditControl_context.Document.SaveDocument(filePath, DocumentFormat.Rtf);
            ct.Bytes = StreamByteTransfer.FileToBytes(filePath);


            ct.Id = Id;
            //保存
            if (id == 0 && true == operateService.addRow(ct))
            {
                MessageBox.Show("保存成功！", "提示");
                this.Close();
                return ;
            }
            else if (id != 0 && true == operateService.modifyRow(ct))
            {
                MessageBox.Show("保存成功！", "提示");
                this.Close();
            }
            else
            {
                MessageBox.Show("保存失败！", "提示");
            }

           
        }
    }
}