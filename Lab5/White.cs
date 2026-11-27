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
            int k = 0;
            double sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        k++;
                    }
                }
            }
            if (k > 0) average += sum / k;
            else average = 0;
            // end

            return average;
        }
        public (int row, int col) Task2(int[,] matrix)
        {
            int row = 0, col = 0;

            // code here
            int min = int.MaxValue;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        row = i;
                        col = j;
                    }
                }
            }
            // end

            return (row, col);
        }
        public void Task3(int[,] matrix, int k)
        {

            // code here
            if (matrix == null) return;
            if (matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0 || k < 0 || k >= matrix.GetLength(1)) return;
            int row = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, k] > matrix[row, k])
                {
                    row = i;
                }
            }
            if (row == 0) return;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                (matrix[0, j], matrix[row, j]) = (matrix[row, j], matrix[0, j]);
            }
            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (n == 1)
                return new int[0, 0];

            int min = matrix[0, 0];
            int minm = 0;

            for (int i = 1; i < n; i++)
            {
                if (matrix[i, 0] < min)
                {
                    min = matrix[i, 0];
                    minm = i;
                }
            }

            answer = new int[n - 1, m];

            int k = 0;

            for (int i = 0; i < n; i++)
            {
                if (i != minm)
                {
                    for (int j = 0; j < m; j++)
                    {
                        answer[k, j] = matrix[i, j];
                    }

                    k++;
                }
            }

            // end

            return answer;
        }
        public int Task5(int[,] matrix)
        {
            int sum = 0;

            // code here
            if ( matrix.GetLength(0) != matrix.GetLength(1)) return 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[i, i];
            }
            // end

            return sum;
        }
        public void Task6(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int firstNeg = -1;
                int lastNeg = -1;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        if (firstNeg == -1)
                            firstNeg = j;
                        lastNeg = j;
                    }
                }
                if (firstNeg <= 0)
                    continue;

                int maxIndex = 0;
                for (int j = 1; j < firstNeg; j++)
                {
                    if (matrix[i, j] > matrix[i, maxIndex])
                        maxIndex = j;
                }

                int temp = matrix[i, maxIndex];
                matrix[i, maxIndex] = matrix[i, lastNeg];
                matrix[i, lastNeg] = temp;
            }
            // end

        }
        public int[] Task7(int[,] matrix)
        {
            int[] negatives = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int count = 0;
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    if (matrix[i, j] < 0)
                        count++;

            if (count > 0)
            {
                negatives = new int[count];
                int k = 0;
                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < cols; j++)
                        if (matrix[i, j] < 0)
                            negatives[k++] = matrix[i, j];
            }
            // end

            return negatives;
        }
        public void Task8(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (cols == 1) return; 

            for (int i = 0; i < rows; i++)
            {

                int maxIndex = 0;
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > matrix[i, maxIndex])
                        maxIndex = j;
                }

                int target;
                if (maxIndex == 0)
                    target = 1;
                else if (maxIndex == cols - 1)
                    target = cols - 2;
                else
                {
                  
                    if (matrix[i, maxIndex - 1] <= matrix[i, maxIndex + 1])
                        target = maxIndex - 1;
                    else
                        target = maxIndex + 1;
                }

                matrix[i, target] *= 2;
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1) / 2; j++)
                {                    
                    (matrix[i, j], matrix[i, matrix.GetLength(1) - 1 - j]) = (matrix[i, matrix.GetLength(1) - 1 - j], matrix[i, j]);              
                }
            }
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (n != m)
                return;

            for (int i = n / 2; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    matrix[i, j] = 1;
                }
            }
            // end

        }
        public int[,] Task11(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int count = 0;
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            for (int i = 0; i < n; i++)
            {
                bool zero = false;

                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        zero = true;
                        break;
                    }
                }

                if (!zero)
                    count++;
            }

            int[,] answer1 = new int[count, m];

   
            int k = 0;

            for (int i = 0; i < n; i++)
            {
                bool zero = false;

                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        zero = true;
                        break;
                    }
                }

                if (!zero)
                {
                    for (int j = 0; j < m; j++)
                    {
                        answer1[k, j] = matrix[i, j];
                    }

                    k++;
                }
            }
            // end

            return answer1;
        }
        public void Task12(int[][] array)
        {

            // code here
            for (int i = 0; i < array.Length - 1; i++)
{
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    int sum1 = 0;
                    int sum2 = 0;

                    for (int k = 0; k < array[j].Length; k++)
                    {
                        sum1 += array[j][k];
                    }

                    for (int k = 0; k < array[j + 1].Length; k++)
                    {
                        sum2 += array[j + 1][k];
                    }

                    if (sum1 > sum2)
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                }
            }
            // end

        }
    }
}