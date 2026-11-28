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
            int n=matrix.GetLength(0);
            int m = matrix.GetLength(1);
            answer = new double[n];
            for (int i=0; i<n;i++)
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
                if(count==0)
                {
                    answer[i] = 0;
                }
                else
                {
                    answer[i] = sum / count;
                }
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
            int maxn = 0;
            int maxm = 0;
            int maxVal = matrix[0, 0];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > maxVal)
                    {
                        maxVal = matrix[i, j];
                        maxn = i;
                        maxm = j;
                    }
                }
            }

            answer = new int[n - 1, m - 1];
            int newn = 0;

            for (int i = 0; i < n; i++)
            {
                if (i == maxn) continue;

                int newm = 0;
                for (int j = 0; j < m; j++)
                {
                    if (j == maxm) continue;

                    answer[newn, newm] = matrix[i, j];
                    newm++;
                }
                newn++;
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
                int maxindex = 0;
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] > matrix[i, maxindex])
                    {
                        maxindex = j;
                    }
                }
                int maxval = matrix[i, maxindex];

                for (int j = maxindex; j < m - 1; j++)
                {
                    matrix[i, j] = matrix[i, j + 1];
                }

                matrix[i, m - 1] = maxval;

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

            for (int i = 0; i < n; i++)
            {
                int maxval = matrix[i, 0];
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] > maxval)
                    {
                        maxval = matrix[i, j];
                    }
                }

                for (int j = 0; j < m - 1; j++)
                {
                    answer[i, j] = matrix[i, j];
                }

                answer[i, m - 1] = maxval;

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

            if (count == 0)
            {
                return new int[0];
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

            int maxDiagN = 0;
            int maxDiagVal = matrix[0, 0];

            for (int i = 1; i < n; i++)
            {
                if (matrix[i, i] > maxDiagVal)
                {
                    maxDiagVal = matrix[i, i];
                    maxDiagN = i;
                }
            }

            int negn = -1;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i, k] < 0)
                {
                    negn = i;
                    break;
                }
            }

            if (negn != -1 && maxDiagN != negn)
            {
                for (int j = 0; j < m; j++)
                {
                    int temp = matrix[maxDiagN, j];
                    matrix[maxDiagN, j] = matrix[negn, j];
                    matrix[negn, j] = temp;
                }
            }
            // end

        }
        public void Task7(int[,] matrix, int[] array)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (m < 2) return;
            if (array == null || array.Length != m) return;

            
            int maxn = 0;
            int maxVal = matrix[0, m - 2];

            for (int i = 1; i < n; i++)
            {
                if (matrix[i, m - 2] > maxVal)
                {
                    maxVal = matrix[i, m - 2];
                    maxn = i;
                }
            }

            for (int j = 0; j < m; j++)
            {
                matrix[maxn, j] = array[j];
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
                int maxn= 0;
                int maxVal = matrix[0, j];

                for (int i = 1; i < n; i++)
                {
                    if (matrix[i, j] > maxVal)
                    {
                        maxVal = matrix[i, j];
                        maxn = i;
                    }
                }

                if (maxn < n / 2)
                {
                    int sum = 0;
                    for (int i = maxn + 1; i < n ; i++)
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

            for (int i = 0; i < n - 1; i += 2)
            {
                int oddMaxM = 0;
                int oddMaxVal = matrix[i, 0];

                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] > oddMaxVal)
                    {
                        oddMaxVal = matrix[i, j];
                        oddMaxM = j;
                    }
                }

                int evenMaxM = 0;
                int evenMaxVal = matrix[i + 1, 0];

                for (int j = 1; j < m; j++)
                {
                    if (matrix[i + 1, j] > evenMaxVal)
                    {
                        evenMaxVal = matrix[i + 1, j];
                        evenMaxM = j;
                    }
                }

                matrix[i, oddMaxM] = evenMaxVal;
                matrix[i + 1, evenMaxM] = oddMaxVal;
            }
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (n != m) return;

            int maxDiagN = 0;
            int maxDiagVal = matrix[0, 0];

            for (int i = 1; i < n; i++)
            {
                if (matrix[i, i] > maxDiagVal)
                {
                    maxDiagVal = matrix[i, i];
                    maxDiagN = i;
                }
            }

            for (int i = 0; i < maxDiagN; i++)
            {
                for (int j = i + 1; j < m; j++)
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

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    int count1 = 0;
                    for (int k = 0; k < m; k++)
                    {
                        if (matrix[j, k] > 0) count1++;
                    }

                    int count2 = 0;
                    for (int k = 0; k < m; k++)
                    {
                        if (matrix[j + 1, k] > 0) count2++;
                    }

                    if (count1 < count2)
                    {
                        for (int k = 0; k < m; k++)
                        {
                            int temp = matrix[j, k];
                            matrix[j, k] = matrix[j + 1, k];
                            matrix[j + 1, k] = temp;
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
            if (array == null || array.Length == 0) return new int[0][];

            double totalSum = 0;
            int totalCount = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    totalSum += array[i][j];
                    totalCount++;
                }
            }

            double globalAvg = totalCount == 0 ? 0 : totalSum / totalCount;

            int keepCount = 0;
            for (int i = 0; i < array.Length; i++)
            {
                double rowSum = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    rowSum += array[i][j];
                }
                double rowAvg = array[i].Length == 0 ? 0 : rowSum / array[i].Length;

                if (rowAvg >= globalAvg)
                {
                    keepCount++;
                }
            }

            if (keepCount == 0) return new int[0][];

            answer = new int[keepCount][];
            int index = 0;

            for (int i = 0; i < array.Length; i++)
            {
                double rowSum = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    rowSum += array[i][j];
                }
                double rowAvg = array[i].Length == 0 ? 0 : rowSum / array[i].Length;

                if (rowAvg >= globalAvg)
                {
                    answer[index] = array[i];
                    index++;
                }
            }
            // end

            return answer;
        }
    }
}