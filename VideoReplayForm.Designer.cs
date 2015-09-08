namespace zhuhai
{
    partial class VideoReplayForm
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
            this.groupControl = new DevExpress.XtraEditors.GroupControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_query = new DevExpress.XtraEditors.SimpleButton();
            this.dateTimePicker_startTime = new System.Windows.Forms.DateTimePicker();
            this.labelControl_startTime = new DevExpress.XtraEditors.LabelControl();
            this.comboBox_sex = new System.Windows.Forms.ComboBox();
            this.labelControl_sex = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_country = new DevExpress.XtraEditors.TextEdit();
            this.labelControl__country = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_name = new DevExpress.XtraEditors.TextEdit();
            this.labelControl_name = new DevExpress.XtraEditors.LabelControl();
            this.panel_query = new System.Windows.Forms.Panel();
            this.gridControl_query = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gate_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nvr_begintime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.temperature = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nuclear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nationality = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.birth_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.id_code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.issue_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.expire_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pageUpControl_query = new zhuhai.Component.PageUpControl();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.searchVideoPlayWnd = new System.Windows.Forms.PictureBox();
            this.playButtonsPanel = new System.Windows.Forms.Panel();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnFast = new System.Windows.Forms.Button();
            this.btnSlow = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl)).BeginInit();
            this.groupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_country.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_name.Properties)).BeginInit();
            this.panel_query.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_query)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchVideoPlayWnd)).BeginInit();
            this.playButtonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl
            // 
            this.groupControl.Controls.Add(this.simpleButton1);
            this.groupControl.Controls.Add(this.simpleButton_query);
            this.groupControl.Controls.Add(this.dateTimePicker_startTime);
            this.groupControl.Controls.Add(this.labelControl_startTime);
            this.groupControl.Controls.Add(this.comboBox_sex);
            this.groupControl.Controls.Add(this.labelControl_sex);
            this.groupControl.Controls.Add(this.textEdit_country);
            this.groupControl.Controls.Add(this.labelControl__country);
            this.groupControl.Controls.Add(this.textEdit_name);
            this.groupControl.Controls.Add(this.labelControl_name);
            this.groupControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl.Location = new System.Drawing.Point(0, 0);
            this.groupControl.Name = "groupControl";
            this.groupControl.Size = new System.Drawing.Size(757, 126);
            this.groupControl.TabIndex = 0;
            this.groupControl.Text = "查询条件";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new System.Drawing.Point(599, 91);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(111, 29);
            this.simpleButton1.TabIndex = 15;
            this.simpleButton1.Text = "查  看";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton_view_Click);
            // 
            // simpleButton_query
            // 
            this.simpleButton_query.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_query.Appearance.Options.UseFont = true;
            this.simpleButton_query.Location = new System.Drawing.Point(599, 43);
            this.simpleButton_query.Name = "simpleButton_query";
            this.simpleButton_query.Size = new System.Drawing.Size(111, 29);
            this.simpleButton_query.TabIndex = 14;
            this.simpleButton_query.Text = "查  询";
            this.simpleButton_query.Click += new System.EventHandler(this.simpleButton_query_Click);
            // 
            // dateTimePicker_startTime
            // 
            this.dateTimePicker_startTime.CalendarFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker_startTime.CustomFormat = "yyyy年M月d日";
            this.dateTimePicker_startTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_startTime.Location = new System.Drawing.Point(387, 67);
            this.dateTimePicker_startTime.Name = "dateTimePicker_startTime";
            this.dateTimePicker_startTime.Size = new System.Drawing.Size(145, 21);
            this.dateTimePicker_startTime.TabIndex = 8;
            this.dateTimePicker_startTime.ValueChanged += new System.EventHandler(this.dateTimePicker_startTime_ValueChanged);
            // 
            // labelControl_startTime
            // 
            this.labelControl_startTime.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_startTime.Location = new System.Drawing.Point(333, 66);
            this.labelControl_startTime.Name = "labelControl_startTime";
            this.labelControl_startTime.Size = new System.Drawing.Size(48, 21);
            this.labelControl_startTime.TabIndex = 6;
            this.labelControl_startTime.Text = "时间：";
            // 
            // comboBox_sex
            // 
            this.comboBox_sex.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_sex.FormattingEnabled = true;
            this.comboBox_sex.Items.AddRange(new object[] {
            "全部",
            "男",
            "女"});
            this.comboBox_sex.Location = new System.Drawing.Point(94, 59);
            this.comboBox_sex.Name = "comboBox_sex";
            this.comboBox_sex.Size = new System.Drawing.Size(145, 29);
            this.comboBox_sex.TabIndex = 5;
            // 
            // labelControl_sex
            // 
            this.labelControl_sex.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_sex.Location = new System.Drawing.Point(40, 62);
            this.labelControl_sex.Name = "labelControl_sex";
            this.labelControl_sex.Size = new System.Drawing.Size(48, 21);
            this.labelControl_sex.TabIndex = 4;
            this.labelControl_sex.Text = "性别：";
            // 
            // textEdit_country
            // 
            this.textEdit_country.Location = new System.Drawing.Point(387, 25);
            this.textEdit_country.Name = "textEdit_country";
            this.textEdit_country.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_country.Properties.Appearance.Options.UseFont = true;
            this.textEdit_country.Size = new System.Drawing.Size(145, 28);
            this.textEdit_country.TabIndex = 3;
            // 
            // labelControl__country
            // 
            this.labelControl__country.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl__country.Location = new System.Drawing.Point(333, 28);
            this.labelControl__country.Name = "labelControl__country";
            this.labelControl__country.Size = new System.Drawing.Size(48, 21);
            this.labelControl__country.TabIndex = 2;
            this.labelControl__country.Text = "国籍：";
            // 
            // textEdit_name
            // 
            this.textEdit_name.Location = new System.Drawing.Point(94, 25);
            this.textEdit_name.Name = "textEdit_name";
            this.textEdit_name.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_name.Properties.Appearance.Options.UseFont = true;
            this.textEdit_name.Size = new System.Drawing.Size(145, 28);
            this.textEdit_name.TabIndex = 1;
            // 
            // labelControl_name
            // 
            this.labelControl_name.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_name.Location = new System.Drawing.Point(40, 25);
            this.labelControl_name.Name = "labelControl_name";
            this.labelControl_name.Size = new System.Drawing.Size(48, 21);
            this.labelControl_name.TabIndex = 0;
            this.labelControl_name.Text = "姓名：";
            // 
            // panel_query
            // 
            this.panel_query.Controls.Add(this.gridControl_query);
            this.panel_query.Controls.Add(this.pageUpControl_query);
            this.panel_query.Controls.Add(this.groupControl);
            this.panel_query.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_query.Location = new System.Drawing.Point(0, 0);
            this.panel_query.Name = "panel_query";
            this.panel_query.Size = new System.Drawing.Size(757, 527);
            this.panel_query.TabIndex = 15;
            // 
            // gridControl_query
            // 
            this.gridControl_query.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_query.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_query.Location = new System.Drawing.Point(0, 126);
            this.gridControl_query.MainView = this.gridView;
            this.gridControl_query.Name = "gridControl_query";
            this.gridControl_query.Size = new System.Drawing.Size(757, 359);
            this.gridControl_query.TabIndex = 2;
            this.gridControl_query.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            this.gridControl_query.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gridControl_query_MouseDoubleClick);
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.name,
            this.gate_id,
            this.nvr_begintime,
            this.temperature,
            this.nuclear,
            this.nationality,
            this.sex,
            this.birth_date,
            this.id_code,
            this.issue_date,
            this.expire_date});
            this.gridView.GridControl = this.gridControl_query;
            this.gridView.Name = "gridView";
            this.gridView.OptionsSelection.MultiSelect = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            // 
            // name
            // 
            this.name.Caption = "姓名";
            this.name.FieldName = "name";
            this.name.Name = "name";
            this.name.OptionsColumn.AllowEdit = false;
            this.name.Visible = true;
            this.name.VisibleIndex = 0;
            // 
            // gate_id
            // 
            this.gate_id.Caption = "通道";
            this.gate_id.FieldName = "gate_id";
            this.gate_id.Name = "gate_id";
            this.gate_id.OptionsColumn.AllowEdit = false;
            this.gate_id.Visible = true;
            this.gate_id.VisibleIndex = 1;
            // 
            // nvr_begintime
            // 
            this.nvr_begintime.Caption = "开始时间";
            this.nvr_begintime.FieldName = "nvr_begintime";
            this.nvr_begintime.Name = "nvr_begintime";
            this.nvr_begintime.OptionsColumn.AllowEdit = false;
            this.nvr_begintime.Visible = true;
            this.nvr_begintime.VisibleIndex = 2;
            // 
            // temperature
            // 
            this.temperature.Caption = "体温";
            this.temperature.FieldName = "temperature";
            this.temperature.Name = "temperature";
            this.temperature.OptionsColumn.AllowEdit = false;
            this.temperature.Visible = true;
            this.temperature.VisibleIndex = 3;
            // 
            // nuclear
            // 
            this.nuclear.Caption = "核素";
            this.nuclear.FieldName = "nuclear";
            this.nuclear.Name = "nuclear";
            this.nuclear.OptionsColumn.AllowEdit = false;
            this.nuclear.Visible = true;
            this.nuclear.VisibleIndex = 4;
            // 
            // nationality
            // 
            this.nationality.Caption = "国籍";
            this.nationality.FieldName = "nationality";
            this.nationality.Name = "nationality";
            this.nationality.OptionsColumn.AllowEdit = false;
            this.nationality.Visible = true;
            this.nationality.VisibleIndex = 5;
            // 
            // sex
            // 
            this.sex.Caption = "性别";
            this.sex.FieldName = "sex";
            this.sex.Name = "sex";
            this.sex.OptionsColumn.AllowEdit = false;
            this.sex.Visible = true;
            this.sex.VisibleIndex = 6;
            // 
            // birth_date
            // 
            this.birth_date.Caption = "出生日期";
            this.birth_date.FieldName = "birth_date";
            this.birth_date.Name = "birth_date";
            this.birth_date.OptionsColumn.AllowEdit = false;
            this.birth_date.Visible = true;
            this.birth_date.VisibleIndex = 7;
            // 
            // id_code
            // 
            this.id_code.Caption = "证件号码";
            this.id_code.FieldName = "id_code";
            this.id_code.Name = "id_code";
            this.id_code.OptionsColumn.AllowEdit = false;
            this.id_code.Visible = true;
            this.id_code.VisibleIndex = 8;
            // 
            // issue_date
            // 
            this.issue_date.Caption = "签发日期";
            this.issue_date.FieldName = "issue_date";
            this.issue_date.Name = "issue_date";
            this.issue_date.OptionsColumn.AllowEdit = false;
            this.issue_date.Visible = true;
            this.issue_date.VisibleIndex = 9;
            // 
            // expire_date
            // 
            this.expire_date.Caption = "有效期";
            this.expire_date.FieldName = "expire_date";
            this.expire_date.Name = "expire_date";
            this.expire_date.OptionsColumn.AllowEdit = false;
            this.expire_date.Visible = true;
            this.expire_date.VisibleIndex = 10;
            // 
            // pageUpControl_query
            // 
            this.pageUpControl_query.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pageUpControl_query.Location = new System.Drawing.Point(0, 485);
            this.pageUpControl_query.MyControl = null;
            this.pageUpControl_query.Name = "pageUpControl_query";
            this.pageUpControl_query.PageIndex = 0;
            this.pageUpControl_query.PageRow = 0;
            this.pageUpControl_query.Pagesize = 0;
            this.pageUpControl_query.QueryService = null;
            this.pageUpControl_query.Size = new System.Drawing.Size(757, 42);
            this.pageUpControl_query.StrWhere = null;
            this.pageUpControl_query.TabIndex = 1;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.searchVideoPlayWnd);
            this.groupBox6.Controls.Add(this.playButtonsPanel);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(757, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(535, 527);
            this.groupBox6.TabIndex = 16;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "视频回放";
            // 
            // searchVideoPlayWnd
            // 
            this.searchVideoPlayWnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchVideoPlayWnd.Location = new System.Drawing.Point(3, 17);
            this.searchVideoPlayWnd.Name = "searchVideoPlayWnd";
            this.searchVideoPlayWnd.Size = new System.Drawing.Size(529, 437);
            this.searchVideoPlayWnd.TabIndex = 1;
            this.searchVideoPlayWnd.TabStop = false;
            // 
            // playButtonsPanel
            // 
            this.playButtonsPanel.Controls.Add(this.btnPlay);
            this.playButtonsPanel.Controls.Add(this.btnStop);
            this.playButtonsPanel.Controls.Add(this.btnFast);
            this.playButtonsPanel.Controls.Add(this.btnSlow);
            this.playButtonsPanel.Controls.Add(this.btnPause);
            this.playButtonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.playButtonsPanel.Location = new System.Drawing.Point(3, 454);
            this.playButtonsPanel.Name = "playButtonsPanel";
            this.playButtonsPanel.Size = new System.Drawing.Size(529, 70);
            this.playButtonsPanel.TabIndex = 45;
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(175)))), ((int)(((byte)(198)))));
            this.btnPlay.BackgroundImage = global::zhuhai.Properties.Resources.play;
            this.btnPlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlay.FlatAppearance.BorderSize = 0;
            this.btnPlay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPlay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.Location = new System.Drawing.Point(225, 10);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(58, 52);
            this.btnPlay.TabIndex = 53;
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(175)))), ((int)(((byte)(198)))));
            this.btnStop.BackgroundImage = global::zhuhai.Properties.Resources.stop;
            this.btnStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStop.FlatAppearance.BorderSize = 0;
            this.btnStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Location = new System.Drawing.Point(305, 10);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(58, 52);
            this.btnStop.TabIndex = 51;
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnFast
            // 
            this.btnFast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(175)))), ((int)(((byte)(198)))));
            this.btnFast.BackgroundImage = global::zhuhai.Properties.Resources.fast;
            this.btnFast.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFast.FlatAppearance.BorderSize = 0;
            this.btnFast.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnFast.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnFast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFast.Location = new System.Drawing.Point(385, 10);
            this.btnFast.Name = "btnFast";
            this.btnFast.Size = new System.Drawing.Size(58, 52);
            this.btnFast.TabIndex = 41;
            this.btnFast.UseVisualStyleBackColor = false;
            this.btnFast.Click += new System.EventHandler(this.btnFast_Click);
            // 
            // btnSlow
            // 
            this.btnSlow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(175)))), ((int)(((byte)(198)))));
            this.btnSlow.BackgroundImage = global::zhuhai.Properties.Resources.slow;
            this.btnSlow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSlow.FlatAppearance.BorderSize = 0;
            this.btnSlow.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSlow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSlow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSlow.Location = new System.Drawing.Point(55, 10);
            this.btnSlow.Name = "btnSlow";
            this.btnSlow.Size = new System.Drawing.Size(58, 52);
            this.btnSlow.TabIndex = 40;
            this.btnSlow.UseVisualStyleBackColor = false;
            this.btnSlow.Click += new System.EventHandler(this.btnSlow_Click);
            // 
            // btnPause
            // 
            this.btnPause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(175)))), ((int)(((byte)(198)))));
            this.btnPause.BackgroundImage = global::zhuhai.Properties.Resources.pause;
            this.btnPause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPause.FlatAppearance.BorderSize = 0;
            this.btnPause.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPause.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPause.Location = new System.Drawing.Point(142, 10);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(58, 52);
            this.btnPause.TabIndex = 39;
            this.btnPause.UseVisualStyleBackColor = false;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(29, 36);
            this.toolStripStatusLabel.Text = "就绪";
            // 
            // VideoReplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 527);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.panel_query);
            this.Name = "VideoReplayForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "通关记录查询";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VideoReplayForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl)).EndInit();
            this.groupControl.ResumeLayout(false);
            this.groupControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_country.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_name.Properties)).EndInit();
            this.panel_query.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_query)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchVideoPlayWnd)).EndInit();
            this.playButtonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl;
        private DevExpress.XtraEditors.LabelControl labelControl_name;
        private DevExpress.XtraEditors.TextEdit textEdit_name;
        private DevExpress.XtraEditors.TextEdit textEdit_country;
        private DevExpress.XtraEditors.LabelControl labelControl__country;
        private DevExpress.XtraEditors.LabelControl labelControl_sex;
        private System.Windows.Forms.ComboBox comboBox_sex;
        private DevExpress.XtraEditors.LabelControl labelControl_startTime;
        private System.Windows.Forms.DateTimePicker dateTimePicker_startTime;
        private DevExpress.XtraEditors.SimpleButton simpleButton_query;
        private DevExpress.XtraGrid.GridControl gridControl_query;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn name;
        private DevExpress.XtraGrid.Columns.GridColumn gate_id;
        private DevExpress.XtraGrid.Columns.GridColumn nvr_begintime;
        private DevExpress.XtraGrid.Columns.GridColumn temperature;
        private DevExpress.XtraGrid.Columns.GridColumn nuclear;
        private DevExpress.XtraGrid.Columns.GridColumn nationality;
        private DevExpress.XtraGrid.Columns.GridColumn sex;
        private DevExpress.XtraGrid.Columns.GridColumn birth_date;
        private DevExpress.XtraGrid.Columns.GridColumn id_code;
        private DevExpress.XtraGrid.Columns.GridColumn issue_date;
        private DevExpress.XtraGrid.Columns.GridColumn expire_date;
        private System.Windows.Forms.Panel panel_query;
        private Component.PageUpControl pageUpControl_query;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Panel playButtonsPanel;
        private System.Windows.Forms.PictureBox searchVideoPlayWnd;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnFast;
        private System.Windows.Forms.Button btnSlow;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}