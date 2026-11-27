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
                double s = 0;
                int k = 0;

                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        s += matrix[i, j];
                        k++;
                    }
                }

                if (k > 0)
                    answer[i] = s / k;
                else
                    answer[i] = 0;
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

            if (n == 0 || m == 0)
                return matrix;

            int k = 0;
            int l = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > matrix[k, l])
                    {
                        k = i;
                        l = j;
                    }
                }
            }

            answer = new int[n - 1, m - 1];

            int a = 0;

            for (int i = 0; i < n; i++)
            {
                if (i == k)
                    continue;

                int b = 0;

                for (int j = 0; j < m; j++)
                {
                    if (j == l)
                        continue;

                    answer[a, b] = matrix[i, j];
                    b++;
                }

                a++;
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
                int k = 0;

                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] > matrix[i, k])
                        k = j;
                }

                if (m == 0)
                    continue;

                int a = matrix[i, k];

                for (int j = k; j < m - 1; j++)
                {
                    matrix[i, j] = matrix[i, j + 1];
                }

                matrix[i, m - 1] = a;
            }
            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (m == 0)
                return matrix;

            answer = new int[n, m + 1];

            for (int i = 0; i < n; i++)
            {
                int a = matrix[i, 0];

                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > a)
                        a = matrix[i, j];
                }

                for (int j = 0; j < m - 1; j++)
                {
                    answer[i, j] = matrix[i, j];
                }

                answer[i, m - 1] = a;
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

            answer = new int[n * m / 2];

            int k = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if ((i + j) % 2 != 0)
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

            if (n != m || n == 0 || k < 0 || k >= m)
                return;

            int a = 0;
            int b = -1;

            for (int i = 0; i < n; i++)
            {
                if (matrix[i, i] > matrix[a, a])
                    a = i;
            }

            for (int i = 0; i < n; i++)
            {
                if (matrix[i, k] < 0)
                {
                    b = i;
                    break;
                }
            }

            if (b != -1 && a != b)
            {
                for (int j = 0; j < m; j++)
                {
                    int t = matrix[a, j];
                    matrix[a, j] = matrix[b, j];
                    matrix[b, j] = t;
                }
            }

            // end

        }
        public void Task7(int[,] matrix, int[] array)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (n == 0 || m < 2 || array.Length != m)
                return;

            int k = 0;

            for (int i = 0; i < n; i++)
            {
                if (matrix[i, m - 2] > matrix[k, m - 2])
                    k = i;
            }

            for (int j = 0; j < m; j++)
            {
                matrix[k, j] = array[j];
            }

            // end

        }
        public void Task8(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (n == 0)
                return;

            for (int j = 0; j < m; j++)
            {
                int k = 0;

                for (int i = 1; i < n; i++)
                {
                    if (matrix[i, j] > matrix[k, j])
                        k = i;
                }

                if (k < n / 2)
                {
                    int s = 0;

                    for (int i = k + 1; i < n; i++)
                    {
                        s += matrix[i, j];
                    }

                    matrix[0, j] = s;
                }
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (m == 0)
                return;

            for (int i = 0; i < n - 1; i += 2)
            {
                int a = 0;
                int b = 0;

                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] > matrix[i, a])
                        a = j;

                    if (matrix[i + 1, j] > matrix[i + 1, b])
                        b = j;
                }

                int t = matrix[i, a];
                matrix[i, a] = matrix[i + 1, b];
                matrix[i + 1, b] = t;
            }

            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (n != m || n == 0)
                return;

            int k = 0;

            for (int i = 1; i < n; i++)
            {
                if (matrix[i, i] > matrix[k, k])
                    k = i;
            }

            for (int i = 0; i < k; i++)
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

            int[] k = new int[n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                        k[i]++;
                }
            }

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (k[j] < k[j + 1])
                    {
                        int t = k[j];
                        k[j] = k[j + 1];
                        k[j + 1] = t;

                        for (int l = 0; l < m; l++)
                        {
                            int a = matrix[j, l];
                            matrix[j, l] = matrix[j + 1, l];
                            matrix[j + 1, l] = a;
                        }
                    }
                }
            }
            // end

        }
        public int[][] Task12(int[][] array)
        {
            int[][] answer = null;

            // code here
            int n = array.Length;

            double s = 0;
            int k = 0;

            double[] a = new double[n];

            for (int i = 0; i < n; i++)
            {
                double t = 0;

                for (int j = 0; j < array[i].Length; j++)
                {
                    t += array[i][j];
                    s += array[i][j];
                    k++;
                }

                if (array[i].Length > 0)
                    a[i] = t / array[i].Length;
            }

            if (k == 0)
                return array;

            double p = s / k;

            int c = 0;

            for (int i = 0; i < n; i++)
            {
                if (array[i].Length == 0 || a[i] >= p)
                    c++;
            }

            answer = new int[c][];

            int l = 0;

            for (int i = 0; i < n; i++)
            {
                if (array[i].Length == 0 || a[i] >= p)
                {
                    answer[l] = array[i];
                    l++;
                }
            }
            // end

            return answer;
        }
    }
}