namespace zhuhai
{
    partial class LogRecordForm
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
            this.dateTimePicker_endTime_time = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_startTime_time = new System.Windows.Forms.DateTimePicker();
            this.simpleButton_query = new DevExpress.XtraEditors.SimpleButton();
            this.dateTimePicker_endTime = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_startTime = new System.Windows.Forms.DateTimePicker();
            this.labelControl_endTime = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_startTime = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_name = new DevExpress.XtraEditors.TextEdit();
            this.labelControl_name = new DevExpress.XtraEditors.LabelControl();
            this.pageUpControl_query = new zhuhai.Component.PageUpControl();
            this.gridControl_query = new DevExpress.XtraGrid.GridControl();
            this.gridView_query = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.operateContent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.operateModule = new DevExpress.XtraGrid.Columns.GridColumn();
            this.operatePeople = new DevExpress.XtraGrid.Columns.GridColumn();
            this.operateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_query)).BeginInit();
            this.groupControl_query.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_query)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_query)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl_query
            // 
            this.groupControl_query.Controls.Add(this.dateTimePicker_endTime_time);
            this.groupControl_query.Controls.Add(this.dateTimePicker_startTime_time);
            this.groupControl_query.Controls.Add(this.simpleButton_query);
            this.groupControl_query.Controls.Add(this.dateTimePicker_endTime);
            this.groupControl_query.Controls.Add(this.dateTimePicker_startTime);
            this.groupControl_query.Controls.Add(this.labelControl_endTime);
            this.groupControl_query.Controls.Add(this.labelControl_startTime);
            this.groupControl_query.Controls.Add(this.textEdit_name);
            this.groupControl_query.Controls.Add(this.labelControl_name);
            this.groupControl_query.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl_query.Location = new System.Drawing.Point(0, 0);
            this.groupControl_query.Name = "groupControl_query";
            this.groupControl_query.Size = new System.Drawing.Size(902, 110);
            this.groupControl_query.TabIndex = 0;
            this.groupControl_query.Text = "查询条件";
            // 
            // dateTimePicker_endTime_time
            // 
            this.dateTimePicker_endTime_time.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker_endTime_time.Location = new System.Drawing.Point(757, 29);
            this.dateTimePicker_endTime_time.Name = "dateTimePicker_endTime_time";
            this.dateTimePicker_endTime_time.ShowUpDown = true;
            this.dateTimePicker_endTime_time.Size = new System.Drawing.Size(76, 21);
            this.dateTimePicker_endTime_time.TabIndex = 17;
            // 
            // dateTimePicker_startTime_time
            // 
            this.dateTimePicker_startTime_time.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker_startTime_time.Location = new System.Drawing.Point(459, 27);
            this.dateTimePicker_startTime_time.Name = "dateTimePicker_startTime_time";
            this.dateTimePicker_startTime_time.ShowUpDown = true;
            this.dateTimePicker_startTime_time.Size = new System.Drawing.Size(76, 21);
            this.dateTimePicker_startTime_time.TabIndex = 16;
            // 
            // simpleButton_query
            // 
            this.simpleButton_query.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_query.Appearance.Options.UseFont = true;
            this.simpleButton_query.Location = new System.Drawing.Point(739, 76);
            this.simpleButton_query.Name = "simpleButton_query";
            this.simpleButton_query.Size = new System.Drawing.Size(111, 29);
            this.simpleButton_query.TabIndex = 14;
            this.simpleButton_query.Text = "查  询";
            this.simpleButton_query.Click += new System.EventHandler(this.simpleButton_query_Click);
            // 
            // dateTimePicker_endTime
            // 
            this.dateTimePicker_endTime.CalendarFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker_endTime.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker_endTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_endTime.Location = new System.Drawing.Point(650, 28);
            this.dateTimePicker_endTime.Name = "dateTimePicker_endTime";
            this.dateTimePicker_endTime.Size = new System.Drawing.Size(99, 21);
            this.dateTimePicker_endTime.TabIndex = 9;
            // 
            // dateTimePicker_startTime
            // 
            this.dateTimePicker_startTime.CalendarFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker_startTime.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker_startTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_startTime.Location = new System.Drawing.Point(349, 27);
            this.dateTimePicker_startTime.Name = "dateTimePicker_startTime";
            this.dateTimePicker_startTime.Size = new System.Drawing.Size(103, 21);
            this.dateTimePicker_startTime.TabIndex = 8;
            // 
            // labelControl_endTime
            // 
            this.labelControl_endTime.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_endTime.Location = new System.Drawing.Point(564, 28);
            this.labelControl_endTime.Name = "labelControl_endTime";
            this.labelControl_endTime.Size = new System.Drawing.Size(80, 21);
            this.labelControl_endTime.TabIndex = 7;
            this.labelControl_endTime.Text = "结束时间：";
            // 
            // labelControl_startTime
            // 
            this.labelControl_startTime.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_startTime.Location = new System.Drawing.Point(267, 26);
            this.labelControl_startTime.Name = "labelControl_startTime";
            this.labelControl_startTime.Size = new System.Drawing.Size(80, 21);
            this.labelControl_startTime.TabIndex = 6;
            this.labelControl_startTime.Text = "开始时间：";
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
            this.labelControl_name.Location = new System.Drawing.Point(40, 28);
            this.labelControl_name.Name = "labelControl_name";
            this.labelControl_name.Size = new System.Drawing.Size(64, 21);
            this.labelControl_name.TabIndex = 0;
            this.labelControl_name.Text = "操作人：";
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
            this.pageUpControl_query.Size = new System.Drawing.Size(902, 42);
            this.pageUpControl_query.StrWhere = null;
            this.pageUpControl_query.TabIndex = 1;
            // 
            // gridControl_query
            // 
            this.gridControl_query.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_query.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_query.Location = new System.Drawing.Point(0, 110);
            this.gridControl_query.MainView = this.gridView_query;
            this.gridControl_query.Name = "gridControl_query";
            this.gridControl_query.Size = new System.Drawing.Size(902, 375);
            this.gridControl_query.TabIndex = 2;
            this.gridControl_query.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_query});
            // 
            // gridView_query
            // 
            this.gridView_query.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.operateContent,
            this.operateModule,
            this.operatePeople,
            this.operateTime});
            this.gridView_query.GridControl = this.gridControl_query;
            this.gridView_query.Name = "gridView_query";
            this.gridView_query.OptionsView.ShowGroupPanel = false;
            // 
            // operateContent
            // 
            this.operateContent.Caption = "操作内容";
            this.operateContent.FieldName = "operateContent";
            this.operateContent.Name = "operateContent";
            this.operateContent.OptionsColumn.AllowEdit = false;
            this.operateContent.Visible = true;
            this.operateContent.VisibleIndex = 0;
            // 
            // operateModule
            // 
            this.operateModule.Caption = "操作模块";
            this.operateModule.FieldName = "operateModule";
            this.operateModule.Name = "operateModule";
            this.operateModule.OptionsColumn.AllowEdit = false;
            this.operateModule.Visible = true;
            this.operateModule.VisibleIndex = 1;
            // 
            // operatePeople
            // 
            this.operatePeople.Caption = "操作人";
            this.operatePeople.FieldName = "operatePeople";
            this.operatePeople.Name = "operatePeople";
            this.operatePeople.OptionsColumn.AllowEdit = false;
            this.operatePeople.Visible = true;
            this.operatePeople.VisibleIndex = 2;
            // 
            // operateTime
            // 
            this.operateTime.Caption = "操作时间";
            this.operateTime.FieldName = "operateTime";
            this.operateTime.Name = "operateTime";
            this.operateTime.Visible = true;
            this.operateTime.VisibleIndex = 3;
            // 
            // LogRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 527);
            this.Controls.Add(this.gridControl_query);
            this.Controls.Add(this.pageUpControl_query);
            this.Controls.Add(this.groupControl_query);
            this.Name = "LogRecordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "日志查询";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_query)).EndInit();
            this.groupControl_query.ResumeLayout(false);
            this.groupControl_query.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_query)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_query)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl_query;
        private DevExpress.XtraEditors.LabelControl labelControl_name;
        private DevExpress.XtraEditors.TextEdit textEdit_name;
        private DevExpress.XtraEditors.LabelControl labelControl_startTime;
        private DevExpress.XtraEditors.LabelControl labelControl_endTime;
        private System.Windows.Forms.DateTimePicker dateTimePicker_startTime;
        private System.Windows.Forms.DateTimePicker dateTimePicker_endTime;
        private DevExpress.XtraEditors.SimpleButton simpleButton_query;
        private Component.PageUpControl pageUpControl_query;
        private System.Windows.Forms.DateTimePicker dateTimePicker_startTime_time;
        private System.Windows.Forms.DateTimePicker dateTimePicker_endTime_time;
        private DevExpress.XtraGrid.GridControl gridControl_query;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_query;
        private DevExpress.XtraGrid.Columns.GridColumn operateContent;
        private DevExpress.XtraGrid.Columns.GridColumn operateModule;
        private DevExpress.XtraGrid.Columns.GridColumn operatePeople;
        private DevExpress.XtraGrid.Columns.GridColumn operateTime;
    }
}