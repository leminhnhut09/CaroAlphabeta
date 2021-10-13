using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCaro
{
    public partial class PlayerList : Form
    {
        int loai;
        public PlayerList()
        {
            InitializeComponent();
        }

        public PlayerList(int type)
        {
            InitializeComponent();
            loai = type;
            if(type == 2)
            {
                label2.Visible = txtPlayer2.Visible = false;
            }
        }

        public bool kiemTraType()
        {
            if(loai == 1)
            {
                if (txtPlayer1.Text == String.Empty)
                {
                    MessageBox.Show("Vui lòng nhập tên người chơi 1");
                    return false;
                }
               if (txtPlayer2.Text == String.Empty)
                {
                    MessageBox.Show("Vui lòng nhập tên người chơi 2");
                    return false;

                }
                if (txtPlayer1.Text.Trim().ToString().Equals(txtPlayer2.Text.Trim().ToString()))
                    {
                        MessageBox.Show("Vui lòng nhập tên người chơi 1 và người chơi 2 không trùng nhau");
                        return false;
                    }
                
            }
            else
            {
                if (txtPlayer1.Text == String.Empty)
                {
                    MessageBox.Show("Vui lòng nhập tên người chơi");
                    return false;
                }
                 if (txtPlayer1.Text.Equals("Computer"))
                {
                    MessageBox.Show("Vui lòng nhập tên người chơi khác Computer");
                    return false;
                }
            }
            return true;
               
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(kiemTraType())
            {
                Caro frmCaro;
                if(loai == 1)
                    frmCaro = new Caro(txtPlayer1.Text, txtPlayer2.Text, loai);
                else
                    frmCaro = new Caro("Computer", txtPlayer1.Text, loai);
                frmCaro.Show();
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MenuGame frmMenu = new MenuGame();
            frmMenu.Show();
            this.Hide();
        }

        private void PlayerList_FormClosing(object sender, FormClosingEventArgs e)
        {
            MenuGame frmMenu = new MenuGame();
            frmMenu.Show();
            this.Hide();
        } 
    }
}
