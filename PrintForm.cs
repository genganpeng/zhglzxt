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
using System.Text.RegularExpressions;
using zhuhai.xmlrpc;

namespace zhuhai
{
    public partial class PrintForm : DevExpress.XtraEditors.XtraForm
    {
        public PrintForm(GateRecord gateRecord)
        {
            InitializeComponent();
            //加载内容
            richEditControl1.Document.LoadDocument("printTemplate.rtf", DocumentFormat.Rtf);
            richEditControl1.Document.ReplaceAll(new Regex("#name#"), string.IsNullOrEmpty(gateRecord.name) ? "" : gateRecord.name);
            richEditControl1.Document.ReplaceAll(new Regex("#sex#"), string.IsNullOrEmpty(gateRecord.sex) ? "" : gateRecord.sex);
            richEditControl1.Document.ReplaceAll(new Regex("#birth_date#"), gateRecord.birth_date==null ? "" : gateRecord.birth_date.ToString());
            richEditControl1.Document.ReplaceAll(new Regex("#nationality#"), string.IsNullOrEmpty(gateRecord.nationality) ? "" : gateRecord.nationality);
            richEditControl1.Document.ReplaceAll(new Regex("#id_code#"), string.IsNullOrEmpty(gateRecord.id_code) ? "" : gateRecord.id_code);
            richEditControl1.Document.ReplaceAll(new Regex("#destination#"), "");
        }
    }
}