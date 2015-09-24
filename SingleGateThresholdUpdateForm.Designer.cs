namespace zhuhai
{
    partial class SingleGateThresholdUpdateForm
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
            this.labelControl_gate = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton_modify = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_close = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl_temperature = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_nuclear = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_temperature = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_nuclear = new DevExpress.XtraEditors.TextEdit();
            this.label_gateNo = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_temperature.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_nuclear.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl_gate
            // 
            this.labelControl_gate.Appearance.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_gate.Location = new System.Drawing.Point(26, 30);
            this.labelControl_gate.Name = "labelControl_gate";
            this.labelControl_gate.Size = new System.Drawing.Size(72, 27);
            this.labelControl_gate.TabIndex = 0;
            this.labelControl_gate.Text = "通  道：";
            // 
            // simpleButton_modify
            // 
            this.simpleButton_modify.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_modify.Appearance.Options.UseFont = true;
            this.simpleButton_modify.Location = new System.Drawing.Point(203, 173);
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
            this.simpleButton_close.Location = new System.Drawing.Point(397, 173);
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
            this.labelControl_temperature.Location = new System.Drawing.Point(26, 97);
            this.labelControl_temperature.Name = "labelControl_temperature";
            this.labelControl_temperature.Size = new System.Drawing.Size(72, 27);
            this.labelControl_temperature.TabIndex = 8;
            this.labelControl_temperature.Text = "温  度：";
            // 
            // labelControl_nuclear
            // 
            this.labelControl_nuclear.Appearance.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_nuclear.Location = new System.Drawing.Point(397, 97);
            this.labelControl_nuclear.Name = "labelControl_nuclear";
            this.labelControl_nuclear.Size = new System.Drawing.Size(72, 27);
            this.labelControl_nuclear.TabIndex = 9;
            this.labelControl_nuclear.Text = "核  素：";
            // 
            // textEdit_temperature
            // 
            this.textEdit_temperature.Location = new System.Drawing.Point(119, 97);
            this.textEdit_temperature.Name = "textEdit_temperature";
            this.textEdit_temperature.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_temperature.Properties.Appearance.Options.UseFont = true;
            this.textEdit_temperature.Size = new System.Drawing.Size(230, 28);
            this.textEdit_temperature.TabIndex = 10;
            // 
            // textEdit_nuclear
            // 
            this.textEdit_nuclear.Location = new System.Drawing.Point(490, 98);
            this.textEdit_nuclear.Name = "textEdit_nuclear";
            this.textEdit_nuclear.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_nuclear.Properties.Appearance.Options.UseFont = true;
            this.textEdit_nuclear.Size = new System.Drawing.Size(230, 28);
            this.textEdit_nuclear.TabIndex = 11;
            // 
            // label_gateNo
            // 
            this.label_gateNo.Appearance.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_gateNo.Location = new System.Drawing.Point(119, 30);
            this.label_gateNo.Name = "label_gateNo";
            this.label_gateNo.Size = new System.Drawing.Size(0, 27);
            this.label_gateNo.TabIndex = 12;
            // 
            // SingleGateThresholdUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 247);
            this.Controls.Add(this.label_gateNo);
            this.Controls.Add(this.textEdit_nuclear);
            this.Controls.Add(this.textEdit_temperature);
            this.Controls.Add(this.labelControl_nuclear);
            this.Controls.Add(this.labelControl_temperature);
            this.Controls.Add(this.simpleButton_close);
            this.Controls.Add(this.simpleButton_modify);
            this.Controls.Add(this.labelControl_gate);
            this.Name = "SingleGateThresholdUpdateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "闸机阈值修改";
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_temperature.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_nuclear.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl_gate;
        private DevExpress.XtraEditors.SimpleButton simpleButton_modify;
        private DevExpress.XtraEditors.SimpleButton simpleButton_close;
        private DevExpress.XtraEditors.LabelControl labelControl_temperature;
        private DevExpress.XtraEditors.LabelControl labelControl_nuclear;
        private DevExpress.XtraEditors.TextEdit textEdit_temperature;
        private DevExpress.XtraEditors.TextEdit textEdit_nuclear;
        private DevExpress.XtraEditors.LabelControl label_gateNo;
    }
}