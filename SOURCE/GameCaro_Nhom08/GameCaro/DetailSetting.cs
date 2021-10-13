using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCaro
{
    public partial class DetailSetting : Form
    {
        private int value;
        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int APPCOMMAND_VOLUME_UP = 0xA0000;
        private const int APPCOMMAND_VOLUME_DOWN = 0x90000;
        private const int WM_APPCOMMAND = 0x319;


        public DetailSetting()
        {
            InitializeComponent();
            if (Mode.chanHaiDau)
                chkChanHaiDau.Checked = true;
            else chkChanHaiDau.Checked = false;
            if (Mode.doKho == 1)
            {
                rdDe.Checked = true;
            }
            else if (Mode.doKho == 3)
            {
                rdThuong.Checked = true;
            }
            else if (Mode.doKho == 4)
            {
                rdKho.Checked = true;
            }
            else
            {
                MessageBox.Show("Chưa có độ khó");
            }
            txtSD.Text = Mode.soDong.ToString();
            txtSC.Text = Mode.soCot.ToString();
            value = trackBar1.Value;
        }
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg,
         IntPtr wParam, IntPtr lParam);
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (trackBar1.Value > value)
            {
                VolUp();
            }
            else if (trackBar1.Value < value)
            {
                VolDown();
            }
            value = trackBar1.Value;
        }

        private void DetailSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            MenuGame frm = new MenuGame();
            frm.Show();
        }

        private void trackBar1_MouseLeave(object sender, EventArgs e)
        {

        }
        private void Mute()
        {
            SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
                (IntPtr)APPCOMMAND_VOLUME_MUTE);
        }

        private void VolDown()
        {
            SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
                (IntPtr)APPCOMMAND_VOLUME_DOWN);
        }

        private void VolUp()
        {
            SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
                (IntPtr)APPCOMMAND_VOLUME_UP);
        }

        private void btnMute_Click(object sender, EventArgs e)
        {
            Mute();
        }

        private void chkChanHaiDau_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChanHaiDau.Checked)
                Mode.chanHaiDau = true;
            else
                Mode.chanHaiDau = false;
        }

        private void rdKho_CheckedChanged(object sender, EventArgs e)
        {
            if (rdKho.Checked)
            {
                Mode.doKho = 4;
                // MessageBox.Show("Khó");
            }
        }

        private void rdDe_CheckedChanged(object sender, EventArgs e)
        {
            if (rdDe.Checked)
            {
                Mode.doKho = 1;
                // MessageBox.Show("Dễ");
            }
        }

        private void rdThuong_CheckedChanged(object sender, EventArgs e)
        {
            if (rdThuong.Checked)
            {
                Mode.doKho = 3;
                // MessageBox.Show("Thường");
            }
        }

        private void txtSD_TextChanged(object sender, EventArgs e)
        {
            //Mode.soDong = int.Parse(txtSD.Text);
        }

        private void DetailSetting_Load(object sender, EventArgs e)
        {

        }
        public bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }
        public bool checkDongCot()
        {
            if (!IsNumeric(txtSD.Text) || !IsNumeric(txtSC.Text))
            {
                MessageBox.Show("Vui long nhập giá trị là số");
                return false;
            }
            int dong = int.Parse(txtSD.Text);
            int cot = int.Parse(txtSC.Text);
            if (dong < 5 || dong > 20 || cot < 5 || cot > 20)
            {
                MessageBox.Show("Vui lòng nhập số từ khoảng 5 -> 20");
                return false;
            }
            return true;
        }
        private void txtSC_TextChanged(object sender, EventArgs e)
        {
            //Mode.soCot = int.Parse(txtSC.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkDongCot())
            {
                MessageBox.Show("Giá trị hợp lệ");
            }
            else
            {
                txtSD.Text = "20";
                txtSC.Text = "20";
            }
            Mode.soDong = int.Parse(txtSD.Text);
            Mode.soCot = int.Parse(txtSC.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}