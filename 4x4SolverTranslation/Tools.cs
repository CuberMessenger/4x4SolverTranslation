using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSTPR444SolverTranslation {
    public class Tools {
        private static void read(int[] arr, BinaryReader input) {
            for (int i = 0, len = arr.Length; i < len; i++) {
                arr[i] = input.ReadInt32();
            }
        }

        private static void write(int[] arr, BinaryWriter output) {
            for (int i = 0, len = arr.Length; i < len; i++) {
                output.Write(arr[i]);
            }
        }

        private static void read(int[,] arr, BinaryReader input) {
            for (int i = 0, leng = arr.GetLength(0); i < leng; i++) {
                for (int j = 0, len = arr.GetLength(1); j < len; j++) {
                    arr[i, j] = input.ReadInt32();
                }
            }
        }

        private static void write(int[,] arr, BinaryWriter output) {
            for (int i = 0, leng = arr.GetLength(0); i < leng; i++) {
                for (int j = 0, len = arr.GetLength(1); j < len; j++) {
                    output.Write(arr[i, j]);
                }
            }
        }

        static Random r = new Random();

        public static string randomCube() {
            return randomCube(r);
        }

        public static string randomCube(Random r) {
            FullCube c = new FullCube(r);
            sbyte[] f = new sbyte[96];
            c.toFacelet(f);
            StringBuilder sb = new StringBuilder();
            foreach (sbyte i in f) {
                sb.Append("URFDLB"[i]);
            }
            return sb.ToString();
        }

        public static void initFrom(BinaryReader input) {
            if (Search.inited) {
                return;
            }

            //System.out.println("Initialize Center1 Solver...");

            Center1.initSym();
            Center1.initSym2Raw();
            read(Center1.ctsmv, input);
            Center1.createPrun();

            //System.out.println("Initialize Center2 Solver...");

            Center2.init();

            //System.out.println("Initialize Center3 Solver...");

            Center3.init();

            //System.out.println("Initialize Edge3 Solver...");

            Edge3.initMvrot();
            Edge3.initRaw2Sym();
            read(Edge3.eprun, input);

            //System.out.println("OK");

            Search.inited = true;
        }

        public static void saveTo(BinaryWriter output) {
            if (!Search.inited) {
                Search.init();
            }
            write(Center1.ctsmv, output);
            write(Edge3.eprun, output);
        }
    }
}
