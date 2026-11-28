using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;

            // code here
            if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
            {
                return null;
            }

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            answer = new int[m];

            for (int j = 0; j < m; j++)
            {
                int c = 0;
                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, j] < 0)
                    {
                        c++;
                    }
                }
                answer[j] = c;
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            if (matrix == null || matrix.GetLength(1) == 0)
            {
                return;
            }

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int[] min_js = new int[n];
            for (int i = 0; i < n; i++)
            {
                int min = matrix[i, 0];
                int min_j = 0;
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        min_j = j;
                    }
                }
                min_js[i] = min_j;
            }

            for (int i = 0; i < n; i++)
            {
                if (min_js[i] != 0)
                {
                    int temp = matrix[i, min_js[i]];
                    for (int j = min_js[i]; j > 0; j--)
                    {
                        matrix[i, j] = matrix[i, j - 1];
                    }
                    matrix[i, 0] = temp;
                }
            }
            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
            {
                return null;
            }

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            answer = new int[n, m + 1];

            for (int i = 0; i < n; i++)
            {
                int max = matrix[i, 0];
                int max_j = 0;
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        max_j = j;
                    }
                }

                for (int j = 0; j <= max_j; j++)
                {
                    answer[i, j] = matrix[i, j];
                }
                answer[i, max_j + 1] = max;
                for (int j = max_j + 1; j < m; j++)
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
            if (matrix == null || matrix.GetLength(1) == 0)
            {
                return;
            }

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            for (int i = 0; i < n; i++)
            {
                int max = matrix[i, 0];
                int max_j = 0;
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        max_j = j;
                    }
                }

                int s = 0, c = 0;
                for (int j = max_j + 1; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        s += matrix[i, j];
                        c++;
                    }
                }

                if (c > 0)
                {
                    int sa = s / c;
                    for (int j = 0; j < max_j; j++)
                    {
                        if (matrix[i, j] < 0)
                        {
                            matrix[i, j] = sa;
                        }
                    }
                }
            }
            // end

        }
        public void Task5(int[,] matrix, int k)
        {

            // code here
            if (matrix == null || matrix.GetLength(1) == 0 ||
                k < 0 || k >= matrix.GetLength(1))
            {
                return;
            }

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int[] nk = new int[n];
            for (int i = 0; i < n; i++)
            {
                int max = matrix[i, 0];
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                    }
                }
                nk[n - 1 - i] = max;
            }

            for (int i = 0; i < n; i++)
            {
                matrix[i, k] = nk[i];
            }
            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            if (matrix == null || matrix.GetLength(0) == 0 ||
                matrix.GetLength(1) == 0 || array == null ||
                array.Length != matrix.GetLength(1))
            {
                return;
            }

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            for (int j = 0; j < m; j++)
            {
                int max = matrix[0, j];
                int max_i = 0;
                for (int i = 1; i < n; i++)
                {
                    if (matrix[i ,j] > max)
                    {
                        max = matrix[i, j];
                        max_i = i;
                    }
                }
                if (max < array[j])
                {
                    matrix[max_i, j] = array[j];
                }
            }
            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here
            if (matrix == null || matrix.GetLength(0) == 0 ||
                matrix.GetLength(1) == 0)
            {
                return;
            }

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int[] mins = new int[n];
            int[] order = new int[n];

            for (int i = 0; i < n; i++)
            {
                mins[i] = matrix[i, 0];

                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] < mins[i])
                    {
                        mins[i] = matrix[i, j];
                    }
                }

                order[i] = i;
            }

            for (int i = 1; i < n; i++)
            {
                int min = mins[order[i]];
                int index = order[i];
                int k = i - 1;

                while (k >= 0 && mins[order[k]] < min)
                {
                    order[k + 1] = order[k];
                    k--;
                }

                order[k + 1] = index;
            }

            int[,] answer = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                Array.Copy(matrix, order[i] * m, answer, i * m, m);
            }

            Array.Copy(answer, matrix, answer.Length);

        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here
            if (matrix == null || matrix.GetLength(0) == 0 ||
                matrix.GetLength(0) != matrix.GetLength(1))
            {
                return null;
            }

            int n = matrix.GetLength(0);
            answer = new int[2 * n - 1];

            int k = 0;

            for (int i = n - 1; i >= 0; i--)
            {
                int s = 0;
                int x = i;
                int y = 0;

                while (x < n && y < n)
                {
                    s += matrix[x, y];
                    x++;
                    y++;
                }

                answer[k] = s;
                k++;
            }

            for (int j = 1; j < n; j++)
            {
                int s = 0;
                int x = 0;
                int y = j;

                while (x < n && y < n)
                {
                    s += matrix[x, y];
                    x++;
                    y++;
                }

                answer[k] = s;
                k++;
            }
            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here
            if (matrix == null || matrix.GetLength(0) == 0 ||
                matrix.GetLength(0) != matrix.GetLength(1) ||
                k < 0 || k >= matrix.GetLength(0))
            {
                return;
            }

            int n = matrix.GetLength(0);

            int max_i = 0;
            int max_j = 0;
            int max = Math.Abs(matrix[0, 0]);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (Math.Abs(matrix[i, j]) > max)
                    {
                        max = Math.Abs(matrix[i, j]);
                        max_i = i;
                        max_j = j;
                    }
                }
            }

            int[] temp = new int[n];

            if (max_i < k)
            {
                for (int j = 0; j < n; j++)
                {
                    temp[j] = matrix[max_i, j];
                }

                for (int i = max_i; i < k; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        matrix[i, j] = matrix[i + 1, j];
                    }
                }

                for (int j = 0; j < n; j++)
                {
                    matrix[k, j] = temp[j];
                }
            }
            else if (max_i > k)
            {
                for (int j = 0; j < n; j++)
                {
                    temp[j] = matrix[max_i, j];
                }

                for (int i = max_i; i > k; i--)
                {
                    for (int j = 0; j < n; j++)
                    {
                        matrix[i, j] = matrix[i - 1, j];
                    }
                }

                for (int j = 0; j < n; j++)
                {
                    matrix[k, j] = temp[j];
                }
            }

            if (max_j < k)
            {
                for (int i = 0; i < n; i++)
                {
                    temp[i] = matrix[i, max_j];
                }

                for (int j = max_j; j < k; j++)
                {
                    for (int i = 0; i < n; i++)
                    {
                        matrix[i, j] = matrix[i, j + 1];
                    }
                }

                for (int i = 0; i < n; i++)
                {
                    matrix[i, k] = temp[i];
                }
            }
            else if (max_j > k)
            {
                for (int i = 0; i < n; i++)
                {
                    temp[i] = matrix[i, max_j];
                }

                for (int j = max_j; j > k; j--)
                {
                    for (int i = 0; i < n; i++)
                    {
                        matrix[i, j] = matrix[i, j - 1];
                    }
                }

                for (int i = 0; i < n; i++)
                {
                    matrix[i, k] = temp[i];
                }
            }
            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here
            if (A == null || B == null ||
                A.GetLength(1) != B.GetLength(0) ||
                A.GetLength(0) == 0 || A.GetLength(1) == 0 ||
                B.GetLength(1) == 0)
            {
                return null;
            }

            int n = A.GetLength(0);
            int m = A.GetLength(1);
            int p = B.GetLength(1);

            answer = new int[n, p];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < p; j++)
                {
                    answer[i, j] = FigZnaetKakReshitV2Cikla(A, B, i, j, m);
                }
            }
            // end

            return answer;
        }

        private int FigZnaetKakReshitV2Cikla(int[,] A, int[,] B, int i, int j, int m)
        {
            int s = 0;

            for (int k = 0; k < m; k++)
            {
                s += A[i, k] * B[k, j];
            }

            return s;
        }
        public int[][] Task11(int[,] matrix)
        {
            int[][] answer = null;

            // code here
            if (matrix == null)
            {
                return null;
            }

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            answer = new int[n][];

            for (int i = 0; i < n; i++)
            {
                int c = 0;

                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        c++;
                    }
                }

                answer[i] = new int[c];

                int k = 0;

                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        answer[i][k] = matrix[i, j];
                        k++;
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
            if (array == null)
            {
                return null;
            }

            int n = 0;
            int c = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null)
                {
                    n += array[i].Length;
                }
            }

            while (c * c < n)
            {
                c++;
            }

            answer = new int[c, c];

            int k = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null)
                {
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        answer[k / c, k % c] = array[i][j];
                        k++;
                    }
                }
            }
            // end

            return answer;
        }
    }
}
