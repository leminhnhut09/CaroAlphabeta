using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCaro
{
    class BanCo
    {
        private int _SoDong;
        private int _SoCot;

        public int SoDong
        {
            get { return _SoDong; }

        }
        public int SoCot
        {
            get { return _SoCot; }

        }
        public BanCo()
        {
            _SoDong = 0;
            _SoCot = 0;
        }
        public BanCo(int soDong, int soCot)
        {
            _SoDong = soDong;
            _SoCot = soCot;
        }
        //Ve Ban Co
        public void VeBanCo(Graphics g)
        {
            for (int i = 0; i <= _SoCot; i++)
            {
                g.DrawLine(CaroChess.pen, i * OCo._ChieuRong, 0, i * OCo._ChieuRong, _SoDong * OCo._ChieuCao);
            }
            for (int j = 0; j <= _SoDong; j++)
            {
                g.DrawLine(CaroChess.pen, 0, j * OCo._ChieuCao, _SoCot * OCo._ChieuRong, j * OCo._ChieuCao);
            }
        }
        public void VeQuanCo(Graphics g, Point point, Image img)
        {
            //g.FillEllipse(sb, point.X + 1, point.Y + 1, OCo._ChieuRong - 2, OCo._ChieuCao - 2);
            g.DrawImage(img, point.X + 1, point.Y + 1, OCo._ChieuRong - 2, OCo._ChieuCao - 2);
        }
        public void XoaQuanCo(Graphics g, Point point, SolidBrush sb)
        {
            // vẽ đè len quan co cho Redo
            g.FillRectangle(sb, point.X + 1, point.Y + 1, OCo._ChieuRong - 2, OCo._ChieuCao - 2);
        }


        public static void veKhung(Graphics gr, int x, int y, int width, int idx)
        {
            Pen pen = new Pen(Color.Red);
            Pen penTam = new Pen(Color.FromArgb(45, 45, 45));
            if (idx == 1)
            {
                pen = penTam;
            }
            gr.DrawRectangle(pen, x, y, width, width);
        }
        public static void mouseMove(Graphics gr, ref int old_x, ref int old_y, int mouse_x, int mouse_y)
        {
            int c = (mouse_x) / 30;
            int d = (mouse_y) / 30;
            if (c >= 0 && d >= 0 && d < 20 && c < 20)
            {
                if (old_x != c || old_y != c)
                {
                    if (old_x >= 0 && old_y >= 0)
                    {
                        veKhung(gr, old_x * 30, old_y * 30, 30, 1);
                    }
                    veKhung(gr, c * 30, d * 30, 30, 0);
                    old_x = c; old_y = d;
                }
            }

        }
    }
}
