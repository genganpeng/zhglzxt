using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zhuhai.model;
using System.IO;
using zhuhai.service;

namespace zhuhai
{
    public partial class ShowClearanceInfoForm : Form
    {
        public ShowClearanceInfoForm(DataRow row)
        {
            InitializeComponent();

            nameLabel.Text = row[ClearanceRecord.NAME_COLUMN].ToString();
            nationalityLabel.Text = row[ClearanceRecord.NATIONALITY_COLUMN].ToString();
            idnoLabel.Text = row[ClearanceRecord.ID_CODE_COLUMN].ToString();
            passTime.Text = ((DateTime)row[ClearanceRecord.NVR_STARTTIME_COLUMN]).ToString("yyyy-MM-dd hh:mm:ss");
            exchannellabel.Text = row[ClearanceRecord.GATE_ID_COLUMN].ToString();
            extempraturelabel.Text = row[ClearanceRecord.TEMPERATURE_COLUMN].ToString() + "℃";
            exceptionLabel.Text = row[ClearanceRecord.NUCLEAR_COLUMN].ToString();
            string nuclear_detail = row[ClearanceRecord.NULCLEAR_DETAIL_COLUMN].ToString();
            if (nuclear_detail.Contains("铱"))
            {
                this.nuclearyilabel.Image = global::zhuhai.Properties.Resources.yired;
            }
            else
            {
                this.nuclearyilabel.Image = global::zhuhai.Properties.Resources.yiwhite;
            }
            if (nuclear_detail.Contains("钴"))
            {
                this.nucleargulabel.Image = global::zhuhai.Properties.Resources.gured;
            }
            else
            {
                this.nucleargulabel.Image = global::zhuhai.Properties.Resources.guwhite;
            }
            if (nuclear_detail.Contains("钍"))
            {
                this.nucleartulabel.Image = global::zhuhai.Properties.Resources.tured;
            }
            else
            {
                this.nucleartulabel.Image = global::zhuhai.Properties.Resources.tuwhite;
            }
            if (nuclear_detail.Contains("铯"))
            {
                this.nuclearselabel.Image = global::zhuhai.Properties.Resources.sered;
            }
            else
            {
                this.nuclearselabel.Image = global::zhuhai.Properties.Resources.sewhite;
            }
            if (nuclear_detail.Contains("钾"))
            {
                this.nuclearjialabel.Image = global::zhuhai.Properties.Resources.jiared;
            }
            else
            {
                this.nuclearjialabel.Image = global::zhuhai.Properties.Resources.jiawhite;
            }

            try
            {
                byte[] bytes = GateService.getInstance().getPassengerPhoto(int.Parse(row[ClearanceRecord.ID_PHOTO_ID_COLUMN].ToString()));
                MemoryStream ms = new MemoryStream(bytes, 0, bytes.Length);
                this.photoPictureBox.BackgroundImage = Image.FromStream(ms);
                ms.Close();
            }
            catch (Exception ex)
            {
                this.photoPictureBox.Image = global::zhuhai.Properties.Resources.people;
                
                MessageBox.Show(ex.Message, "错误");
            }
            
        }
    }
}
