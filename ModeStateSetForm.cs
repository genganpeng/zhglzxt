using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zhuhai.xmlrpc;
using zhuhai.util;
using zhuhai.service;

namespace zhuhai
{
    public partial class ModeStateSetForm : Form
    {
        private int gateTotal = 10;

        public ModeStateSetForm(int gateTotal)
        {
            InitializeComponent();
            this.gateTotal = gateTotal;
            object[] checkListItems = new object[gateTotal];
            for (int i = 0; i < gateTotal; i++)
            {
                checkListItems[i] = i + 1;
            }
            this.checkedListBoxControl_gate.Items.Clear();
            this.checkedListBoxControl_gate.Items.AddRange(checkListItems);
        }

        private void simpleButton_allChecked_Click(object sender, EventArgs e)
        {
            checkAllState(true);
        }

        private void simpleButton_cancelChecked_Click(object sender, EventArgs e)
        {
            checkAllState(false);
        }

        private void checkAllState(bool check)
        {
            for (int i = 0; i < this.checkedListBoxControl_gate.Items.Count; i++)
            {
                this.checkedListBoxControl_gate.SetItemChecked(i, check);
            }
        }

        /// <summary>
        /// 获取选中的闸机编号并返回
        /// </summary>
        /// <returns></returns>
        private int[] getSelectedGates()
        {
            if (this.checkedListBoxControl_gate.CheckedItems.Count == 0)
            {
                MessageBox.Show("请选择通道！");
                return null;
            }

            int[] gateIds = new int[this.checkedListBoxControl_gate.CheckedItems.Count];
            for (int i = 0; i < this.checkedListBoxControl_gate.CheckedItems.Count; i++)
            {
                object obj = this.checkedListBoxControl_gate.CheckedItems[i];
                gateIds[i] = (int)obj;
            }
            return gateIds;
        }

        /// <summary>
        /// 改变闸机运行模式
        /// </summary>
        /// <param name="modeStr">模式字符串</param>
        /// <param name="mode">运行模式</param>
        public void changeGateMode(string modeStr, int mode)
        {
            
            int[] gateIds = getSelectedGates();
            if (gateIds == null) return;
            if (MessageBox.Show("你确定要改变选中闸机的运行模式到" + modeStr + "模式？", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            ModeStateSetService service = ModeStateSetService.getInstance();
            try
            {
                service.updateGateMode(mode, gateIds);
                MessageBox.Show("修改闸机运行模式成功！");
                LogService.getInstance().log(gateIds.ToString() + "运行模式变为" + modeStr, ModuleConstant.GateMode_MODULE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }

        private void simpleButton_zizhu_Click(object sender, EventArgs e)
        {
            changeGateMode("自助通关", (int)WorkMode.Zizhu);
        }

        private void simpleButton_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton_shuaka_Click(object sender, EventArgs e)
        {
            changeGateMode("刷卡通关", (int)WorkMode.Shuaka);
        }

        private void simpleButton_shenbao_Click(object sender, EventArgs e)
        {
            changeGateMode("申报通关", (int)WorkMode.Shenbao);
        }

        private void simpleButton_fengbi_Click(object sender, EventArgs e)
        {
            changeGateMode("通关封闭", (int)WorkMode.Fengbi);
        }

        /// <summary>
        /// 改变闸机状态
        /// </summary>
        /// <param name="modeStr">状态字符串</param>
        /// <param name="mode">状态</param>
        public void changeGateState(string stateStr, int state)
        {

            int[] gateIds = getSelectedGates();
            if (gateIds == null) return;
            if (MessageBox.Show("你确定要改变选中闸机进行" + stateStr + "操作？", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            ModeStateSetService service = ModeStateSetService.getInstance();
            try
            {
                service.updateGateState(state, gateIds);
                LogService.getInstance().log(gateIds.ToString() + "闸机状态变为" + stateStr, ModuleConstant.ModeStateSet_MODULE);
                MessageBox.Show("操作闸机状态成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }

        private void simpleButton_sleep_Click(object sender, EventArgs e)
        {
            changeGateState("闸机休眠", (int)OrderType.Gate_Sleep);
        }

        private void simpleButton_restart_Click(object sender, EventArgs e)
        {
            changeGateState("闸机重启", (int)OrderType.Gate_Reboot);
        }

        private void simpleButton_lock_Click(object sender, EventArgs e)
        {
            changeGateState("闸机锁定", (int)OrderType.Gate_Lock);
        }

        private void simpleButton_unlock_Click(object sender, EventArgs e)
        {
            changeGateState("闸机解锁", (int)OrderType.Gate_Unlock);
        }
    }
}
