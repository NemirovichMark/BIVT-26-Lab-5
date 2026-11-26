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
            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);
            answer = new int[c];

            for (int j = 0; j < c; j++)
            {
                int k = 0;
                for (int i = 0; i < r; i++)
                {
                    if (matrix[i, j] < 0) k++;
                }
                answer[j] = k;
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);

            for (int i = 0; i < r; i++)
            {
                int m = 0;
                for (int j = 1; j < c; j++)
                {
                    if (matrix[i, j] < matrix[i, m]) m = j;
                }

                int v = matrix[i, m];
                for (int j = m; j > 0; j--)
                {
                    matrix[i, j] = matrix[i, j - 1];
                }
                matrix[i, 0] = v;
            }
            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);
            answer = new int[r, c + 1];

            for (int i = 0; i < r; i++)
            {
                int m = 0;
                for (int j = 1; j < c; j++)
                {
                    if (matrix[i, j] > matrix[i, m]) m = j;
                }

                for (int j = 0; j <= m; j++)
                {
                    answer[i, j] = matrix[i, j];
                }
                answer[i, m + 1] = matrix[i, m];
                for (int j = m + 1; j < c; j++)
                {
                    answer[i, j + 1] = matrix[i, j];
                }
            }
            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here
            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);

            for (int i = 0; i < r; i++)
            {
                int m = 0;
                for (int j = 1; j < c; j++)
                {
                    if (matrix[i, j] > matrix[i, m]) m = j;
                }

                int s = 0;
                int k = 0;
                for (int j = m + 1; j < c; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        s += matrix[i, j];
                        k++;
                    }
                }

                if (k > 0)
                {
                    int a = s / k;
                    for (int j = 0; j < m; j++)
                    {
                        if (matrix[i, j] < 0) matrix[i, j] = a;
                    }
                }
            }
            // end

        }
        public void Task5(int[,] matrix, int k)
        {

            // code here
            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);

            if (k >= 0 && k < c)
            {
                int[] b = new int[r];
                for (int i = 0; i < r; i++)
                {
                    int m = matrix[i, 0];
                    for (int j = 1; j < c; j++)
                    {
                        if (matrix[i, j] > m) m = matrix[i, j];
                    }
                    b[r - 1 - i] = m;
                }

                for (int i = 0; i < r; i++)
                {
                    matrix[i, k] = b[i];
                }
            }
            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);

            if (array != null && array.Length == c)
            {
                for (int j = 0; j < c; j++)
                {
                    int m = 0;
                    for (int i = 1; i < r; i++)
                    {
                        if (matrix[i, j] > matrix[m, j]) m = i;
                    }

                    if (array[j] > matrix[m, j])
                    {
                        matrix[m, j] = array[j];
                    }
                }
            }
            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here
            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);

            int[] b = new int[r];
            int[] p = new int[r];
            for (int i = 0; i < r; i++)
            {
                int m = matrix[i, 0];
                for (int j = 1; j < c; j++)
                {
                    if (matrix[i, j] < m) m = matrix[i, j];
                }
                b[i] = m;
                p[i] = i;
            }

            for (int i = 0; i < r - 1; i++)
            {
                for (int j = 0; j < r - 1 - i; j++)
                {
                    if (b[j] < b[j + 1])
                    {
                        int t = b[j];
                        b[j] = b[j + 1];
                        b[j + 1] = t;

                        int q = p[j];
                        p[j] = p[j + 1];
                        p[j + 1] = q;
                    }
                }
            }

            int[,] d = new int[r, c];
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    d[i, j] = matrix[p[i], j];
                }
            }

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    matrix[i, j] = d[i, j];
                }
            }
            // end

        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);

            if (r == c)
            {
                answer = new int[2 * r - 1];
                for (int i = 0; i < r; i++)
                {
                    for (int j = 0; j < c; j++)
                    {
                        int d = j - i + r - 1;
                        answer[d] += matrix[i, j];
                    }
                }
            }
            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here
            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);

            if (r == c && k >= 0 && k < r)
            {
                int x = 0;
                int y = 0;
                for (int i = 0; i < r; i++)
                {
                    for (int j = 0; j < c; j++)
                    {
                        if (Math.Abs(matrix[i, j]) > Math.Abs(matrix[x, y]))
                        {
                            x = i;
                            y = j;
                        }
                    }
                }

                while (x < k)
                {
                    for (int j = 0; j < c; j++)
                    {
                        int t = matrix[x, j];
                        matrix[x, j] = matrix[x + 1, j];
                        matrix[x + 1, j] = t;
                    }
                    x++;
                }
                while (x > k)
                {
                    for (int j = 0; j < c; j++)
                    {
                        int t = matrix[x, j];
                        matrix[x, j] = matrix[x - 1, j];
                        matrix[x - 1, j] = t;
                    }
                    x--;
                }

                while (y < k)
                {
                    for (int i = 0; i < r; i++)
                    {
                        int t = matrix[i, y];
                        matrix[i, y] = matrix[i, y + 1];
                        matrix[i, y + 1] = t;
                    }
                    y++;
                }
                while (y > k)
                {
                    for (int i = 0; i < r; i++)
                    {
                        int t = matrix[i, y];
                        matrix[i, y] = matrix[i, y - 1];
                        matrix[i, y - 1] = t;
                    }
                    y--;
                }
            }
            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here
            int r = A.GetLength(0);
            int c = A.GetLength(1);
            int m = B.GetLength(0);
            int n = B.GetLength(1);

            if (c == m)
            {
                answer = new int[r, n];
                int t = r * n;
                for (int p = 0; p < t; p++)
                {
                    int i = p / n;
                    int j = p % n;
                    int s = 0;
                    for (int k = 0; k < c; k++)
                    {
                        s += A[i, k] * B[k, j];
                    }
                    answer[i, j] = s;
                }
            }
            // end

            return answer;
        }
        public int[][] Task11(int[,] matrix)
        {
            int[][] answer = null;

            // code here
            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);
            answer = new int[r][];

            for (int i = 0; i < r; i++)
            {
                int k = 0;
                for (int j = 0; j < c; j++)
                {
                    if (matrix[i, j] > 0) k++;
                }

                answer[i] = new int[k];
                int p = 0;
                for (int j = 0; j < c; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        answer[i][p] = matrix[i, j];
                        p++;
                    }
                }
            }
            // end

            return answer;
        }
        public int[,] Task12(int[][] array)
        {
            int[,] answer = null;

            // code here
            if (array != null)
            {
                int k = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] != null) k += array[i].Length;
                }
                if (k == 0)
                {
                    answer = new int[0, 0];
                }
                else
                {
                    int n = 1;
                    while (n * n < k) n++;
                    answer = new int[n, n];
                    int x = 0;
                    int y = 0;
                    for (int i = 0; i < array.Length; i++)
                    {
                        for (int j = 0; j < array[i].Length; j++)
                        {
                            answer[x, y] = array[i][j];
                            y++;
                            if (y == n)
                            {
                                y = 0;
                                x++;
                            }
                        }
                    }
                }
            }
            // end

            return answer;
        }
    }
}
