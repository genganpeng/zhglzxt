namespace zhuhai
{
    partial class DisposePlanManageForm
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
            this.textEdit_title = new DevExpress.XtraEditors.TextEdit();
            this.labelControl_title = new DevExpress.XtraEditors.LabelControl();
            this.pageUpControl = new zhuhai.Component.PageUpControl();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Title = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButton_view = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl)).BeginInit();
            this.groupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_title.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl
            // 
            this.groupControl.Controls.Add(this.simpleButton_view);
            this.groupControl.Controls.Add(this.simpleButton_delete);
            this.groupControl.Controls.Add(this.simpleButton_modify);
            this.groupControl.Controls.Add(this.simpleButton_add);
            this.groupControl.Controls.Add(this.simpleButton_reset);
            this.groupControl.Controls.Add(this.simpleButton_query);
            this.groupControl.Controls.Add(this.textEdit_title);
            this.groupControl.Controls.Add(this.labelControl_title);
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
            // textEdit_title
            // 
            this.textEdit_title.Location = new System.Drawing.Point(68, 28);
            this.textEdit_title.Name = "textEdit_title";
            this.textEdit_title.Size = new System.Drawing.Size(329, 20);
            this.textEdit_title.TabIndex = 4;
            // 
            // labelControl_title
            // 
            this.labelControl_title.Location = new System.Drawing.Point(13, 31);
            this.labelControl_title.Name = "labelControl_title";
            this.labelControl_title.Size = new System.Drawing.Size(44, 14);
            this.labelControl_title.TabIndex = 0;
            this.labelControl_title.Text = "标  题：";
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
            this.Title});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsSelection.MultiSelect = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            // 
            // Title
            // 
            this.Title.Caption = "标题";
            this.Title.FieldName = "Title";
            this.Title.Name = "Title";
            this.Title.OptionsColumn.AllowEdit = false;
            this.Title.Visible = true;
            this.Title.VisibleIndex = 0;
            // 
            // simpleButton_view
            // 
            this.simpleButton_view.Location = new System.Drawing.Point(443, 58);
            this.simpleButton_view.Name = "simpleButton_view";
            this.simpleButton_view.Size = new System.Drawing.Size(83, 23);
            this.simpleButton_view.TabIndex = 13;
            this.simpleButton_view.Text = "查   看";
            this.simpleButton_view.Click += new System.EventHandler(this.simpleButton_view_Click);
            // 
            // DisposePlanManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 449);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.pageUpControl);
            this.Controls.Add(this.groupControl);
            this.Name = "DisposePlanManageForm";
            this.Text = "处置预案";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl)).EndInit();
            this.groupControl.ResumeLayout(false);
            this.groupControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_title.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl;
        private Component.PageUpControl pageUpControl;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraEditors.LabelControl labelControl_title;
        private DevExpress.XtraEditors.TextEdit textEdit_title;
        private DevExpress.XtraEditors.SimpleButton simpleButton_query;
        private DevExpress.XtraEditors.SimpleButton simpleButton_reset;
        private DevExpress.XtraGrid.Columns.GridColumn Title;
        private DevExpress.XtraEditors.SimpleButton simpleButton_delete;
        private DevExpress.XtraEditors.SimpleButton simpleButton_modify;
        private DevExpress.XtraEditors.SimpleButton simpleButton_add;
        private DevExpress.XtraEditors.SimpleButton simpleButton_view;



    }
}