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
            answer = new int[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        answer[j]++;
                    }
                }
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
                int minI = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, minI] > matrix[i, j])
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
            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            answer = new int[n, m + 1];

            for (int i = 0; i < n; i++)
            {
                int max = matrix[i, 0];
                int maxI = 0;
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxI = j;
                    }
                }
                for (int j = 0; j <= maxI; j++)
                {
                    answer[i, j] = matrix[i, j];
                }
                answer[i, maxI + 1] = max;
                for (int j = maxI + 1; j < m; j++)
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
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                int max = matrix[i, 0];
                int maxI = 0;
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxI = j;
                    }
                }
                int sum = 0;
                int c = 0;
                for (int j = maxI + 1; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        c++;
                    }
                }
                if (c == 0)
                {
                    continue;
                }
                int mid = sum / c;
                for (int j = 0; j < maxI; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        matrix[i, j] = mid;
                    }
                }
            }
            // end

        }
        public void Task5(int[,] matrix, int k)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (k < 0 || k >= m)
            {
                return;
            }
            int[] maxes = new int[n];
            for (int i = 0; i < n; i++)
            {
                maxes[i] = matrix[i, 0];
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] > maxes[i])
                    {
                        maxes[i] = matrix[i, j];
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                matrix[i, k] = maxes[n - 1 - i];
            }
            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i < m && i < array.Length; i++)
            {
                int max = matrix[0, i];
                int maxN = 0;
                for (int j = 1; j < n; j++)
                {
                    if (matrix[j, i] > max)
                    {
                        max = matrix[j, i];
                        maxN = j;
                    }
                }
                if (array[i] > max)
                {
                    matrix[maxN, i] = array[i];
                }
            }
            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[] mins = new int[n];
            int[] order = new int[n];
            for (int i = 0; i < n; i++)
            {
                order[i] = i;
                mins[i] = matrix[i, 0];
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] < mins[i])
                    {
                        mins[i] = matrix[i, j];
                    }
                }
            }
            for (int i = 1; i < n; i++)
            {
                int key = order[i];
                int p = i - 1;
                while (p >= 0 && mins[order[p]] < mins[key])
                {
                    order[p + 1] = order[p];
                    p--;
                }
                order[p + 1] = key;
            }
            int[,] copy = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    copy[i, j] = matrix[i, j];
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = copy[order[i], j];
                }
            }
            // end

        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n != m)
            {
                return null;
            }
            answer = new int[2 * n - 1];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    answer[j - i + n - 1] += matrix[i, j];
                }
            }
            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here
            int n = matrix.GetLength(0);
            if (n != matrix.GetLength(1) || k < 0 || k >= n) return;
            int r = 0, c = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (System.Math.Abs(matrix[i, j]) > System.Math.Abs(matrix[r, c]))
                    {
                        r = i;
                        c = j;
                    }
                }
            }
            int[] rowSrc = new int[n];
            int[] colSrc = new int[n];
            int sr = 0, sc = 0;
            for (int p = 0; p < n; p++)
            {
                if (p == k)
                {
                    rowSrc[p] = r;
                    colSrc[p] = c;
                }
                else
                {
                    if (sr == r) sr++;
                    if (sc == c) sc++;
                    rowSrc[p] = sr++;
                    colSrc[p] = sc++;
                }
            }
            int[,] copy = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    copy[i, j] = matrix[i, j];
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = copy[rowSrc[i], colSrc[j]];
                }
            }
            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here
            int n = A.GetLength(0);
            int m = A.GetLength(1);
            int p = B.GetLength(1);
            if (m != B.GetLength(0)) return null;
            answer = new int[n, p];
            for (int idx = 0; idx < n * p; idx++)
            {
                int i = idx / p;
                int j = idx % p;
                int sum = 0;
                for (int t = 0; t < m; t++)
                {
                    sum += A[i, t] * B[t, j];
                }
                answer[i, j] = sum;
            }
            // end

            return answer;
        }
        public int[][] Task11(int[,] matrix)
        {
            int[][] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            answer = new int[n][];
            for (int i = 0; i < n; i++)
            {
                int count = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0) count++;
                }
                answer[i] = new int[count];
                int pos = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0) answer[i][pos++] = matrix[i, j];
                }
            }
            // end

            return answer;
        }
        public int[,] Task12(int[][] array)
        {
            int[,] answer = null;

            // code here
            if (array == null) return null;
            int total = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null) total += array[i].Length;
            }
            int size = 0;
            while (size * size < total) size++;
            answer = new int[size, size];
            int pos = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null) continue;
                for (int j = 0; j < array[i].Length; j++)
                {
                    answer[pos / size, pos % size] = array[i][j];
                    pos++;
                }
            }
            // end

            return answer;
        }
    }
}
