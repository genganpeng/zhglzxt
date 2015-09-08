namespace zhuhai
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.btn_reset = new DevExpress.XtraEditors.SimpleButton();
            this.btn_login = new DevExpress.XtraEditors.SimpleButton();
            this.pictureBox_checkCode = new System.Windows.Forms.PictureBox();
            this.txt_verificationCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txt_passwd = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txt_user = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_checkCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_verificationCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_passwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_user.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_reset
            // 
            this.btn_reset.Location = new System.Drawing.Point(335, 240);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(90, 23);
            this.btn_reset.TabIndex = 26;
            this.btn_reset.Text = "重　置";
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(239, 240);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(90, 23);
            this.btn_login.TabIndex = 25;
            this.btn_login.Text = "登　录";
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // pictureBox_checkCode
            // 
            this.pictureBox_checkCode.BackColor = System.Drawing.Color.Maroon;
            this.pictureBox_checkCode.Location = new System.Drawing.Point(375, 212);
            this.pictureBox_checkCode.Name = "pictureBox_checkCode";
            this.pictureBox_checkCode.Size = new System.Drawing.Size(50, 20);
            this.pictureBox_checkCode.TabIndex = 24;
            this.pictureBox_checkCode.TabStop = false;
            this.pictureBox_checkCode.Click += new System.EventHandler(this.pictureBox_checkCode_Click);
            // 
            // txt_verificationCode
            // 
            this.txt_verificationCode.Location = new System.Drawing.Point(305, 213);
            this.txt_verificationCode.Name = "txt_verificationCode";
            this.txt_verificationCode.Size = new System.Drawing.Size(65, 20);
            this.txt_verificationCode.TabIndex = 23;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(239, 214);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 19);
            this.labelControl3.TabIndex = 22;
            this.labelControl3.Text = "验 证 码：";
            // 
            // txt_passwd
            // 
            this.txt_passwd.Location = new System.Drawing.Point(305, 186);
            this.txt_passwd.Name = "txt_passwd";
            this.txt_passwd.Size = new System.Drawing.Size(120, 20);
            this.txt_passwd.TabIndex = 21;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(239, 187);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 19);
            this.labelControl2.TabIndex = 20;
            this.labelControl2.Text = "密 　 码：";
            // 
            // txt_user
            // 
            this.txt_user.Location = new System.Drawing.Point(305, 158);
            this.txt_user.Name = "txt_user";
            this.txt_user.Size = new System.Drawing.Size(120, 20);
            this.txt_user.TabIndex = 19;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl1.Location = new System.Drawing.Point(239, 159);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 19);
            this.labelControl1.TabIndex = 18;
            this.labelControl1.Text = "用 户 名：";
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btn_login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Tile;
            this.BackgroundImageStore = global::zhuhai.Properties.Resources.login_bg;
            this.ClientSize = new System.Drawing.Size(640, 480);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.pictureBox_checkCode);
            this.Controls.Add(this.txt_verificationCode);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txt_passwd);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txt_user);
            this.Controls.Add(this.labelControl1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_checkCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_verificationCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_passwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_user.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn_reset;
        private DevExpress.XtraEditors.SimpleButton btn_login;
        private System.Windows.Forms.PictureBox pictureBox_checkCode;
        private DevExpress.XtraEditors.TextEdit txt_verificationCode;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txt_passwd;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txt_user;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}