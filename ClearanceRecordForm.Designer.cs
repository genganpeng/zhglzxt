namespace zhuhai
{
    partial class ClearanceRecordForm
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
            this.simpleButton_view = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_query = new DevExpress.XtraEditors.SimpleButton();
            this.comboBox__channel = new System.Windows.Forms.ComboBox();
            this.labelControl_channel = new DevExpress.XtraEditors.LabelControl();
            this.comboBox_abnormal = new System.Windows.Forms.ComboBox();
            this.labelControl_abnormal = new DevExpress.XtraEditors.LabelControl();
            this.dateTimePicker_endTime = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_startTime = new System.Windows.Forms.DateTimePicker();
            this.labelControl_endTime = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_startTime = new DevExpress.XtraEditors.LabelControl();
            this.comboBox_sex = new System.Windows.Forms.ComboBox();
            this.labelControl_sex = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_country = new DevExpress.XtraEditors.TextEdit();
            this.labelControl__country = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_name = new DevExpress.XtraEditors.TextEdit();
            this.labelControl_name = new DevExpress.XtraEditors.LabelControl();
            this.pageUpControl_query = new zhuhai.Component.PageUpControl();
            this.gridControl_query = new DevExpress.XtraGrid.GridControl();
            this.gridView_query = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_query)).BeginInit();
            this.groupControl_query.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_country.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_query)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_query)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl_query
            // 
            this.groupControl_query.Controls.Add(this.simpleButton_view);
            this.groupControl_query.Controls.Add(this.simpleButton_query);
            this.groupControl_query.Controls.Add(this.comboBox__channel);
            this.groupControl_query.Controls.Add(this.labelControl_channel);
            this.groupControl_query.Controls.Add(this.comboBox_abnormal);
            this.groupControl_query.Controls.Add(this.labelControl_abnormal);
            this.groupControl_query.Controls.Add(this.dateTimePicker_endTime);
            this.groupControl_query.Controls.Add(this.dateTimePicker_startTime);
            this.groupControl_query.Controls.Add(this.labelControl_endTime);
            this.groupControl_query.Controls.Add(this.labelControl_startTime);
            this.groupControl_query.Controls.Add(this.comboBox_sex);
            this.groupControl_query.Controls.Add(this.labelControl_sex);
            this.groupControl_query.Controls.Add(this.textEdit_country);
            this.groupControl_query.Controls.Add(this.labelControl__country);
            this.groupControl_query.Controls.Add(this.textEdit_name);
            this.groupControl_query.Controls.Add(this.labelControl_name);
            this.groupControl_query.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl_query.Location = new System.Drawing.Point(0, 0);
            this.groupControl_query.Name = "groupControl_query";
            this.groupControl_query.Size = new System.Drawing.Size(1292, 110);
            this.groupControl_query.TabIndex = 0;
            this.groupControl_query.Text = "查询条件";
            // 
            // simpleButton_view
            // 
            this.simpleButton_view.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_view.Appearance.Options.UseFont = true;
            this.simpleButton_view.Location = new System.Drawing.Point(1128, 67);
            this.simpleButton_view.Name = "simpleButton_view";
            this.simpleButton_view.Size = new System.Drawing.Size(111, 29);
            this.simpleButton_view.TabIndex = 15;
            this.simpleButton_view.Text = "查  看";
            this.simpleButton_view.Click += new System.EventHandler(this.simpleButton_view_Click);
            // 
            // simpleButton_query
            // 
            this.simpleButton_query.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_query.Appearance.Options.UseFont = true;
            this.simpleButton_query.Location = new System.Drawing.Point(965, 67);
            this.simpleButton_query.Name = "simpleButton_query";
            this.simpleButton_query.Size = new System.Drawing.Size(111, 29);
            this.simpleButton_query.TabIndex = 14;
            this.simpleButton_query.Text = "查  询";
            this.simpleButton_query.Click += new System.EventHandler(this.simpleButton_query_Click);
            // 
            // comboBox__channel
            // 
            this.comboBox__channel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox__channel.FormattingEnabled = true;
            this.comboBox__channel.Location = new System.Drawing.Point(820, 24);
            this.comboBox__channel.Name = "comboBox__channel";
            this.comboBox__channel.Size = new System.Drawing.Size(145, 29);
            this.comboBox__channel.TabIndex = 13;
            // 
            // labelControl_channel
            // 
            this.labelControl_channel.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_channel.Location = new System.Drawing.Point(766, 27);
            this.labelControl_channel.Name = "labelControl_channel";
            this.labelControl_channel.Size = new System.Drawing.Size(48, 21);
            this.labelControl_channel.TabIndex = 12;
            this.labelControl_channel.Text = "通道：";
            // 
            // comboBox_abnormal
            // 
            this.comboBox_abnormal.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_abnormal.FormattingEnabled = true;
            this.comboBox_abnormal.Location = new System.Drawing.Point(1108, 25);
            this.comboBox_abnormal.Name = "comboBox_abnormal";
            this.comboBox_abnormal.Size = new System.Drawing.Size(145, 29);
            this.comboBox_abnormal.TabIndex = 11;
            // 
            // labelControl_abnormal
            // 
            this.labelControl_abnormal.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_abnormal.Location = new System.Drawing.Point(1010, 28);
            this.labelControl_abnormal.Name = "labelControl_abnormal";
            this.labelControl_abnormal.Size = new System.Drawing.Size(80, 21);
            this.labelControl_abnormal.TabIndex = 10;
            this.labelControl_abnormal.Text = "异常类型：";
            // 
            // dateTimePicker_endTime
            // 
            this.dateTimePicker_endTime.CalendarFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker_endTime.CustomFormat = "yyyy年M月d日";
            this.dateTimePicker_endTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_endTime.Location = new System.Drawing.Point(340, 67);
            this.dateTimePicker_endTime.Name = "dateTimePicker_endTime";
            this.dateTimePicker_endTime.Size = new System.Drawing.Size(133, 21);
            this.dateTimePicker_endTime.TabIndex = 9;
            // 
            // dateTimePicker_startTime
            // 
            this.dateTimePicker_startTime.CalendarFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker_startTime.CustomFormat = "yyyy年M月d日";
            this.dateTimePicker_startTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_startTime.Location = new System.Drawing.Point(94, 66);
            this.dateTimePicker_startTime.Name = "dateTimePicker_startTime";
            this.dateTimePicker_startTime.Size = new System.Drawing.Size(145, 21);
            this.dateTimePicker_startTime.TabIndex = 8;
            // 
            // labelControl_endTime
            // 
            this.labelControl_endTime.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_endTime.Location = new System.Drawing.Point(254, 67);
            this.labelControl_endTime.Name = "labelControl_endTime";
            this.labelControl_endTime.Size = new System.Drawing.Size(80, 21);
            this.labelControl_endTime.TabIndex = 7;
            this.labelControl_endTime.Text = "结束时间：";
            // 
            // labelControl_startTime
            // 
            this.labelControl_startTime.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_startTime.Location = new System.Drawing.Point(12, 67);
            this.labelControl_startTime.Name = "labelControl_startTime";
            this.labelControl_startTime.Size = new System.Drawing.Size(80, 21);
            this.labelControl_startTime.TabIndex = 6;
            this.labelControl_startTime.Text = "开始时间：";
            // 
            // comboBox_sex
            // 
            this.comboBox_sex.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_sex.FormattingEnabled = true;
            this.comboBox_sex.Items.AddRange(new object[] {
            "全部",
            "男",
            "女"});
            this.comboBox_sex.Location = new System.Drawing.Point(596, 22);
            this.comboBox_sex.Name = "comboBox_sex";
            this.comboBox_sex.Size = new System.Drawing.Size(145, 29);
            this.comboBox_sex.TabIndex = 5;
            // 
            // labelControl_sex
            // 
            this.labelControl_sex.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_sex.Location = new System.Drawing.Point(530, 28);
            this.labelControl_sex.Name = "labelControl_sex";
            this.labelControl_sex.Size = new System.Drawing.Size(48, 21);
            this.labelControl_sex.TabIndex = 4;
            this.labelControl_sex.Text = "性别：";
            // 
            // textEdit_country
            // 
            this.textEdit_country.Location = new System.Drawing.Point(340, 25);
            this.textEdit_country.Name = "textEdit_country";
            this.textEdit_country.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_country.Properties.Appearance.Options.UseFont = true;
            this.textEdit_country.Size = new System.Drawing.Size(133, 28);
            this.textEdit_country.TabIndex = 3;
            // 
            // labelControl__country
            // 
            this.labelControl__country.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl__country.Location = new System.Drawing.Point(286, 28);
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
            this.pageUpControl_query.Size = new System.Drawing.Size(1292, 42);
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
            this.gridControl_query.Size = new System.Drawing.Size(1292, 375);
            this.gridControl_query.TabIndex = 2;
            this.gridControl_query.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_query});
            // 
            // gridView_query
            // 
            this.gridView_query.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
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
            this.gridView_query.GridControl = this.gridControl_query;
            this.gridView_query.Name = "gridView_query";
            this.gridView_query.OptionsSelection.MultiSelect = true;
            this.gridView_query.OptionsView.ShowGroupPanel = false;
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
            // ClearanceRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 527);
            this.Controls.Add(this.gridControl_query);
            this.Controls.Add(this.pageUpControl_query);
            this.Controls.Add(this.groupControl_query);
            this.Name = "ClearanceRecordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "通关记录查询";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_query)).EndInit();
            this.groupControl_query.ResumeLayout(false);
            this.groupControl_query.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_country.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_query)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_query)).EndInit();
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
        private DevExpress.XtraEditors.LabelControl labelControl_startTime;
        private DevExpress.XtraEditors.LabelControl labelControl_endTime;
        private System.Windows.Forms.DateTimePicker dateTimePicker_startTime;
        private System.Windows.Forms.DateTimePicker dateTimePicker_endTime;
        private DevExpress.XtraEditors.LabelControl labelControl_abnormal;
        private System.Windows.Forms.ComboBox comboBox_abnormal;
        private System.Windows.Forms.ComboBox comboBox__channel;
        private DevExpress.XtraEditors.LabelControl labelControl_channel;
        private DevExpress.XtraEditors.SimpleButton simpleButton_query;
        private DevExpress.XtraEditors.SimpleButton simpleButton_view;
        private Component.PageUpControl pageUpControl_query;
        private DevExpress.XtraGrid.GridControl gridControl_query;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_query;
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
    }
}