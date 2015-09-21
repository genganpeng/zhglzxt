namespace zhuhai
{
    partial class ClearanceStatisticsForm
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
            this.groupControl_query = new DevExpress.XtraEditors.GroupControl();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.groupControl_adavance = new DevExpress.XtraEditors.GroupControl();
            this.comboBox_sex = new System.Windows.Forms.ComboBox();
            this.labelControl_name = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_name = new DevExpress.XtraEditors.TextEdit();
            this.labelControl__country = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_country = new DevExpress.XtraEditors.TextEdit();
            this.labelControl_sex = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_abnormal = new DevExpress.XtraEditors.LabelControl();
            this.comboBox_abnormal = new System.Windows.Forms.ComboBox();
            this.labelControl_channel = new DevExpress.XtraEditors.LabelControl();
            this.comboBox__channel = new System.Windows.Forms.ComboBox();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarItem1 = new DevExpress.XtraNavBar.NavBarItem();
            this.dateTimePicker_endTime_time = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_startTime_time = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_endTime = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_startTime = new System.Windows.Forms.DateTimePicker();
            this.labelControl_endTime = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_startTime = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton_query = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_query)).BeginInit();
            this.groupControl_query.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_adavance)).BeginInit();
            this.groupControl_adavance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_country.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl_query
            // 
            this.groupControl_query.Controls.Add(this.checkBox);
            this.groupControl_query.Controls.Add(this.groupControl_adavance);
            this.groupControl_query.Controls.Add(this.navBarControl1);
            this.groupControl_query.Controls.Add(this.dateTimePicker_endTime_time);
            this.groupControl_query.Controls.Add(this.dateTimePicker_startTime_time);
            this.groupControl_query.Controls.Add(this.dateTimePicker_endTime);
            this.groupControl_query.Controls.Add(this.dateTimePicker_startTime);
            this.groupControl_query.Controls.Add(this.labelControl_endTime);
            this.groupControl_query.Controls.Add(this.labelControl_startTime);
            this.groupControl_query.Controls.Add(this.simpleButton_query);
            this.groupControl_query.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl_query.Location = new System.Drawing.Point(0, 0);
            this.groupControl_query.Name = "groupControl_query";
            this.groupControl_query.Size = new System.Drawing.Size(772, 368);
            this.groupControl_query.TabIndex = 0;
            this.groupControl_query.Text = "查询条件";
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox.Location = new System.Drawing.Point(25, 60);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(125, 25);
            this.checkBox.TabIndex = 26;
            this.checkBox.Text = "高级查询条件";
            this.checkBox.UseVisualStyleBackColor = true;
            this.checkBox.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // groupControl_adavance
            // 
            this.groupControl_adavance.Controls.Add(this.comboBox_sex);
            this.groupControl_adavance.Controls.Add(this.labelControl_name);
            this.groupControl_adavance.Controls.Add(this.textEdit_name);
            this.groupControl_adavance.Controls.Add(this.labelControl__country);
            this.groupControl_adavance.Controls.Add(this.textEdit_country);
            this.groupControl_adavance.Controls.Add(this.labelControl_sex);
            this.groupControl_adavance.Controls.Add(this.labelControl_abnormal);
            this.groupControl_adavance.Controls.Add(this.comboBox_abnormal);
            this.groupControl_adavance.Controls.Add(this.labelControl_channel);
            this.groupControl_adavance.Controls.Add(this.comboBox__channel);
            this.groupControl_adavance.Location = new System.Drawing.Point(15, 96);
            this.groupControl_adavance.Name = "groupControl_adavance";
            this.groupControl_adavance.ShowCaption = false;
            this.groupControl_adavance.Size = new System.Drawing.Size(730, 145);
            this.groupControl_adavance.TabIndex = 25;
            this.groupControl_adavance.Text = "高级查询条件";
            this.groupControl_adavance.Visible = false;
            // 
            // comboBox_sex
            // 
            this.comboBox_sex.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_sex.FormattingEnabled = true;
            this.comboBox_sex.Items.AddRange(new object[] {
            "全部",
            "男",
            "女"});
            this.comboBox_sex.Location = new System.Drawing.Point(570, 19);
            this.comboBox_sex.Name = "comboBox_sex";
            this.comboBox_sex.Size = new System.Drawing.Size(145, 29);
            this.comboBox_sex.TabIndex = 5;
            // 
            // labelControl_name
            // 
            this.labelControl_name.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_name.Location = new System.Drawing.Point(27, 16);
            this.labelControl_name.Name = "labelControl_name";
            this.labelControl_name.Size = new System.Drawing.Size(48, 21);
            this.labelControl_name.TabIndex = 0;
            this.labelControl_name.Text = "姓名：";
            // 
            // textEdit_name
            // 
            this.textEdit_name.Location = new System.Drawing.Point(81, 19);
            this.textEdit_name.Name = "textEdit_name";
            this.textEdit_name.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_name.Properties.Appearance.Options.UseFont = true;
            this.textEdit_name.Size = new System.Drawing.Size(145, 28);
            this.textEdit_name.TabIndex = 1;
            // 
            // labelControl__country
            // 
            this.labelControl__country.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl__country.Location = new System.Drawing.Point(299, 18);
            this.labelControl__country.Name = "labelControl__country";
            this.labelControl__country.Size = new System.Drawing.Size(48, 21);
            this.labelControl__country.TabIndex = 2;
            this.labelControl__country.Text = "国籍：";
            // 
            // textEdit_country
            // 
            this.textEdit_country.Location = new System.Drawing.Point(353, 18);
            this.textEdit_country.Name = "textEdit_country";
            this.textEdit_country.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_country.Properties.Appearance.Options.UseFont = true;
            this.textEdit_country.Size = new System.Drawing.Size(133, 28);
            this.textEdit_country.TabIndex = 3;
            // 
            // labelControl_sex
            // 
            this.labelControl_sex.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_sex.Location = new System.Drawing.Point(516, 19);
            this.labelControl_sex.Name = "labelControl_sex";
            this.labelControl_sex.Size = new System.Drawing.Size(48, 21);
            this.labelControl_sex.TabIndex = 4;
            this.labelControl_sex.Text = "性别：";
            // 
            // labelControl_abnormal
            // 
            this.labelControl_abnormal.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_abnormal.Location = new System.Drawing.Point(269, 60);
            this.labelControl_abnormal.Name = "labelControl_abnormal";
            this.labelControl_abnormal.Size = new System.Drawing.Size(80, 21);
            this.labelControl_abnormal.TabIndex = 10;
            this.labelControl_abnormal.Text = "异常类型：";
            // 
            // comboBox_abnormal
            // 
            this.comboBox_abnormal.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_abnormal.FormattingEnabled = true;
            this.comboBox_abnormal.Location = new System.Drawing.Point(355, 60);
            this.comboBox_abnormal.Name = "comboBox_abnormal";
            this.comboBox_abnormal.Size = new System.Drawing.Size(145, 29);
            this.comboBox_abnormal.TabIndex = 11;
            // 
            // labelControl_channel
            // 
            this.labelControl_channel.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_channel.Location = new System.Drawing.Point(27, 57);
            this.labelControl_channel.Name = "labelControl_channel";
            this.labelControl_channel.Size = new System.Drawing.Size(48, 21);
            this.labelControl_channel.TabIndex = 12;
            this.labelControl_channel.Text = "通道：";
            // 
            // comboBox__channel
            // 
            this.comboBox__channel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox__channel.FormattingEnabled = true;
            this.comboBox__channel.Location = new System.Drawing.Point(81, 57);
            this.comboBox__channel.Name = "comboBox__channel";
            this.comboBox__channel.Size = new System.Drawing.Size(145, 29);
            this.comboBox__channel.TabIndex = 13;
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = null;
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBarItem1});
            this.navBarControl1.Location = new System.Drawing.Point(140, 158);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 230;
            this.navBarControl1.Size = new System.Drawing.Size(230, 179);
            this.navBarControl1.TabIndex = 24;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // navBarItem1
            // 
            this.navBarItem1.Caption = "navBarItem1";
            this.navBarItem1.Name = "navBarItem1";
            // 
            // dateTimePicker_endTime_time
            // 
            this.dateTimePicker_endTime_time.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker_endTime_time.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker_endTime_time.Location = new System.Drawing.Point(588, 24);
            this.dateTimePicker_endTime_time.Name = "dateTimePicker_endTime_time";
            this.dateTimePicker_endTime_time.ShowUpDown = true;
            this.dateTimePicker_endTime_time.Size = new System.Drawing.Size(87, 29);
            this.dateTimePicker_endTime_time.TabIndex = 23;
            // 
            // dateTimePicker_startTime_time
            // 
            this.dateTimePicker_startTime_time.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker_startTime_time.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker_startTime_time.Location = new System.Drawing.Point(262, 23);
            this.dateTimePicker_startTime_time.Name = "dateTimePicker_startTime_time";
            this.dateTimePicker_startTime_time.ShowUpDown = true;
            this.dateTimePicker_startTime_time.Size = new System.Drawing.Size(87, 29);
            this.dateTimePicker_startTime_time.TabIndex = 22;
            // 
            // dateTimePicker_endTime
            // 
            this.dateTimePicker_endTime.CalendarFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker_endTime.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker_endTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker_endTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_endTime.Location = new System.Drawing.Point(453, 24);
            this.dateTimePicker_endTime.Name = "dateTimePicker_endTime";
            this.dateTimePicker_endTime.Size = new System.Drawing.Size(129, 29);
            this.dateTimePicker_endTime.TabIndex = 21;
            // 
            // dateTimePicker_startTime
            // 
            this.dateTimePicker_startTime.CalendarFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker_startTime.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker_startTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker_startTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_startTime.Location = new System.Drawing.Point(111, 24);
            this.dateTimePicker_startTime.Name = "dateTimePicker_startTime";
            this.dateTimePicker_startTime.Size = new System.Drawing.Size(128, 29);
            this.dateTimePicker_startTime.TabIndex = 20;
            // 
            // labelControl_endTime
            // 
            this.labelControl_endTime.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl_endTime.Location = new System.Drawing.Point(367, 27);
            this.labelControl_endTime.Name = "labelControl_endTime";
            this.labelControl_endTime.Size = new System.Drawing.Size(80, 21);
            this.labelControl_endTime.TabIndex = 19;
            this.labelControl_endTime.Text = "结束时间：";
            // 
            // labelControl_startTime
            // 
            this.labelControl_startTime.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl_startTime.Location = new System.Drawing.Point(25, 26);
            this.labelControl_startTime.Name = "labelControl_startTime";
            this.labelControl_startTime.Size = new System.Drawing.Size(80, 21);
            this.labelControl_startTime.TabIndex = 18;
            this.labelControl_startTime.Text = "开始时间：";
            // 
            // simpleButton_query
            // 
            this.simpleButton_query.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_query.Appearance.Options.UseFont = true;
            this.simpleButton_query.Location = new System.Drawing.Point(531, 247);
            this.simpleButton_query.Name = "simpleButton_query";
            this.simpleButton_query.Size = new System.Drawing.Size(214, 51);
            this.simpleButton_query.TabIndex = 14;
            this.simpleButton_query.Text = "查  询";
            this.simpleButton_query.Click += new System.EventHandler(this.simpleButton_query_Click);
            // 
            // ClearanceStatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 368);
            this.Controls.Add(this.groupControl_query);
            this.Name = "ClearanceStatisticsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "通关人数统计";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_query)).EndInit();
            this.groupControl_query.ResumeLayout(false);
            this.groupControl_query.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_adavance)).EndInit();
            this.groupControl_adavance.ResumeLayout(false);
            this.groupControl_adavance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_country.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl_query;
        private DevExpress.XtraEditors.LabelControl labelControl_name;
        private DevExpress.XtraEditors.TextEdit textEdit_name;
        private DevExpress.XtraEditors.TextEdit textEdit_country;
        private DevExpress.XtraEditors.LabelControl labelControl__country;
        private DevExpress.XtraEditors.LabelControl labelControl_sex;
        private System.Windows.Forms.ComboBox comboBox_sex;
        private DevExpress.XtraEditors.LabelControl labelControl_abnormal;
        private System.Windows.Forms.ComboBox comboBox_abnormal;
        private System.Windows.Forms.ComboBox comboBox__channel;
        private DevExpress.XtraEditors.LabelControl labelControl_channel;
        private DevExpress.XtraEditors.SimpleButton simpleButton_query;
        private System.Windows.Forms.DateTimePicker dateTimePicker_endTime_time;
        private System.Windows.Forms.DateTimePicker dateTimePicker_startTime_time;
        private System.Windows.Forms.DateTimePicker dateTimePicker_endTime;
        private System.Windows.Forms.DateTimePicker dateTimePicker_startTime;
        private DevExpress.XtraEditors.LabelControl labelControl_endTime;
        private DevExpress.XtraEditors.LabelControl labelControl_startTime;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarItem navBarItem1;
        private DevExpress.XtraEditors.GroupControl groupControl_adavance;
        private System.Windows.Forms.CheckBox checkBox;
    }
}