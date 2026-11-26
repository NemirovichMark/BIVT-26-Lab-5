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
                int c = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        s += matrix[i, j];
                        c++;
                    }
                }
                answer[i] = c > 0 ? s / c : 0;
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
            int a = 0, b = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > matrix[a, b])
                    {
                        a = i;
                        b = j;
                    }
                }
            }

            answer = new int[n - 1, m - 1];
            int r = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == a) continue;
                int c = 0;
                for (int j = 0; j < m; j++)
                {
                    if (j == b) continue;
                    answer[r, c] = matrix[i, j];
                    c++;
                }
                r++;
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
                int p = 0;
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] > matrix[i, p])
                        p = j;
                }

                int v = matrix[i, p];
                for (int j = p; j < m - 1; j++)
                    matrix[i, j] = matrix[i, j + 1];
                matrix[i, m - 1] = v;
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
                int x = matrix[i, 0];
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] > x)
                        x = matrix[i, j];
                }

                for (int j = 0; j < m - 1; j++)
                    answer[i, j] = matrix[i, j];
                answer[i, m - 1] = x;
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
            answer = new int[(n * m) / 2];

            int p = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if ((i + j) % 2 != 0)
                        answer[p++] = matrix[i, j];
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

            if (n == m && k >= 0 && k < m)
            {
                int a = 0;
                for (int i = 1; i < n; i++)
                {
                    if (matrix[i, i] > matrix[a, a])
                        a = i;
                }

                int b = -1;
                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, k] < 0)
                    {
                        b = i;
                        break;
                    }
                }

                if (b != -1 && b != a)
                {
                    for (int j = 0; j < m; j++)
                    {
                        int t = matrix[a, j];
                        matrix[a, j] = matrix[b, j];
                        matrix[b, j] = t;
                    }
                }
            }
            // end

        }
        public void Task7(int[,] matrix, int[] array)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (m >= 2 && array != null && array.Length == m)
            {
                int c = m - 2;
                int r = 0;
                for (int i = 1; i < n; i++)
                {
                    if (matrix[i, c] > matrix[r, c])
                        r = i;
                }

                for (int j = 0; j < m; j++)
                    matrix[r, j] = array[j];
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
                int r = 0;
                for (int i = 1; i < n; i++)
                {
                    if (matrix[i, j] > matrix[r, j])
                        r = i;
                }

                if (r < n / 2)
                {
                    int s = 0;
                    for (int i = r + 1; i < n; i++)
                        s += matrix[i, j];
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

            for (int i = 0; i + 1 < n; i += 2)
            {
                int a = 0;
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] > matrix[i, a])
                        a = j;
                }

                int b = 0;
                for (int j = 1; j < m; j++)
                {
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

            if (n == m)
            {
                int r = 0;
                for (int i = 1; i < n; i++)
                {
                    if (matrix[i, i] > matrix[r, r])
                        r = i;
                }

                for (int i = 0; i < r; i++)
                {
                    for (int j = i + 1; j < m; j++)
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
            int[] c = new int[n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0) c[i]++;
                }
            }

            for (int i = 1; i < n; i++)
            {
                int x = c[i];
                int[] r = new int[m];
                for (int j = 0; j < m; j++) r[j] = matrix[i, j];

                int k = i - 1;
                while (k >= 0 && c[k] < x)
                {
                    c[k + 1] = c[k];
                    for (int j = 0; j < m; j++)
                        matrix[k + 1, j] = matrix[k, j];
                    k--;
                }
                c[k + 1] = x;
                for (int j = 0; j < m; j++)
                    matrix[k + 1, j] = r[j];
            }
            // end

        }
        public int[][] Task12(int[][] array)
        {
            int[][] answer = null;

            // code here
            double s = 0;
            int c = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null) continue;
                for (int j = 0; j < array[i].Length; j++)
                {
                    s += array[i][j];
                    c++;
                }
            }

            double a = c > 0 ? s / c : 0;
            int k = 0;

            for (int i = 0; i < array.Length; i++)
            {
                double r = 0;
                int l = array[i] != null ? array[i].Length : 0;
                for (int j = 0; j < l; j++) r += array[i][j];
                if ((l > 0 ? r / l : 0) >= a) k++;
            }

            answer = new int[k][];
            int p = 0;

            for (int i = 0; i < array.Length; i++)
            {
                double r = 0;
                int l = array[i] != null ? array[i].Length : 0;
                for (int j = 0; j < l; j++) r += array[i][j];
                if ((l > 0 ? r / l : 0) >= a)
                {
                    answer[p] = new int[l];
                    for (int j = 0; j < l; j++) answer[p][j] = array[i][j];
                    p++;
                }
            }
            // end

            return answer;
        }
    }
}
