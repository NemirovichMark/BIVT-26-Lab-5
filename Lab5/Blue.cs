using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Blue
    {
        public double[] Task1(int[,] matrix)
        {
            double[] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            answer = new double[n];
            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                int count = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        count++;
                    }
                }
                if (count > 0)
                {
                    answer[i] = (double)sum / count;
                }
                else
                {
                    answer[i] = 0;
                }
            }
            // end

            return answer;
        }
        public int[,] Task2(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int maxi = 0;
            int maxj = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > matrix[maxi, maxj])
                    {
                        maxi = i;
                        maxj = j;
                    }
                }
            }
            answer = new int[n - 1, m - 1];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i == maxi || j == maxj)
                    {
                        continue;
                    }
                    int a = i;
                    int b = j;
                    if (i > maxi)
                    {
                        a--;
                    }
                    if (j > maxj)
                    {
                        b--;
                    }
                    answer[a, b] = matrix[i, j];
                }
            }
            // end

            return answer;
        }
        public void Task3(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                int maxj = 0;
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] > matrix[i, maxj])
                    {
                        maxj = j;
                    }
                }
                int max = matrix[i, maxj];
                for (int j = maxj; j < m - 1; j++)
                {
                    matrix[i, j] = matrix[i, j + 1];
                }
                matrix[i, m - 1] = max;
            }
            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            answer = new int[n, m + 1];
            for (int i = 0; i < n; i++)
            {
                int max = matrix[i, 0];
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                    }
                }
                for (int j = 0; j < m - 1; j++)
                {
                    answer[i, j] = matrix[i, j];
                }
                answer[i, m - 1] = max;
                answer[i, m] = matrix[i, m - 1];
            }
            // end

            return answer;
        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if ((i + j) % 2 == 1)
                    {
                        count++;
                    }
                }
            }
            answer = new int[count];
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if ((i + j) % 2 == 1)
                    {
                        answer[k] = matrix[i, j];
                        k++;
                    }
                }
            }
            // end

            return answer;
        }
        public void Task6(int[,] matrix, int k)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n != m || k < 0 || k >= m)
            {
                return;
            }

            int maxrow = 0;
            for (int i = 1; i < n; i++)
            {
                if (matrix[i, i] > matrix[maxrow, maxrow])
                {
                    maxrow = i;
                }
            }

            int negrow = -1;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i, k] < 0)
                {
                    negrow = i;
                    break;
                }
            }

            if (negrow == -1 || negrow == maxrow)
            {
                return;
            }

            for (int j = 0; j < m; j++)
            {
                int temp = matrix[maxrow, j];
                matrix[maxrow, j] = matrix[negrow, j];
                matrix[negrow, j] = temp;
            }
            // end

        }
        public void Task7(int[,] matrix, int[] array)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (m < 2 || array == null || array.Length != m)
            {
                return;
            }

            int row = 0;
            for (int i = 1; i < n; i++)
            {
                if (matrix[i, m - 2] > matrix[row, m - 2])
                {
                    row = i;
                }
            }
            for (int j = 0; j < m; j++)
            {
                matrix[row, j] = array[j];
            }
            // end

        }
        public void Task8(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int j = 0; j < m; j++)
            {
                int maxi = 0;
                for (int i = 1; i < n; i++)
                {
                    if (matrix[i, j] > matrix[maxi, j])
                    {
                        maxi = i;
                    }
                }
                if (maxi < n / 2)
                {
                    int sum = 0;
                    for (int i = maxi + 1; i < n; i++)
                    {
                        sum += matrix[i, j];
                    }
                    matrix[0, j] = sum;
                }
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i + 1 < n; i += 2)
            {
                int j1 = 0;
                int j2 = 0;
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] > matrix[i, j1])
                    {
                        j1 = j;
                    }
                    if (matrix[i + 1, j] > matrix[i + 1, j2])
                    {
                        j2 = j;
                    }
                }
                int temp = matrix[i, j1];
                matrix[i, j1] = matrix[i + 1, j2];
                matrix[i + 1, j2] = temp;
            }
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n != m)
            {
                return;
            }
            int p = 0;
            for (int i = 1; i < n; i++)
            {
                if (matrix[i, i] > matrix[p, p])
                {
                    p = i;
                }
            }
            for (int i = 0; i < p; i++)
            {
                for (int j = i + 1; j < m; j++)
                {
                    matrix[i, j] = 0;
                }
            }
            // end

        }
        public void Task11(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[] cnt = new int[n];
            int[] ind = new int[n];
            for (int i = 0; i < n; i++)
            {
                ind[i] = i;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        cnt[i]++;
                    }
                }
            }
            for (int i = 1; i < n; i++)
            {
                int x = ind[i];
                int j = i - 1;
                while (j >= 0 && cnt[ind[j]] < cnt[x])
                {
                    ind[j + 1] = ind[j];
                    j--;
                }
                ind[j + 1] = x;
            }
            int[,] copy = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    copy[i, j] = matrix[ind[i], j];
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = copy[i, j];
                }
            }
            // end

        }
        public int[][] Task12(int[][] array)
        {
            int[][] answer = null;

            // code here
            int n = array.Length;
            long total = 0;
            int totalcount = 0;
            for (int i = 0; i < n; i++)
            {
                if (array[i] == null)
                {
                    continue;
                }
                for (int j = 0; j < array[i].Length; j++)
                {
                    total += array[i][j];
                    totalcount++;
                }
            }
            double overall = 0;
            if (totalcount > 0)
            {
                overall = (double)total / totalcount;
            }
            bool[] keep = new bool[n];
            int keepcount = 0;
            for (int i = 0; i < n; i++)
            {
                double avg = 0;
                if (array[i] != null && array[i].Length > 0)
                {
                    long sum = 0;
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        sum += array[i][j];
                    }
                    avg = (double)sum / array[i].Length;
                }
                if (avg >= overall)
                {
                    keep[i] = true;
                    keepcount++;
                }
            }
            answer = new int[keepcount][];
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                if (!keep[i])
                {
                    continue;
                }
                if (array[i] == null)
                {
                    answer[k] = new int[0];
                }
                else
                {
                    answer[k] = new int[array[i].Length];
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        answer[k][j] = array[i][j];
                    }
                }
                k++;
            }
            // end

            return answer;
        }
    }
}