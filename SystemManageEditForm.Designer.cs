namespace zhuhai
{
    partial class SystemManageEditForm
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
            this.comboBoxEdit_type = new DevExpress.XtraEditors.ComboBoxEdit();
            this.textEdit_IDCard = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_name = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_userName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl_IDCard = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_name = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_type = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_password = new DevExpress.XtraEditors.TextEdit();
            this.labelControl_password = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton_add = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_cancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_type.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_IDCard.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_userName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_password.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxEdit_type
            // 
            this.comboBoxEdit_type.Location = new System.Drawing.Point(89, 79);
            this.comboBoxEdit_type.Name = "comboBoxEdit_type";
            this.comboBoxEdit_type.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_type.Size = new System.Drawing.Size(158, 20);
            this.comboBoxEdit_type.TabIndex = 15;
            // 
            // textEdit_IDCard
            // 
            this.textEdit_IDCard.Location = new System.Drawing.Point(89, 136);
            this.textEdit_IDCard.Name = "textEdit_IDCard";
            this.textEdit_IDCard.Size = new System.Drawing.Size(229, 20);
            this.textEdit_IDCard.TabIndex = 14;
            // 
            // textEdit_name
            // 
            this.textEdit_name.Location = new System.Drawing.Point(419, 79);
            this.textEdit_name.Name = "textEdit_name";
            this.textEdit_name.Size = new System.Drawing.Size(143, 20);
            this.textEdit_name.TabIndex = 13;
            // 
            // textEdit_userName
            // 
            this.textEdit_userName.Location = new System.Drawing.Point(89, 28);
            this.textEdit_userName.Name = "textEdit_userName";
            this.textEdit_userName.Size = new System.Drawing.Size(158, 20);
            this.textEdit_userName.TabIndex = 12;
            // 
            // labelControl_IDCard
            // 
            this.labelControl_IDCard.Location = new System.Drawing.Point(28, 139);
            this.labelControl_IDCard.Name = "labelControl_IDCard";
            this.labelControl_IDCard.Size = new System.Drawing.Size(48, 14);
            this.labelControl_IDCard.TabIndex = 11;
            this.labelControl_IDCard.Text = "证件号：";
            // 
            // labelControl_name
            // 
            this.labelControl_name.Location = new System.Drawing.Point(343, 82);
            this.labelControl_name.Name = "labelControl_name";
            this.labelControl_name.Size = new System.Drawing.Size(44, 14);
            this.labelControl_name.TabIndex = 10;
            this.labelControl_name.Text = "姓  名：";
            // 
            // labelControl_type
            // 
            this.labelControl_type.Location = new System.Drawing.Point(32, 82);
            this.labelControl_type.Name = "labelControl_type";
            this.labelControl_type.Size = new System.Drawing.Size(44, 14);
            this.labelControl_type.TabIndex = 9;
            this.labelControl_type.Text = "类  别：";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(28, 31);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "用户名：";
            // 
            // textEdit_password
            // 
            this.textEdit_password.Location = new System.Drawing.Point(417, 28);
            this.textEdit_password.Name = "textEdit_password";
            this.textEdit_password.Size = new System.Drawing.Size(143, 20);
            this.textEdit_password.TabIndex = 17;
            // 
            // labelControl_password
            // 
            this.labelControl_password.Location = new System.Drawing.Point(341, 31);
            this.labelControl_password.Name = "labelControl_password";
            this.labelControl_password.Size = new System.Drawing.Size(44, 14);
            this.labelControl_password.TabIndex = 16;
            this.labelControl_password.Text = "密  码：";
            // 
            // simpleButton_add
            // 
            this.simpleButton_add.Location = new System.Drawing.Point(110, 249);
            this.simpleButton_add.Name = "simpleButton_add";
            this.simpleButton_add.Size = new System.Drawing.Size(118, 23);
            this.simpleButton_add.TabIndex = 18;
            this.simpleButton_add.Text = "保  存";
            this.simpleButton_add.Click += new System.EventHandler(this.simpleButton_add_Click);
            // 
            // simpleButton_cancel
            // 
            this.simpleButton_cancel.Location = new System.Drawing.Point(321, 249);
            this.simpleButton_cancel.Name = "simpleButton_cancel";
            this.simpleButton_cancel.Size = new System.Drawing.Size(118, 23);
            this.simpleButton_cancel.TabIndex = 19;
            this.simpleButton_cancel.Text = "取  消";
            this.simpleButton_cancel.Click += new System.EventHandler(this.simpleButton_cancel_Click);
            // 
            // SystemManageEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 352);
            this.Controls.Add(this.simpleButton_cancel);
            this.Controls.Add(this.simpleButton_add);
            this.Controls.Add(this.textEdit_password);
            this.Controls.Add(this.labelControl_password);
            this.Controls.Add(this.comboBoxEdit_type);
            this.Controls.Add(this.textEdit_IDCard);
            this.Controls.Add(this.textEdit_name);
            this.Controls.Add(this.textEdit_userName);
            this.Controls.Add(this.labelControl_IDCard);
            this.Controls.Add(this.labelControl_name);
            this.Controls.Add(this.labelControl_type);
            this.Controls.Add(this.labelControl1);
            this.Name = "SystemManageEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "系统管理编辑";
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_type.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_IDCard.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_userName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_password.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_type;
        private DevExpress.XtraEditors.TextEdit textEdit_IDCard;
        private DevExpress.XtraEditors.TextEdit textEdit_name;
        private DevExpress.XtraEditors.TextEdit textEdit_userName;
        private DevExpress.XtraEditors.LabelControl labelControl_IDCard;
        private DevExpress.XtraEditors.LabelControl labelControl_name;
        private DevExpress.XtraEditors.LabelControl labelControl_type;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit textEdit_password;
        private DevExpress.XtraEditors.LabelControl labelControl_password;
        private DevExpress.XtraEditors.SimpleButton simpleButton_add;
        private DevExpress.XtraEditors.SimpleButton simpleButton_cancel;
    }
}