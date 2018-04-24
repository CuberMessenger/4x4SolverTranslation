using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CSTPR444SolverTranslation {
    internal class EdgeCube {
        private static int[] epmv = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1 };
        static int[,] EdgeColor = new int[,] { { Moves.F, Moves.U }, { Moves.L, Moves.U }, { Moves.B, Moves.U }, { Moves.R, Moves.U }, { Moves.B, Moves.D }, { Moves.L, Moves.D }, { Moves.F, Moves.D }, { Moves.R, Moves.D }, { Moves.F, Moves.L }, { Moves.B, Moves.L }, { Moves.B, Moves.R }, { Moves.F, Moves.R } };
        static int[] EdgeMap = new int[] { Moves.F2, Moves.L2, Moves.B2, Moves.R2, Moves.B8, Moves.L8, Moves.F8, Moves.R8, Moves.F4, Moves.B6, Moves.B4, Moves.F6, Moves.U8, Moves.U4, Moves.U2, Moves.U6, Moves.D8, Moves.D4, Moves.D2, Moves.D6, Moves.L6, Moves.L4, Moves.R6, Moves.R4 };
        //Pitfall: sbyte or sbyte or int
        internal sbyte[] ep = new sbyte[24];

        internal EdgeCube() {
            for (sbyte i = 0; i < 24; i++) {
                ep[i] = i;
            }
        }

        internal EdgeCube(EdgeCube c) {
            copy(c);
        }

        internal EdgeCube(Random r) : this() {
            for (int i = 0; i < 23; i++) {
                int t = i + r.Next(24 - i);
                if (t != i) {
                    sbyte m = ep[i];
                    ep[i] = ep[t];
                    ep[t] = m;
                }
            }
        }

        internal EdgeCube(int[] moveseq) : this() {
            for (int m = 0; m < moveseq.Length; m++) {
                move(m);
            }
        }

        internal int getParity() {
            return Util.parity(ep);
        }

        internal void copy(EdgeCube c) {
            for (int i = 0; i < 24; i++) {
                ep[i] = c.ep[i];
            }
        }

        void print() {
            for (int i = 0; i < 24; i++) {
                Console.Write(ep[i]);
                Console.Write('\t');
            }
            Console.WriteLine();
        }

        internal void fill333Facelet(char[] facelet) {
            for (int i = 0; i < 24; i++) {
                facelet[EdgeMap[i]] = "URFDLB"[EdgeColor[ep[i] % 12, ep[i] / 12]];
            }
        }

        internal bool checkEdge() {
            int ck = 0;
            bool parity = false;
            for (int i = 0; i < 12; i++) {
                ck |= 1 << ep[i];
                parity = parity != ep[i] >= 12;
            }
            ck &= ck >> 12;
            return ck == 0 && !parity;
        }

        /*
Edge Cubies: 
					14	2	
				1			15
				13			3
					0	12	
	1	13			0	12			3	15			2	14	
9			20	20			11	11			22	22			9
21			8	8			23	23			10	10			21
	17	5			18	6			19	7			16	4	
					18	6	
				5			19
				17			7
					4	16	

Center Cubies: 
			0	1
			3	2

20	21		8	9		16	17		12	13
23	22		11	10		19	18		15	14

			4	5
			7	6

	 *             |************|
	 *             |*U1**U2**U3*|
	 *             |************|
	 *             |*U4**U5**U6*|
	 *             |************|
	 *             |*U7**U8**U9*|
	 *             |************|
	 * ************|************|************|************|
	 * *L1**L2**L3*|*F1**F2**F3*|*R1**R2**F3*|*B1**B2**B3*|
	 * ************|************|************|************|
	 * *L4**L5**L6*|*F4**F5**F6*|*R4**R5**R6*|*B4**B5**B6*|
	 * ************|************|************|************|
	 * *L7**L8**L9*|*F7**F8**F9*|*R7**R8**R9*|*B7**B8**B9*|
	 * ************|************|************|************|
	 *             |************|
	 *             |*D1**D2**D3*|
	 *             |************|
	 *             |*D4**D5**D6*|
	 *             |************|
	 *             |*D7**D8**D9*|
	 *             |************|
	 */

        internal void move(int m) {
            int key = m % 3;
            m /= 3;
            switch (m) {
                case 0: //U
                    Util.swap(ep, 0, 1, 2, 3, key);
                    Util.swap(ep, 12, 13, 14, 15, key);
                    break;
                case 1: //R
                    Util.swap(ep, 11, 15, 10, 19, key);
                    Util.swap(ep, 23, 3, 22, 7, key);
                    break;
                case 2: //F
                    Util.swap(ep, 0, 11, 6, 8, key);
                    Util.swap(ep, 12, 23, 18, 20, key);
                    break;
                case 3: //D
                    Util.swap(ep, 4, 5, 6, 7, key);
                    Util.swap(ep, 16, 17, 18, 19, key);
                    break;
                case 4: //L
                    Util.swap(ep, 1, 20, 5, 21, key);
                    Util.swap(ep, 13, 8, 17, 9, key);
                    break;
                case 5: //B
                    Util.swap(ep, 2, 9, 4, 10, key);
                    Util.swap(ep, 14, 21, 16, 22, key);
                    break;
                case 6: //u
                    Util.swap(ep, 0, 1, 2, 3, key);
                    Util.swap(ep, 12, 13, 14, 15, key);
                    Util.swap(ep, 9, 22, 11, 20, key);
                    break;
                case 7: //r
                    Util.swap(ep, 11, 15, 10, 19, key);
                    Util.swap(ep, 23, 3, 22, 7, key);
                    Util.swap(ep, 2, 16, 6, 12, key);
                    break;
                case 8: //f
                    Util.swap(ep, 0, 11, 6, 8, key);
                    Util.swap(ep, 12, 23, 18, 20, key);
                    Util.swap(ep, 3, 19, 5, 13, key);
                    break;
                case 9: //d
                    Util.swap(ep, 4, 5, 6, 7, key);
                    Util.swap(ep, 16, 17, 18, 19, key);
                    Util.swap(ep, 8, 23, 10, 21, key);
                    break;
                case 10://l
                    Util.swap(ep, 1, 20, 5, 21, key);
                    Util.swap(ep, 13, 8, 17, 9, key);
                    Util.swap(ep, 14, 0, 18, 4, key);
                    break;
                case 11://b
                    Util.swap(ep, 2, 9, 4, 10, key);
                    Util.swap(ep, 14, 21, 16, 22, key);
                    Util.swap(ep, 7, 15, 1, 17, key);
                    break;
            }
        }
    }
}