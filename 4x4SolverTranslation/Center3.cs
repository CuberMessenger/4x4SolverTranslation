using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
			0	1
			3	2

4	5		0	1		0	1		4	5
7	6		3	2		3	2		7	6

			4	5
			7	6
*/

namespace CSTPR444SolverTranslation {
    internal class Center3 {
        internal static char[,] ctmove = new char[35 * 35 * 12 * 2, 20];
        static int[] pmove = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1 };

        //Pitfall: sbyte or sbyte or int
        internal static sbyte[] prun = new sbyte[35 * 35 * 12 * 2];

        static int[] rl2std = new int[] { 0, 9, 14, 23, 27, 28, 41, 42, 46, 55, 60, 69 };
        static int[] std2rl = new int[70];


        int[] ud = new int[8];
        int[] rl = new int[8];
        int[] fb = new int[8];
        int parity = 0;

        internal static void init() {
            for (int i = 0; i < 12; i++) {
                std2rl[rl2std[i]] = i;
            }

            Center3 c = new Center3();
            for (int i = 0; i < 35 * 35 * 12 * 2; i++) {
                for (int m = 0; m < 20; m++) {
                    c.setct(i);
                    c.move(m);
                    ctmove[i, m] = (char)c.getct();
                }
            }

            //Arrays.fill(prun, (sbyte)-1);
            for (int i = 0; i < prun.Length; i++) {
                prun[i] = -1;
            }

            prun[0] = 0;
            int depth = 0;
            int done = 1;
            while (done != 29400) {
                for (int i = 0; i < 29400; i++) {
                    if (prun[i] != depth) {
                        continue;
                    }
                    for (int m = 0; m < 17; m++) {
                        if (prun[ctmove[i, m]] == -1) {
                            prun[ctmove[i, m]] = (sbyte)(depth + 1);
                            done++;
                        }
                    }
                }
                depth++;
                // System.out.println(String.format("%2d%10d", depth, done));
            }
        }

        internal void set(CenterCube c, int eXc_parity) {
            int parity = (c.ct[0] % 3 > c.ct[8] % 3 ^ c.ct[8] % 3 > c.ct[16] % 3 ^ c.ct[0] % 3 > c.ct[16] % 3) ? 0 : 1;
            for (int i = 0; i < 8; i++) {
                ud[i] = (c.ct[i] / 3) ^ 1;
                fb[i] = (c.ct[i + 8] / 3) ^ 1;
                rl[i] = (c.ct[i + 16] / 3) ^ 1 ^ parity;
            }
            this.parity = parity ^ eXc_parity;
        }

        internal int getct() {
            int idx = 0;
            int r = 4;
            for (int i = 6; i >= 0; i--) {
                if (ud[i] != ud[7]) {
                    idx += Util.Cnk[i, r--];
                }
            }
            idx *= 35;
            r = 4;
            for (int i = 6; i >= 0; i--) {
                if (fb[i] != fb[7]) {
                    idx += Util.Cnk[i, r--];
                }
            }
            idx *= 12;
            int check = fb[7] ^ ud[7];
            int idxrl = 0;
            r = 4;
            for (int i = 7; i >= 0; i--) {
                if (rl[i] != check) {
                    idxrl += Util.Cnk[i, r--];
                }
            }
            return parity + 2 * (idx + std2rl[idxrl]);
        }

        void setct(int idx) {
            parity = idx & 1;
            //Pitfall: >> or >>>
            idx >>= 1;
            int idxrl = rl2std[idx % 12];
            idx /= 12;
            int r = 4;
            for (int i = 7; i >= 0; i--) {
                rl[i] = 0;
                if (idxrl >= Util.Cnk[i, r]) {
                    idxrl -= Util.Cnk[i, r--];
                    rl[i] = 1;
                }
            }
            int idxfb = idx % 35;
            idx /= 35;
            r = 4;
            fb[7] = 0;
            for (int i = 6; i >= 0; i--) {
                if (idxfb >= Util.Cnk[i, r]) {
                    idxfb -= Util.Cnk[i, r--];
                    fb[i] = 1;
                }
                else {
                    fb[i] = 0;
                }
            }
            r = 4;
            ud[7] = 0;
            for (int i = 6; i >= 0; i--) {
                if (idx >= Util.Cnk[i, r]) {
                    idx -= Util.Cnk[i, r--];
                    ud[i] = 1;
                }
                else {
                    ud[i] = 0;
                }
            }
        }

        void move(int i) {
            parity ^= pmove[i];
            switch (i) {
                case 0:     //U
                case 1:     //U2
                case 2:     //U'	
                    Util.swap(ud, 0, 1, 2, 3, i % 3);
                    break;
                case 3:     //R2
                    Util.swap(rl, 0, 1, 2, 3, 1);
                    break;
                case 4:     //F
                case 5:     //F2
                case 6:     //F'
                    Util.swap(fb, 0, 1, 2, 3, (i - 1) % 3);
                    break;
                case 7:     //D
                case 8:     //D2
                case 9:     //D'
                    Util.swap(ud, 4, 5, 6, 7, (i - 1) % 3);
                    break;
                case 10:    //L2
                    Util.swap(rl, 4, 5, 6, 7, 1);
                    break;
                case 11:    //B
                case 12:    //B2
                case 13:    //B'
                    Util.swap(fb, 4, 5, 6, 7, (i + 1) % 3);
                    break;
                case 14:    //u2
                    Util.swap(ud, 0, 1, 2, 3, 1);
                    Util.swap(rl, 0, 5, 4, 1, 1);
                    Util.swap(fb, 0, 5, 4, 1, 1);
                    break;
                case 15:    //r2
                    Util.swap(rl, 0, 1, 2, 3, 1);
                    Util.swap(fb, 1, 4, 7, 2, 1);
                    Util.swap(ud, 1, 6, 5, 2, 1);
                    break;
                case 16:    //f2
                    Util.swap(fb, 0, 1, 2, 3, 1);
                    Util.swap(ud, 3, 2, 5, 4, 1);
                    Util.swap(rl, 0, 3, 6, 5, 1);
                    break;
                case 17:    //d2
                    Util.swap(ud, 4, 5, 6, 7, 1);
                    Util.swap(rl, 3, 2, 7, 6, 1);
                    Util.swap(fb, 3, 2, 7, 6, 1);
                    break;
                case 18:    //l2
                    Util.swap(rl, 4, 5, 6, 7, 1);
                    Util.swap(fb, 0, 3, 6, 5, 1);
                    Util.swap(ud, 0, 3, 4, 7, 1);
                    break;
                case 19:    //b2
                    Util.swap(fb, 4, 5, 6, 7, 1);
                    Util.swap(ud, 0, 7, 6, 1, 1);
                    Util.swap(rl, 1, 4, 7, 2, 1);
                    break;
            }
        }
    }
}
