using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCaro
{
    class FileGame
    {
        private int luotDi;

        public int Luotdi
        {
            get { return luotDi; }
            set { luotDi = value; }
        }
        private int cheDo;

        public int CheDo
        {
            get { return cheDo; }
            set { cheDo = value; }
        }
        private String nguoiChoi1;

        public String NguoiChoi1
        {
            get { return nguoiChoi1; }
            set { nguoiChoi1 = value; }
        }
        private String nguoiChoi2;

        public String NguoiChoi2
        {
            get { return nguoiChoi2; }
            set { nguoiChoi2 = value; }
        }
        private Stack<OCo> lstDanhSach;

        internal Stack<OCo> LstDanhSach
        {
            get { return lstDanhSach; }
            set { lstDanhSach = value; }
        }
        public FileGame(int luotDi, int cheDo, string nc1, string nc2, Stack<OCo> ds)
        {
            this.cheDo = cheDo;
            this.luotDi = luotDi;
            this.nguoiChoi1 = nc1;
            this.nguoiChoi2 = nc2;
            this.lstDanhSach = ds;
        }
        public void SaveGame()
        {
            SaveFileDialog Save = new SaveFileDialog();

            Save.Filter = "Caro file (*.caro)|*.caro|All file (*.*)|*.*";
            Save.FilterIndex = 2;
            Save.RestoreDirectory = true;

            if (Save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter myStream = new StreamWriter(Save.FileName);
                if (Save.FileName.CompareTo("") != 0)
                {
                    myStream.WriteLine(cheDo);
                    myStream.WriteLine(nguoiChoi1);
                    myStream.WriteLine(nguoiChoi2);

                    for (int i = lstDanhSach.Count; i > 0; i--)
                    {
                        OCo oco = lstDanhSach.Pop();
                        myStream.WriteLine(oco.Dong);
                        myStream.WriteLine(oco.Cot);
                        myStream.WriteLine(oco.SoHuu);
                    }
                    myStream.Close();
                }
            }
            MessageBox.Show("Đã lưu");
        }

        
    }
}
