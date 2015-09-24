namespace zhuhai
{
    partial class ClearanceVideoReplayForm
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
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.searchVideoPlayWnd = new System.Windows.Forms.PictureBox();
            this.playButtonsPanel = new System.Windows.Forms.Panel();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnFast = new System.Windows.Forms.Button();
            this.btnSlow = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchVideoPlayWnd)).BeginInit();
            this.playButtonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.searchVideoPlayWnd);
            this.groupBox6.Controls.Add(this.playButtonsPanel);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(0, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(592, 527);
            this.groupBox6.TabIndex = 16;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "视频回放";
            // 
            // searchVideoPlayWnd
            // 
            this.searchVideoPlayWnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchVideoPlayWnd.Location = new System.Drawing.Point(3, 17);
            this.searchVideoPlayWnd.Name = "searchVideoPlayWnd";
            this.searchVideoPlayWnd.Size = new System.Drawing.Size(586, 437);
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
            this.playButtonsPanel.Size = new System.Drawing.Size(586, 70);
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
            // ClearanceVideoReplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 527);
            this.Controls.Add(this.groupBox6);
            this.Name = "ClearanceVideoReplayForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "通关视频回放";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VideoReplayForm_FormClosed);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchVideoPlayWnd)).EndInit();
            this.playButtonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Panel playButtonsPanel;
        private System.Windows.Forms.PictureBox searchVideoPlayWnd;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnFast;
        private System.Windows.Forms.Button btnSlow;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
    }
}