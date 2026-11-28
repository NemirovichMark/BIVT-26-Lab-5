using System;
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

                if (count == 0)
                    answer[i] = 0;
                else
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

            int maxRow = 0;
            int maxCol = 0;
            int maxVal = matrix[0, 0];

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
                if (cols <= 1) continue;

                int maxIdx = 0;
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > matrix[i, maxIdx])
                    {
                        maxIdx = j;
                    }
                }

                int maxVal = matrix[i, maxIdx];

                for (int j = maxIdx; j < cols - 1; j++)
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

            answer = new int[rows, cols + 1];

            for (int i = 0; i < rows; i++)
            {
                int maxVal = matrix[i, 0];
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > maxVal)
                    {
                        maxVal = matrix[i, j];
                    }
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
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (rows != cols || k < 0 || k >= cols) return;

            int maxDiagRow = 0;
            int maxDiagVal = matrix[0, 0];

            for (int i = 1; i < rows; i++)
            {
                if (matrix[i, i] > maxDiagVal)
                {
                    maxDiagVal = matrix[i, i];
                    maxDiagRow = i;
                }
            }

            int negRow = -1;
            for (int i = 0; i < rows; i++)
            {
                if (matrix[i, k] < 0)
                {
                    negRow = i;
                    break;
                }
            }

            if (negRow != -1 && maxDiagRow != negRow)
            {
                for (int j = 0; j < cols; j++)
                {
                    int temp = matrix[maxDiagRow, j];
                    matrix[maxDiagRow, j] = matrix[negRow, j];
                    matrix[negRow, j] = temp;
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
            if (array == null || array.Length != cols) return;

            int targetCol = cols - 2;
            int maxRow = 0;
            int maxVal = matrix[0, targetCol];

            for (int i = 1; i < rows; i++)
            {
                if (matrix[i, targetCol] > maxVal)
                {
                    maxVal = matrix[i, targetCol];
                    maxRow = i;
                }
            }

            for (int j = 0; j < cols; j++)
            {
                matrix[maxRow, j] = array[j];
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
                int maxRow = 0;
                int maxVal = matrix[0, j];

                for (int i = 1; i < rows; i++)
                {
                    if (matrix[i, j] > maxVal)
                    {
                        maxVal = matrix[i, j];
                        maxRow = i;
                    }
                }

                if (maxRow < rows / 2)
                {
                    int sum = 0;
                    for (int i = maxRow + 1; i < rows; i++)
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

            for (int i = 0; i < rows - 1; i += 2)
            {
                int oddMaxCol = 0;
                int oddMaxVal = matrix[i, 0];

                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > oddMaxVal)
                    {
                        oddMaxVal = matrix[i, j];
                        oddMaxCol = j;
                    }
                }

                int evenMaxCol = 0;
                int evenMaxVal = matrix[i + 1, 0];

                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i + 1, j] > evenMaxVal)
                    {
                        evenMaxVal = matrix[i + 1, j];
                        evenMaxCol = j;
                    }
                }

                matrix[i, oddMaxCol] = evenMaxVal;
                matrix[i + 1, evenMaxCol] = oddMaxVal;
            }
            // end
        }

        public void Task10(int[,] matrix)
        {
            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (rows != cols) return;

            int maxDiagRow = 0;
            int maxDiagVal = matrix[0, 0];

            for (int i = 1; i < rows; i++)
            {
                if (matrix[i, i] > maxDiagVal)
                {
                    maxDiagVal = matrix[i, i];
                    maxDiagRow = i;
                }
            }

            for (int i = 0; i < maxDiagRow; i++)
            {
                for (int j = i + 1; j < cols; j++)
                {
                    matrix[i, j] = 0;
                }
            }
            // end
        }

        public void Task11(int[,] matrix)
        {
            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < rows - 1 - i; j++)
                {
                    int count1 = 0;
                    for (int k = 0; k < cols; k++)
                    {
                        if (matrix[j, k] > 0) count1++;
                    }

                    int count2 = 0;
                    for (int k = 0; k < cols; k++)
                    {
                        if (matrix[j + 1, k] > 0) count2++;
                    }

                    if (count1 < count2)
                    {
                        for (int k = 0; k < cols; k++)
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