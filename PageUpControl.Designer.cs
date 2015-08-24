namespace zhuhai.Component  
{
    partial class PageUpControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nvgtDataPager = new DevExpress.XtraEditors.DataNavigator();
            this.SuspendLayout();
            // 
            // nvgtDataPager
            // 
            this.nvgtDataPager.Buttons.Append.Visible = false;
            this.nvgtDataPager.Buttons.CancelEdit.Visible = false;
            this.nvgtDataPager.Buttons.EndEdit.Visible = false;
            this.nvgtDataPager.Buttons.First.Hint = "首页";
            this.nvgtDataPager.Buttons.First.Visible = false;
            this.nvgtDataPager.Buttons.Last.Hint = "末页";
            this.nvgtDataPager.Buttons.Last.Visible = false;
            this.nvgtDataPager.Buttons.Next.Visible = false;
            this.nvgtDataPager.Buttons.NextPage.Hint = "下一页";
            this.nvgtDataPager.Buttons.NextPage.Visible = false;
            this.nvgtDataPager.Buttons.Prev.Visible = false;
            this.nvgtDataPager.Buttons.PrevPage.Hint = "上一页";
            this.nvgtDataPager.Buttons.PrevPage.Visible = false;
            this.nvgtDataPager.Buttons.Remove.Visible = false;
            this.nvgtDataPager.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, 0, true, true, "首页", "首页"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, 1, true, true, "上一页", "上一页"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, 4, true, true, "下一页", "下一页"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, 5, true, true, "末页", "末页")});
            this.nvgtDataPager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nvgtDataPager.Location = new System.Drawing.Point(0, 0);
            this.nvgtDataPager.Margin = new System.Windows.Forms.Padding(300, 3, 300, 3);
            this.nvgtDataPager.Name = "nvgtDataPager";
            this.nvgtDataPager.ShowToolTips = true;
            this.nvgtDataPager.Size = new System.Drawing.Size(800, 42);
            this.nvgtDataPager.TabIndex = 18;
            this.nvgtDataPager.Text = "dataNavigator";
            this.nvgtDataPager.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.Center;
            this.nvgtDataPager.TextStringFormat = "第 {0} 页 ,共 {1} 页";
            this.nvgtDataPager.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.nvgtDataPager_ButtonClick_1);
            // 
            // PageUpControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nvgtDataPager);
            this.Name = "PageUpControl";
            this.Size = new System.Drawing.Size(800, 42);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DataNavigator nvgtDataPager;
    }
}
