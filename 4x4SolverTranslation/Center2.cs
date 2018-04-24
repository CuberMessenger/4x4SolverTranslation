using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
			0	1
			3	2

4	5		8	9		0	1		12	13
7	6		11	10		3	2		15	14

			4	5
			7	6
*/

namespace CSTPR444SolverTranslation {
    internal class Center2 {
        int[] rl = new int[8];
        int[] ct = new int[16];
        int parity = 0;

        internal static int[,] rlmv = new int[70, 28];
        internal static char[,] ctmv = new char[6435, 28];
        static int[,] rlrot = new int[70, 16];
        static char[,] ctrot = new char[6435, 16];
        //Pitfall: sbyte or sbyte or int
        internal static sbyte[] ctprun = new sbyte[6435 * 35 * 2];

        private static int[] pmv = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0 };

        internal static void init() {
            Center2 c = new Center2();

            for (int i = 0; i < 35 * 2; i++) {
                for (int m = 0; m < 28; m++) {
                    c.setrl(i);
                    c.move(Moves.move2std[m]);
                    rlmv[i, m] = c.getrl();
                }
            }

            for (int i = 0; i < 70; i++) {
                c.setrl(i);
                for (int j = 0; j < 16; j++) {
                    rlrot[i, j] = c.getrl();
                    c.rot(0);
                    if (j % 2 == 1)
                        c.rot(1);
                    if (j % 8 == 7)
                        c.rot(2);
                }
            }

            for (int i = 0; i < 6435; i++) {
                c.setct(i);
                for (int j = 0; j < 16; j++) {
                    ctrot[i, j] = (char)c.getct();
                    c.rot(0);
                    if (j % 2 == 1) c.rot(1);
                    if (j % 8 == 7) c.rot(2);
                }
            }

            for (int i = 0; i < 6435; i++) {
                for (int m = 0; m < 28; m++) {
                    c.setct(i);
                    c.move(Moves.move2std[m]);
                    ctmv[i, m] = (char)c.getct();
                }
            }
            //Arrays.fill(ctprun, (sbyte)-1);
            for (int i = 0; i < ctprun.Length; i++) {
                ctprun[i] = -1;
            }

            ctprun[0] = ctprun[18] = ctprun[28] = ctprun[46] = ctprun[54] = ctprun[56] = 0;
            int depth = 0;
            int done = 6;
            while (done != 6435 * 35 * 2) {
                for (int i = 0; i < 6435 * 35 * 2; i++) {
                    if (ctprun[i] != depth) {
                        continue;
                    }
                    int ct = i / 70;
                    int rl = i % 70;
                    for (int m = 0; m < 23; m++) {
                        int ctx = ctmv[ct, m];
                        int rlx = rlmv[rl, m];
                        int idx = ctx * 70 + rlx;
                        if (ctprun[idx] == -1) {
                            ctprun[idx] = (sbyte)(depth + 1);
                            done++;
                        }
                    }
                }
                depth++;
                //			System.out.println(String.format("%2d%10d", depth, done));
            }
        }

        internal Center2() { }

        internal void set(CenterCube c, int edgeParity) {
            for (int i = 0; i < 16; i++) {
                ct[i] = c.ct[i] % 3;
            }
            for (int i = 0; i < 8; i++) {
                rl[i] = c.ct[i + 16];
            }
            parity = edgeParity;
        }

        internal int getrl() {
            int idx = 0;
            int r = 4;
            for (int i = 6; i >= 0; i--) {
                if (rl[i] != rl[7]) {
                    idx += Util.Cnk[i, r--];
                }
            }
            return idx * 2 + parity;
        }

        void setrl(int idx) {
            parity = idx & 1;
            //Pitfall: >> or >>>
            idx >>= 1;
            int r = 4;
            rl[7] = 0;
            for (int i = 6; i >= 0; i--) {
                if (idx >= Util.Cnk[i, r]) {
                    idx -= Util.Cnk[i, r--];
                    rl[i] = 1;
                }
                else {
                    rl[i] = 0;
                }
            }
        }

        internal int getct() {
            int idx = 0;
            int r = 8;
            for (int i = 14; i >= 0; i--) {
                if (ct[i] != ct[15]) {
                    idx += Util.Cnk[i, r--];
                }
            }
            return idx;
        }

        void setct(int idx) {
            int r = 8;
            ct[15] = 0;
            for (int i = 14; i >= 0; i--) {
                if (idx >= Util.Cnk[i, r]) {
                    idx -= Util.Cnk[i, r--];
                    ct[i] = 1;
                }
                else {
                    ct[i] = 0;
                }
            }
        }

        void rot(int r) {
            switch (r) {
                case 0:
                    move(Moves.ux2);
                    move(Moves.dx2);
                    break;
                case 1:
                    move(Moves.rx1);
                    move(Moves.lx3);
                    break;
                case 2:
                    Util.swap(ct, 0, 3, 1, 2, 1);
                    Util.swap(ct, 8, 11, 9, 10, 1);
                    Util.swap(ct, 4, 7, 5, 6, 1);
                    Util.swap(ct, 12, 15, 13, 14, 1);
                    Util.swap(rl, 0, 3, 5, 6, 1);
                    Util.swap(rl, 1, 2, 4, 7, 1);
                    break;
            }
        }


        void move(int m) {
            parity ^= pmv[m];
            int key = m % 3;
            m /= 3;
            switch (m) {
                case 0:     //U
                    Util.swap(ct, 0, 1, 2, 3, key);
                    break;
                case 1:     //R
                    Util.swap(rl, 0, 1, 2, 3, key);
                    break;
                case 2:     //F
                    Util.swap(ct, 8, 9, 10, 11, key);
                    break;
                case 3:     //D
                    Util.swap(ct, 4, 5, 6, 7, key);
                    break;
                case 4:     //L
                    Util.swap(rl, 4, 5, 6, 7, key);
                    break;
                case 5:     //B
                    Util.swap(ct, 12, 13, 14, 15, key);
                    break;
                case 6:     //u
                    Util.swap(ct, 0, 1, 2, 3, key);
                    Util.swap(rl, 0, 5, 4, 1, key);
                    Util.swap(ct, 8, 9, 12, 13, key);
                    break;
                case 7:     //r
                    Util.swap(rl, 0, 1, 2, 3, key);
                    Util.swap(ct, 1, 15, 5, 9, key);
                    Util.swap(ct, 2, 12, 6, 10, key);
                    break;
                case 8:     //f
                    Util.swap(ct, 8, 9, 10, 11, key);
                    Util.swap(rl, 0, 3, 6, 5, key);
                    Util.swap(ct, 3, 2, 5, 4, key);
                    break;
                case 9:     //d
                    Util.swap(ct, 4, 5, 6, 7, key);
                    Util.swap(rl, 3, 2, 7, 6, key);
                    Util.swap(ct, 11, 10, 15, 14, key);
                    break;
                case 10:    //l
                    Util.swap(rl, 4, 5, 6, 7, key);
                    Util.swap(ct, 0, 8, 4, 14, key);
                    Util.swap(ct, 3, 11, 7, 13, key);
                    break;
                case 11:    //b		
                    Util.swap(ct, 12, 13, 14, 15, key);
                    Util.swap(rl, 1, 4, 7, 2, key);
                    Util.swap(ct, 1, 0, 7, 6, key);
                    break;
            }
        }
    }
}
