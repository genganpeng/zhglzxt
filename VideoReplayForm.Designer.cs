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
            this.comboBox__channel = new System.Windows.Forms.ComboBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dateTimePicker_endTime_time = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_startTime_time = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_endTime = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_startTime = new System.Windows.Forms.DateTimePicker();
            this.labelControl_endTime = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_startTime = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton_view = new DevExpress.XtraEditors.SimpleButton();
            this.panel_query = new System.Windows.Forms.Panel();
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
            this.panel_query.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchVideoPlayWnd)).BeginInit();
            this.playButtonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl
            // 
            this.groupControl.Controls.Add(this.comboBox__channel);
            this.groupControl.Controls.Add(this.labelControl1);
            this.groupControl.Controls.Add(this.dateTimePicker_endTime_time);
            this.groupControl.Controls.Add(this.dateTimePicker_startTime_time);
            this.groupControl.Controls.Add(this.dateTimePicker_endTime);
            this.groupControl.Controls.Add(this.dateTimePicker_startTime);
            this.groupControl.Controls.Add(this.labelControl_endTime);
            this.groupControl.Controls.Add(this.labelControl_startTime);
            this.groupControl.Controls.Add(this.simpleButton_view);
            this.groupControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl.Location = new System.Drawing.Point(0, 0);
            this.groupControl.Name = "groupControl";
            this.groupControl.Size = new System.Drawing.Size(757, 111);
            this.groupControl.TabIndex = 0;
            this.groupControl.Text = "查询条件";
            // 
            // comboBox__channel
            // 
            this.comboBox__channel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox__channel.FormattingEnabled = true;
            this.comboBox__channel.Location = new System.Drawing.Point(92, 68);
            this.comboBox__channel.Name = "comboBox__channel";
            this.comboBox__channel.Size = new System.Drawing.Size(145, 29);
            this.comboBox__channel.TabIndex = 16;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(42, 71);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 21);
            this.labelControl1.TabIndex = 24;
            this.labelControl1.Text = "通道：";
            // 
            // dateTimePicker_endTime_time
            // 
            this.dateTimePicker_endTime_time.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker_endTime_time.Location = new System.Drawing.Point(566, 35);
            this.dateTimePicker_endTime_time.Name = "dateTimePicker_endTime_time";
            this.dateTimePicker_endTime_time.ShowUpDown = true;
            this.dateTimePicker_endTime_time.Size = new System.Drawing.Size(76, 21);
            this.dateTimePicker_endTime_time.TabIndex = 23;
            // 
            // dateTimePicker_startTime_time
            // 
            this.dateTimePicker_startTime_time.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker_startTime_time.Location = new System.Drawing.Point(202, 35);
            this.dateTimePicker_startTime_time.Name = "dateTimePicker_startTime_time";
            this.dateTimePicker_startTime_time.ShowUpDown = true;
            this.dateTimePicker_startTime_time.Size = new System.Drawing.Size(76, 21);
            this.dateTimePicker_startTime_time.TabIndex = 22;
            // 
            // dateTimePicker_endTime
            // 
            this.dateTimePicker_endTime.CalendarFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker_endTime.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker_endTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_endTime.Location = new System.Drawing.Point(459, 35);
            this.dateTimePicker_endTime.Name = "dateTimePicker_endTime";
            this.dateTimePicker_endTime.Size = new System.Drawing.Size(99, 21);
            this.dateTimePicker_endTime.TabIndex = 21;
            // 
            // dateTimePicker_startTime
            // 
            this.dateTimePicker_startTime.CalendarFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker_startTime.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker_startTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_startTime.Location = new System.Drawing.Point(92, 35);
            this.dateTimePicker_startTime.Name = "dateTimePicker_startTime";
            this.dateTimePicker_startTime.Size = new System.Drawing.Size(103, 21);
            this.dateTimePicker_startTime.TabIndex = 20;
            // 
            // labelControl_endTime
            // 
            this.labelControl_endTime.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_endTime.Location = new System.Drawing.Point(373, 35);
            this.labelControl_endTime.Name = "labelControl_endTime";
            this.labelControl_endTime.Size = new System.Drawing.Size(80, 21);
            this.labelControl_endTime.TabIndex = 19;
            this.labelControl_endTime.Text = "结束时间：";
            // 
            // labelControl_startTime
            // 
            this.labelControl_startTime.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_startTime.Location = new System.Drawing.Point(10, 35);
            this.labelControl_startTime.Name = "labelControl_startTime";
            this.labelControl_startTime.Size = new System.Drawing.Size(80, 21);
            this.labelControl_startTime.TabIndex = 18;
            this.labelControl_startTime.Text = "开始时间：";
            // 
            // simpleButton_view
            // 
            this.simpleButton_view.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_view.Appearance.Options.UseFont = true;
            this.simpleButton_view.Location = new System.Drawing.Point(531, 71);
            this.simpleButton_view.Name = "simpleButton_view";
            this.simpleButton_view.Size = new System.Drawing.Size(111, 29);
            this.simpleButton_view.TabIndex = 15;
            this.simpleButton_view.Text = "查  看";
            this.simpleButton_view.Click += new System.EventHandler(this.simpleButton_view_Click);
            // 
            // panel_query
            // 
            this.panel_query.Controls.Add(this.groupBox6);
            this.panel_query.Controls.Add(this.groupControl);
            this.panel_query.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_query.Location = new System.Drawing.Point(0, 0);
            this.panel_query.Name = "panel_query";
            this.panel_query.Size = new System.Drawing.Size(757, 739);
            this.panel_query.TabIndex = 15;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.searchVideoPlayWnd);
            this.groupBox6.Controls.Add(this.playButtonsPanel);
            this.groupBox6.Location = new System.Drawing.Point(3, 117);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(757, 623);
            this.groupBox6.TabIndex = 16;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "视频回放";
            // 
            // searchVideoPlayWnd
            // 
            this.searchVideoPlayWnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchVideoPlayWnd.Location = new System.Drawing.Point(3, 17);
            this.searchVideoPlayWnd.Name = "searchVideoPlayWnd";
            this.searchVideoPlayWnd.Size = new System.Drawing.Size(751, 533);
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
            this.playButtonsPanel.Location = new System.Drawing.Point(3, 550);
            this.playButtonsPanel.Name = "playButtonsPanel";
            this.playButtonsPanel.Size = new System.Drawing.Size(751, 70);
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
            this.btnPlay.Location = new System.Drawing.Point(187, 9);
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
            this.btnStop.Location = new System.Drawing.Point(267, 9);
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
            this.btnFast.Location = new System.Drawing.Point(347, 9);
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
            this.btnSlow.Location = new System.Drawing.Point(17, 9);
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
            this.btnPause.Location = new System.Drawing.Point(104, 9);
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
            this.ClientSize = new System.Drawing.Size(758, 739);
            this.Controls.Add(this.panel_query);
            this.Name = "VideoReplayForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "通关记录查询";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VideoReplayForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl)).EndInit();
            this.groupControl.ResumeLayout(false);
            this.groupControl.PerformLayout();
            this.panel_query.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchVideoPlayWnd)).EndInit();
            this.playButtonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl;
        private System.Windows.Forms.Panel panel_query;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Panel playButtonsPanel;
        private System.Windows.Forms.PictureBox searchVideoPlayWnd;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnFast;
        private System.Windows.Forms.Button btnSlow;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private DevExpress.XtraEditors.SimpleButton simpleButton_view;
        private System.Windows.Forms.DateTimePicker dateTimePicker_endTime_time;
        private System.Windows.Forms.DateTimePicker dateTimePicker_startTime_time;
        private System.Windows.Forms.DateTimePicker dateTimePicker_endTime;
        private System.Windows.Forms.DateTimePicker dateTimePicker_startTime;
        private DevExpress.XtraEditors.LabelControl labelControl_endTime;
        private DevExpress.XtraEditors.LabelControl labelControl_startTime;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.ComboBox comboBox__channel;
    }
}