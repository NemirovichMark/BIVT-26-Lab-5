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
                int minIndex = 0;

                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] < matrix[i, minIndex])
                    {
                        minIndex = j;
                    }
                }

                answer[i] = minIndex;
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
                int maxIndex = 0;

                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] > matrix[i, maxIndex])
                    {
                        maxIndex = j;
                    }
                }

                int max = matrix[i, maxIndex];

                if (max != 0)
                {
                    for (int j = 0; j < maxIndex; j++)
                    {
                        if (matrix[i, j] < 0)
                        {
                            matrix[i, j] =
                                (int)Math.Floor((double)matrix[i, j] / max);
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
                int maxIndex = 0;

                for (int i = 1; i < n; i++)
                {
                    if (matrix[i, i] > matrix[maxIndex, maxIndex])
                    {
                        maxIndex = i;
                    }
                }

                for (int i = 0; i < n; i++)
                {
                    int temp = matrix[i, k];

                    matrix[i, k] = matrix[i, maxIndex];

                    matrix[i, maxIndex] = temp;
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
                int maxIndex = 0;

                for (int i = 1; i < n; i++)
                {
                    if (matrix[i, i] > matrix[maxIndex, maxIndex])
                    {
                        maxIndex = i;
                    }
                }

                for (int i = 0; i < n; i++)
                {
                    int temp = matrix[maxIndex, i];

                    matrix[maxIndex, i] = matrix[i, maxIndex];

                    matrix[i, maxIndex] = temp;
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

            long maxSum = -1;
            int maxIndex = 0;

            for (int i = 0; i < n; i++)
            {
                long sum = 0;

                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                    }
                }

                if (sum > maxSum)
                {
                    maxSum = sum;
                    maxIndex = i;
                }
            }

            answer = new int[n - 1, m];

            int row = 0;

            for (int i = 0; i < n; i++)
            {
                if (i != maxIndex)
                {
                    for (int j = 0; j < m; j++)
                    {
                        answer[row, j] = matrix[i, j];
                    }

                    row++;
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

            int minCount = m + 1;
            int maxCount = -1;

            int minIndex = 0;
            int maxIndex = 0;

            for (int i = 0; i < n; i++)
            {
                int count = 0;

                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        count++;
                    }
                }

                if (count < minCount)
                {
                    minCount = count;
                    minIndex = i;
                }

                if (count > maxCount)
                {
                    maxCount = count;
                    maxIndex = i;
                }
            }

            if (minCount != maxCount)
            {
                for (int j = 0; j < m; j++)
                {
                    int temp = matrix[minIndex, j];

                    matrix[minIndex, j] = matrix[maxIndex, j];

                    matrix[maxIndex, j] = temp;
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

            if (array.Length != n)
            {
                answer = matrix;
            }
            else
            {
                int min = matrix[0, 0];
                int minColumn = 0;

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (matrix[i, j] < min)
                        {
                            min = matrix[i, j];
                            minColumn = j;
                        }
                    }
                }

                answer = new int[n, m + 1];

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (j <= minColumn)
                        {
                            answer[i, j] = matrix[i, j];
                        }
                        else
                        {
                            answer[i, j + 1] = matrix[i, j];
                        }
                    }

                    answer[i, minColumn + 1] = array[i];
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
                int positive = 0;
                int negative = 0;
                int maxIndex = 0;

                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, j] > 0)
                    {
                        positive++;
                    }
                    else if (matrix[i, j] < 0)
                    {
                        negative++;
                    }

                    if (matrix[i, j] > matrix[maxIndex, j])
                    {
                        maxIndex = i;
                    }
                }

                if (positive > negative)
                {
                    matrix[maxIndex, j] = 0;
                }
                else if (negative > positive)
                {
                    matrix[maxIndex, j] = maxIndex;
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

            if (n == m)
            {
                A = new int[n * (n + 1) / 2];
                B = new int[n * (n - 1) / 2];

                int a = 0;
                int b = 0;

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (j >= i)
                        {
                            A[a] = matrix[i, j];
                            a++;
                        }
                        else
                        {
                            B[b] = matrix[i, j];
                            b++;
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
                    for (int t = 0; t < n - 1 - i; t++)
                    {
                        if ((j % 2 == 0 &&
                            matrix[t, j] < matrix[t + 1, j]) ||
                            (j % 2 != 0 &&
                            matrix[t, j] > matrix[t + 1, j]))
                        {
                            int temp = matrix[t, j];
                            matrix[t, j] = matrix[t + 1, j];
                            matrix[t + 1, j] = temp;
                        }
                    }
                }
            }
            // end

        }
        public void Task12(int[][] array)
        {

            // code here
            int n = array.Length;

            long[] sums = new long[n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    sums[i] += array[i][j];
                }
            }

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (array[j].Length < array[j + 1].Length ||
                        (array[j].Length == array[j + 1].Length &&
                         sums[j] < sums[j + 1]))
                    {
                        int[] temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;

                        long tempSum = sums[j];
                        sums[j] = sums[j + 1];
                        sums[j + 1] = tempSum;
                    }
                }
            }
            // end

        }
    }
}