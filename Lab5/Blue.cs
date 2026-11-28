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
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            answer = new double[rows];
            for (int i = 0; i < rows; i++)
            {
                double sum = 0;
                int count = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        count++;
                    }
                }
                if (count > 0)
                    answer[i] = sum / count;
            }
            // end

            return answer;
        }
        public int[,] Task2(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int maxRow = 0, maxCol = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > matrix[maxRow, maxCol])
                    {
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }
            answer = new int[rows - 1, cols - 1];
            for (int i = 0; i < rows - 1; i++)
            {
                int sourceRow = i < maxRow ? i : i + 1;
                for (int j = 0; j < cols - 1; j++)
                {
                    int sourceCol = j < maxCol ? j : j + 1;
                    answer[i, j] = matrix[sourceRow, sourceCol];
                }
            }
            // end

            return answer;
        }
        public void Task3(int[,] matrix)
        {

            // code here
            int cols = matrix.GetLength(1);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int best = 0;
                for (int j = 1; j < cols; j++)
                    if (matrix[i, j] > matrix[i, best])
                        best = j;

                int saved = matrix[i, best];
                for (int j = best; j < cols - 1; j++)
                    matrix[i, j] = matrix[i, j + 1];
                matrix[i, cols - 1] = saved;
            }
            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            answer = new int[rows, cols + 1];
            for (int i = 0; i < rows; i++)
            {
                int largest = matrix[i, 0];
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > largest)
                        largest = matrix[i, j];
                    answer[i, j] = matrix[i, j];
                }
                answer[i, cols] = matrix[i, cols - 1];
                answer[i, cols - 1] = largest;
            }
            // end

            return answer;
        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            answer = new int[matrix.Length / 2];
            int position = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if ((i + j) % 2 == 1)
                        answer[position++] = matrix[i, j];
                }
            }
            // end

            return answer;
        }
        public void Task6(int[,] matrix, int k)
        {

            // code here
            int n = matrix.GetLength(0);
            if (n != matrix.GetLength(1) || k < 0 || k >= n)
                return;
            int best = 0;
            int negative = -1;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i, i] > matrix[best, best])
                    best = i;
                if (negative == -1 && matrix[i, k] < 0)
                    negative = i;
            }
            if (negative == -1 || negative == best)
                return;
            for (int j = 0; j < n; j++)
            {
                int saved = matrix[best, j];
                matrix[best, j] = matrix[negative, j];
                matrix[negative, j] = saved;
            }
            // end

        }
        public void Task7(int[,] matrix, int[] array)
        {

            // code here
            int cols = matrix.GetLength(1);
            if (cols < 2 || array == null || array.Length != cols)
                return;
            int k = cols - 2;
            int best = 0;
            for (int i = 1; i < matrix.GetLength(0); i++)
                if (matrix[i, k] > matrix[best, k])
                    best = i;
            for (int j = 0; j < cols; j++)
                matrix[best, j] = array[j];
            // end

        }
        public void Task8(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int best = 0;
                for (int i = 1; i < rows; i++)
                    if (matrix[i, j] > matrix[best, j])
                        best = i;
                if (best < rows / 2)
                {
                    int sum = 0;
                    for (int i = best + 1; i < rows; i++)
                        sum += matrix[i, j];
                    matrix[0, j] = sum;
                }
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i + 1 < rows; i += 2)
            {
                int first = 0, second = 0;
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > matrix[i, first])
                        first = j;
                    if (matrix[i + 1, j] > matrix[i + 1, second])
                        second = j;
                }
                int saved = matrix[i, first];
                matrix[i, first] = matrix[i + 1, second];
                matrix[i + 1, second] = saved;
            }
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            if (n != matrix.GetLength(1))
                return;
            int best = 0;
            for (int i = 1; i < n; i++)
                if (matrix[i, i] > matrix[best, best])
                    best = i;
            for (int i = 0; i < best; i++)
                for (int j = i + 1; j < n; j++)
                    matrix[i, j] = 0;
            // end

        }
        public void Task11(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[] counts = new int[rows];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    if (matrix[i, j] > 0)
                        counts[i]++;

            for (int end = rows - 1; end > 0; end--)
            {
                for (int i = 0; i < end; i++)
                {
                    if (counts[i] >= counts[i + 1])
                        continue;
                    int savedCount = counts[i];
                    counts[i] = counts[i + 1];
                    counts[i + 1] = savedCount;
                    for (int j = 0; j < cols; j++)
                    {
                        int saved = matrix[i, j];
                        matrix[i, j] = matrix[i + 1, j];
                        matrix[i + 1, j] = saved;
                    }
                }
            }
            // end

        }
        public int[][] Task12(int[][] array)
        {
            int[][] answer = null;

            // code here
            double[] means = new double[array.Length];
            double total = 0;
            long size = 0;
            for (int i = 0; i < array.Length; i++)
            {
                double sum = 0;
                for (int j = 0; j < array[i].Length; j++)
                    sum += array[i][j];
                if (array[i].Length > 0)
                    means[i] = sum / array[i].Length;
                total += sum;
                size += array[i].Length;
            }
            double average = size == 0 ? 0 : total / size;
            int count = 0;
            for (int i = 0; i < array.Length; i++)
                if (means[i] >= average)
                    count++;

            answer = new int[count][];
            int position = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (means[i] >= average)
                    answer[position++] = (int[])array[i].Clone();
            }
            // end

            return answer;
        }
    }
}
