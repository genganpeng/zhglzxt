namespace zhuhai
{
    partial class GateThresholdErrorUpdateForm
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
            this.checkedListBoxControl_gate = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.simpleButton_allChecked = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_cancelChecked = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_modify = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_close = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl_temperatureError = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_nuclearError = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_temperatureError = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_nuclearError = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl_gate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_temperatureError.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_nuclearError.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl_gate
            // 
            this.labelControl_gate.Appearance.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_gate.Location = new System.Drawing.Point(31, 20);
            this.labelControl_gate.Name = "labelControl_gate";
            this.labelControl_gate.Size = new System.Drawing.Size(72, 27);
            this.labelControl_gate.TabIndex = 0;
            this.labelControl_gate.Text = "通  道：";
            // 
            // checkedListBoxControl_gate
            // 
            this.checkedListBoxControl_gate.Appearance.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBoxControl_gate.Appearance.Options.UseFont = true;
            this.checkedListBoxControl_gate.HorizontalScrollbar = true;
            this.checkedListBoxControl_gate.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("1"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("2"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("3"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("4"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("5")});
            this.checkedListBoxControl_gate.Location = new System.Drawing.Point(109, 20);
            this.checkedListBoxControl_gate.MultiColumn = true;
            this.checkedListBoxControl_gate.Name = "checkedListBoxControl_gate";
            this.checkedListBoxControl_gate.Size = new System.Drawing.Size(765, 301);
            this.checkedListBoxControl_gate.TabIndex = 1;
            this.checkedListBoxControl_gate.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.checkedListBoxControl_gate_ItemCheck);
            // 
            // simpleButton_allChecked
            // 
            this.simpleButton_allChecked.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_allChecked.Appearance.Options.UseFont = true;
            this.simpleButton_allChecked.Location = new System.Drawing.Point(12, 74);
            this.simpleButton_allChecked.Name = "simpleButton_allChecked";
            this.simpleButton_allChecked.Size = new System.Drawing.Size(91, 36);
            this.simpleButton_allChecked.TabIndex = 2;
            this.simpleButton_allChecked.Text = "全  选";
            this.simpleButton_allChecked.Click += new System.EventHandler(this.simpleButton_allChecked_Click);
            // 
            // simpleButton_cancelChecked
            // 
            this.simpleButton_cancelChecked.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_cancelChecked.Appearance.Options.UseFont = true;
            this.simpleButton_cancelChecked.Location = new System.Drawing.Point(12, 130);
            this.simpleButton_cancelChecked.Name = "simpleButton_cancelChecked";
            this.simpleButton_cancelChecked.Size = new System.Drawing.Size(91, 36);
            this.simpleButton_cancelChecked.TabIndex = 3;
            this.simpleButton_cancelChecked.Text = "取  消";
            this.simpleButton_cancelChecked.Click += new System.EventHandler(this.simpleButton_cancelChecked_Click);
            // 
            // simpleButton_modify
            // 
            this.simpleButton_modify.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_modify.Appearance.Options.UseFont = true;
            this.simpleButton_modify.Location = new System.Drawing.Point(286, 436);
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
            this.simpleButton_close.Location = new System.Drawing.Point(480, 436);
            this.simpleButton_close.Name = "simpleButton_close";
            this.simpleButton_close.Size = new System.Drawing.Size(91, 36);
            this.simpleButton_close.TabIndex = 7;
            this.simpleButton_close.Text = "关  闭";
            this.simpleButton_close.ToolTip = "关闭对话框";
            this.simpleButton_close.Click += new System.EventHandler(this.simpleButton_close_Click);
            // 
            // labelControl_temperatureError
            // 
            this.labelControl_temperatureError.Appearance.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_temperatureError.Location = new System.Drawing.Point(96, 361);
            this.labelControl_temperatureError.Name = "labelControl_temperatureError";
            this.labelControl_temperatureError.Size = new System.Drawing.Size(100, 27);
            this.labelControl_temperatureError.TabIndex = 8;
            this.labelControl_temperatureError.Text = "温度误差：";
            // 
            // labelControl_nuclearError
            // 
            this.labelControl_nuclearError.Appearance.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_nuclearError.Location = new System.Drawing.Point(471, 361);
            this.labelControl_nuclearError.Name = "labelControl_nuclearError";
            this.labelControl_nuclearError.Size = new System.Drawing.Size(100, 27);
            this.labelControl_nuclearError.TabIndex = 9;
            this.labelControl_nuclearError.Text = "核素误差：";
            // 
            // textEdit_temperatureError
            // 
            this.textEdit_temperatureError.Location = new System.Drawing.Point(202, 360);
            this.textEdit_temperatureError.Name = "textEdit_temperatureError";
            this.textEdit_temperatureError.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_temperatureError.Properties.Appearance.Options.UseFont = true;
            this.textEdit_temperatureError.Size = new System.Drawing.Size(230, 28);
            this.textEdit_temperatureError.TabIndex = 10;
            // 
            // textEdit_nuclearError
            // 
            this.textEdit_nuclearError.Location = new System.Drawing.Point(573, 361);
            this.textEdit_nuclearError.Name = "textEdit_nuclearError";
            this.textEdit_nuclearError.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_nuclearError.Properties.Appearance.Options.UseFont = true;
            this.textEdit_nuclearError.Size = new System.Drawing.Size(230, 28);
            this.textEdit_nuclearError.TabIndex = 11;
            // 
            // GateThresholdErrorUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 503);
            this.Controls.Add(this.textEdit_nuclearError);
            this.Controls.Add(this.textEdit_temperatureError);
            this.Controls.Add(this.labelControl_nuclearError);
            this.Controls.Add(this.labelControl_temperatureError);
            this.Controls.Add(this.simpleButton_close);
            this.Controls.Add(this.simpleButton_modify);
            this.Controls.Add(this.simpleButton_cancelChecked);
            this.Controls.Add(this.simpleButton_allChecked);
            this.Controls.Add(this.checkedListBoxControl_gate);
            this.Controls.Add(this.labelControl_gate);
            this.Name = "GateThresholdErrorUpdateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "闸机误差修改";
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl_gate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_temperatureError.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_nuclearError.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl_gate;
        private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControl_gate;
        private DevExpress.XtraEditors.SimpleButton simpleButton_allChecked;
        private DevExpress.XtraEditors.SimpleButton simpleButton_cancelChecked;
        private DevExpress.XtraEditors.SimpleButton simpleButton_modify;
        private DevExpress.XtraEditors.SimpleButton simpleButton_close;
        private DevExpress.XtraEditors.LabelControl labelControl_temperatureError;
        private DevExpress.XtraEditors.LabelControl labelControl_nuclearError;
        private DevExpress.XtraEditors.TextEdit textEdit_temperatureError;
        private DevExpress.XtraEditors.TextEdit textEdit_nuclearError;
    }
}