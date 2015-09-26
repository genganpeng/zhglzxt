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
            richEditControl1.Document.ReplaceAll(new Regex("#destination#"), string.IsNullOrEmpty(gateRecord.issue_place) ? "" : gateRecord.issue_place);

            string retport_content = gateRecord.report_content;
            if (string.IsNullOrEmpty(retport_content))
            {
                richEditControl1.Document.ReplaceAll(new Regex("#questionone#"), "");
                richEditControl1.Document.ReplaceAll(new Regex("#questiononeanswer#"), "");
                richEditControl1.Document.ReplaceAll(new Regex("#questiontwo#"), "");
                richEditControl1.Document.ReplaceAll(new Regex("#questiontwoanswer#"), "");
                richEditControl1.Document.ReplaceAll(new Regex("#questionthreeanswer#"), "");
            }
            else
            {
                string[] questions = retport_content.Split(new char[]{';'});
                string[] questionone = questions[0].Split(new char[]{':'});
                richEditControl1.Document.ReplaceAll(new Regex("#questionone#"), questionone[0]);
                richEditControl1.Document.ReplaceAll(new Regex("#questiononeanswer#"), questionone[1]);
                string[] questiotwo = questions[1].Split(new char[] { ':' });
                richEditControl1.Document.ReplaceAll(new Regex("#questiontwo#"), questiotwo[0]);
                richEditControl1.Document.ReplaceAll(new Regex("#questiontwoanswer#"), questiotwo[1]);
                string[] questiothree = questions[2].Split(new char[] { '|' });
                string display = "";
                for (int i = 0; i < questiothree.Length; i++ )
                {
                    string[] arr = questiothree[i].Split(new char[]{':'});
                    if (arr[1] == "1")
                        display += "√ " + arr[0];
                    else
                    {
                        display += "× " + arr[0];
                    }
                    display += "        ";
                }

                richEditControl1.Document.ReplaceAll(new Regex("#questionthreeanswer#"), display);
            }
            

            richEditControl1.Document.ReplaceAll(new Regex("#temperature#"), gateRecord.temperature.ToString());
        }
    }
}