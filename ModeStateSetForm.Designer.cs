namespace zhuhai
{
    partial class ModeStateSetForm
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
            this.simpleButton_zizhu = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_close = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_shuaka = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_shenbao = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_fengbi = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_unlock = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_lock = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_restart = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_sleep = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_reset = new DevExpress.XtraEditors.SimpleButton();
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
            // simpleButton_zizhu
            // 
            this.simpleButton_zizhu.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_zizhu.Appearance.Options.UseFont = true;
            this.simpleButton_zizhu.Location = new System.Drawing.Point(109, 341);
            this.simpleButton_zizhu.Name = "simpleButton_zizhu";
            this.simpleButton_zizhu.Size = new System.Drawing.Size(91, 36);
            this.simpleButton_zizhu.TabIndex = 6;
            this.simpleButton_zizhu.Text = "自助通关";
            this.simpleButton_zizhu.Click += new System.EventHandler(this.simpleButton_zizhu_Click);
            // 
            // simpleButton_close
            // 
            this.simpleButton_close.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_close.Appearance.Options.UseFont = true;
            this.simpleButton_close.Location = new System.Drawing.Point(448, 455);
            this.simpleButton_close.Name = "simpleButton_close";
            this.simpleButton_close.Size = new System.Drawing.Size(91, 36);
            this.simpleButton_close.TabIndex = 7;
            this.simpleButton_close.Text = "关  闭";
            this.simpleButton_close.ToolTip = "关闭对话框";
            this.simpleButton_close.Click += new System.EventHandler(this.simpleButton_close_Click);
            // 
            // simpleButton_shuaka
            // 
            this.simpleButton_shuaka.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_shuaka.Appearance.Options.UseFont = true;
            this.simpleButton_shuaka.Location = new System.Drawing.Point(335, 341);
            this.simpleButton_shuaka.Name = "simpleButton_shuaka";
            this.simpleButton_shuaka.Size = new System.Drawing.Size(91, 36);
            this.simpleButton_shuaka.TabIndex = 8;
            this.simpleButton_shuaka.Text = "刷卡通关";
            this.simpleButton_shuaka.Click += new System.EventHandler(this.simpleButton_shuaka_Click);
            // 
            // simpleButton_shenbao
            // 
            this.simpleButton_shenbao.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_shenbao.Appearance.Options.UseFont = true;
            this.simpleButton_shenbao.Location = new System.Drawing.Point(561, 341);
            this.simpleButton_shenbao.Name = "simpleButton_shenbao";
            this.simpleButton_shenbao.Size = new System.Drawing.Size(91, 36);
            this.simpleButton_shenbao.TabIndex = 9;
            this.simpleButton_shenbao.Text = "申报通关";
            this.simpleButton_shenbao.Click += new System.EventHandler(this.simpleButton_shenbao_Click);
            // 
            // simpleButton_fengbi
            // 
            this.simpleButton_fengbi.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_fengbi.Appearance.Options.UseFont = true;
            this.simpleButton_fengbi.Location = new System.Drawing.Point(787, 341);
            this.simpleButton_fengbi.Name = "simpleButton_fengbi";
            this.simpleButton_fengbi.Size = new System.Drawing.Size(91, 36);
            this.simpleButton_fengbi.TabIndex = 10;
            this.simpleButton_fengbi.Text = "封闭通关";
            this.simpleButton_fengbi.Click += new System.EventHandler(this.simpleButton_fengbi_Click);
            // 
            // simpleButton_unlock
            // 
            this.simpleButton_unlock.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_unlock.Appearance.Options.UseFont = true;
            this.simpleButton_unlock.Location = new System.Drawing.Point(787, 408);
            this.simpleButton_unlock.Name = "simpleButton_unlock";
            this.simpleButton_unlock.Size = new System.Drawing.Size(91, 36);
            this.simpleButton_unlock.TabIndex = 14;
            this.simpleButton_unlock.Text = "闸机解锁";
            this.simpleButton_unlock.Visible = false;
            this.simpleButton_unlock.Click += new System.EventHandler(this.simpleButton_unlock_Click);
            // 
            // simpleButton_lock
            // 
            this.simpleButton_lock.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_lock.Appearance.Options.UseFont = true;
            this.simpleButton_lock.Location = new System.Drawing.Point(690, 408);
            this.simpleButton_lock.Name = "simpleButton_lock";
            this.simpleButton_lock.Size = new System.Drawing.Size(91, 36);
            this.simpleButton_lock.TabIndex = 13;
            this.simpleButton_lock.Text = "闸机锁定";
            this.simpleButton_lock.Visible = false;
            this.simpleButton_lock.Click += new System.EventHandler(this.simpleButton_lock_Click);
            // 
            // simpleButton_restart
            // 
            this.simpleButton_restart.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_restart.Appearance.Options.UseFont = true;
            this.simpleButton_restart.Location = new System.Drawing.Point(335, 408);
            this.simpleButton_restart.Name = "simpleButton_restart";
            this.simpleButton_restart.Size = new System.Drawing.Size(91, 36);
            this.simpleButton_restart.TabIndex = 12;
            this.simpleButton_restart.Text = "闸机重启";
            this.simpleButton_restart.Click += new System.EventHandler(this.simpleButton_restart_Click);
            // 
            // simpleButton_sleep
            // 
            this.simpleButton_sleep.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_sleep.Appearance.Options.UseFont = true;
            this.simpleButton_sleep.Location = new System.Drawing.Point(109, 408);
            this.simpleButton_sleep.Name = "simpleButton_sleep";
            this.simpleButton_sleep.Size = new System.Drawing.Size(91, 36);
            this.simpleButton_sleep.TabIndex = 11;
            this.simpleButton_sleep.Text = "闸机休眠";
            this.simpleButton_sleep.Visible = false;
            this.simpleButton_sleep.Click += new System.EventHandler(this.simpleButton_sleep_Click);
            // 
            // simpleButton_reset
            // 
            this.simpleButton_reset.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_reset.Appearance.Options.UseFont = true;
            this.simpleButton_reset.Location = new System.Drawing.Point(561, 408);
            this.simpleButton_reset.Name = "simpleButton_reset";
            this.simpleButton_reset.Size = new System.Drawing.Size(91, 36);
            this.simpleButton_reset.TabIndex = 15;
            this.simpleButton_reset.Text = "闸机复位";
            this.simpleButton_reset.Click += new System.EventHandler(this.simpleButton_reset_Click);
            // 
            // ModeStateSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 503);
            this.Controls.Add(this.simpleButton_reset);
            this.Controls.Add(this.simpleButton_unlock);
            this.Controls.Add(this.simpleButton_lock);
            this.Controls.Add(this.simpleButton_restart);
            this.Controls.Add(this.simpleButton_sleep);
            this.Controls.Add(this.simpleButton_fengbi);
            this.Controls.Add(this.simpleButton_shenbao);
            this.Controls.Add(this.simpleButton_shuaka);
            this.Controls.Add(this.simpleButton_close);
            this.Controls.Add(this.simpleButton_zizhu);
            this.Controls.Add(this.simpleButton_cancelChecked);
            this.Controls.Add(this.simpleButton_allChecked);
            this.Controls.Add(this.checkedListBoxControl_gate);
            this.Controls.Add(this.labelControl_gate);
            this.Name = "ModeStateSetForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "闸机模式状态设置";
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl_gate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl_gate;
        private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControl_gate;
        private DevExpress.XtraEditors.SimpleButton simpleButton_allChecked;
        private DevExpress.XtraEditors.SimpleButton simpleButton_cancelChecked;
        private DevExpress.XtraEditors.SimpleButton simpleButton_zizhu;
        private DevExpress.XtraEditors.SimpleButton simpleButton_close;
        private DevExpress.XtraEditors.SimpleButton simpleButton_shuaka;
        private DevExpress.XtraEditors.SimpleButton simpleButton_shenbao;
        private DevExpress.XtraEditors.SimpleButton simpleButton_fengbi;
        private DevExpress.XtraEditors.SimpleButton simpleButton_unlock;
        private DevExpress.XtraEditors.SimpleButton simpleButton_lock;
        private DevExpress.XtraEditors.SimpleButton simpleButton_restart;
        private DevExpress.XtraEditors.SimpleButton simpleButton_sleep;
        private DevExpress.XtraEditors.SimpleButton simpleButton_reset;
    }
}