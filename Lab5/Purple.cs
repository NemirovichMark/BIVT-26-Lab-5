using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;
            // code here
            int stl = matrix.GetLength(1);
            int[] array = new int[stl];

            int str = matrix.GetLength(0);
            for (int j = 0; j < stl; j++)
            {
                int c = 0;
                for (int i = 0; i < str; i++)
                {
                    if (matrix[i, j] < 0)
                        c++;
                }
                array[j] = c;
            }
            answer = array;
                // end

                return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int stl = matrix.GetLength(1);
            int str = matrix.GetLength(0);
            for (int i = 0; i < str; i++)
            {
                int m = int.MaxValue;
                int mini = -1;
                for (int j = 0; j < stl; j++)
                {
                    if (matrix[i, j] < m)
                    {
                        m = matrix[i, j];
                        mini = j;
                    }
                }
                for (int j = mini; j > 0; j--)
                    matrix[i, j] = matrix[i, j - 1];

                matrix[i, 0] = m;
            }

        }
             // end
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int stl = matrix.GetLength(1);
            int str = matrix.GetLength(0);
            int[,] ans = new int[str, stl + 1];
            for (int i = 0; i < str; i++)
            {
                int max = int.MinValue;
                int maxi = -1;
                for (int j = 0; j < stl; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxi = j;
                    }
                }
                for (int j = matrix.GetLength(1) - 1; j >= maxi; j--)
                    ans[i, j + 1] = matrix[i, j];
                for (int j = 0; j <= maxi; j++)
                    ans[i, j] = matrix[i, j];
            }
            answer = ans;
            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here
            int stl = matrix.GetLength(1);
            int str = matrix.GetLength(0);
            for (int i = 0; i < str; i++)
            {
                int max = int.MinValue;
                int maxi = -1;
                for (int j = 0; j < stl; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxi = j;
                    }
                }
                int s = 0;
                int c = 0;
                for (int j = maxi + 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        s += matrix[i, j];
                        c++;
                    }
                }
                int x = 0;
                if (c > 0)
                    x = s / c;
                else
                    continue;
                for (int j = 0; j < maxi; j++)
                {
                    if (matrix[i, j] < 0 & x > 0)
                        matrix[i, j] = x;
                }
            }
            // end

        }
        public void Task5(int[,] matrix, int k)
        {

            // code here
            int stl = matrix.GetLength(1);
            int str = matrix.GetLength(0);
            if (k >= 0 & k < stl)
            {
                int[] array = new int[matrix.GetLength(0)];
                for (int i = 0; i < str; i++)
                {
                    int m = int.MinValue;
                    for (int j = 0; j < stl; j++)
                    {
                        if (matrix[i, j] > m)
                            m = matrix[i, j];
                    }
                    array[i] = m;
                }
                int l = str - 1;
                for (int i = 0; i < str; i++)
                {
                    matrix[i, k] = array[l];
                    l--;
                }
            }
            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            int stl = matrix.GetLength(1);
            int str = matrix.GetLength(0);
            if (array.Length == stl)
            {
                for (int i = 0; i < stl; i++)
                {
                    int m = int.MinValue;
                    int maxi = -1;
                    for (int j = 0; j < str; j++)
                    {
                        if (matrix[j, i] > m)
                        {
                            m = matrix[j, i];
                            maxi = j;
                        }
                    }
                    if (m < array[i])
                        matrix[maxi, i] = array[i];
                }
            }
            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here
            int stl = matrix.GetLength(1);
            int str = matrix.GetLength(0);
            int[] minin = new int[matrix.GetLength(0)];
            int[][] x = new int[matrix.GetLength(0)][];
            for (int i = 0; i < str; i++)
                x[i] = new int[matrix.GetLength(1)];
            for (int i = 0; i < str; i++)
            {
                int min = int.MaxValue;
                int mini = -1;
                for (int j = 0; j < stl; j++)
                {
                    if (matrix[i, j] < min)
                        min = matrix[i, j];
                }

                minin[i] = min;
            }
            for (int i = 0; i < str; i++)
            {
                for (int j = 0; j < stl; j++)
                    x[i][j] = matrix[i, j];
            }
            for (int i = 0; i < str; i++)
            {
                for (int j = 0; j < str - i - 1; j++)
                    if (minin[j] < minin[j + 1])
                    {
                        (x[j], x[j + 1]) = (x[j + 1], x[j]);
                        (minin[j], minin[j + 1]) = (minin[j + 1], minin[j]);
                    }
            }
            for (int i = 0; i < str; i++)
            {
                for (int j = 0; j < stl; j++)
                    matrix[i, j] = x[i][j];
            }
            // end

        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int stl = matrix.GetLength(1);
            int str = matrix.GetLength(0);
            if (str != stl)
                return null;
            int n = str;
            int[] ans = new int[2*n - 1];
            for (int i = 0; i < str; i++)
            {
                for (int j = 0; j < stl; j++)
                    ans[j - i + n - 1] += matrix[i, j];
            }
            answer = ans;
            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here
            int stl = matrix.GetLength(1);
            int str = matrix.GetLength(0);
            if (str != stl)
                return;
            if (k >= str || k < 0)
                return;
            int r = 0, c = 0;
            for (int i = 0; i < str; i++)
            {
                for (int j = 0; j < stl; j++)
                {
                    if (Math.Abs(matrix[i, j]) > Math.Abs(matrix[r, c]))
                    {
                        r = i;
                        c = j;
                    }
                }
            }
            while (r != k)
            {
                int st = r > k ? -1 : 1;
                for (int j = 0; j < stl; j++)
                {
                    int temp = matrix[r, j];
                    matrix[r, j] = matrix[r + st, j];
                    matrix[r + st, j] = temp;
                }
                r += st;
            }
            while (c != k)
            {
                int st = c > k ? -1 : 1;
                for (int i = 0; i < str; i++)
                {
                    int temp = matrix[i, c];
                    matrix[i, c] = matrix[i, c + st];
                    matrix[i, c + st] = temp;
                }
                c += st;
            }
            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here
            int stla = A.GetLength(1);
            int stra = A.GetLength(0);
            int stlb = B.GetLength(1);
            int strb = B.GetLength(0);
            if (stla != strb)
                return null;
            int[,] ans = new int[stla, stlb];
            for (int i = 0; i < stla; i++)
            {
                for (int j = 0; j < stlb; j++)
                {
                    for (int t = 0; t < stra; t++)
                        ans[i, j] += A[i, t] * B[t, j];
                        
                }
            }
            answer = ans;
            // end

                return answer;
        }
        public int[][] Task11(int[,] matrix)
        {
            int[][] answer = null;

            // code here
            int str = matrix.GetLength(0);
            int stl = matrix.GetLength(1);
            int[][] ans = new int[str][];
            for (int i = 0; i < str; i++)
            {
                int c = 0;
                for (int j = 0; j < stl; j++)
                {
                    if (matrix[i, j] > 0)
                        c++;
                }
                ans[i] = new int[c];
                int ind = 0;
                for (int j = 0; j < stl; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        ans[i][ind] = matrix[i, j];
                        ind++;
                    }
                }
            }
            answer = ans;
            // end

            return answer;
        }
        public int[,] Task12(int[][] array)
        {
            int[,] answer = null;

            // code here
            int rs = 0;
            for (int i = 0; i < array.Length; i++)
                rs += array[i].Length;
            int x = 0;
            while (x*x < rs)
                x++;
            int[,] ans = new int[x, x];
            int k = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    ans[k/x, k%x] = array[i][j];
                    k++;
                }
            }
            answer = ans;
            // end

            return answer;
        }
    }
}
