namespace zhuhai
{
    partial class PublishNoticeForm
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
            this.labelControl_message = new DevExpress.XtraEditors.LabelControl();
            this.textBox_message = new System.Windows.Forms.TextBox();
            this.simpleButton_publish = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_close = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl_gate)).BeginInit();
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
            // labelControl_message
            // 
            this.labelControl_message.Appearance.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_message.Location = new System.Drawing.Point(31, 327);
            this.labelControl_message.Name = "labelControl_message";
            this.labelControl_message.Size = new System.Drawing.Size(72, 27);
            this.labelControl_message.TabIndex = 4;
            this.labelControl_message.Text = "消  息：";
            // 
            // textBox_message
            // 
            this.textBox_message.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_message.Location = new System.Drawing.Point(109, 327);
            this.textBox_message.MaxLength = 1000;
            this.textBox_message.Multiline = true;
            this.textBox_message.Name = "textBox_message";
            this.textBox_message.Size = new System.Drawing.Size(765, 164);
            this.textBox_message.TabIndex = 5;
            // 
            // simpleButton_publish
            // 
            this.simpleButton_publish.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_publish.Appearance.Options.UseFont = true;
            this.simpleButton_publish.Location = new System.Drawing.Point(12, 387);
            this.simpleButton_publish.Name = "simpleButton_publish";
            this.simpleButton_publish.Size = new System.Drawing.Size(91, 36);
            this.simpleButton_publish.TabIndex = 6;
            this.simpleButton_publish.Text = "发  布";
            this.simpleButton_publish.Click += new System.EventHandler(this.simpleButton_publish_Click);
            // 
            // simpleButton_close
            // 
            this.simpleButton_close.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_close.Appearance.Options.UseFont = true;
            this.simpleButton_close.Location = new System.Drawing.Point(12, 442);
            this.simpleButton_close.Name = "simpleButton_close";
            this.simpleButton_close.Size = new System.Drawing.Size(91, 36);
            this.simpleButton_close.TabIndex = 7;
            this.simpleButton_close.Text = "关  闭";
            this.simpleButton_close.ToolTip = "关闭对话框";
            this.simpleButton_close.Click += new System.EventHandler(this.simpleButton_close_Click);
            // 
            // PublishNoticeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 503);
            this.Controls.Add(this.simpleButton_close);
            this.Controls.Add(this.simpleButton_publish);
            this.Controls.Add(this.textBox_message);
            this.Controls.Add(this.labelControl_message);
            this.Controls.Add(this.simpleButton_cancelChecked);
            this.Controls.Add(this.simpleButton_allChecked);
            this.Controls.Add(this.checkedListBoxControl_gate);
            this.Controls.Add(this.labelControl_gate);
            this.Name = "PublishNoticeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "信息发布";
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl_gate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl_gate;
        private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControl_gate;
        private DevExpress.XtraEditors.SimpleButton simpleButton_allChecked;
        private DevExpress.XtraEditors.SimpleButton simpleButton_cancelChecked;
        private DevExpress.XtraEditors.LabelControl labelControl_message;
        private System.Windows.Forms.TextBox textBox_message;
        private DevExpress.XtraEditors.SimpleButton simpleButton_publish;
        private DevExpress.XtraEditors.SimpleButton simpleButton_close;
    }
}