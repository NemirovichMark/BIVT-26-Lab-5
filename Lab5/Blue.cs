using System.Linq;
using System.Numerics;
using System.Runtime.ExceptionServices;
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
                double sum = 0;
                int count = 0;

                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        count++;
                    }
                }
                
                if (count > 0) answer[i] = sum / count;
                else answer[i] = 0;
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

            int maxnum = matrix[0, 0];
            int maxstr = 0;
            int maxstolb = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > maxnum)
                    {
                        maxnum = matrix[i, j];
                        maxstr = i;
                        maxstolb = j;
                    }
                }
            }

            answer = new int[n - 1, m - 1];
            int newi = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == maxstr) continue;
                int newj = 0;
                for (int j = 0; j < m; j++)
                {
                    if (j == maxstolb) continue;
                    answer[newi, newj] = matrix[i, j];
                    newj++;
                }
                newi++;
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
                int max_num = matrix[i, 0];
                int stIndex = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > max_num)
                    {
                        max_num = matrix[i, j];
                        stIndex = j;
                    }
                }
                for (int j = stIndex; j < m - 1; j++)
                {
                    matrix[i, j] = matrix[i, j + 1];
                }

                matrix[i, m - 1] = max_num;
            }
            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            answer = new int[n, m+1];

            for (int i = 0; i < n; i++)
            {
                int max = matrix[i, 0];

                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > max) max = matrix[i, j];
                    if (j < m - 1) answer[i, j] = matrix[i, j];
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
                    if ((i + j) % 2 != 0)
                    {
                        count++;
                    }
                }
            }

            answer = new int[count];
            int index = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if ((i + j) % 2 != 0)
                    {
                        answer[index] = matrix[i, j];
                        index++;
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
            if (n != m || k < 0 || k >= m) return;

            int r1 = 0;
            for (int i = 1; i < n; i++)
                if (matrix[i, i] > matrix[r1, r1]) r1 = i;

            int r2 = -1;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i, k] < 0) 
                { 
                    r2 = i; 
                    break; 
                }
            }

            if (r2 != -1 && r1 != r2)
            {
                for (int j = 0; j < m; j++)
                {
                    int temp = matrix[r1, j];
                    matrix[r1, j] = matrix[r2, j];
                    matrix[r2, j] = temp;
                }
            }
            // end

        }
        public void Task7(int[,] matrix, int[] array)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            if (array == null || array.Length != m) return;

            int r = 0;
            for (int i = 1; i < n; i++)
                if (matrix[i, m - 2] > matrix[r, m - 2]) r = i;

            if (m >= 2)
            {
                for (int j = 0; j < m; j++)
                    matrix[r, j] = array[j];
            }
            // end

        }
        public void Task8(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);

            for (int j = 0; j < m; j++)
            {
                int r = 0;
                for (int i = 1; i < n; i++)
                    if (matrix[i, j] > matrix[r, j]) r = i;

                if (r < n / 2)
                {
                    int sum = 0;
                    for (int i = r + 1; i < n; i++) sum += matrix[i, j];
                    matrix[0, j] = sum;
                }
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);

            for (int i = 0; i + 1 < n; i += 2)
            {
                int max1 = 0, max2 = 0;

                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] > matrix[i, max1]) max1 = j;
                    if (matrix[i + 1, j] > matrix[i + 1, max2]) max2 = j;
                }

                int temp = matrix[i, max1];
                matrix[i, max1] = matrix[i + 1, max2];
                matrix[i + 1, max2] = temp;
            }

            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            if (n != m) return;

            int max = 0;
            for (int i = 1; i < n; i++)
            {
                if (matrix[i, i] > matrix[max, max]) max = i;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i < max)
                    {
                        if (j > i) matrix[i, j] = 0;
                    }
                }
            }
            // end

        }
        public void Task11(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);

            int[] cnt = new int[n];
            int[] order = new int[n];
            for (int i = 0; i < n; i++)
            {
                order[i] = i;
                for (int j = 0; j < m; j++)
                    if (matrix[i, j] > 0) cnt[i]++;
            }

            for (int i = 1; i < n; i++)
            {
                int cur = order[i];
                int p = i - 1;
                while (p >= 0 && cnt[order[p]] < cnt[cur])
                {
                    order[p + 1] = order[p];
                    p--;
                }
                order[p + 1] = cur;
            }

            int[,] tmp = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    tmp[i, j] = matrix[order[i], j];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    matrix[i, j] = tmp[i, j];
            // end

        }
        public int[][] Task12(int[][] array)
        {
            int[][] answer = null;

            // code here
            int n = array.Length;

            double total = 0;
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    total += array[i][j];
                    count++;
                }
            }
            double overall = count == 0 ? 0 : total / count;

            bool[] keep = new bool[n];
            int kept = 0;
            for (int i = 0; i < n; i++)
            {
                double sum = 0;
                for (int j = 0; j < array[i].Length; j++) sum += array[i][j];
                double avg = array[i].Length == 0 ? 0 : sum / array[i].Length;
                if (!(avg < overall))
                {
                    keep[i] = true;
                    kept++;
                }
            }

            answer = new int[kept][];
            int k = 0;

            for (int i = 0; i < n; i++)
            {
                if (!keep[i]) continue;

                answer[k] = new int[array[i].Length];

                for (int j = 0; j < array[i].Length; j++)
                {
                    answer[k][j] = array[i][j];
                }

                k++;
            }
            // end

            return answer;
        }
    }
}
