using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zhuhai.xmlrpc;
using zhuhai.util;
using zhuhai.service;

namespace zhuhai
{
    public partial class HxswqhThresholdUpdateForm : Form
    {
        private double biology = 38;
        private double chem = 10;
        private double biology_default = 38;
        private double chem_default = 10;

        public HxswqhThresholdUpdateForm()
        {
            InitializeComponent();

            HxswqhThresholdValue hxswqhThresholdValue = GateService.getInstance().getHxswqhThreshold();
            if (hxswqhThresholdValue != null)
            {
                double biology = hxswqhThresholdValue.biology;
                double chem = hxswqhThresholdValue.chem;
                textEdit_biology.Text = biology.ToString();
                textEdit_chem.Text = chem.ToString();
            }
            else//为空时显示默认值
            {
                textEdit_biology.Text = biology_default.ToString();
                textEdit_chem.Text = chem_default.ToString();
            }
        }

        private void simpleButton_modify_Click(object sender, EventArgs e)
        {
            if (this.textEdit_biology.Text == "" || this.textEdit_biology.Text.Trim() == "")
            {
                MessageBox.Show("请输入生物战剂阀值！");
                this.textEdit_biology.Focus();
                return;
            }
            else
            {
                try
                {
                    biology = double.Parse(this.textEdit_biology.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("请输入有效生物战剂值！");
                    this.textEdit_biology.Focus();
                    return;
                }
            }
            if (this.textEdit_chem.Text == "" || this.textEdit_chem.Text.Trim() == "")
            {
                MessageBox.Show("请输入化学战剂阀值！");
                this.textEdit_chem.Focus();
                return;
            }
            else
            {
                try
                {
                    chem = double.Parse(this.textEdit_chem.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("请输入化学战剂值！");
                    this.textEdit_chem.Focus();
                    return;
                }
            }

            try
            {
                UpdateThresholdService.getInstance().updateHxswqhThreshold(biology, chem);
                MessageBox.Show("修改口岸阈值成功！");
                LogService.getInstance().log("更新口岸阈值", ModuleConstant.GateThresholdUpdate_MODULE);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
            
        }

        private void simpleButton_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
