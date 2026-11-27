using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Blue
    {
        public double[] Task1(int[,] matrix)
        {
            double[] answer = new double[matrix.GetLength(0)];
            int n= matrix.GetLength(0),m=matrix.GetLength(1);

            // code here
            for (int i = 0; i < n; i++) {
                double a = 0;
                 int count =0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0) { a += matrix[i, j];count++; }

                }
                if (count != 0) answer[i] = a / count;
                else { answer[i] = 0; }
            }
            // end

            return answer;
        }
        public int[,] Task2(int[,] matrix)
        {
            int[,] answer = new int[matrix.GetLength(0)-1,matrix.GetLength(1)-1];

            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int max=int.MinValue;
            int f = 0, z = 0;
            // code here
            for (int i = n-1; i >=0; i--)            {
                
                for (int j = m-1; j >=0; j--)
                {
                    if (matrix[i, j] >= max) { max = matrix[i, j];f = i;z = j; }

                }
               
           
            }
            for (int i = n - 1; i >= 0; i--)
            {
             
                for (int j = m - 1; j >= 0; j--)
                {
                    if (i == f || j == z)
                        continue;

                    int row = i > f ? i - 1 : i;
                    int col = j > z ? j - 1 : j;
                    answer[row, col] = matrix[i, j];


                }


            }

            return answer;
        }
        public void Task3(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);

            if (m == 0)
                return;

            for (int i = n - 1; i >= 0; i--)
            {
                int max = int.MinValue;
                int z = 0;

                for (int j = m - 1; j >= 0; j--)
                {
                    if (matrix[i, j] >= max)
                    {
                        max = matrix[i, j];
                        z = j;
                    }
                }

                for (int j = z; j < m - 1; j++)
                {
                    matrix[i, j] = matrix[i, j + 1];
                }

                matrix[i, m - 1] = max;
            }
            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);

            if (m == 0)
                return matrix;

            int[,] answer = new int[n, m + 1];

            for (int i = n - 1; i >= 0; i--)
            {
                int max = int.MinValue;

                for (int j = m - 1; j >= 0; j--)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                    }

                    int col = j == m - 1 ? m : j;
                    answer[i, col] = matrix[i, j];
                }

                answer[i, m - 1] = max;
            }

            return answer;

            
        }
        public int[] Task5(int[,] matrix)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int[] answer = new int[matrix.Length / 2];
            int k = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if ((i + j) % 2 != 0)
                    {
                        answer[k] = matrix[i, j];
                        k++;
                    }
                }
            }

            return answer;

            
        }
        public void Task6(int[,] matrix, int k)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);

            if (n != m || k < 0 || k >= m)
                return;

            int max = matrix[0, 0];
            int f = 0, z = -1;

            for (int i = 1; i < n; i++)
            {
                if (matrix[i, i] > max)
                {
                    max = matrix[i, i];
                    f = i;
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (matrix[i, k] < 0)
                {
                    z = i;
                    break;
                }
            }

            if (z == -1 || f == z)
                return;

            for (int j = 0; j < m; j++)
            {
                int temp = matrix[f, j];
                matrix[f, j] = matrix[z, j];
                matrix[z, j] = temp;
            }
        }
        public void Task7(int[,] matrix, int[] array)
        {

            int n = matrix.GetLength(0), m = matrix.GetLength(1);

            if (n == 0 || m < 2 || array.Length != m)
                return;

            int col = m - 2;
            int f = 0;
            int max = matrix[0, col];

            for (int i = 1; i < n; i++)
            {
                if (matrix[i, col] > max)
                {
                    max = matrix[i, col];
                    f = i;
                }
            }

            for (int j = 0; j < m; j++)
            {
                matrix[f, j] = array[j];
            }

        }
        public void Task8(int[,] matrix)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);

            if (n < 2)
                return;

            for (int j = 0; j < m; j++)
            {
                int max = matrix[0, j];
                int f = 0;

                for (int i = 1; i < n; i++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        f = i;
                    }
                }

                if (f < n / 2)
                {
                    int sum = 0;

                    for (int i = f + 1; i < n; i++)
                    {
                        sum += matrix[i, j];
                    }

                    matrix[0, j] = sum;
                }
            }

        }
        public void Task9(int[,] matrix)
        {

            int n = matrix.GetLength(0), m = matrix.GetLength(1);

            if (m == 0)
                return;

            for (int i = 0; i + 1 < n; i += 2)
            {
                int f = 0, z = 0;

                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] > matrix[i, f])
                        f = j;

                    if (matrix[i + 1, j] > matrix[i + 1, z])
                        z = j;
                }

                int temp = matrix[i, f];
                matrix[i, f] = matrix[i + 1, z];
                matrix[i + 1, z] = temp;
            }
        }
        public void Task10(int[,] matrix)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);

            if (n != m || n == 0)
                return;

            int f = 0;

            for (int i = 1; i < n; i++)
            {
                if (matrix[i, i] > matrix[f, f])
                    f = i;
            }

            for (int i = 0; i < f; i++)
            {
                for (int j = i + 1; j < m; j++)
                {
                    matrix[i, j] = 0;
                }
            }

        }
        public void Task11(int[,] matrix)
        {

            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int[] count = new int[n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                        count[i]++;
                }
            }

            for (int i = n - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (count[j] >= count[j + 1])
                        continue;

                    int temp = count[j];
                    count[j] = count[j + 1];
                    count[j + 1] = temp;

                    for (int k = 0; k < m; k++)
                    {
                        temp = matrix[j, k];
                        matrix[j, k] = matrix[j + 1, k];
                        matrix[j + 1, k] = temp;
                    }
                }
            }

        }
        public int[][] Task12(int[][] array)
        {
            int n = array.Length;
            long[] rowSum = new long[n];
            long sum = 0, count = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    rowSum[i] += array[i][j];
                }

                sum += rowSum[i];
                count += array[i].Length;
            }

            if (count == 0)
                return array;

            double average = (double)sum / count;
            int[][] answer = new int[n][];
            int k = 0;

            for (int i = 0; i < n; i++)
            {
                int m = array[i].Length;

                if (m == 0 || (double)rowSum[i] / m >= average)
                {
                    answer[k] = array[i];
                    k++;
                }
            }

            System.Array.Resize(ref answer, k);
            return answer;

           
        }
    }
}
