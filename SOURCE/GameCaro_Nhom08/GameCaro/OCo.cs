using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCaro
{
    public class OCo
    {
        public const int _ChieuRong = 30;
        public const int _ChieuCao = 30;

        private int _Dong;
        private int _Cot;
        private Point _ViTri;
        private int _SoHuu;

        public int Dong
        {
            get { return _Dong; }
            set { _Dong = value; }
        }
     
        public int Cot
        {
            get { return _Cot; }
            set { _Cot = value; }
        }
        public Point ViTri
        {
            get { return _ViTri; }
            set { _ViTri = value; }
        }

        public int SoHuu
        {
            get { return _SoHuu; }
            set { _SoHuu = value; }
        }
        public OCo()
        {

        }
        public OCo(int dong, int cot, Point vitri, int sohuu)
        {
            _Dong = dong;
            _Cot = cot;
            _ViTri = vitri;
            _SoHuu = sohuu;
        }
    }
}
