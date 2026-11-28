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
            int k = 0,  x = matrix.GetLength(0), y = matrix.GetLength(1);
            answer = new double[x];

            for (int i = 0; i < x; i++)
            {
                int sum = 0, count = 0;


                for (int j = 0; j < y; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        count++;
                    }
                }
                if (count > 0)
                    answer[i] = (double)sum / count;
                else
                    answer[i] = 0;
            }
            

            // end

            return answer;
        }
        public int[,] Task2(int[,] matrix)
        {
            int[,] answer = null;

            // code here  
            int max = int.MinValue, maxN = -1, maxM = -1;
            int k = 0, n = matrix.GetLength(0), m = matrix.GetLength(1);
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m ; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i,j];
                        maxN = i;
                        maxM = j;
                    }
                }
            }
            answer = new int[n - 1, m - 1];
            int row = 0;
            
            for (int i = 0; i<n; i++)
            {
                if (i == maxN) continue;
                int col = 0;
                for (int j = 0; j<m; j++)
                {

                    if (j == maxM) continue;
                    answer[row, col] = matrix[i, j];
                    col++;
                }
                row++;
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
                int max = int.MinValue;
                int maxRow = -1;
                int maxCol = -1;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxCol = j;

                    }    
                }
                for (int j = maxCol; j < m - 1; j++)
                {
                    matrix[i, j] = matrix[i, j + 1];
                }
                matrix[i, m - 1] = max;
            }

            // end
            

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            answer = new int[n, m + 1];
            for (int i = 0; i<n; i++)
            {
                int max = int.MinValue;
                for (int j = 0; (j < m); j++)
                {
                    if ((matrix[i, j] > max))
                    {
                        max = matrix[i, j];
                    }
                }
                for (int j = 0; j<m-1; j++)
                {
                    answer[i, j] = matrix[i, j];
                }      
                answer[i, m-1] = max;
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
            int k = 0;

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
            // end

            return answer;
        }
        public void Task6(int[,] matrix, int k)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (n != m || k < 0 || k >= n)
                return;

            int max = int.MinValue;
            int maxRow = -1;
            int negativeRow = -1;

            for (int i = 0; i < n; i++)
            {
                if (maxRow == -1 || matrix[i, i] > max)
                {
                    max = matrix[i, i];
                    maxRow = i;
                }

                if (negativeRow == -1 && matrix[i, k] < 0)
                {
                    negativeRow = i;
                }
            }

            if (negativeRow == -1 || negativeRow == maxRow)
                return;

            for (int j = 0; j < m; j++)
            {
                int saved = matrix[maxRow, j];
                matrix[maxRow, j] = matrix[negativeRow, j];
                matrix[negativeRow, j] = saved;
            }
            // end

        }
        public void Task7(int[,] matrix, int[] array)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (m < 2 || n == 0 || array == null || array.Length != m)
                return;

            int max = int.MinValue;
            int maxRow = -1;
            int targetCol = m - 2;

            for (int i = 0; i < n; i++)
            {
                if (matrix[i, targetCol] > max)
                {
                    max = matrix[i, targetCol];
                    maxRow = i;
                }
            }

            for (int j = 0; j < m; j++)
            {
                matrix[maxRow, j] = array[j];
            }
            // end

        }
        public void Task8(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            for (int j = 0; j < m; j++)
            {
                int maxRow = 0;

                for (int i = 1; i < n; i++)
                {
                    if (matrix[i, j] > matrix[maxRow, j])
                    {
                        maxRow = i;
                    }
                }

                if (maxRow < n / 2)
                {
                    int sum = 0;

                    for (int i = maxRow + 1; i < n; i++)
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
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            for (int i = 0; i + 1 < n; i += 2)
            {
                int firstCol = 0;
                int secondCol = 0;

                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] > matrix[i, firstCol])
                    {
                        firstCol = j;
                    }

                    if (matrix[i + 1, j] > matrix[i + 1, secondCol])
                    {
                        secondCol = j;
                    }
                }

                int saved = matrix[i, firstCol];
                matrix[i, firstCol] = matrix[i + 1, secondCol];
                matrix[i + 1, secondCol] = saved;
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

            int maxIndex = 0;

            for (int i = 1; i < n; i++)
            {
                if (matrix[i, i] > matrix[maxIndex, maxIndex])
                {
                    maxIndex = i;
                }
            }

            for (int i = 0; i < maxIndex; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    matrix[i, j] = 0;
                }
            }
            // end

        }
        public void Task11(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[] counts = new int[n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        counts[i]++;
                    }
                }
            }

            for (int end = n - 1; end > 0; end--)
            {
                for (int i = 0; i < end; i++)
                {
                    if (counts[i] >= counts[i + 1])
                        continue;

                    int savedCount = counts[i];
                    counts[i] = counts[i + 1];
                    counts[i + 1] = savedCount;

                    for (int j = 0; j < m; j++)
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
            int n = array.Length;
            double[] means = new double[n];
            double total = 0;
            long size = 0;

            for (int i = 0; i < n; i++)
            {
                double sum = 0;
                for (int j = 0; j < array[i].Length; j++)
                    sum += array[i][j];

                if (array[i].Length > 0)
                    means[i] = sum / array[i].Length;

                total += sum;
                size += array[i].Length;
            }

            double average = 0;
            if (size != 0)
                average = total / size;

            int count = 0;
            for (int i = 0; i < n; i++)
                if (means[i] >= average)
                    count++;

            answer = new int[count][];
            int position = 0;

            for (int i = 0; i < n; i++)
                if (means[i] >= average)
                    answer[position++] = (int[])array[i].Clone();
            // end

            return answer;
        }
    }
}