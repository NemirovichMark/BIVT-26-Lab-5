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
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int maxRow = 0, maxCol = 0;
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

            int newRows = rows - 1;
            int newCols = cols - 1;
            answer = new int[newRows, newCols];

            int ni = 0;
            for (int i = 0; i < rows; i++)
            {
                if (i == maxRow) continue;
                int nj = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (j == maxCol) continue;
                    answer[ni, nj] = matrix[i, j];
                    nj++;
                }
                ni++;
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
                int maxIdx = 0;
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > matrix[i, maxIdx])
                        maxIdx = j;
                }

                int maxVal = matrix[i, maxIdx];
                for (int j = maxIdx; j < cols - 1; j++)
                    matrix[i, j] = matrix[i, j + 1];
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

            int insertCol = cols - 1;

            for (int i = 0; i < rows; i++)
            {
                int maxVal = matrix[i, 0];
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > maxVal)
                        maxVal = matrix[i, j];
                }

                int destJ = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (j == insertCol)
                    {
                        answer[i, destJ] = maxVal;
                        destJ++;
                    }
                    answer[i, destJ] = matrix[i, j];
                    destJ++;
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
            int count = 0;
            for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                if ((i + j) % 2 == 1)
                    count++;

            answer = new int[count];
            int idx = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if ((i + j) % 2 == 1)
                        answer[idx++] = matrix[i, j];
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
            if (n != m) return;
            if (k < 0 || k >= n) return;

            int diagRow = 0;
            int diagMax = matrix[0, 0];
            for (int i = 1; i < n; i++)
            {
                if (matrix[i, i] > diagMax)
                {
                    diagMax = matrix[i, i];
                    diagRow = i;
                }
            }

            int negRow = -1;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i, k] < 0)
                {
                    negRow = i;
                    break;
                }
            }

            if (negRow == -1 || negRow == diagRow) return;

            for (int j = 0; j < m; j++)
            {
                int tmp = matrix[diagRow, j]; matrix[diagRow, j] = matrix[negRow, j]; matrix[negRow, j] = tmp;
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
                matrix[maxRow, j] = array[j];
            // end

        }
        public void Task8(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int j = 0; j < cols; j++)
            {
                int maxIdx = 0;
                for (int i = 1; i < rows; i++)
                {
                    if (matrix[i, j] > matrix[maxIdx, j])
                        maxIdx = i;
                }

                int half = rows / 2;          
                if (maxIdx < half)            
                {
                    int sum = 0;
                    for (int i = maxIdx + 1; i < rows; i++)
                        sum += matrix[i, j];
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

            for (int r = 0; r + 1 < n; r += 2)
            {
                int max1Idx = 0;
                for (int j = 1; j < m; j++)
                    if (matrix[r, j] > matrix[r, max1Idx])
                        max1Idx = j;

                int max2Idx = 0;
                for (int j = 1; j < m; j++)
                    if (matrix[r + 1, j] > matrix[r + 1, max2Idx])
                        max2Idx = j;

                int tmp = matrix[r, max1Idx];
                matrix[r, max1Idx] = matrix[r + 1, max2Idx];
                matrix[r + 1, max2Idx] = tmp;
            }
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n != m) return;

            int diagMax = matrix[0, 0];
            int diagRow = 0;
            for (int i = 1; i < n; i++)
            {
                if (matrix[i, i] > diagMax)
                {
                    diagMax = matrix[i, i];
                    diagRow = i;
                }
            }

            for (int i = 0; i < diagRow; i++)
            {
                for (int j = i + 1; j < m; j++)
                    matrix[i, j] = 0;
            }
            // end

        }
        public void Task11(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[] counts = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                int c = 0;
                for (int j = 0; j < cols; j++)
                    if (matrix[i, j] > 0) c++;
                counts[i] = c;
            }

            int[] order = new int[rows];
            for (int i = 0; i < rows; i++) order[i] = i;

            for (int i = 1; i < rows; i++)
            {
                int key = order[i];
                int keyCount = counts[key];
                int j = i - 1;
                while (j >= 0 && counts[order[j]] < keyCount)
                {
                    order[j + 1] = order[j];
                    j--;
                }
                order[j + 1] = key;
            }

            int[,] temp = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                temp[i, j] = matrix[order[i], j];

            for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                matrix[i, j] = temp[i, j];
            // end

        }
        public int[][] Task12(int[][] array)
        {
            int[][] answer = null;

            // code here
            if (array == null) return null;

            int totalCount = 0;
            double totalSum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null) continue;
                for (int j = 0; j < array[i].Length; j++)
                {
                    totalSum += array[i][j];
                    totalCount++;
                }
            }
            double totalAvg = totalCount == 0 ? 0 : totalSum / totalCount;

            int keep = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null || array[i].Length == 0)
                {
                    keep++;
                    continue;
                }
                double rowSum = 0;
                for (int j = 0; j < array[i].Length; j++)
                    rowSum += array[i][j];
                double rowAvg = rowSum / array[i].Length;
                if (rowAvg >= totalAvg) keep++;
            }

            answer = new int[keep][];
            int idx = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null || array[i].Length == 0)
                {
                    answer[idx++] = array[i];
                    continue;
                }
                double rowSum = 0;
                for (int j = 0; j < array[i].Length; j++)
                    rowSum += array[i][j];
                double rowAvg = rowSum / array[i].Length;
                if (rowAvg >= totalAvg)
                    answer[idx++] = array[i];
            }
            // end

            return answer;
        }
    }
}
