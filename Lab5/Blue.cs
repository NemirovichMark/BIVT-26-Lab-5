using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Blue
    {
        public double[] Task1(int[,] matrix)
        {
            double[] answer = null;


            if (matrix == null) 
                return null;

            int a = matrix.GetLength(0);
            int b = matrix.GetLength(1);


            if (a == 0) 
                return new double[0];

            answer = new double[a];

            for (int i = 0; i < a; i++)
            {
                double sum = 0;
                int cnt = 0;
                for (int j = 0; j < b; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];

                        cnt++;
                    }
                }
                if (cnt > 0)
                { answer[i] = sum / cnt; }
                else 
                    answer[i] = 0;
            }


            // end

            return answer;
        }
        public int[,] Task2(int[,] matrix)
        {
            int[,] answer = null;

            if (matrix == null)
                return null;
            int a2 = matrix.GetLength(0);
            int b2 = matrix.GetLength(1);

            if (a2 == 0 || b2 == 0) 
                return new int[a2, b2];

            int maxx = matrix[0, 0];

            int maxx1 = 0;
            // вроде а

            int maxx2 = 0;
            // вроде б

            for (int i = 0; i < a2; i++)
            {
                for (int j = 0; j < b2; j++)
                {
                    if (matrix[i, j] > maxx)
                    {
                        maxx = matrix[i, j];
                        maxx1 = i;
                        maxx2 = j;
                    }
                }
            }

            int new_a = a2 - 1;
            if (new_a < 0)
            {
                new_a = 0;
            }

            int new_b = b2 - 1;
            if (new_b < 0)
            {
                new_b = 0;
            }

            answer = new int[new_a, new_b];

            int ansI = 0;
            for (int i = 0; i < a2; i++)
            {
                if (i == maxx1) 
                    continue;
                int ansJ = 0;
                for (int j = 0; j < b2; j++)
                {
                    if (j == maxx2)
                        continue;
                    answer[ansI, ansJ] = matrix[i, j];
                    ansJ++;
                }
                ansI++;
            }

            return answer;
        }

        public void Task3(int[,] matrix)
        {
            if (matrix == null) 
                return;

            int a3 = matrix.GetLength(0);
            int b3 = matrix.GetLength(1);

            for (int i = 0; i < a3; i++)
            {
                if (b3 == 0) 
                    continue;
                int maxx = matrix[i, 0];
                int maxJ = 0;

                for (int j = 1; j < b3; j++)
                {
                    if (matrix[i, j] > maxx)
                    {
                        maxx = matrix[i, j];
                        maxJ = j;
                    }
                }

                for (int j = maxJ; j < b3 - 1; j++)
                {
                    matrix[i, j] = matrix[i, j + 1];
                }
                matrix[i, b3 - 1] = maxx;
            }
        }

        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            if (matrix == null)
                return null;

            int a4 = matrix.GetLength(0);
            int b4 = matrix.GetLength(1);

            if (b4 == 0) 

                return new int[a4, 0];

            answer = new int[a4, b4 + 1];

            for (int i = 0; i < a4; i++)
            {
                int maxx = matrix[i, 0];
                for (int j = 1; j < b4; j++)
                {
                    if (matrix[i, j] > maxx)

                        maxx = matrix[i, j];
                }

                for (int j = 0; j < b4 - 1; j++)
                {
                    answer[i, j] = matrix[i, j];
                }
                answer[i, b4 - 1] = maxx;

                answer[i, b4] = matrix[i, b4 - 1];
            }

            return answer;
        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            if (matrix == null) 
                return null;

            int a5 = matrix.GetLength(0);
            int b5 = matrix.GetLength(1);

            int cnt = 0;
            for (int i = 0; i < a5; i++)
            {
                for (int j = 0; j < b5; j++)
                {
                    if ((i + j) % 2 != 0) 
                        // cnt = cnt+1
                        cnt++;
                }
            }

            answer = new int[cnt];
            int ind = 0;

            for (int i = 0; i < a5; i++)
            {
                for (int j = 0; j < b5; j++)
                {
                    if ((i + j) % 2 != 0)
                    {
                        answer[ind] = matrix[i, j];
                        ind++;
                    }
                }
            }

            return answer;
        }

        public void Task6(int[,] matrix, int k)
        {
            if (matrix == null)
                return;

            int a6 = matrix.GetLength(0);
            int b6 = matrix.GetLength(1);

            if (a6 != b6 || k < 0 ||  k >= b6 || a6 == 0) 
                
                return;

            int maxxdi = matrix[0, 0];
            int maxx2 = 0;

            for (int i = 1; i < a6; i++)
            {
                if (matrix[i, i] > maxxdi)
                {
                    maxxdi = matrix[i, i];
                    maxx2 = i;
                }
            }

            int help = -1;
            for (int i = 0; i < a6; i++)
            {
                if (matrix[i, k] < 0)
                {
                    help = i;
                    break;
                }
            }

            if (help != -1 && maxx2 != help)
            {
                for (int j = 0; j < b6; j++)
                {
                    int temp = matrix[maxx2, j];
                    matrix[maxx2, j] = matrix[help, j];
                    matrix[help, j] = temp;

                }
            }


        }

        public void Task7(int[,] matrix, int[] array)
        {
            int a7 = matrix.GetLength(0);
            int b7 = matrix.GetLength(1);

            if (b7 < 2 || array.Length != b7)
            {
                return;
            }
            int ind = 0;
            int maxx = int.MinValue;
            for (int j =b7 - 2; j < b7- 1; j++)
            {
                for (int i = 0; i < a7; i++)
                {
                    if (matrix[i, j] > maxx)
                    {
                        ind = i;
                        maxx = matrix[i, j];
                    }
                }
            }
            for (int i = 0; i < b7; i++)
            {
                matrix[ind, i] = array[i];
            }
        }

        public void Task8(int[,] matrix)
        {
            if (matrix == null)
                return;
            int a8 = matrix.GetLength(0);
            int b8 = matrix.GetLength(1);
            if (a8 == 0 || b8 == 0) return;

            int[] maxx = new int[b8];

            for (int j = 0; j < b8; j++)
            {
                int maxx2 = matrix[0, j];
                maxx[j] = 0;
                for (int i = 1; i < a8; i++)
                {
                    if (matrix[i, j] > maxx2)
                    {
                        //maxx = matrix[i, j];
                        maxx2 = matrix[i, j];
                        maxx[j] = i;
                    }
                }
            }

            int pol = a8 / 2;

            for (int j = 0; j < b8; j++)
            {
                if (maxx[j] < pol)
                {
                    int summ = 0;
                    for (int i = maxx[j] + 1; i < a8; i++)
                    {
                        summ += matrix[i, j];
                    }
                    matrix[0, j] = summ;
                }
            }
        }

        public void Task9(int[,] matrix)
        {

            int a9 = matrix.GetLength(0);
            int b9 = matrix.GetLength(1);


            for (int i = 0; i + 1 < a9; i += 2)
            {
                int inx = 0;

                int iny = 0;
                for (int j = 1; j < b9; j++)

                {
                    if (matrix[i, j] > matrix[i, inx])
                    {
                        inx = j;

                    }

                }

                for (int j = 1; j < b9; j++)
                {
                    if (matrix[i + 1, j] > matrix[i + 1, iny])
                    {
                        iny = j;
                    }
                }
                int t = matrix[i, inx];
                matrix[i, inx] = matrix[i + 1, iny];
                matrix[i + 1, iny] = t;
            }
        }

        public void Task10(int[,] matrix)
        {
            if (matrix == null) 
                return;
            int a10 = matrix.GetLength(0);

            int b10 = matrix.GetLength(1);
            if (a10 != b10 || a10 == 0) 

                return;

            int maxxd = matrix[0, 0];
            int maxxl = 0;

            for (int i = 1; i < a10; i++)
            {
                if (matrix[i, i] > maxxd)
                {
                    maxxd = matrix[i, i];
                    maxxl = i;
                }
            }

            for (int i = 0; i < maxxl; i++)
            {

                for (int j = i + 1; j < b10; j++)
                {
                    matrix[i, j] = 0;  }
              


            }
        }

        public void Task11(int[,] matrix)
        {
            int a11 = matrix.GetLength(0);

            int b11 = matrix.GetLength(1);
            int[] neww = new int[a11];

            for (int i = 0; i < a11; i++)
            {
                for (int j = 0; j < b11; j++)
                {

                    if (matrix[i, j] > 0) 

                        neww[i]++;
                }
            }

            for (int i = 1; i < a11; i++)
            {
                int vot = neww[i];
                int[] newb = new int[b11];
                for (int j = 0; j < b11; j++) newb[j] = matrix[i, j];

                int z = i - 1;
                while (z >= 0 && neww[z] < vot)
                {
                    neww[z + 1] = neww[z];
                    for (int j = 0; j < b11; j++)
                        matrix[z + 1, j] = matrix[z, j];
                    z--;
                }

                neww[z + 1] = vot;

                for (int j = 0; j < b11; j++)
                    matrix[z + 1, j] = newb[j];
            }
        }

        public int[][] Task12(int[][] array)
        {
            int[][] answer = null;

            if (array == null)
                return null;


            if (array.Length == 0) 
                return new int[0][];

            long summ = 0;
            int cnt = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null)
                {
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        summ += array[i][j];
                        cnt++;
                    }
                }
            }

            double hz = 0;
            if (cnt > 0)
            { hz = (double)summ / cnt; }
            int eshe = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null || array[i].Length == 0)
                {

                    if (0 >= hz) 
                        eshe++;
                }
                else
                {
                    long summ1 = 0;
                    for (int j = 0; j < array[i].Length; j++)
                        summ1 += array[i][j];

                    double lin = (double)summ1 / array[i].Length;

                    if (lin >= hz) 
                        
                        eshe++;
                }
            }
            answer = new int[eshe][];
            int ansI = 0;

            for (int i = 0; i < array.Length; i++)
            {
                bool keep = false;
                // флаг на фолсе

                if (array[i] == null || array[i].Length == 0)
                {
                    if (0 >= hz) 
                        keep = true;
                }

                else
                {
                    long sum = 0;
                    for (int j = 0; j < array[i].Length; j++)

                        sum += array[i][j];
                    double l = (double)sum / array[i].Length;
                    if (l >= hz)
                        keep = true;
                }

                if (keep)
                {
                    if (array[i] == null) 

                        answer[ansI] = new int[0];
                    else
                    {
                        answer[ansI] = new int[array[i].Length];
                        for (int j = 0; j < array[i].Length; j++)
                        {
                            answer[ansI][j] = array[i][j];
                        }
                    }
                    ansI++;
                }
            }

            return answer;
        }
    }
}
