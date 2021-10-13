using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCaro
{
    public class Mode
    {
        // 1: Người vs người, 2: Người vs máy, 3: Người vs người qua LAN
        public static int cheDoChoi = 1;
        public static int xWin = 0;
        public static int yWin = 0;
        // dễ : 1, thường 2, khó 3
        public static int doKho = 1;
        public static bool load_game = false;
        public static bool chanHaiDau = false;
        public static int soDong = 20;
        public static int soCot = 20;
    }
}
