using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSTPR444SolverTranslation {
    internal class Moves {
        internal const sbyte U1 = 0;
        internal const sbyte U2 = 1;
        internal const sbyte U3 = 2;
        internal const sbyte U4 = 3;
        internal const sbyte U5 = 4;
        internal const sbyte U6 = 5;
        internal const sbyte U7 = 6;
        internal const sbyte U8 = 7;
        internal const sbyte U9 = 8;
        internal const sbyte R1 = 9;
        internal const sbyte R2 = 10;
        internal const sbyte R3 = 11;
        internal const sbyte R4 = 12;
        internal const sbyte R5 = 13;
        internal const sbyte R6 = 14;
        internal const sbyte R7 = 15;
        internal const sbyte R8 = 16;
        internal const sbyte R9 = 17;
        internal const sbyte F1 = 18;
        internal const sbyte F2 = 19;
        internal const sbyte F3 = 20;
        internal const sbyte F4 = 21;
        internal const sbyte F5 = 22;
        internal const sbyte F6 = 23;
        internal const sbyte F7 = 24;
        internal const sbyte F8 = 25;
        internal const sbyte F9 = 26;
        internal const sbyte D1 = 27;
        internal const sbyte D2 = 28;
        internal const sbyte D3 = 29;
        internal const sbyte D4 = 30;
        internal const sbyte D5 = 31;
        internal const sbyte D6 = 32;
        internal const sbyte D7 = 33;
        internal const sbyte D8 = 34;
        internal const sbyte D9 = 35;
        internal const sbyte L1 = 36;
        internal const sbyte L2 = 37;
        internal const sbyte L3 = 38;
        internal const sbyte L4 = 39;
        internal const sbyte L5 = 40;
        internal const sbyte L6 = 41;
        internal const sbyte L7 = 42;
        internal const sbyte L8 = 43;
        internal const sbyte L9 = 44;
        internal const sbyte B1 = 45;
        internal const sbyte B2 = 46;
        internal const sbyte B3 = 47;
        internal const sbyte B4 = 48;
        internal const sbyte B5 = 49;
        internal const sbyte B6 = 50;
        internal const sbyte B7 = 51;
        internal const sbyte B8 = 52;
        internal const sbyte B9 = 53;

        internal const sbyte u0 = 0x0;
        internal const sbyte u1 = 0x1;
        internal const sbyte u2 = 0x2;
        internal const sbyte u3 = 0x3;
        internal const sbyte u4 = 0x4;
        internal const sbyte u5 = 0x5;
        internal const sbyte u6 = 0x6;
        internal const sbyte u7 = 0x7;
        internal const sbyte u8 = 0x8;
        internal const sbyte u9 = 0x9;
        internal const sbyte ua = 0xa;
        internal const sbyte ub = 0xb;
        internal const sbyte uc = 0xc;
        internal const sbyte ud = 0xd;
        internal const sbyte ue = 0xe;
        internal const sbyte uf = 0xf;
        internal const sbyte r0 = 0x10;
        internal const sbyte r1 = 0x11;
        internal const sbyte r2 = 0x12;
        internal const sbyte r3 = 0x13;
        internal const sbyte r4 = 0x14;
        internal const sbyte r5 = 0x15;
        internal const sbyte r6 = 0x16;
        internal const sbyte r7 = 0x17;
        internal const sbyte r8 = 0x18;
        internal const sbyte r9 = 0x19;
        internal const sbyte ra = 0x1a;
        internal const sbyte rb = 0x1b;
        internal const sbyte rc = 0x1c;
        internal const sbyte rd = 0x1d;
        internal const sbyte re = 0x1e;
        internal const sbyte rf = 0x1f;
        internal const sbyte f0 = 0x20;
        internal const sbyte f1 = 0x21;
        internal const sbyte f2 = 0x22;
        internal const sbyte f3 = 0x23;
        internal const sbyte f4 = 0x24;
        internal const sbyte f5 = 0x25;
        internal const sbyte f6 = 0x26;
        internal const sbyte f7 = 0x27;
        internal const sbyte f8 = 0x28;
        internal const sbyte f9 = 0x29;
        internal const sbyte fa = 0x2a;
        internal const sbyte fb = 0x2b;
        internal const sbyte fc = 0x2c;
        internal const sbyte fd = 0x2d;
        internal const sbyte fe = 0x2e;
        internal const sbyte ff = 0x2f;
        internal const sbyte d0 = 0x30;
        internal const sbyte d1 = 0x31;
        internal const sbyte d2 = 0x32;
        internal const sbyte d3 = 0x33;
        internal const sbyte d4 = 0x34;
        internal const sbyte d5 = 0x35;
        internal const sbyte d6 = 0x36;
        internal const sbyte d7 = 0x37;
        internal const sbyte d8 = 0x38;
        internal const sbyte d9 = 0x39;
        internal const sbyte da = 0x3a;
        internal const sbyte db = 0x3b;
        internal const sbyte dc = 0x3c;
        internal const sbyte dd = 0x3d;
        internal const sbyte de = 0x3e;
        internal const sbyte df = 0x3f;
        internal const sbyte l0 = 0x40;
        internal const sbyte l1 = 0x41;
        internal const sbyte l2 = 0x42;
        internal const sbyte l3 = 0x43;
        internal const sbyte l4 = 0x44;
        internal const sbyte l5 = 0x45;
        internal const sbyte l6 = 0x46;
        internal const sbyte l7 = 0x47;
        internal const sbyte l8 = 0x48;
        internal const sbyte l9 = 0x49;
        internal const sbyte la = 0x4a;
        internal const sbyte lb = 0x4b;
        internal const sbyte lc = 0x4c;
        internal const sbyte ld = 0x4d;
        internal const sbyte le = 0x4e;
        internal const sbyte lf = 0x4f;
        internal const sbyte b0 = 0x50;
        internal const sbyte b1 = 0x51;
        internal const sbyte b2 = 0x52;
        internal const sbyte b3 = 0x53;
        internal const sbyte b4 = 0x54;
        internal const sbyte b5 = 0x55;
        internal const sbyte b6 = 0x56;
        internal const sbyte b7 = 0x57;
        internal const sbyte b8 = 0x58;
        internal const sbyte b9 = 0x59;
        internal const sbyte ba = 0x5a;
        internal const sbyte bb = 0x5b;
        internal const sbyte bc = 0x5c;
        internal const sbyte bd = 0x5d;
        internal const sbyte be = 0x5e;
        internal const sbyte bf = 0x5f;

        internal const int U = 0;
        internal const int R = 1;
        internal const int F = 2;
        internal const int D = 3;
        internal const int L = 4;
        internal const int B = 5;

        internal const int Ux1 = 0;
        internal const int Ux2 = 1;
        internal const int Ux3 = 2;
        internal const int Rx1 = 3;
        internal const int Rx2 = 4;
        internal const int Rx3 = 5;
        internal const int Fx1 = 6;
        internal const int Fx2 = 7;
        internal const int Fx3 = 8;
        internal const int Dx1 = 9;
        internal const int Dx2 = 10;
        internal const int Dx3 = 11;
        internal const int Lx1 = 12;
        internal const int Lx2 = 13;
        internal const int Lx3 = 14;
        internal const int Bx1 = 15;
        internal const int Bx2 = 16;
        internal const int Bx3 = 17;
        internal const int ux1 = 18;
        internal const int ux2 = 19;
        internal const int ux3 = 20;
        internal const int rx1 = 21;
        internal const int rx2 = 22;
        internal const int rx3 = 23;
        internal const int fx1 = 24;
        internal const int fx2 = 25;
        internal const int fx3 = 26;
        internal const int dx1 = 27;
        internal const int dx2 = 28;
        internal const int dx3 = 29;
        internal const int lx1 = 30;
        internal const int lx2 = 31;
        internal const int lx3 = 32;
        internal const int bx1 = 33;
        internal const int bx2 = 34;
        internal const int bx3 = 35;
        internal const int eom = 36;//End Of Moves

        internal static string[] move2str =
            new string[] {"U  ", "U2 ", "U' ", "R  ", "R2 ", "R' ", "F  ", "F2 ", "F' ",
                                "D  ", "D2 ", "D' ", "L  ", "L2 ", "L' ", "B  ", "B2 ", "B' ",
                                "Uw ", "Uw2", "Uw'", "Rw ", "Rw2", "Rw'", "Fw ", "Fw2", "Fw'",
                                "Dw ", "Dw2", "Dw'", "Lw ", "Lw2", "Lw'", "Bw ", "Bw2", "Bw'"};

        internal static string[] moveIstr =
            new string[] {"U' ", "U2 ", "U  ", "R' ", "R2 ", "R  ", "F' ", "F2 ", "F  ",
                                "D' ", "D2 ", "D  ", "L' ", "L2 ", "L  ", "B' ", "B2 ", "B  ",
                                "Uw'", "Uw2", "Uw ", "Rw'", "Rw2", "Rw ", "Fw'", "Fw2", "Fw ",
                                "Dw'", "Dw2", "Dw ", "Lw'", "Lw2", "Lw ", "Bw'", "Bw2", "Bw "};

        internal static int[] move2std =
            new int[] {Ux1, Ux2, Ux3, Rx1, Rx2, Rx3, Fx1, Fx2, Fx3,
                            Dx1, Dx2, Dx3, Lx1, Lx2, Lx3, Bx1, Bx2, Bx3,
                            ux2, rx1, rx2, rx3, fx2, dx2, lx1, lx2, lx3, bx2, eom};

        internal static int[] move3std =
            new int[] {Ux1, Ux2, Ux3, Rx2, Fx1, Fx2, Fx3, Dx1, Dx2, Dx3, Lx2, Bx1, Bx2, Bx3,
                            ux2, rx2, fx2, dx2, lx2, bx2, eom};

        internal static int[] std2move = new int[37];
        internal static int[] std3move = new int[37];

        internal static bool[,] ckmv = new bool[37, 36];
        internal static bool[,] ckmv2 = new bool[29, 28];
        internal static bool[,] ckmv3 = new bool[21, 20];

        internal static int[] skipAxis = new int[36];
        internal static int[] skipAxis2 = new int[28];
        internal static int[] skipAxis3 = new int[20];

        static Moves() {
            for (int i = 0; i < 29; i++) {
                std2move[move2std[i]] = i;
            }
            for (int i = 0; i < 21; i++) {
                std3move[move3std[i]] = i;
            }
            for (int i = 0; i < 36; i++) {
                for (int j = 0; j < 36; j++) {
                    ckmv[i, j] = (i / 3 == j / 3) || ((i / 3 % 3 == j / 3 % 3) && (i > j));
                }
                ckmv[36, i] = false;
            }
            for (int i = 0; i < 29; i++) {
                for (int j = 0; j < 28; j++) {
                    ckmv2[i, j] = ckmv[move2std[i], move2std[j]];
                }
            }
            for (int i = 0; i < 21; i++) {
                for (int j = 0; j < 20; j++) {
                    ckmv3[i, j] = ckmv[move3std[i], move3std[j]];
                }
            }
            for (int i = 0; i < 36; i++) {
                skipAxis[i] = 36;
                for (int j = i; j < 36; j++) {
                    if (!ckmv[i, j]) {
                        skipAxis[i] = j - 1;
                        break;
                    }
                }
            }
            for (int i = 0; i < 28; i++) {
                skipAxis2[i] = 28;
                for (int j = i; j < 28; j++) {
                    if (!ckmv2[i, j]) {
                        skipAxis2[i] = j - 1;
                        break;
                    }
                }
            }
            for (int i = 0; i < 20; i++) {
                skipAxis3[i] = 20;
                for (int j = i; j < 20; j++) {
                    if (!ckmv3[i, j]) {
                        skipAxis3[i] = j - 1;
                        break;
                    }
                }
            }
        }
    }
}
