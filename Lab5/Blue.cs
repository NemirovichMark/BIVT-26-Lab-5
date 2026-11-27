using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Blue
    {
        public double[] Task1(int[,] matrix)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            double[] answer = new double[n];
            for (int i = 0; i < n; i++)
            {
                double av = 0;
                int c = m;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        av += matrix[i, j];
                    }
                    else c--;
                }
                if (c != 0) answer[i] = av / c;
                else answer[i] = 0;
            }
            return answer;
        }
        public int[,] Task2(int[,] matrix)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int[,] answer = new int[n - 1, m - 1];
            int mr = 0, mc = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > matrix[mr, mc])
                    {
                        (mr, mc) = (i, j);
                    }
                }
            }
            int ic = 0;
            for (int i = 0; i < n; i++)
            {
                int ir = 0;
                if (i == mr) 
                { 
                    ic = 1; 
                    continue; 
                }
                for (int j = 0; j < m; j++)
                {
                    
                    if (j == mc)
                    {
                        ir = 1;
                        continue;
                    }
                    answer[i - ic, j - ir] = matrix[i, j];
                }
            }
            return answer;
        }
        public void Task3(int[,] matrix)
        {
            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);
            for (int i = 0; i < r; i++)
            {
                int mxi = 0;
                for (int j = 0; j < c; j++)
                {
                    if (matrix[i, j] > matrix[i, mxi]) mxi = j;
                }
                int xd = 0;
                int mx = matrix[i, mxi];
                for (int j = 0; j < c; ++j)
                {
                    if (j == mxi)
                    {
                        xd = 1;
                        continue;
                    }
                    matrix[i, j - xd] = matrix[i, j];
                }
                matrix[i, c - 1] = mx;
            }
            

        }
        public int[,] Task4(int[,] matrix)
        {
            int r = matrix.GetLength(0), c = matrix.GetLength(1);
            int[,] answer = new int[r, c + 1];
            for (int i = 0; i < r; i++)
            {
                int mx = matrix[i, 0];
                for (int j = 0; j < c; j++)
                {
                    mx = Math.Max(mx, matrix[i, j]);
                }
                for (int j = 0; j < c - 1; j++)
                {
                    answer[i, j] = matrix[i, j];
                }
                (answer[i, c - 1], answer[i, c]) = (mx, matrix[i, c - 1]);
            }

            return answer;
        }
        public int[] Task5(int[,] matrix)
        {
            int r = matrix.GetLength(0), c = matrix.GetLength(1);
            int[] temp = new int[matrix.Length];
            int[] answer = null;
            int xd = 0;
            for (int i = 0; i < r; i++)
            {
                for (int j = 0;j < c; j++)
                {
                    if ((i + j) % 2 == 1)
                    {
                        temp[xd] = matrix[i, j];
                        xd++;
                    }
                }
            }
            answer = temp[..xd];
            return answer;
        }
        public void Task6(int[,] matrix, int k)
        {
            bool ob = false;
            int ki = 0;
            int r = matrix.GetLength(0), c = matrix.GetLength(1);
            if (k < 0 || k >= c || r != c) return;
            for (int i = 0; i < r; i++)
            {
                if (matrix[i,k] < 0)
                {
                    ob = true;
                    ki = i;
                    break;
                }
            }
            if (!ob) return;
            int mxi = 0;
            for (int i = 0; i < r && i < c; i++)
            {
                if (matrix[i, i] > matrix[mxi, mxi])
                {
                    mxi = i;
                }
            }
            if (mxi == ki) return;
            for (int i = 0; i < c; i++)
            {
                (matrix[mxi, i], matrix[ki, i]) = (matrix[ki, i], matrix[mxi, i]);
            }
            
        }
        public void Task7(int[,] matrix, int[] array)
        {
            int r = matrix.GetLength(0), c = matrix.GetLength(1);
            if (c < 2 || c != array.Length) return;
            int mxr = 0;
            for (int i = 0; i < r; i++)
            {
                if (matrix[mxr, c - 2] < matrix[i, c - 2]) mxr = i;
            }
            for (int i = 0; i < c; i++)
            {
                matrix[mxr, i] = array[i];
            }
        }
        public void Task8(int[,] matrix)
        {
            int r = matrix.GetLength(0), c = matrix.GetLength(1);
            int cr7 = r / 2;
            for (int i = 0; i < c; i++)
            {
                int mxi = 0;
                for (int j = 0; j < r; j++)
                {
                    if (matrix[j, i] > matrix[mxi, i]) mxi = j;
                }
                if (mxi >= cr7) continue;
                int s = 0;
                for (int j = mxi + 1; j < r; j++)
                {
                    s += matrix[j, i];
                }
                matrix[0, i] = s;
            }
        }
        public void Task9(int[,] matrix)
        {
            int r = matrix.GetLength(0), c = matrix.GetLength(1);
            int mxi1, mxi2;
            for (int i = 0; i < r - r % 2; i += 2)
            {
                mxi1 = 0;
                for (int j = 0; j < c; j++)
                {
                    if (matrix[i, mxi1] < matrix[i, j]) mxi1 = j;
                }
                mxi2 = 0;
                for (int j = 0; j < c; j++)
                {
                    if (matrix[i + 1, mxi2] < matrix[i + 1, j]) mxi2 = j;
                }
                (matrix[i, mxi1], matrix[i + 1, mxi2]) = (matrix[i + 1, mxi2], matrix[i, mxi1]);
            }
        }
        public void Task10(int[,] matrix)
        {
            int r = matrix.GetLength(0), c = matrix.GetLength(1);
            if (r != c) return;
            int mxi = 0;
            for (int i = 0; i < r && i < c; i++)
            {
                if (matrix[i, i] > matrix[mxi, mxi]) mxi = i;
            }
            for (int i = 0; i < mxi; i++)
            {
                for (int j = i + 1; j < c; j++)
                {
                    matrix[i, j] = 0;
                } 
            }

        }
        public void Task11(int[,] matrix)
        {
            int r = matrix.GetLength(0), c = matrix.GetLength(1);
            int[] xd = new int[r];
            for (int i = 0; i < r; i++)
            {
                int s = 0;
                for (int j = 0; j < c; j++)
                {
                    if (matrix[i, j] > 0) s++;
                }
                xd[i] = s;
            }
            int it = 0;
            while (it < r)
            {
                if (it == 0 || xd[it] <= xd[it - 1]) it++;
                else
                {
                    (xd[it], xd[it - 1]) = (xd[it - 1], xd[it]);
                    for (int i = 0; i < c; i++)
                    {
                        (matrix[it, i], matrix[it - 1, i]) = (matrix[it - 1, i], matrix[it, i]);
                    }
                    it--;
                }
            }


        }
        public int[][] Task12(int[][] array)
        {
            int[][] answer = new int[array.Length][];
            int s = 0, c = 0;
            for (int i = 0; i < array.Length; i++)
            {
                foreach (int j in array[i]) s += j;
                c += array[i].Length;
            }
            double sr = s / (double)c, xd = 0;
            int it = 0;
            for (int i = 0; i < array.Length; i++)
            {
                xd = 0;
                foreach (int j in array[i]) xd += j;
                xd /= array[i].Length;
                if (xd >= sr)
                {
                    answer[it] = array[i];
                    it++;
                }
            }
            return answer[..it];
        }
    }
}