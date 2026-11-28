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
                answer[i] = count > 0 ? sum / count : 0;
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
            int maxVal = int.MinValue;
            int maxRow = -1, maxCol = -1;
            
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > maxVal)
                    {
                        maxVal = matrix[i, j];
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }

            answer = new int[rows - 1, cols - 1];
            int newRow = 0;

            for (int i = 0; i < rows; i++)
            {
                if (i == maxRow) continue; 
                int newCol = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (j == maxCol) continue; 
                    answer[newRow, newCol] = matrix[i, j];
                    newCol++;
                }
                newRow++;
            }
            // end

            return answer;
        }
        public void Task3(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                int maxVal = int.MinValue;
                int maxIndex = -1;
                
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > maxVal)
                    {
                        maxVal = matrix[i, j];
                        maxIndex = j;
                    }
                }
                
                for (int j = maxIndex; j < cols - 1; j++)
                {
                    matrix[i, j] = matrix[i, j + 1];
                }
                
                matrix[i, cols - 1] = maxVal;
            }
            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            
            if (cols == 0) return matrix; 

            answer = new int[rows, cols + 1];

            for (int i = 0; i < rows; i++)
            {
                int maxVal = matrix[i, 0];
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > maxVal) maxVal = matrix[i, j];
                }

                
                for (int j = 0; j < cols - 1; j++)
                {
                    answer[i, j] = matrix[i, j];
                }

                
                answer[i, cols - 1] = maxVal;

                
                answer[i, cols] = matrix[i, cols - 1];
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
            int count = 0;

            
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if ((i + j) % 2 != 0) count++;
                }
            }

            
            answer = new int[count];
            int index = 0;

           
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
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
            if (k < 0 || k >= n) return;

            int maxDiagVal = matrix[0, 0];
            int maxDiagRow = 0;
            for (int i = 1; i < n; i++)
            {
                if (matrix[i, i] > maxDiagVal)
                {
                    maxDiagVal = matrix[i, i];
                    maxDiagRow = i;
                }
            }

            int firstNegRow = -1;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i, k] < 0)
                {
                    firstNegRow = i;
                    break;
                }
            }

            if (firstNegRow != -1 && firstNegRow != maxDiagRow)
            {
                for (int j = 0; j < n; j++)
                {
                    int temp = matrix[maxDiagRow, j];
                    matrix[maxDiagRow, j] = matrix[firstNegRow, j];
                    matrix[firstNegRow, j] = temp;
                }
            }

            // end

        }
        public void Task7(int[,] matrix, int[] array)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (cols < 2) return;

            int targetCol = cols - 2;
            int maxVal = int.MinValue;
            int targetRow = -1;

            for (int i = 0; i < rows; i++)
            {
                if (matrix[i, targetCol] > maxVal)
                {
                    maxVal = matrix[i, targetCol];
                    targetRow = i;
                }
            }

            if (targetRow != -1 && array.Length == cols)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[targetRow, j] = array[j];
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
                int maxVal = int.MinValue;
                int maxPos = -1;

                for (int i = 0; i < rows; i++)
                {
                    if (matrix[i, j] > maxVal)
                    {
                        maxVal = matrix[i, j];
                        maxPos = i;
                    }
                }

                int half = rows / 2;
                if (maxPos < half)
                {
                    int sum = 0;
                    for (int i = maxPos + 1; i < rows; i++)
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
            int n= matrix.GetLength(0);
            int m= matrix.GetLength(1);
            
            for (int i = 0; i < n-1; i=i+2)
            {
                int el1= int.MinValue;
                int el2 = int.MinValue;
                int jind1 = 0;
                int jind2 = 0;
                for (int j=0; j<m;j++)
                {
                    if (matrix[i, j]>el1)
                    {
                        el1= matrix[i, j];
                        jind1 = j;
                    }
                    if (matrix[i+1, j]>el2)
                    {
                        el2 = matrix[i+1, j];
                        jind2 = j;
                    }
                }
                int p = matrix[i, jind1];
                matrix[i, jind1] = matrix[i + 1, jind2];
                matrix[i+1, jind2] = p;
            }
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            int n=matrix.GetLength(0);
            int m=matrix.GetLength(1);
            if (n!=m)
            {
                return;
            }
            int el = int.MinValue;
            int iind = 0;
            for (int i = 0;i < n; i++)
            {
                for (int j=0; j<m; j++)
                {
                    if (i==j && matrix[i, j]>el)
                    {
                        el= matrix[i, j];
                        iind = i;
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (j>i && i<iind)
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

            int[] posCounts = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                int count = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > 0) count++;
                }
                posCounts[i] = count;
            }

            for (int i = 0; i < rows - 1; i++)
            {
                for (int k = 0; k < rows - i - 1; k++)
                {
                    if (posCounts[k] < posCounts[k + 1])
                    {
                        int tempCount = posCounts[k];
                        posCounts[k] = posCounts[k + 1];
                        posCounts[k + 1] = tempCount;

                        for (int j = 0; j < cols; j++)
                        {
                            int tempVal = matrix[k, j];
                            matrix[k, j] = matrix[k + 1, j];
                            matrix[k + 1, j] = tempVal;
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
            if (array == null || array.Length == 0) return array;

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

            if (totalCount == 0) return array;
            double globalAvg = totalSum / totalCount;

            
            int validRowsCount = 0;
            for (int i = 0; i < array.Length; i++)
            {
                double rowSum = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    rowSum += array[i][j];
                }
                double rowAvg = array[i].Length > 0 ? rowSum / array[i].Length : 0;

                if (rowAvg >= globalAvg) validRowsCount++;
            }

            
            answer = new int[validRowsCount][];
            int index = 0;

            
            for (int i = 0; i < array.Length; i++)
            {
                double rowSum = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    rowSum += array[i][j];
                }
                double rowAvg = array[i].Length > 0 ? rowSum / array[i].Length : 0;

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