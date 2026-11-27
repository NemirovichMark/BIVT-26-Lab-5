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
            if (matrix == null || matrix.GetLength(0) < 1 || matrix.GetLength(1) < 1)
                return new int[0];

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[] result = new int[rows];

            for (int i = 0; i < rows; i++)
            {
                int min = matrix[i, 0];
                int minIndex = 0;
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        minIndex = j;
                    }
                }
                result[i] = minIndex;
            }
            answer = result;
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            if (matrix == null || matrix.GetLength(0) < 1 || matrix.GetLength(1) < 1)
                return;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                int max = matrix[i, 0];
                int maxIndex = 0;
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxIndex = j;
                    }
                }

                for (int j = maxIndex - 1; j >= 0; j--)
                {
                    if (matrix[i, j] < 0)
                    {
                        int divisor = max;
                        if (divisor != 0)
                        {
                            matrix[i, j] = (int)Math.Floor((double)matrix[i, j] / divisor);
                        }
                    }
                }
            }
            // end

        }
        public void Task3(int[,] matrix, int k)
        {

            // code here
            if (matrix == null || matrix.GetLength(0) < 1 || matrix.GetLength(1) < 1)
                return;

            int n = matrix.GetLength(0);
            if (n != matrix.GetLength(1))
                return;
            if (k < 0 || k >= n)
                return;

            int maxDiag = matrix[0, 0];
            int maxCol = 0;
            for (int i = 1; i < n; i++)
            {
                if (matrix[i, i] > maxDiag)
                {
                    maxDiag = matrix[i, i];
                    maxCol = i;
                }
            }

            if (maxCol == k)
                return;

            for (int i = 0; i < n; i++)
            {
                int temp = matrix[i, k];
                matrix[i, k] = matrix[i, maxCol];
                matrix[i, maxCol] = temp;
            }
            // end

        }
        public void Task4(int[,] matrix)
        {

            // code here
            if (matrix == null || matrix.GetLength(0) < 1 || matrix.GetLength(1) < 1)
                return;

            int n = matrix.GetLength(0);
            if (n != matrix.GetLength(1))
                return;

            int maxDiag = matrix[0, 0];
            int k = 0;
            for (int i = 1; i < n; i++)
            {
                if (matrix[i, i] > maxDiag)
                {
                    maxDiag = matrix[i, i];
                    k = i;
                }
            }

            for (int j = 0; j < n; j++)
            {
                if (j == k)
                    continue;
                int temp = matrix[k, j];
                matrix[k, j] = matrix[j, k];
                matrix[j, k] = temp;
            }
            // end

        }
        public int[,] Task5(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            if (matrix == null || matrix.GetLength(0) < 1 || matrix.GetLength(1) < 1)
                return null;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int maxSum = int.MinValue;
            int maxRow = 0;
            for (int i = 0; i < rows; i++)
            {
                int sum = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > 0)
                        sum += matrix[i, j];
                }
                if (sum > maxSum)
                {
                    maxSum = sum;
                    maxRow = i;
                }
            }

            if (rows == 1)
                return new int[0, cols];

            int[,] result = new int[rows - 1, cols];
            int r = 0;
            for (int i = 0; i < rows; i++)
            {
                if (i == maxRow)
                    continue;
                for (int j = 0; j < cols; j++)
                {
                    result[r, j] = matrix[i, j];
                }
                r++;
            }
            answer = result;
            // end

            return answer;
        }
        public void Task6(int[,] matrix)
        {

            // code here
            if (matrix == null || matrix.GetLength(0) < 1 || matrix.GetLength(1) < 1)
                return;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[] negCount = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                int count = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < 0)
                        count++;
                }
                negCount[i] = count;
            }

            int minRow = 0, maxRow = 0;
            for (int i = 1; i < rows; i++)
            {
                if (negCount[i] < negCount[minRow])
                    minRow = i;
                if (negCount[i] > negCount[maxRow])
                    maxRow = i;
            }

            bool allSame = true;
            for (int i = 1; i < rows; i++)
            {
                if (negCount[i] != negCount[0])
                {
                    allSame = false;
                    break;
                }
            }

            if (allSame || minRow == maxRow)
                return;

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
            if (matrix == null)
                return null;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            
            if (array == null || array.Length != rows)
            {
                int[,] copy = new int[rows, cols];
                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < cols; j++)
                        copy[i, j] = matrix[i, j];
                return copy;
            }

            
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

            
            int[,] result = new int[rows, cols + 1];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j <= minCol; j++)
                    result[i, j] = matrix[i, j];

                result[i, minCol + 1] = array[i];

                for (int j = minCol + 1; j < cols; j++)
                    result[i, j + 1] = matrix[i, j];
            }

            answer = result;
            // end

            return answer;
        }
        public void Task8(int[,] matrix)
        {

            // code here
            if (matrix == null || matrix.GetLength(0) < 1 || matrix.GetLength(1) < 1)
                return;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int j = 0; j < cols; j++)
            {
                int posCount = 0, negCount = 0;
                int maxVal = matrix[0, j];
                int maxRow = 0;

                for (int i = 0; i < rows; i++)
                {
                    if (matrix[i, j] > 0)
                        posCount++;
                    else if (matrix[i, j] < 0)
                        negCount++;
                    if (matrix[i, j] > maxVal)
                    {
                        maxVal = matrix[i, j];
                        maxRow = i;
                    }
                }

                if (posCount > negCount)
                    matrix[maxRow, j] = 0;
                else if (negCount > posCount)
                    matrix[maxRow, j] = maxRow;
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            if (matrix == null || matrix.GetLength(0) < 1 || matrix.GetLength(1) < 1)
                return;

            int n = matrix.GetLength(0);
            if (n != matrix.GetLength(1))
                return;

            int total = n * n;
            for (int idx = 0; idx < total; idx++)
            {
                int i = idx / n;
                int j = idx % n;
                bool onPerimeter = (i == 0 || i == n - 1 || j == 0 || j == n - 1);
                if (onPerimeter)
                    matrix[i, j] = 0;
            }
            // end

        }
        public (int[] A, int[] B) Task10(int[,] matrix)
        {
            int[] A = null, B = null;

            // code here
            if (matrix == null)
                return (null, null);

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n < 1 || m < 1 || n != m)
                return (null, null);

            int countA = n * (n + 1) / 2;
            int countB = n * (n - 1) / 2;

            A = new int[countA];
            B = new int[countB];

            int aIdx = 0, bIdx = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j >= i)
                        A[aIdx++] = matrix[i, j];
                    else
                        B[bIdx++] = matrix[i, j];
                }
            }
            // end

            return (A, B);
        }
        public void Task11(int[,] matrix)
        {

            // code here
            if (matrix == null || matrix.GetLength(0) < 1 || matrix.GetLength(1) < 1)
                return;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int j = 0; j < cols; j++)
            {
                int[] column = new int[rows];
                for (int i = 0; i < rows; i++)
                    column[i] = matrix[i, j];

                int[] sorted;
                if (j % 2 == 0)
                    sorted = column.OrderByDescending(x => x).ToArray();
                else
                    sorted = column.OrderBy(x => x).ToArray();

                for (int i = 0; i < rows; i++)
                    matrix[i, j] = sorted[i];
            }
            // end

        }
        public void Task12(int[][] array)
        {

            // code here
            if (array == null)
                return;

            int n = array.Length;
            if (n <= 1)
                return;

            for (int i = 1; i < n; i++)
            {
                int[] key = array[i];
                int keyLen = key?.Length ?? 0;
                int keySum = 0;
                if (key != null)
                    for (int x = 0; x < key.Length; x++)
                        keySum += key[x];

                int j = i - 1;
                while (j >= 0)
                {
                    int[] cur = array[j];
                    int curLen = cur?.Length ?? 0;
                    int curSum = 0;
                    if (cur != null)
                        for (int x = 0; x < cur.Length; x++)
                            curSum += cur[x];

                    bool shouldMove = curLen < keyLen || (curLen == keyLen && curSum < keySum);
                    if (!shouldMove)
                        break;

                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key;
            }
            // end

        }
    }
}
