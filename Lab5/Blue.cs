using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Xml.Serialization;

namespace Lab5
{
    public class Blue
    {
        public double[] Task1(int[,] matrix)
        {
            double[] answer = null;

            // code here
            answer = new double[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                double sum = 0;
                int cnt = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        cnt++;
                    }
                }
                double average;
                if (cnt > 0)
                {
                    average = sum / cnt;
                }
                else
                {
                    average = 0;
                }
                answer[i] = average;
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
            int max = matrix[0, 0];
            int max_i = 0;
            int max_j = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        max_i = i;
                        max_j = j;
                    }
                }
            }
            answer = new int[rows - 1, cols - 1];
            for (int i = 0; i < rows - 1; i++)
            {
                int a_i = (i < max_i) ? i : i + 1;
                for (int j = 0; j < cols - 1; j++)
                {
                    int a_j = (j < max_j) ? j : j + 1;
                    answer[i, j] = matrix[a_i, a_j]; 
                }
            }

            // end

            return answer;
        }
        public void Task3(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (cols <= 1) return;
            for (int i = 0; i < rows; i++)
            {
                int max = matrix[i, 0];
                int max_j = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        max_j = j;
                    }
                }
                for (int j = max_j; j < cols - 1; j++)
                {
                    matrix[i, j] = matrix[i, j + 1];
                }
                matrix[i, cols - 1] = max;
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
                int max = matrix[i, 0];
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                    }
                }
                for (int j = 0; j < cols + 1; j++)
                {
                    if (j < cols - 1)
                    {
                        answer[i, j] = matrix[i, j];
                    }
                    else if (j == cols - 1)
                    {
                        answer[i, j] = max;
                    }
                    else if (j == cols)
                    {
                        answer[i, j] = matrix[i, j - 1];
                    }
                }
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
            int cnt = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if ((i + j) % 2 != 0)
                    {
                        cnt++;
                    }
                }
            }
            answer = new int[cnt];
            int k = 0;
            for (int i_nech = 0; i_nech < rows; i_nech++)
            {
                for (int j_nech = 0; j_nech < cols; j_nech++)
                {
                    if ((i_nech + j_nech) % 2 != 0)
                    {
                        answer[k] = matrix[i_nech, j_nech];
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
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int max = matrix[0, 0];
            int max_i = 0;
            int str = -1;

            if (k >= 0 && k < cols && rows == cols)
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if ((i == j) && (matrix[i, j] > max))
                        {
                            max = matrix[i, j];
                            max_i = i;
                        }
                    }
                }
                for (int i = 0; i < rows; i++)
                {
                    if (matrix[i, k] < 0)
                    {
                        str = i;
                        break;
                    }
                }
                if (str == -1 || str == max_i) return;
                for (int j = 0; j < cols; j++)
                {
                    int temp = matrix[str, j];
                    matrix[str, j] = matrix[max_i, j];
                    matrix[max_i, j] = temp;
                }
            }
            // end

        }
        public void Task7(int[,] matrix, int[] array)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int max_i = 0; 
            if (cols >= 2 && array.Length == cols)
            {
                int max = matrix[0, cols - 2];
                for (int i = 0; i < rows; i++)
                {
                    if (matrix[i, cols - 2] > max)
                    {
                        max = matrix[i, cols - 2];
                        max_i = i;
                        break;
                    }
                }
                for (int j = 0; j < array.Length; j++)
                {
                    matrix[max_i, j] = array[j];
                }
            }
            // end

        }
        public void Task8(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int j = 0; j < cols; j++)
            {
                int max = int.MinValue;
                int max_i = -1;
                int sum = 0;
                for (int i = 0; i < rows; i++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        max_i = i;
                    }
                }
                if (max_i < rows / 2)
                {
                    for (int i = max_i + 1; i < rows; i++)
                    {
                            sum += matrix[i, j];
                    }
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
            if (rows > 1)
            {
                for (int i = 0; i < rows - 1; i += 2)
                {
                    int max = int.MinValue;
                    int max_j = -1;
                    int max2 = int.MinValue;
                    int max_j2 = -1;
                    for (int j = 0; j < cols; j++)
                    {
                        if (matrix[i, j] > max)
                        {
                            max = matrix[i, j];
                            max_j = j;
                        }
                        if (matrix[i + 1, j] > max2)
                        {
                            max2 = matrix[i + 1, j];
                            max_j2 = j;
                        }
                    }
                    int temp = matrix[i, max_j];
                    matrix[i, max_j] = matrix[i + 1, max_j2];
                    matrix[i + 1, max_j2] = temp;
                }
            }
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (cols == rows)
            {
                int max = matrix[0, 0];
                int max_i = 0;
                int max_j = 0;
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (i == j && matrix[i, j] > max)
                        {
                            max = matrix[i, j];
                            max_i = i;
                            max_j = j;
                        }
                    }
                }
                for (int i = 0; i < max_i; i++)
                {
                    for (int j = i + 1; j < cols; j++)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }
            // end

        }
        public void Task11(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[] pos = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                int cnt = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        cnt++;
                    }
                }
                pos[i] = cnt;
            }
            for (int i = 0; i < rows - 1; i++)
            {
                for (int k = 0; k < rows - 1 - i; k++)
                {
                    if (pos[k] < pos[k + 1])
                    {
                        (pos[k], pos[k + 1]) = (pos[k + 1], pos[k]);
                        for (int j = 0; j < cols; j++)
                        {
                            (matrix[k, j], matrix[k + 1, j]) = (matrix[k + 1, j], matrix[k, j]);
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
            double totalsum = 0;
            int totalcnt = 0;
            double[] rowsums = new double[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    totalsum += array[i][j];
                    totalcnt++;
                    rowsums[i] += array[i][j];
                }
            }
            if (totalcnt > 0)
            {
                int rows = 0;
                double totalaverage = totalsum / totalcnt;
                for (int i = 0; i < array.Length; i++)
                {
                    double average = rowsums[i] / array[i].Length;
                    if (totalaverage <= average)
                    {
                        rows++;
                    }
                }
                answer = new int[rows][];
                int index = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    double average = rowsums[i] / array[i].Length;
                    if (totalaverage <= average)
                    {
                        answer[index] = new int[array[i].Length];
                        for (int j = 0; j < array[i].Length; j++)
                        {
                            answer[index][j] = array[i][j];
                        }
                        index++;
                    }
                }
            }
                    // end

                    return answer;
        }
    }
}
