using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CSTPR444SolverTranslation {
    internal class CornerCube {

        /*
         * 18 move cubes
         */
        private static CornerCube[] moveCube = new CornerCube[18];

        private static int[] cpmv = new int[] { 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1 };

        //Pitfall: sbyte or sbyte or int
        internal sbyte[] cp = new sbyte[] { 0, 1, 2, 3, 4, 5, 6, 7 };
        internal sbyte[] co = new sbyte[] { 0, 0, 0, 0, 0, 0, 0, 0 };

        CornerCube temps = null;//new CornerCube();

        internal CornerCube() {
        }

        internal CornerCube(Random r) : this(r.Next(40320), r.Next(2187)) { }

        internal CornerCube(int cperm, int twist) {
            this.setCPerm(cperm);
            this.setTwist(twist);
        }

        internal CornerCube(CornerCube c) {
            copy(c);
        }

        internal void copy(CornerCube c) {
            for (int i = 0; i < 8; i++) {
                this.cp[i] = c.cp[i];
                this.co[i] = c.co[i];
            }
        }

        internal int getParity() => Util.parity(cp);

        //Pitfall: sbyte or sbyte or int
        static sbyte[,] cornerFacelet = new sbyte[,]{
            { Moves.U9, Moves.R1, Moves.F3 }, { Moves.U7, Moves.F1, Moves.L3 }, {Moves. U1, Moves.L1, Moves.B3 }, { Moves.U3,Moves. B1, Moves.R3 },
            { Moves.D3, Moves.F9, Moves.R7 }, { Moves.D1, Moves.L9, Moves.F7 }, { Moves.D7, Moves.B9,Moves. L7 }, { Moves.D9, Moves.R9, Moves.B7 } };

        internal void fill333Facelet(char[] facelet) {
            for (int corn = 0; corn < 8; corn++) {
                int j = cp[corn];
                int ori = co[corn];
                for (int n = 0; n < 3; n++) {
                    facelet[cornerFacelet[corn, (n + ori) % 3]] = "URFDLB"[cornerFacelet[j, n] / 9];
                }
            }
        }

        /**
	 * prod = a * b, Corner Only.
	 */
        static void CornMult(CornerCube a, CornerCube b, CornerCube prod) {
            for (int corn = 0; corn < 8; corn++) {
                prod.cp[corn] = a.cp[b.cp[corn]];
                sbyte oriA = a.co[b.cp[corn]];
                sbyte oriB = b.co[corn];
                sbyte ori = oriA;
                ori = (sbyte)(ori + ((oriA < 3) ? oriB : 6 - oriB));
                ori %= 3;
                if ((oriA >= 3) ^ (oriB >= 3)) {
                    ori += 3;
                }
                prod.co[corn] = ori;
            }
        }

        void setTwist(int idx) {
            int twst = 0;
            for (int i = 6; i >= 0; i--) {
                twst += co[i] = (sbyte)(idx % 3);
                idx /= 3;
            }
            co[7] = (sbyte)((15 - twst) % 3);
        }

        void setCPerm(int idx) => Util.set8Perm(cp, idx);

        internal void move(int idx) {
            if (temps == null) {
                temps = new CornerCube();
            }
            CornMult(this, moveCube[idx], temps);
            copy(temps);
        }

        static CornerCube() => initMove();

        static void initMove() {
            moveCube[0] = new CornerCube(15120, 0);
            moveCube[3] = new CornerCube(21021, 1494);
            moveCube[6] = new CornerCube(8064, 1236);
            moveCube[9] = new CornerCube(9, 0);
            moveCube[12] = new CornerCube(1230, 412);
            moveCube[15] = new CornerCube(224, 137);
            for (int a = 0; a < 18; a += 3) {
                for (int p = 0; p < 2; p++) {
                    moveCube[a + p + 1] = new CornerCube();
                    CornMult(moveCube[a + p], moveCube[a], moveCube[a + p + 1]);
                }
            }
        }
    }
}