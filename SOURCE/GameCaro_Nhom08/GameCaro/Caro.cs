using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCaro
{
    public partial class Caro : Form
    {
        private CaroChess caroChess;
        private Graphics grs;
        SocketManager socket;
        private int old_x = -1, old_y = -1;
        public Caro()
        {
            InitializeComponent();
            caroChess = new CaroChess("a", "b", progressBarThinking, timer1, picPlayer, txtName, lblDiem);
            caroChess.KhoiTaoMangOCo();
            grs = pnlBoard.CreateGraphics();
            socket = new SocketManager();
        }

        public Caro(String player1, String player2, int loai)
        {
            InitializeComponent();
            // đặt panel ở giữa
            pnlBoard.Size = new System.Drawing.Size(Mode.soCot * 30 + 2, Mode.soDong * 30 + 2);
            pnlBoard.Location = new Point(14 + 602 / 2 - pnlBoard.Size.Width / 2, 27 + 602 / 2 - pnlBoard.Size.Height / 2);
            pnlBoard.Anchor = AnchorStyles.None;
            btnLan.Enabled = false;
            Mode.cheDoChoi = loai;
            caroChess = new CaroChess(player1, player2, progressBarThinking, timer1, picPlayer, txtName, lblDiem);
            caroChess.KhoiTaoMangOCo();
            grs = pnlBoard.CreateGraphics();
            if (loai == 3)
            {
                socket = new SocketManager();
                Control.CheckForIllegalCrossThreadCalls = false;
                btnLan.Enabled = true;
                btnBatDau.Enabled = false;
            }
           
        }

        public Caro(String player1, String player2, int loai, OCo[] _MangOCo)
        {
            InitializeComponent();
            pnlBoard.Size = new System.Drawing.Size(Mode.soCot * 30 + 2, Mode.soDong * 30 + 2);
            pnlBoard.Location = new Point(14 + 602 / 2 - pnlBoard.Size.Width / 2, 27 + 602 / 2 - pnlBoard.Size.Height / 2);
            pnlBoard.Anchor = AnchorStyles.None;
            btnLan.Enabled = false;
            Mode.cheDoChoi = loai;
            grs = pnlBoard.CreateGraphics();
            caroChess = new CaroChess(player1, player2, progressBarThinking, timer1, picPlayer, txtName, lblDiem, _MangOCo, grs);
            //caroChess.KhoiTaoMangOCo();
        }


        private void pnlBoard_Paint(object sender, PaintEventArgs e)
        {
            caroChess.VeBanCo(grs);
            //PThuc nay để bàn cờ k delete khi ẩn Frm xuống
            caroChess.VeLaiQuanCo(grs);
        }

        private void pnlBoard_MouseClick(object sender, MouseEventArgs e)
        {
            if (!caroChess.SanSang)
                return;
            if (!caroChess.DanhCo(e.X, e.Y, grs))
            {
                return;
            }

            if (caroChess.CheDoChoi == 2)
            {
                caroChess.KhoiDongCom(grs);

            }
            else if (caroChess.CheDoChoi == 3)
                {
                    socket.Send(new SocketData((int)SocketCommand.SEND_POINT, "", new Point(e.X, e.Y)));
                    pnlBoard.Enabled = false;
                    btnUndo.Enabled = false;
                    btnRedo.Enabled = false;
                    newGameToolStripMenuItem.Enabled = false;
                    undoToolStripMenuItem.Enabled = false;
                    redoToolStripMenuItem.Enabled = false;
                    if (caroChess.KTChienThang())
                    {
                        caroChess.VeDuongChienThang(grs, caroChess._LuotDi == 1 ? 2 : 1);
                        caroChess.KetThucGame();
                        return;
                    }
                    Listen();
                }
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            if (caroChess.CheDoChoi == 1)
            {
                if (Mode.load_game)
                {
                    caroChess.StartPlayervsPlayer(grs);
                    Mode.load_game = false;
                }
                else
                {
                    grs.Clear(pnlBoard.BackColor);
                    caroChess.StartPlayervsPlayer(grs);
                }
            }
            else if (caroChess.CheDoChoi == 2)
            {
                if (Mode.load_game)
                    caroChess.StartPvsC(grs);
                else
                {
                    grs.Clear(pnlBoard.BackColor);
                    caroChess.StartPvsC(grs);
                }
            }
            else if (caroChess.CheDoChoi == 3)
            {
                pnlBoard.Enabled = true;
                grs.Clear(pnlBoard.BackColor);
                caroChess.StartPlayervsPlayer(grs);
                //MessageBox.Show(caroChess.SanSang.ToString());
                try
                {
                    socket.Send(new SocketData((int)SocketCommand.NEW_GAME, "", new Point()));
                }
                catch (Exception)
                {
                }
            }
            else
            {
                MessageBox.Show("Không có chế độ chơi");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBarThinking.Value >= 100)
            {
                timer1.Stop();
                MessageBox.Show(caroChess.getNameWin(txtName.Text) + " chiến thắng");
                if (caroChess.getXorO(caroChess.getNameWin(txtName.Text)) == 1)
                    Mode.xWin++;
                else
                    Mode.yWin++;
                lblDiem.Text = Mode.xWin + ":" + Mode.yWin;
                caroChess.SanSang = false;
                return;
            }
            else
            {
                progressBarThinking.Value += 1;
            }
        }


        public void Undo()
        {
            if(caroChess.CheDoChoi == 1)
                caroChess.Undo(grs);
            else if (caroChess.CheDoChoi == 2)
            {
                caroChess.UndoX2(grs);
            }
           else if (caroChess.CheDoChoi == 3)
            {
                caroChess.UndoX2(grs);
                socket.Send(new SocketData((int)SocketCommand.UNDO, "", new Point()));
            }

        }

        public void Redo()
        {
            if (caroChess.CheDoChoi == 1)
                caroChess.Redo(grs);
            else if (caroChess.CheDoChoi == 2)
            {
                caroChess.RedoX2(grs);
            }

            else if (caroChess.CheDoChoi == 3)
            {
                caroChess.RedoX2(grs);
                socket.Send(new SocketData((int)SocketCommand.REDO, "", new Point()));
            }
        }
        private void btnUndo_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            Redo();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!caroChess.SanSang)
            {
                MessageBox.Show("Ván cờ đã kết thúc");
                return;
            }
            if (caroChess.CheDoChoi != 1)
                return;
            timer1.Stop();
            if (caroChess.LuuGame(grs))
            {
                //grs.Clear(pnlBoard.BackColor);
                MenuGame frm = new MenuGame();
                frm.Show();
                this.Hide();
            }
            else
            {
                timer1.Start();
            }
        }

        private void btnLan_Click(object sender, EventArgs e)
        {
            btnBatDau.Enabled = true;
            btnLan.Enabled = false;
            socket.IP = txtIP.Text;

            if (!socket.ConnectServer())
            {
                socket.isServer = true;
                pnlBoard.Enabled = true;
                socket.CreateServer();
            }
            else
            {
                socket.isServer = false;
                pnlBoard.Enabled = false;
                Listen();
            }
        }

        private void Caro_Shown(object sender, EventArgs e)
        {
            if (Mode.cheDoChoi == 3)
            {
                txtIP.Text = socket.GetLocalIPv4(NetworkInterfaceType.Wireless80211);

                if (string.IsNullOrEmpty(txtIP.Text))
                {
                    txtIP.Text = socket.GetLocalIPv4(NetworkInterfaceType.Ethernet);
                }
            }

        }
        void Listen()
        {
            Thread listenThread = new Thread(() =>
            {
                try
                {
                    SocketData data = (SocketData)socket.Receive();

                    ProcessData(data);
                }
                catch (Exception e)
                {
                }
            });
            listenThread.IsBackground = true;
            listenThread.Start();
        }

        private void ProcessData(SocketData data)
        {
            switch (data.Command)
            {
                case (int)SocketCommand.NOTIFY:
                    MessageBox.Show(data.Message);
                    break;
                case (int)SocketCommand.NEW_GAME:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        grs.Clear(pnlBoard.BackColor);
                        caroChess.StartPlayervsPlayer(grs);
                        pnlBoard.Enabled = false;
                    }));
                    break;
                case (int)SocketCommand.SEND_POINT:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        pnlBoard.Enabled = true;
                        btnUndo.Enabled = true;
                        btnRedo.Enabled = true;
                        undoToolStripMenuItem.Enabled = true;
                        redoToolStripMenuItem.Enabled = true;
                        newGameToolStripMenuItem.Enabled = true;
                        caroChess.DanhCo(data.Point.X, data.Point.Y, grs);
                        if (caroChess.KTChienThang())
                        {
                            caroChess.VeDuongChienThang(grs, caroChess._LuotDi == 1 ? 2 : 1);
                            caroChess.KetThucGame();
                            return;
                        }
                    }));
                    break;
                case (int)SocketCommand.UNDO:
                    this.Invoke((MethodInvoker)(() =>
                   {
                       pnlBoard.Enabled = true;
                       caroChess.UndoX2(grs);
                       pnlBoard.Enabled = false;
                   }));

                    break;
                case (int)SocketCommand.REDO:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        pnlBoard.Enabled = true;
                        caroChess.RedoX2(grs);
                        pnlBoard.Enabled = false;
                    }));

                    break;
                case (int)SocketCommand.END_GAME:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        timer1.Stop();
                        MessageBox.Show("Bạn đã thua rồi");
                        btnUndo.Enabled = false;
                        btnRedo.Enabled = false;
                        undoToolStripMenuItem.Enabled = false;
                        redoToolStripMenuItem.Enabled = false;
                   }));
                   
                    break;
                case (int)SocketCommand.TIME_OUT:
                    this.Invoke((MethodInvoker)(() =>
                   {
                       HetGio();
                   }));
                    break;
                case (int)SocketCommand.QUIT:
                    timer1.Stop();
                    MessageBox.Show("Đối thủ đã off game rồi");
                    break;
                default:
                    break;
            }
            Listen();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
          
        }

        private void Caro_FormClosing(object sender, FormClosingEventArgs e)
        {

            timer1.Stop();
            if (caroChess.SanSang == true && caroChess.CheDoChoi == 1)
            {
                DialogResult dr = MessageBox.Show("Bạn có muốn lưu game không?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.Cancel)
                {
                    timer1.Start();
                    e.Cancel = true;
                }
                else if (dr == DialogResult.No)
                {
                    MenuGame frm = new MenuGame();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    timer1.Stop();
                    if (caroChess.LuuGame(grs))
                    {
                        //grs.Clear(pnlBoard.BackColor);
                        MenuGame frm = new MenuGame();
                        frm.Show();
                        this.Hide();
                    }
                }
            }
            else if (MessageBox.Show("Bạn có muốn thoát game không?", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else
            {
                if (Mode.cheDoChoi == 3)
                {
                    try
                    {
                        socket.Send(new SocketData((int)SocketCommand.QUIT, "", new Point()));
                    }
                    catch (Exception)
                    {
                    }
                }
                MenuGame frm = new MenuGame();
                frm.Show();
                Mode.cheDoChoi = 1;
                Mode.xWin = 0;
                Mode.yWin = 0;
                Mode.load_game = false;
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newGameToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (caroChess.CheDoChoi == 1)
            {
                if (Mode.load_game)
                {
                    caroChess.StartPlayervsPlayer(grs);
                }
                else
                {
                    grs.Clear(pnlBoard.BackColor);
                    caroChess.StartPlayervsPlayer(grs);
                }

            }
            else if (caroChess.CheDoChoi == 2)
            {
                if (Mode.load_game)
                    caroChess.StartPvsC(grs);
                else
                {
                    grs.Clear(pnlBoard.BackColor);
                    caroChess.StartPvsC(grs);
                }
            }
            else if (caroChess.CheDoChoi == 3)
            {
                grs.Clear(pnlBoard.BackColor);
                caroChess.StartPlayervsPlayer(grs);
                try
                {
                    socket.Send(new SocketData((int)SocketCommand.NEW_GAME, "", new Point()));
                }
                catch (Exception)
                {
                }
            }
            else
            {
                MessageBox.Show("Khong có chế độ chơi");
            }

            
        }
        void HetGio()
        {
            btnUndo.Enabled = false;
            btnRedo.Enabled = false;
            undoToolStripMenuItem.Enabled = false;
            redoToolStripMenuItem.Enabled = false;
            timer1.Stop();
            MessageBox.Show("Đã hết giờ rồi");
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Redo();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn có thể lựa chọn 1 trong 3 chế độ chơi:\n\n-Player vs Player\n\n-Player vs COM\n\nPlayer vs Player(LAN)\n\nSau khi nhập đầy đủ tên người chơi và nhấn nút OK.\n\nBạn sẽ được quay lại màn hình chính\n\nBạn cần nhấn vào nút START để bắt đầu đánh cờ!!");
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Game Caro : Version 1.0\n@2021 Trương Công Hậu - Lê Minh Nhựt - Nguyễn Thành Nhân");
        }


        private void pnlBoard_MouseMove(object sender, MouseEventArgs e)
        {
            if (!caroChess.SanSang)
                return;
            BanCo.mouseMove(grs, ref old_x, ref old_y, e.X, e.Y);
        }
    }
}
