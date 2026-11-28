using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;

            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);

            if (matrix.Length == 0) return null;

            answer = new int[col];
            int k = 0;
            int c = 0;
            for (int j = 0; j < col;  j++)
            {
                c = 0;
                for (int i = 0; i < row; i++)
                {
                    if (matrix[i,j] < 0)
                    {
                        c++;
                    }
                }
                answer[k++] = c;
            }

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            if (matrix == null) return;
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);

            for (int i = 0;  i < row; i++)
            {
                int minI = 0;
                for (int j = 1; j < col; j++)
                {
                    if (matrix[i,j] < matrix[i,minI])
                    {
                        minI = j;
                    }
                }

                int min = matrix[i, minI];

                for (int j = minI; j > 0; j--)
                {
                    matrix[i, j] = matrix[i, j - 1];
                }

                matrix[i, 0] = min;
            }
        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;
            if (matrix == null) return null;
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);

            answer = new int[row, col+1];

            for (int i = 0; i < row; i++)
            {
                int maxI = 0;
                for (int j = 1; j < col; j++)
                {
                    if (matrix[i, j] > matrix[i, maxI])
                    {
                        maxI = j;
                    }
                }

                int max = matrix[i, maxI];

                for (int j = 0; j <= maxI; j++)
                {
                    answer[i, j] = matrix[i, j];
                }

                answer[i, maxI + 1] = max;

                for (int j = maxI+1; j < col; j++)
                {
                    answer[i, j+1] = matrix[i, j];
                }
            }

            return answer;
        }
        public void Task4(int[,] matrix)
        {
            if (matrix == null) return;
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);

            for (int i = 0; i < row; i++)
            {
                int maxI = 0;
                for (int j = 1; j < col; j++)
                {
                    if (matrix[i, j] > matrix[i, maxI])
                    {
                        maxI = j;
                    }
                }

                int s = 0;
                int k = 0;
                for (int j = maxI + 1; j < col; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        s += matrix[i, j];
                        k++;
                    }
                }

                if (k > 0)
                {
                    int avg = s / k;
                    for (int j = 0; j < maxI; j++)
                    {
                        if (matrix[i, j] < 0)
                        {
                            matrix[i, j] = avg;
                        }
                    }
                }
            }

            }
        public void Task5(int[,] matrix, int k)
        {
            if (matrix == null || k < 0) return;
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            if (k >= col) return;
            int[] max = new int[row];
            int l = 0;
            for (int i = 0; i < row; i++)
            {
                int maxI = 0;
                for (int j = 1; j < col; j++)
                {
                    if (matrix[i, j] > matrix[i, maxI])
                    {
                        maxI = j;
                    }
                }
                max[l++] = matrix[i, maxI];
            }

            for (int i = 0; i < row; i++)
            {
                matrix[i, k] = max[row - 1 - i];
            }
        }
        public void Task6(int[,] matrix, int[] array)
        {
            if (matrix == null || array == null) return;

            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);

            if (row == 0 || col == 0 || array.Length != col) return;

            for (int j = 0; j < col; j++)
            {
                int maxI = 0;

                for (int i = 1; i < row; i++)
                {
                    if (matrix[i, j] > matrix[maxI, j])
                    {
                        maxI = i;
                    }
                }

                if (array[j] > matrix[maxI, j])
                {
                    matrix[maxI, j] = array[j];
                }
            }
        }
        public void Task7(int[,] matrix)
        {

            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);

            if (row <= 1 || col == 0) return;

            int[] mins = new int[row];
            for (int i = 0; i < row; i++)
            {
                int min = matrix[i, 0];
                for (int j = 1; j < col; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                    }
                }
                mins[i] = min;
            }

            int[] order = new int[row];
            for (int i = 0; i < row; i++)
            {
                order[i] = i;
            }

            for (int i = 1; i < row; i++)
            {
                int cur = order[i];
                int p = i - 1;
                while (p >= 0 && mins[order[p]] < mins[cur])
                {
                    order[p + 1] = order[p];
                    p--;
                }
                order[p + 1] = cur;
            }

            int[,] temp = new int[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    temp[i, j] = matrix[order[i], j];
                }
            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = temp[i, j];
                }
            }
        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;
            int n = matrix.GetLength(0);

            if (n == 0 || n != matrix.GetLength(1)) return null;

            answer = new int[2 * n - 1];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    answer[j - i + n - 1] += matrix[i, j];
                }
            }

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            int n = matrix.GetLength(0);

            if (n == 0 || n != matrix.GetLength(1)) return;
            if (k < 0 || k >= n) return;

            int r = 0, c = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (Math.Abs(matrix[i, j]) > Math.Abs(matrix[r, c]))
                    {
                        r = i;
                        c = j;
                    }
                }
            }

            int[] rowOrder = new int[n];
            rowOrder[k] = r;
            int p = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == k) continue;
                if (p == r) p++;
                rowOrder[i] = p;
                p++;
            }

            int[] colOrder = new int[n];
            colOrder[k] = c;
            p = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == k) continue;
                if (p == c) p++;
                colOrder[i] = p;
                p++;
            }

            int[,] temp = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    temp[i, j] = matrix[rowOrder[i], colOrder[j]];
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = temp[i, j];
                }
            }

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            int n = A.GetLength(0);
            int m = A.GetLength(1);
            int p = B.GetLength(1);

            if (n == 0 || m == 0 || p == 0) return null;
            if (m != B.GetLength(0)) return null;

            answer = new int[n, p];

            for (int idx = 0; idx < n * p; idx++)
            {
                int i = idx / p;
                int j = idx % p;

                int sum = 0;
                for (int k = 0; k < m; k++)
                {
                    sum += A[i, k] * B[k, j];
                }
                answer[i, j] = sum;
            }

            return answer;
        }
        public int[][] Task11(int[,] matrix)
        {
            int[][] answer = null;

            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);

            answer = new int[row][];
            int jj, c;
            for (int i = 0; i < row; i++)
            {
                c = 0;
                for (int j = 0; j < col; j++)
                {
                    if (matrix[i, j] > 0) c++;
                }
                
                answer[i] = new int[c];
                if (c > 0)
                {
                    jj = 0;
                    for (int j = 0; j < col; j++)
                    {
                        if (matrix[i, j] > 0)
                        {
                            answer[i][jj++] = matrix[i, j];
                        }
                    }
                }
            }

            return answer;
        }
        public int[,] Task12(int[][] array)
        {
            int[,] answer = null;

            int s = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null)
                {
                    s += array[i].Length;
                }
            }

            int size = 1;
            while (size * size < s)
            {
                size++;
            }

            int[] f = new int[size * size];
            int k = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null) continue;

                for (int j = 0; j < array[i].Length; j++)
                {
                    f[k] = array[i][j];
                    k++;
                }
            }

            answer = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    answer[i, j] = f[i * size + j];
                }
            }

            return answer;
        }
    }
}
