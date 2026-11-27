using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class White
    {
        public double Task1(int[,] matrix)
        {
            double average = 0;

            // code here

            double sum = 0;
            int count = 0;
            int i = 0;
            while (i < matrix.GetLength(0))
            {
                int j = 0;
                while (j < matrix.GetLength(1))
                {
                    if (matrix[i, j] > 0)
                    {
                        sum = sum + matrix[i, j];
                        count++;
                    }
                    j++;
                }
                i++;
            }
            if (count > 0)
                average = sum / count;

            // end

            return average;
        }
        public (int row, int col) Task2(int[,] matrix)
        {
            int row = 0, col = 0;

            // code here

            int i = 0;
            while (i < matrix.GetLength(0))
            {
                int j = 0;
                while (j < matrix.GetLength(1))
                {
                    if (matrix[i, j] < matrix[row, col])
                    {
                        row = i;
                        col = j;
                    }
                    j++;
                }
                i++;
            }

            // end

            return (row, col);
        }
        public void Task3(int[,] matrix, int k)
        {

            // code here

            if (k < 0 || k >= matrix.GetLength(1))
                return;

            int maxRow = 0;
            int i = 1;
            while (i < matrix.GetLength(0))
            {
                if (matrix[i, k] > matrix[maxRow, k])
                    maxRow = i;
                i++;
            }
            if (maxRow != 0)
            {
                int j = 0;
                while (j < matrix.GetLength(1))
                {
                    int temp = matrix[0, j];
                    matrix[0, j] = matrix[maxRow, j];
                    matrix[maxRow, j] = temp;
                    j++;
                }
            }

            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int minRow = 0;
            int i = 1;
            while (i < rows)
            {
                if (matrix[i, 0] < matrix[minRow, 0])
                    minRow = i;
                i++;
            }

            answer = new int[rows - 1, cols];
            int newRow = 0;
            i = 0;
            while (i < rows)
            {
                if (i != minRow)
                {
                    int j = 0;
                    while (j < cols)
                    {
                        answer[newRow, j] = matrix[i, j];
                        j++;
                    }
                    newRow++;
                }
                i++;
            }

            // end

            return answer;
        }
        public int Task5(int[,] matrix)
        {
            int sum = 0;

            // code here

            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                int i = 0;
                while (i < matrix.GetLength(0))
                {
                    sum = sum + matrix[i, i];
                    i++;
                }
            }

            // end

            return sum;
        }
        public void Task6(int[,] matrix)
        {

            // code here

            int i = 0;
            while (i < matrix.GetLength(0))
            {
                int firstNegative = -1;
                int lastNegative = -1;
                int j = 0;
                while (j < matrix.GetLength(1))
                {
                    if (matrix[i, j] < 0)
                    {
                        if (firstNegative == -1)
                            firstNegative = j;
                        lastNegative = j;
                    }
                    j++;
                }

                if (firstNegative > 0)
                {
                    int maxCol = 0;
                    j = 1;
                    while (j < firstNegative)
                    {
                        if (matrix[i, j] > matrix[i, maxCol])
                            maxCol = j;
                        j++;
                    }
                    int temp = matrix[i, maxCol];
                    matrix[i, maxCol] = matrix[i, lastNegative];
                    matrix[i, lastNegative] = temp;
                }
                i++;
            }

            // end

        }
        public int[] Task7(int[,] matrix)
        {
            int[] negatives = null;

            // code here

            int count = 0;
            int i = 0;
            while (i < matrix.GetLength(0))
            {
                int j = 0;
                while (j < matrix.GetLength(1))
                {
                    if (matrix[i, j] < 0)
                        count++;
                    j++;
                }
                i++;
            }

            if (count == 0)
                return negatives;

            negatives = new int[count];
            int index = 0;
            i = 0;
            while (i < matrix.GetLength(0))
            {
                int j = 0;
                while (j < matrix.GetLength(1))
                {
                    if (matrix[i, j] < 0)
                    {
                        negatives[index] = matrix[i, j];
                        index++;
                    }
                    j++;
                }
                i++;
            }

            // end

            return negatives;
        }
        public void Task8(int[,] matrix)
        {

            // code here

            int cols = matrix.GetLength(1);
            if (cols < 2)
                return;

            int i = 0;
            while (i < matrix.GetLength(0))
            {
                int maxCol = 0;
                int j = 1;
                while (j < cols)
                {
                    if (matrix[i, j] > matrix[i, maxCol])
                        maxCol = j;
                    j++;
                }

                int neighbor;
                if (maxCol == 0)
                    neighbor = 1;
                else if (maxCol == cols - 1)
                    neighbor = cols - 2;
                else if (matrix[i, maxCol - 1] <= matrix[i, maxCol + 1])
                    neighbor = maxCol - 1;
                else
                    neighbor = maxCol + 1;

                matrix[i, neighbor] = matrix[i, neighbor] * 2;
                i++;
            }

            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here

            int i = 0;
            while (i < matrix.GetLength(0))
            {
                int left = 0;
                int right = matrix.GetLength(1) - 1;
                while (left < right)
                {
                    int temp = matrix[i, left];
                    matrix[i, left] = matrix[i, right];
                    matrix[i, right] = temp;
                    left++;
                    right--;
                }
                i++;
            }

            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here

            int n = matrix.GetLength(0);
            if (n != matrix.GetLength(1))
                return;

            int i = n / 2;
            while (i < n)
            {
                int j = 0;
                while (j <= i)
                {
                    matrix[i, j] = 1;
                    j++;
                }
                i++;
            }

            // end

        }
        public int[,] Task11(int[,] matrix)
        {
            int[,] answer = null;

            // code here

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            bool[] hasZero = new bool[rows];
            int count = 0;
            int i = 0;
            while (i < rows)
            {
                int j = 0;
                while (j < cols)
                {
                    if (matrix[i, j] == 0)
                        hasZero[i] = true;
                    j++;
                }
                if (!hasZero[i])
                    count++;
                i++;
            }

            answer = new int[count, cols];
            int newRow = 0;
            i = 0;
            while (i < rows)
            {
                if (!hasZero[i])
                {
                    int j = 0;
                    while (j < cols)
                    {
                        answer[newRow, j] = matrix[i, j];
                        j++;
                    }
                    newRow++;
                }
                i++;
            }

            // end

            return answer;
        }
        public void Task12(int[][] array)
        {

            // code here

            long[] sums = new long[array.Length];
            int i = 0;
            while (i < array.Length)
            {
                int j = 0;
                while (j < array[i].Length)
                {
                    sums[i] = sums[i] + array[i][j];
                    j++;
                }
                i++;
            }

            // Сортировка пузырьком сохраняет порядок строк с равными суммами.
            int end = array.Length - 1;
            while (end > 0)
            {
                i = 0;
                while (i < end)
                {
                    if (sums[i] > sums[i + 1])
                    {
                        long tempSum = sums[i];
                        sums[i] = sums[i + 1];
                        sums[i + 1] = tempSum;

                        int[] tempRow = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = tempRow;
                    }
                    i++;
                }
                end--;
            }

            // end

        }
    }
}
