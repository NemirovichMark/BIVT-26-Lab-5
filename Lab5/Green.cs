using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Green
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            answer = new int[n];

            for (int i = 0; i < n; i++)
            {
                int min = matrix[i, 0];
                int idx = 0;
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        idx = j;
                    }
                }
                answer[i] = idx;
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            for (int i = 0; i < n; i++)
            {
                int max = matrix[i, 0];
                int idx = 0;
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        idx = j;
                    }
                }

                if (max != 0)
                {
                    for (int j = 0; j < idx; j++)
                    {
                        if (matrix[i, j] < 0)
                        {
                            matrix[i, j] = (int)Math.Floor((double)matrix[i, j] / max);
                        }
                    }
                }
            }
            // end

        }
        public void Task3(int[,] matrix, int k)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (n == m && k >= 0 && k < m)
            {
                int max = matrix[0, 0];
                int col = 0;
                for (int i = 1; i < n; i++)
                {
                    if (matrix[i, i] > max)
                    {
                        max = matrix[i, i];
                        col = i;
                    }
                }

                if (col != k)
                {
                    for (int i = 0; i < n; i++)
                    {
                        int t = matrix[i, k];
                        matrix[i, k] = matrix[i, col];
                        matrix[i, col] = t;
                    }
                }
            }
            // end

        }
        public void Task4(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (n == m)
            {
                int max = matrix[0, 0];
                int idx = 0;
                for (int i = 1; i < n; i++)
                {
                    if (matrix[i, i] > max)
                    {
                        max = matrix[i, i];
                        idx = i;
                    }
                }

                for (int i = 0; i < n; i++)
                {
                    int t = matrix[idx, i];
                    matrix[idx, i] = matrix[i, idx];
                    matrix[i, idx] = t;
                }
            }
            // end

        }
        public int[,] Task5(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int max = 0;
            int row = 0;

            for (int i = 0; i < n; i++)
            {
                int s = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        s += matrix[i, j];
                    }
                }

                if (s > max)
                {
                    max = s;
                    row = i;
                }
            }

            answer = new int[n - 1, m];
            int r = 0;
            for (int i = 0; i < n; i++)
            {
                if (i != row)
                {
                    for (int j = 0; j < m; j++)
                    {
                        answer[r, j] = matrix[i, j];
                    }
                    r++;
                }
            }
            // end

            return answer;
        }
        public void Task6(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int min = m + 1;
            int max = -1;
            int r1 = 0;
            int r2 = 0;

            for (int i = 0; i < n; i++)
            {
                int c = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        c++;
                    }
                }

                if (c < min)
                {
                    min = c;
                    r1 = i;
                }
                if (c > max)
                {
                    max = c;
                    r2 = i;
                }
            }

            if (min != max && r1 != r2)
            {
                for (int j = 0; j < m; j++)
                {
                    int t = matrix[r1, j];
                    matrix[r1, j] = matrix[r2, j];
                    matrix[r2, j] = t;
                }
            }
            // end

        }
        public int[,] Task7(int[,] matrix, int[] array)
        {
            int[,] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (array == null || array.Length != n)
            {
                answer = new int[n, m];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        answer[i, j] = matrix[i, j];
                    }
                }
            }
            else
            {
                int min = matrix[0, 0];
                int col = 0;

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (matrix[i, j] < min)
                        {
                            min = matrix[i, j];
                            col = j;
                        }
                    }
                }

                answer = new int[n, m + 1];
                for (int i = 0; i < n; i++)
                {
                    int c = 0;
                    for (int j = 0; j < m; j++)
                    {
                        answer[i, c] = matrix[i, j];
                        c++;
                        if (j == col)
                        {
                            answer[i, c] = array[i];
                            c++;
                        }
                    }
                }
            }
            // end

            return answer;
        }
        public void Task8(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            for (int j = 0; j < m; j++)
            {
                int pos = 0;
                int neg = 0;
                int max = matrix[0, j];
                int row = 0;

                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, j] > 0) pos++;
                    else if (matrix[i, j] < 0) neg++;

                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        row = i;
                    }
                }

                if (pos > neg)
                {
                    matrix[row, j] = 0;
                }
                else if (neg > pos)
                {
                    matrix[row, j] = row;
                }
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (n == m)
            {
                for (int i = 0; i < n; i++)
                {
                    matrix[0, i] = 0;
                    matrix[n - 1, i] = 0;
                    matrix[i, 0] = 0;
                    matrix[i, n - 1] = 0;
                }
            }
            // end

        }
        public (int[] A, int[] B) Task10(int[,] matrix)
        {
            int[] A = null, B = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (n != m)
            {
                A = null;
                B = null;
            }
            else
            {
                A = new int[n * (n + 1) / 2];
                B = new int[n * (n - 1) / 2];

                int ia = 0;
                int ib = 0;

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (j >= i)
                        {
                            A[ia] = matrix[i, j];
                            ia++;
                        }
                        else
                        {
                            B[ib] = matrix[i, j];
                            ib++;
                        }
                    }
                }
            }
            // end

            return (A, B);
        }
        public void Task11(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            for (int j = 0; j < m; j++)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    for (int k = 0; k < n - 1 - i; k++)
                    {
                        if (j % 2 == 0)
                        {
                            if (matrix[k, j] < matrix[k + 1, j])
                            {
                                int t = matrix[k, j];
                                matrix[k, j] = matrix[k + 1, j];
                                matrix[k + 1, j] = t;
                            }
                        }
                        else
                        {
                            if (matrix[k, j] > matrix[k + 1, j])
                            {
                                int t = matrix[k, j];
                                matrix[k, j] = matrix[k + 1, j];
                                matrix[k + 1, j] = t;
                            }
                        }
                    }
                }
            }
            // end

        }
        public void Task12(int[][] array)
        {

            // code here
            if (array != null && array.Length > 1)
            {
                int n = array.Length;
                int[] sums = new int[n];

                for (int i = 0; i < n; i++)
                {
                    if (array[i] != null)
                    {
                        int s = 0;
                        for (int j = 0; j < array[i].Length; j++)
                        {
                            s += array[i][j];
                        }
                        sums[i] = s;
                    }
                }

                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - 1 - i; j++)
                    {
                        int l1 = 0;
                        if (array[j] != null) l1 = array[j].Length;

                        int l2 = 0;
                        if (array[j + 1] != null) l2 = array[j + 1].Length;

                        if (l1 < l2 || (l1 == l2 && sums[j] < sums[j + 1]))
                        {
                            int[] t = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = t;

                            int ts = sums[j];
                            sums[j] = sums[j + 1];
                            sums[j + 1] = ts;
                        }
                    }
                }
            }
            // end

        }
    }
}
