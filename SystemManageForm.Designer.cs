namespace zhuhai
{
    partial class SystemManageForm
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
            this.simpleButton_delete = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_modify = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_add = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_reset = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_query = new DevExpress.XtraEditors.SimpleButton();
            this.comboBoxEdit_type = new DevExpress.XtraEditors.ComboBoxEdit();
            this.textEdit_IDCard = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_name = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_userName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl_IDCard = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_name = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_type = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pageUpControl = new zhuhai.Component.PageUpControl();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.UserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Password = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PeopleName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IdCard = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl)).BeginInit();
            this.groupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_type.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_IDCard.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_userName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl
            // 
            this.groupControl.Controls.Add(this.simpleButton_delete);
            this.groupControl.Controls.Add(this.simpleButton_modify);
            this.groupControl.Controls.Add(this.simpleButton_add);
            this.groupControl.Controls.Add(this.simpleButton_reset);
            this.groupControl.Controls.Add(this.simpleButton_query);
            this.groupControl.Controls.Add(this.comboBoxEdit_type);
            this.groupControl.Controls.Add(this.textEdit_IDCard);
            this.groupControl.Controls.Add(this.textEdit_name);
            this.groupControl.Controls.Add(this.textEdit_userName);
            this.groupControl.Controls.Add(this.labelControl_IDCard);
            this.groupControl.Controls.Add(this.labelControl_name);
            this.groupControl.Controls.Add(this.labelControl_type);
            this.groupControl.Controls.Add(this.labelControl1);
            this.groupControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl.Location = new System.Drawing.Point(0, 0);
            this.groupControl.Name = "groupControl";
            this.groupControl.Size = new System.Drawing.Size(979, 87);
            this.groupControl.TabIndex = 0;
            this.groupControl.Text = "查询条件";
            // 
            // simpleButton_delete
            // 
            this.simpleButton_delete.Location = new System.Drawing.Point(896, 58);
            this.simpleButton_delete.Name = "simpleButton_delete";
            this.simpleButton_delete.Size = new System.Drawing.Size(83, 23);
            this.simpleButton_delete.TabIndex = 12;
            this.simpleButton_delete.Text = "删  除";
            this.simpleButton_delete.Click += new System.EventHandler(this.simpleButton_delete_Click);
            // 
            // simpleButton_modify
            // 
            this.simpleButton_modify.Location = new System.Drawing.Point(805, 58);
            this.simpleButton_modify.Name = "simpleButton_modify";
            this.simpleButton_modify.Size = new System.Drawing.Size(83, 23);
            this.simpleButton_modify.TabIndex = 11;
            this.simpleButton_modify.Text = "修  改";
            this.simpleButton_modify.Click += new System.EventHandler(this.simpleButton_modify_Click);
            // 
            // simpleButton_add
            // 
            this.simpleButton_add.Location = new System.Drawing.Point(714, 59);
            this.simpleButton_add.Name = "simpleButton_add";
            this.simpleButton_add.Size = new System.Drawing.Size(83, 23);
            this.simpleButton_add.TabIndex = 10;
            this.simpleButton_add.Text = "增  加";
            this.simpleButton_add.Click += new System.EventHandler(this.simpleButton_add_Click);
            // 
            // simpleButton_reset
            // 
            this.simpleButton_reset.Location = new System.Drawing.Point(623, 59);
            this.simpleButton_reset.Name = "simpleButton_reset";
            this.simpleButton_reset.Size = new System.Drawing.Size(83, 23);
            this.simpleButton_reset.TabIndex = 9;
            this.simpleButton_reset.Text = "重  置";
            this.simpleButton_reset.Click += new System.EventHandler(this.simpleButton_reset_Click);
            // 
            // simpleButton_query
            // 
            this.simpleButton_query.Location = new System.Drawing.Point(532, 58);
            this.simpleButton_query.Name = "simpleButton_query";
            this.simpleButton_query.Size = new System.Drawing.Size(83, 23);
            this.simpleButton_query.TabIndex = 8;
            this.simpleButton_query.Text = "查   询";
            this.simpleButton_query.Click += new System.EventHandler(this.simpleButton_query_Click);
            // 
            // comboBoxEdit_type
            // 
            this.comboBoxEdit_type.Location = new System.Drawing.Point(282, 28);
            this.comboBoxEdit_type.Name = "comboBoxEdit_type";
            this.comboBoxEdit_type.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_type.Size = new System.Drawing.Size(158, 20);
            this.comboBoxEdit_type.TabIndex = 7;
            // 
            // textEdit_IDCard
            // 
            this.textEdit_IDCard.Location = new System.Drawing.Point(727, 28);
            this.textEdit_IDCard.Name = "textEdit_IDCard";
            this.textEdit_IDCard.Size = new System.Drawing.Size(229, 20);
            this.textEdit_IDCard.TabIndex = 6;
            // 
            // textEdit_name
            // 
            this.textEdit_name.Location = new System.Drawing.Point(510, 28);
            this.textEdit_name.Name = "textEdit_name";
            this.textEdit_name.Size = new System.Drawing.Size(143, 20);
            this.textEdit_name.TabIndex = 5;
            // 
            // textEdit_userName
            // 
            this.textEdit_userName.Location = new System.Drawing.Point(68, 28);
            this.textEdit_userName.Name = "textEdit_userName";
            this.textEdit_userName.Size = new System.Drawing.Size(143, 20);
            this.textEdit_userName.TabIndex = 4;
            // 
            // labelControl_IDCard
            // 
            this.labelControl_IDCard.Location = new System.Drawing.Point(673, 31);
            this.labelControl_IDCard.Name = "labelControl_IDCard";
            this.labelControl_IDCard.Size = new System.Drawing.Size(48, 14);
            this.labelControl_IDCard.TabIndex = 3;
            this.labelControl_IDCard.Text = "证件号：";
            // 
            // labelControl_name
            // 
            this.labelControl_name.Location = new System.Drawing.Point(468, 31);
            this.labelControl_name.Name = "labelControl_name";
            this.labelControl_name.Size = new System.Drawing.Size(36, 14);
            this.labelControl_name.TabIndex = 2;
            this.labelControl_name.Text = "姓名：";
            // 
            // labelControl_type
            // 
            this.labelControl_type.Location = new System.Drawing.Point(227, 31);
            this.labelControl_type.Name = "labelControl_type";
            this.labelControl_type.Size = new System.Drawing.Size(36, 14);
            this.labelControl_type.TabIndex = 1;
            this.labelControl_type.Text = "类别：";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 31);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "用户名：";
            // 
            // pageUpControl
            // 
            this.pageUpControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pageUpControl.Location = new System.Drawing.Point(0, 413);
            this.pageUpControl.MyControl = null;
            this.pageUpControl.Name = "pageUpControl";
            this.pageUpControl.PageIndex = 0;
            this.pageUpControl.PageRow = 0;
            this.pageUpControl.Pagesize = 0;
            this.pageUpControl.QueryService = null;
            this.pageUpControl.Size = new System.Drawing.Size(979, 36);
            this.pageUpControl.StrWhere = null;
            this.pageUpControl.TabIndex = 1;
            // 
            // gridControl
            // 
            this.gridControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 87);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(979, 326);
            this.gridControl.TabIndex = 2;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.UserName,
            this.Password,
            this.Type,
            this.PeopleName,
            this.IdCard});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsSelection.MultiSelect = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            // 
            // UserName
            // 
            this.UserName.Caption = "用户名";
            this.UserName.FieldName = "UserName";
            this.UserName.Name = "UserName";
            this.UserName.OptionsColumn.AllowEdit = false;
            this.UserName.Visible = true;
            this.UserName.VisibleIndex = 0;
            // 
            // Password
            // 
            this.Password.Caption = "密码";
            this.Password.FieldName = "Password";
            this.Password.Name = "Password";
            this.Password.OptionsColumn.AllowEdit = false;
            this.Password.Visible = true;
            this.Password.VisibleIndex = 1;
            // 
            // Type
            // 
            this.Type.Caption = "类型";
            this.Type.FieldName = "TypeName";
            this.Type.Name = "Type";
            this.Type.OptionsColumn.AllowEdit = false;
            this.Type.Visible = true;
            this.Type.VisibleIndex = 2;
            // 
            // PeopleName
            // 
            this.PeopleName.Caption = "姓名";
            this.PeopleName.FieldName = "Name";
            this.PeopleName.Name = "PeopleName";
            this.PeopleName.OptionsColumn.AllowEdit = false;
            this.PeopleName.Visible = true;
            this.PeopleName.VisibleIndex = 3;
            // 
            // IdCard
            // 
            this.IdCard.Caption = "证件号";
            this.IdCard.FieldName = "IdCard";
            this.IdCard.Name = "IdCard";
            this.IdCard.OptionsColumn.AllowEdit = false;
            this.IdCard.Visible = true;
            this.IdCard.VisibleIndex = 4;
            // 
            // SystemManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 449);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.pageUpControl);
            this.Controls.Add(this.groupControl);
            this.Name = "SystemManageForm";
            this.Text = "系统管理";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl)).EndInit();
            this.groupControl.ResumeLayout(false);
            this.groupControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_type.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_IDCard.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_userName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl;
        private Component.PageUpControl pageUpControl;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl_type;
        private DevExpress.XtraEditors.LabelControl labelControl_IDCard;
        private DevExpress.XtraEditors.LabelControl labelControl_name;
        private DevExpress.XtraEditors.TextEdit textEdit_IDCard;
        private DevExpress.XtraEditors.TextEdit textEdit_name;
        private DevExpress.XtraEditors.TextEdit textEdit_userName;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_type;
        private DevExpress.XtraEditors.SimpleButton simpleButton_query;
        private DevExpress.XtraEditors.SimpleButton simpleButton_reset;
        private DevExpress.XtraGrid.Columns.GridColumn UserName;
        private DevExpress.XtraGrid.Columns.GridColumn Password;
        private DevExpress.XtraGrid.Columns.GridColumn Type;
        private DevExpress.XtraGrid.Columns.GridColumn PeopleName;
        private DevExpress.XtraGrid.Columns.GridColumn IdCard;
        private DevExpress.XtraEditors.SimpleButton simpleButton_delete;
        private DevExpress.XtraEditors.SimpleButton simpleButton_modify;
        private DevExpress.XtraEditors.SimpleButton simpleButton_add;



    }
}