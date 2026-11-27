using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Green
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;

            // code here
            if (matrix == null) return null;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            answer = new int[rows];

            for (int i = 0; i < rows; i++)
            {
                int minVal = matrix[i, 0];
                int minCol = 0;
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] < minVal)
                    {
                        minVal = matrix[i, j];
                        minCol = j;
                    }
                }
                answer[i] = minCol;
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            if (matrix == null) return;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                int maxVal = matrix[i, 0];
                int maxCol = 0;
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > maxVal)
                    {
                        maxVal = matrix[i, j];
                        maxCol = j;
                    }
                }

                if (maxVal != 0)
                {
                    for (int j = 0; j < maxCol; j++)
                    {
                        if (matrix[i, j] < 0)
                        {
                            matrix[i, j] = (int)Math.Floor((double)matrix[i, j] / maxVal);
                        }
                    }
                }
            }
            // end

        }
        public void Task3(int[,] matrix, int k)
        {

            // code here
            if (matrix == null) return;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (rows != cols || k < 0 || k >= cols) return;

            int maxDiag = matrix[0, 0];
            int diagCol = 0;
            for (int i = 1; i < rows; i++)
            {
                if (matrix[i, i] > maxDiag)
                {
                    maxDiag = matrix[i, i];
                    diagCol = i;
                }
            }

            if (diagCol != k)
            {
                for (int i = 0; i < rows; i++)
                {
                    int temp = matrix[i, k];
                    matrix[i, k] = matrix[i, diagCol];
                    matrix[i, diagCol] = temp;
                }
            }
            // end

        }
        public void Task4(int[,] matrix)
        {

            // code here
            if (matrix == null) return;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (rows != cols) return;

            int maxDiag = matrix[0, 0];
            int idx = 0;
            for (int i = 1; i < rows; i++)
            {
                if (matrix[i, i] > maxDiag)
                {
                    maxDiag = matrix[i, i];
                    idx = i;
                }
            }

            for (int i = 0; i < rows; i++)
            {
                int temp = matrix[idx, i];
                matrix[idx, i] = matrix[i, idx];
                matrix[i, idx] = temp;
            }
            // end

        }
        public int[,] Task5(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            if (matrix == null) return null;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int maxSum = 0;
            int targetRow = 0;
            for (int i = 0; i < rows; i++)
            {
                int sum = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                    }
                }
                if (i == 0 || sum > maxSum)
                {
                    maxSum = sum;
                    targetRow = i;
                }
            }

            answer = new int[rows - 1, cols];
            int newRow = 0;
            for (int i = 0; i < rows; i++)
            {
                if (i == targetRow) continue;
                for (int j = 0; j < cols; j++)
                {
                    answer[newRow, j] = matrix[i, j];
                }
                newRow++;
            }
            // end

            return answer;
        }
        public void Task6(int[,] matrix)
        {

            // code here
            if (matrix == null) return;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (rows < 2) return;

            int[] negCounts = new int[rows];
            int minNeg = int.MaxValue;
            int maxNeg = int.MinValue;
            int minRow = 0;
            int maxRow = 0;

            for (int i = 0; i < rows; i++)
            {
                int count = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        count++;
                    }
                }
                negCounts[i] = count;

                if (count < minNeg)
                {
                    minNeg = count;
                    minRow = i;
                }
                if (count > maxNeg)
                {
                    maxNeg = count;
                    maxRow = i;
                }
            }

            if (minNeg == maxNeg || minRow == maxRow) return;

            for (int j = 0; j < cols; j++)
            {
                int temp = matrix[minRow, j];
                matrix[minRow, j] = matrix[maxRow, j];
                matrix[maxRow, j] = temp;
            }
            // end

        }
        public int[,] Task7(int[,] matrix, int[] array)
        {
            int[,] answer = null;

            // code here
            if (matrix == null || array == null) return null;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (array.Length != rows) return null;

            int minVal = matrix[0, 0];
            int minCol = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < minVal)
                    {
                        minVal = matrix[i, j];
                        minCol = j;
                    }
                }
            }

            answer = new int[rows, cols + 1];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j <= minCol; j++)
                {
                    answer[i, j] = matrix[i, j];
                }
                answer[i, minCol + 1] = array[i];
                for (int j = minCol + 1; j < cols; j++)
                {
                    answer[i, j + 1] = matrix[i, j];
                }
            }
            // end

            return answer;
        }
        public void Task8(int[,] matrix)
        {

            // code here
            if (matrix == null) return;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int j = 0; j < cols; j++)
            {
                int pos = 0;
                int neg = 0;
                int maxVal = matrix[0, j];
                int maxRow = 0;

                for (int i = 0; i < rows; i++)
                {
                    int val = matrix[i, j];
                    if (val > 0) pos++;
                    else if (val < 0) neg++;

                    if (val > maxVal)
                    {
                        maxVal = val;
                        maxRow = i;
                    }
                }

                if (pos > neg)
                {
                    matrix[maxRow, j] = 0;
                }
                else if (neg > pos)
                {
                    matrix[maxRow, j] = maxRow;
                }
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            if (matrix == null) return;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (rows != cols) return;

            for (int i = 0; i < rows; i++)
            {
                matrix[0, i] = 0;
                matrix[rows - 1, i] = 0;
                matrix[i, 0] = 0;
                matrix[i, cols - 1] = 0;
            }
            // end

        }
        public (int[] A, int[] B) Task10(int[,] matrix)
        {
            int[] A = null, B = null;

            // code here
            if (matrix == null) return (null, null);
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (rows != cols) return (null, null);

            int upperCount = rows * (rows + 1) / 2;
            int lowerCount = rows * (rows - 1) / 2;
            A = new int[upperCount];
            B = new int[lowerCount];

            int idxA = 0;
            int idxB = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (j >= i)
                    {
                        A[idxA++] = matrix[i, j];
                    }
                    else
                    {
                        B[idxB++] = matrix[i, j];
                    }
                }
            }
            // end

            return (A, B);
        }
        public void Task11(int[,] matrix)
        {

            // code here
            if (matrix == null) return;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int j = 0; j < cols; j++)
            {
                int[] col = new int[rows];
                for (int i = 0; i < rows; i++)
                {
                    col[i] = matrix[i, j];
                }

                bool evenCol = (j % 2 == 0);
                for (int i = 1; i < rows; i++)
                {
                    int key = col[i];
                    int k = i - 1;
                    while (k >= 0 && (evenCol ? col[k] < key : col[k] > key))
                    {
                        col[k + 1] = col[k];
                        k--;
                    }
                    col[k + 1] = key;
                }

                for (int i = 0; i < rows; i++)
                {
                    matrix[i, j] = col[i];
                }
            }
            // end

        }
        public void Task12(int[][] array)
        {

            // code here
            if (array == null || array.Length <= 1) return;

            for (int i = 1; i < array.Length; i++)
            {
                int[] current = array[i];
                int curLen = current != null ? current.Length : 0;
                int curSum = 0;
                if (current != null)
                {
                    for (int x = 0; x < current.Length; x++)
                    {
                        curSum += current[x];
                    }
                }

                int j = i - 1;
                while (j >= 0)
                {
                    int[] prev = array[j];
                    int prevLen = prev != null ? prev.Length : 0;
                    int prevSum = 0;
                    if (prev != null)
                    {
                        for (int x = 0; x < prev.Length; x++)
                        {
                            prevSum += prev[x];
                        }
                    }

                    bool shouldSwap = prevLen < curLen || (prevLen == curLen && prevSum < curSum);
                    if (!shouldSwap) break;

                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = current;
            }
            // end

        }
    }
}
