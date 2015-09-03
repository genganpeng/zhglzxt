namespace zhuhai
{
    partial class HxswqhThresholdUpdateForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.simpleButton_modify = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_close = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl_temperature = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_nuclear = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_biology = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_chem = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_biology.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_chem.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton_modify
            // 
            this.simpleButton_modify.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_modify.Appearance.Options.UseFont = true;
            this.simpleButton_modify.Location = new System.Drawing.Point(145, 164);
            this.simpleButton_modify.Name = "simpleButton_modify";
            this.simpleButton_modify.Size = new System.Drawing.Size(91, 36);
            this.simpleButton_modify.TabIndex = 6;
            this.simpleButton_modify.Text = "修  改";
            this.simpleButton_modify.Click += new System.EventHandler(this.simpleButton_modify_Click);
            // 
            // simpleButton_close
            // 
            this.simpleButton_close.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_close.Appearance.Options.UseFont = true;
            this.simpleButton_close.Location = new System.Drawing.Point(309, 164);
            this.simpleButton_close.Name = "simpleButton_close";
            this.simpleButton_close.Size = new System.Drawing.Size(91, 36);
            this.simpleButton_close.TabIndex = 7;
            this.simpleButton_close.Text = "关  闭";
            this.simpleButton_close.ToolTip = "关闭对话框";
            this.simpleButton_close.Click += new System.EventHandler(this.simpleButton_close_Click);
            // 
            // labelControl_temperature
            // 
            this.labelControl_temperature.Appearance.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_temperature.Location = new System.Drawing.Point(115, 23);
            this.labelControl_temperature.Name = "labelControl_temperature";
            this.labelControl_temperature.Size = new System.Drawing.Size(100, 27);
            this.labelControl_temperature.TabIndex = 8;
            this.labelControl_temperature.Text = "生物战剂：";
            // 
            // labelControl_nuclear
            // 
            this.labelControl_nuclear.Appearance.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_nuclear.Location = new System.Drawing.Point(115, 84);
            this.labelControl_nuclear.Name = "labelControl_nuclear";
            this.labelControl_nuclear.Size = new System.Drawing.Size(100, 27);
            this.labelControl_nuclear.TabIndex = 9;
            this.labelControl_nuclear.Text = "化学战剂：";
            // 
            // textEdit_biology
            // 
            this.textEdit_biology.Location = new System.Drawing.Point(215, 22);
            this.textEdit_biology.Name = "textEdit_biology";
            this.textEdit_biology.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_biology.Properties.Appearance.Options.UseFont = true;
            this.textEdit_biology.Size = new System.Drawing.Size(230, 28);
            this.textEdit_biology.TabIndex = 10;
            // 
            // textEdit_chem
            // 
            this.textEdit_chem.Location = new System.Drawing.Point(215, 85);
            this.textEdit_chem.Name = "textEdit_chem";
            this.textEdit_chem.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_chem.Properties.Appearance.Options.UseFont = true;
            this.textEdit_chem.Size = new System.Drawing.Size(230, 28);
            this.textEdit_chem.TabIndex = 11;
            // 
            // HxswqhThresholdUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 276);
            this.Controls.Add(this.textEdit_chem);
            this.Controls.Add(this.textEdit_biology);
            this.Controls.Add(this.labelControl_nuclear);
            this.Controls.Add(this.labelControl_temperature);
            this.Controls.Add(this.simpleButton_close);
            this.Controls.Add(this.simpleButton_modify);
            this.Name = "HxswqhThresholdUpdateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "口岸阈值修改";
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_biology.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_chem.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton_modify;
        private DevExpress.XtraEditors.SimpleButton simpleButton_close;
        private DevExpress.XtraEditors.LabelControl labelControl_temperature;
        private DevExpress.XtraEditors.LabelControl labelControl_nuclear;
        private DevExpress.XtraEditors.TextEdit textEdit_biology;
        private DevExpress.XtraEditors.TextEdit textEdit_chem;
    }
}