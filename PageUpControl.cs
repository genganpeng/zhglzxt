using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using zhuhai.service;

namespace zhuhai.Component  
{
    /// <summary>
    /// 使用方法
    /// 实现的service方法
    ///  SystemManageService smService = new SystemManageService();
    ///  表格控件
    ///  pageUpControl.MyControl = gridControl;
    ///  注册service
    ///  pageUpControl.QueryService = smService;
    ///  开始页码
    ///  pageUpControl.PageIndex = 1;
    ///  每页的条数
    ///  pageUpControl.Pagesize = 10;
    ///  获取数据
    ///  pageUpControl.GetDataTable();
    /// </summary>
    public partial class PageUpControl : DevExpress.XtraEditors.XtraUserControl
    {

        /// <summary>
        /// 查询的实现
        /// </summary>
        private IQueryService queryService;
        public IQueryService QueryService
        {
            get { return queryService; }
            set { queryService = value; }
        }

        public PageUpControl()
        {
            InitializeComponent();
            nvgtDataPager.Buttons.CustomButtons[0].Enabled = false;
            nvgtDataPager.Buttons.CustomButtons[1].Enabled = false;
            nvgtDataPager.Buttons.CustomButtons[2].Enabled = false;
            nvgtDataPager.Buttons.CustomButtons[3].Enabled = false;
            nvgtDataPager.TextStringFormat = string.Format("");
        }

        private GridControl myControl;
        public GridControl MyControl
        {
            get { return myControl; }
            set { myControl = value; }
        }

        private int pageIndex;
        /// <summary>
        /// 当前页数
        /// </summary>
        public int PageIndex
        {
            get { return pageIndex; }
            set { pageIndex = value; }
        }


        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount = 0;

        private int pagesize;
        /// <summary>
        /// 页行数
        /// </summary>
        public int Pagesize
        {
            get { return pagesize; }
            set { pagesize = value; }
        }

        /// <summary>
        /// 总行数
        /// </summary>
        private int pageRow;
        public int PageRow
        {
            get { return pageRow; }
            set { pageRow = value; }
        }

        private int startIndex;
        private int endIndex;

        public void GetDataTable()
        {
            BindPageGridList();

            DevExpress.XtraGrid.Views.Grid.GridView gv = (GridView)MyControl.Views[0];
            //查询为空提示
            gv.CustomDrawEmptyForeground += new DevExpress.XtraGrid.Views.Base.CustomDrawEventHandler(gv_CustomDrawEmptyForeground);
        }

        public void gv_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
        {
            string s = "";
            if (PageRow == 0)
            {
                s = "当前查询没有返回结果.";
                nvgtDataPager.Buttons.CustomButtons[0].Enabled = false;
                nvgtDataPager.Buttons.CustomButtons[1].Enabled = false;
                nvgtDataPager.Buttons.CustomButtons[2].Enabled = false;
                nvgtDataPager.Buttons.CustomButtons[3].Enabled = false;
                nvgtDataPager.TextStringFormat = string.Format("");
            }

            Font font = new Font("Tahoma", 10, FontStyle.Bold);
            Rectangle r = new Rectangle(e.Bounds.Left + 5, e.Bounds.Top + 5, e.Bounds.Width - 5,
              e.Bounds.Height - 5);
            e.Graphics.DrawString(s, font, Brushes.Black, r);
        }

        private void ShowEvent(string eventString, NavigatorButtonBase button)
        {
            //string type = button.ButtonType.ToString();
            NavigatorCustomButton btn = (NavigatorCustomButton)button;
            string type = btn.Tag.ToString();
            if (type == "首页")
            {
                PageIndex = 1;
            }

            if (type == "下一页")
            {
                PageIndex++;
            }

            if (type == "末页")
            {
                PageIndex = PageCount;
            }

            if (type == "上一页")
            {
                PageIndex--;
            }
            BindPageGridList();
        }

        public void BindPageGridList()
        {
            nvgtDataPager.Buttons.CustomButtons[0].Enabled = true;
            nvgtDataPager.Buttons.CustomButtons[1].Enabled = true;
            nvgtDataPager.Buttons.CustomButtons[2].Enabled = true;
            nvgtDataPager.Buttons.CustomButtons[3].Enabled = true;
          

            //记录获取开始数
            startIndex = (PageIndex - 1) * Pagesize + 1;
            //结束数
            endIndex = PageIndex * Pagesize;

            //获取查询的列表
            MyControl.DataSource = queryService.GetListByPage(startIndex, endIndex);
            //总页数
            PageRow = queryService.GetRecordCount();

            //获取总页数  
            if (PageRow % Pagesize > 0)
            {
                PageCount = PageRow / Pagesize + 1;
            }
            else
            {
                PageCount = PageRow / Pagesize;
            }

            if (PageIndex == 1)
            {
                nvgtDataPager.Buttons.CustomButtons[0].Enabled = false;
                nvgtDataPager.Buttons.CustomButtons[1].Enabled = false; ;
            }

            //最后页时获取真实记录数
            if (PageCount == PageIndex)
            {
                endIndex = PageRow;
                nvgtDataPager.Buttons.CustomButtons[2].Enabled = false;
                nvgtDataPager.Buttons.CustomButtons[3].Enabled = false;
            }

            
            nvgtDataPager.TextStringFormat = string.Format("第 {0} 页, 共 {1} 页，共 {2} 条数据", PageIndex, PageCount, PageRow);
        }

        private void nvgtDataPager_ButtonClick_1(object sender, NavigatorButtonClickEventArgs e)
        {
            ShowEvent("ButtonClick", e.Button);
        }
    }
}
