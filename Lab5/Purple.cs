using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;
            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            answer = new int[cols];
            for (int i = 0; i < cols; i++)
            {
                int k = 0;
                for (int j = 0; j < rows; j++)
                {
                    if (matrix[j,i] < 0)
                    {
                        k++;
                    }
                }
                answer[i] = k;
                
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                int min = int.MaxValue;
                int minIndex = -1;
                for (int j = 0; j < cols; j++)
                {
                    if ( matrix[i,j] < min)
                    {
                        min = matrix[i,j];
                    }
                }
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] == min)
                    {
                        minIndex = j;
                        break;
                    }
                }
                for (int nach = minIndex; nach > 0; nach--)
                {
                    matrix[i, nach] = matrix[i, nach - 1];
                }
                matrix[i, 0] = min;

            }
            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            answer = new int[rows, cols + 1];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    answer[i,j] = matrix[i,j];
                }
                answer[i, cols] = 0;
            }
            for (int i = 0; i < rows; i++)
            {
                int max = int.MinValue;
                int maxIndex = -1;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                    }
                }
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] == max)
                    {
                        maxIndex = j;
                        break;
                    }
                }
                for (int nach = cols; nach > maxIndex; nach--)
                {
                    answer[i, nach] = matrix[i, nach - 1];
                }
            }
                // end

                return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                int max = int.MinValue;
                int maxIndex = -1;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                    }
                }
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] == max)
                    {
                        maxIndex = j;
                        break;
                    }
                }
                int sr_arifm = 0;
                int k_arifm = 0;
                for (int nach = maxIndex + 1; nach < cols; nach++)
                {
                    if (matrix[i, nach] > 0)
                    {
                        sr_arifm += matrix[i, nach];
                        k_arifm++;
                    }
                }
                
                if (k_arifm != 0)
                {
                    sr_arifm = sr_arifm / k_arifm;
                    for (int nach = 0; nach < maxIndex; nach++)
                    {
                        if (matrix[i, nach] < 0)
                        {
                            matrix[i, nach] = sr_arifm;
                        }
                    }
                }
                
            }
                // end

            }
        public void Task5(int[,] matrix, int k)
        {

            // code here
            
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if ((k >= 0) && (k < cols))
            {
                int[] maximus = new int[rows];
                int nach = rows - 1;
                for (int i = 0; i < rows; i++)
                {
                    int max = int.MinValue;
                    for (int j = 0; j < cols; j++)
                    {
                        if (matrix[i, j] > max)
                        {
                            max = matrix[i, j];
                        }
                    }
                    maximus[nach] = max;
                    nach--;
                }
                for (int i = 0; i < rows; i++)
                {
                    matrix[i, k] = maximus[i];
                }
            }
                // end

            }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (array.Length != cols)
            {
                return;
            }
            for (int j = 0; j < cols; j++)
            {
                int max = int.MinValue;
                int maxIndex = -1;
                for (int i = 0; i < rows; i++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxIndex = i;
                    }
                }
                if (array[j] > max)
                {
                    matrix[maxIndex, j] = array[j];
                }
            }
              
                    // end

        }
        public void Task7(int[,] matrix)
        {
            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[] mins = new int[rows];
            int[] order = new int[rows];

            for (int i = 0; i < rows; i++)
            {
                int min = int.MaxValue;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                    }
                }
                mins[i] = min;
                order[i] = i;
            }

            
            for (int pass = 0; pass < rows - 1; pass++)
            {
                for (int r = 0; r < rows - 1 - pass; r++)
                {
                    if (mins[order[r]] < mins[order[r + 1]])
                    {
                        int t = order[r];
                        order[r] = order[r + 1];
                        order[r + 1] = t;
                    }
                }
            }

            int[,] copy = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    copy[i, j] = matrix[order[i], j];
                }
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = copy[i, j];
                }
            }
            // end
        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here
            
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int n = rows;
           
            if (rows == cols)
            {
                answer = new int[n * 2 - 1];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0;j < n; j++)
                    {
                        answer[n - 1 - i + j] += matrix[i, j];
                    }
                   
                }
            }
            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int n = rows;

            if ((rows == cols) && (k >= 0 && k < n))
            {
                int max = int.MinValue;
                int rowIndex = -1;
                int colIndex = -1;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (Math.Abs(matrix[i, j]) > max)
                        {
                            max = Math.Abs(matrix[i, j]);
                            rowIndex = i;
                            colIndex = j;
                        }
                    }
                }
                if (rowIndex > k)
                {
                    while (rowIndex != k)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            int temp = matrix[rowIndex, j];
                            matrix[rowIndex, j] = matrix[rowIndex - 1, j];
                            matrix[rowIndex - 1, j] = temp;
                        }
                        rowIndex--;
                    }
                }
                else
                {
                    while (rowIndex != k)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            int temp = matrix[rowIndex, j];
                            matrix[rowIndex, j] = matrix[rowIndex + 1, j];
                            matrix[rowIndex + 1, j] = temp;
                        }
                        rowIndex++;
                    }
                }
                if (colIndex > k)
                {
                    while (colIndex != k)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            int temp = matrix[i, colIndex];
                            matrix[i, colIndex] = matrix[i, colIndex - 1];
                            matrix[i, colIndex - 1] = temp;
                        }
                        colIndex--;
                    }
                }
                else
                {
                    while (colIndex != k)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            int temp = matrix[i, colIndex];
                            matrix[i, colIndex] = matrix[i, colIndex + 1];
                            matrix[i, colIndex + 1] = temp;
                        }
                        colIndex++;
                    }
                }

            }
            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here
            int rowsA = A.GetLength(0);
            int colsA = A.GetLength(1);

            int rowsB = B.GetLength(0);
            int colsB = B.GetLength(1);

            if (colsA == rowsB)
            {
                answer = new int[rowsA, colsB];

                for (int idx = 0; idx < rowsA * colsB; idx++)
                {
                    int i = idx / colsB;
                    int j = idx % colsB;
                    int element = 0;
                    for (int k = 0; k < colsA; k++)
                    {
                        element += A[i, k] * B[k, j];
                    }
                    answer[i, j] = element;
                }
            }
            // end

            return answer;
        }
        public int[][] Task11(int[,] matrix)
        {
            int[][] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            answer = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                int count = 0;

                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        count++;
                    }
                }
                answer[i] = new int[count];
            }

            for (int i = 0; i < rows; i++)
            {
                int nach = 0;

                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        answer[i][nach] = matrix[i, j];
                        nach++;
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
            int col = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    col++;
                }
            }

            while (Math.Sqrt(col) % 1 != 0)
            {
                col++;
            }

            int n = (int)Math.Sqrt(col);
            answer = new int[n, n];

            int k = 0;
            int g = 0;
            for (int i = 0; i < array.Length; i++)
            {
                
                for (int j = 0; j < array[i].Length; j++)
                {
                    answer[k,g] = array[i][j];
                    g++;
                    if (g == n)
                    {
                        g = 0;
                        k++;
                    }
                }
            }
            // end

            return answer;
        }
    }
}
