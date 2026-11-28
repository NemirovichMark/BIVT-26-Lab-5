using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;

namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;

            // code here
            answer = new int[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int cnt = 0;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[j, i] < 0) cnt++;
                }
                answer[i] = cnt;
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
                int minIndex = 0;
                for (int j = 1; j < m; j++)if (matrix[i, j] < matrix[i, minIndex]) minIndex = j;
                int min = matrix[i, minIndex];
                for (int j = minIndex; j > 0; j--)matrix[i, j] = matrix[i, j - 1];
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
                int maxindex = 0;
                for (int j = 1; j < m; j++)if (matrix[i, j] > matrix[i, maxindex]) maxindex = j;
                for (int j = 0; j < m; j++)
                {
                    if (j <= maxindex) answer[i, j] = matrix[i, j];
                    else answer[i, j + 1] = matrix[i, j];
                }
                answer[i, maxindex + 1] = matrix[i, maxindex];
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
                int maxindex = 0;
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] > matrix[i, maxindex]) maxindex = j;
                }
                int sum = 0;
                int cnt = 0;
                for (int j = maxindex + 1; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        cnt++;
                    }
                }
                if (cnt == 0) continue;
                int srednee = sum / cnt;
                for (int j = 0; j < maxindex; j++)
                {
                    if (matrix[i, j] < 0) matrix[i, j] = srednee;
                }
            }
            // end

        }
        public void Task5(int[,] matrix, int k)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (k < 0 || k >= m) return;
            int[] max = new int[n];
            for (int i = 0; i < n; i++)
            {
                max[i] = matrix[i, 0];
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] > max[i]) max[i] = matrix[i, j];
                }
            }
            for (int i = 0; i < n; i++)
            {
                matrix[i, k] = max[n - 1 - i];
            }
            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (array == null || array.Length != m) return;
            for (int j = 0; j < m; j++)
            {
                int max = 0;
                for (int i = 1; i < n; i++)
                {
                    if (matrix[i, j] > matrix[max, j]) max = i;
                }
                if (array[j] > matrix[max, j]) matrix[max, j] = array[j];
            }
            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[] mins = new int[n];
            for (int i = 0; i < n; i++)
            {
                mins[i] = matrix[i, 0];
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] < mins[i]) mins[i] = matrix[i, j];
                }
            }
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (mins[j] < mins[j + 1])
                    {
                        int min = mins[j];
                        mins[j] = mins[j + 1];
                        mins[j + 1] = min;

                        for (int c = 0; c < m; c++)
                        {
                            int l = matrix[j, c];
                            matrix[j, c] = matrix[j + 1, c];
                            matrix[j + 1, c] = l;
                        }
                    }
                }
            }
            // end

        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int n = matrix.GetLength(0);
            if (n != matrix.GetLength(1)) return null;
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
            if (n != matrix.GetLength(1)) return;
            if (k < 0 || k >= n) return;
            int row = 0;
            int col = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (Math.Abs(matrix[i, j]) > Math.Abs(matrix[row, col]))
                    {
                        row = i;
                        col = j;
                    }
                }
            }
            while (row > k)
            {
                for (int j = 0; j < n; j++)
                {
                    int temp = matrix[row, j];
                    matrix[row, j] = matrix[row - 1, j];
                    matrix[row - 1, j] = temp;
                }
                row--;
            }
            while (row < k)
            {
                for (int j = 0; j < n; j++)
                {
                    int temp = matrix[row, j];
                    matrix[row, j] = matrix[row + 1, j];
                    matrix[row + 1, j] = temp;
                }
                row++;
            }
            while (col > k)
            {
                for (int i = 0; i < n; i++)
                {
                    int temp = matrix[i, col];
                    matrix[i, col] = matrix[i, col - 1];
                    matrix[i, col - 1] = temp;
                }
                col--;
            }
            while (col < k)
            {
                for (int i = 0; i < n; i++)
                {
                    int temp = matrix[i, col];
                    matrix[i, col] = matrix[i, col + 1];
                    matrix[i, col + 1] = temp;
                }
                col++;
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
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < p; j++)
                {
                    int sum = 0;
                    for (int t = 0; t < m; t++)
                    {
                        sum += A[i, t] * B[t, j];
                    }
                    answer[i, j] = sum;
                }
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
                int index = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        answer[i][index] = matrix[i, j];
                        index++;
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
            if (array == null) return null;
            int total = 0;
            for (int i = 0; i < array.Length; i++)
            {
                total += array[i].Length;
            }
            int razmer = 0;
            while (razmer * razmer < total) razmer++;
            answer = new int[razmer, razmer];
            int pos = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    answer[pos / razmer, pos % razmer] = array[i][j];
                    pos++;
                }
            }
            // end

            return answer;
        }
    }
}