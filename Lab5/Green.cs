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
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            answer = new int[n];

            for (int i = 0; i < n; i++)
            {
                int minIndex = 0;
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] < matrix[i, minIndex])
                    {
                        minIndex = j;
                    }
                }
                answer[i] = minIndex;
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            for (int i = 0; i < n; i++)
            {
                int maxIndex = 0;
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] > matrix[i, maxIndex])
                    {
                        maxIndex = j;
                    }
                }

                int maxValue = matrix[i, maxIndex];
                if (maxValue == 0) continue;

                for (int j = 0; j < maxIndex; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        matrix[i, j] = (int)Math.Floor((double)matrix[i, j] / maxValue);
                    }
                }
            }
            // end

        }
        public void Task3(int[,] matrix, int k)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (n != m || k < 0 || k >= m) return;

            int maxCountr = 0;
            for (int i = 1; i < n; i++)
            {
                if (matrix[i, i] > matrix[maxCountr, maxCountr])
                {
                    maxCountr = i;
                }
            }

            if (maxCountr != k)
            {
                for (int i = 0; i < n; i++)
                {
                    int temp = matrix[i, k];
                    matrix[i, k] = matrix[i, maxCountr];
                    matrix[i, maxCountr] = temp;
                }
            }
            // end

        }
        public void Task4(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (n != m) return;

            int maxIndex = 0;
            for (int i = 1; i < n; i++)
            {
                if (matrix[i, i] > matrix[maxIndex, maxIndex])
                {
                    maxIndex = i;
                }
            }

            for (int i = 0; i < n; i++)
            {
                int temp = matrix[maxIndex, i];
                matrix[maxIndex, i] = matrix[i, maxIndex];
                matrix[i, maxIndex] = temp;
            }
            // end

        }
        public int[,] Task5(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (n <= 1)
            {
                return new int[0, m];
            }

            int maxRow = 0;
            int maxSum = 0;

            for (int i = 0; i < n; i++)
            {
                int NowSum = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        NowSum += matrix[i, j];
                    }
                }

                if (i == 0 || NowSum > maxSum)
                {
                    maxSum = NowSum;
                    maxRow = i;
                }
            }

            answer = new int[n - 1, m];
            int statRow = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == maxRow) continue;
                for (int j = 0; j < m; j++)
                {
                    answer[statRow, j] = matrix[i, j];
                }
                statRow++;
            }
            // end

            return answer;
        }
        public void Task6(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int minNegRow = 0, maxNegRow = 0;
            int minNegCount = m + 1, maxNegCount = -1;

            for (int i = 0; i < n; i++)
            {
                int negCount = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < 0) negCount++;
                }

                if (negCount < minNegCount)
                {
                    minNegCount = negCount;
                    minNegRow = i;
                }
                if (negCount > maxNegCount)
                {
                    maxNegCount = negCount;
                    maxNegRow = i;
                }
            }

            if (minNegCount != maxNegCount && minNegRow != maxNegRow)
            {
                for (int j = 0; j < m; j++)
                {
                    int temp = matrix[minNegRow, j];
                    matrix[minNegRow, j] = matrix[maxNegRow, j];
                    matrix[maxNegRow, j] = temp;
                }
            }
            // end

        }
        public int[,] Task7(int[,] matrix, int[] array)
        {
            int[,] answer = null;

            // code here
            int height = matrix.GetLength(0);
            int width = matrix.GetLength(1);

            answer = matrix;

            if (array.Length != height)
            {
                return answer;
            }

            int smallest = matrix[0, 0];
            int insertAfter = 0;

            for (int r = 0; r < height; r++)
            {
                for (int c = 0; c < width; c++)
                {
                    if (matrix[r, c] < smallest)
                    {
                        smallest = matrix[r, c];
                        insertAfter = c;
                    }
                }
            }

            answer = new int[height, width + 1];

            for (int r = 0; r < height; r++)
            {
                for (int c = 0; c < width; c++)
                {
                    if (c <= insertAfter)
                    {
                        answer[r, c] = matrix[r, c];
                    }
                    else
                    {
                        answer[r, c + 1] = matrix[r, c];
                    }
                }

                answer[r, insertAfter + 1] = array[r];
            }
            // end

            return answer;
        }
        public void Task8(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            for (int j = 0; j < m; j++)
            {
                int posCount = 0;
                int negCount = 0;
                int maxRow = 0;

                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, j] > 0) posCount++;
                    else if (matrix[i, j] < 0) negCount++;

                    if (matrix[i, j] > matrix[maxRow, j])
                    {
                        maxRow = i;
                    }
                }

                if (posCount > negCount)
                {
                    matrix[maxRow, j] = 0;
                }
                else if (negCount > posCount)
                {
                    matrix[maxRow, j] = maxRow;
                }
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (n != m) return;

            for (int i = 0; i < n; i++)
            {
                matrix[0, i] = 0;
                matrix[n - 1, i] = 0;
                matrix[i, 0] = 0;
                matrix[i, m - 1] = 0;
            }
            // end

        }
        public (int[] A, int[] B) Task10(int[,] matrix)
        {
            int[] A = null, B = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (n != m) return (null, null);

            int upperSize = n * (n + 1) / 2;
            int lowerSize = n * (n - 1) / 2;

            A = new int[upperSize];
            B = new int[lowerSize];

            int IndexA = 0, InnexB = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (j >= i)
                    {
                        A[IndexA++] = matrix[i, j];
                    }
                    else
                    {
                        B[InnexB++] = matrix[i, j];
                    }
                }
            }
            // end

            return (A, B);
        }
        public void Task11(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (n <= 1) return;

            int[] tempCol = new int[n];

            for (int j = 0; j < m; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    tempCol[i] = matrix[i, j];
                }

                for (int i = 1; i < n; i++)
                {
                    int key = tempCol[i];
                    int k = i - 1;

                    if (j % 2 == 0)
                    {
                        while (k >= 0 && tempCol[k] < key)
                        {
                            tempCol[k + 1] = tempCol[k];
                            k--;
                        }
                    }
                    else
                    {
                        while (k >= 0 && tempCol[k] > key)
                        {
                            tempCol[k + 1] = tempCol[k];
                            k--;
                        }
                    }

                    tempCol[k + 1] = key;
                }

                for (int i = 0; i < n; i++)
                {
                    matrix[i, j] = tempCol[i];
                }
            }
            // end

        }
        public void Task12(int[][] array)
        {

            // code here
            if (array == null || array.Length <= 1) return;

            int n = array.Length;
            int[] sums = new int[n];

            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                if (array[i] != null)
                {
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        sum += array[i][j];
                    }
                }
                sums[i] = sum;
            }

            for (int i = 1; i < n; i++)
            {
                int[] keyRow = array[i];
                int keySum = sums[i];
                int keyLen = keyRow != null ? keyRow.Length : 0;
                int j = i - 1;

                while (j >= 0)
                {
                    int curLen = array[j] != null ? array[j].Length : 0;
                    bool shouldSwap = false;

                    if (curLen < keyLen)
                    {
                        shouldSwap = true;
                    }
                    else if (curLen == keyLen && sums[j] < keySum)
                    {
                        shouldSwap = true;
                    }

                    if (!shouldSwap) break;

                    array[j + 1] = array[j];
                    sums[j + 1] = sums[j];
                    j--;
                }

                array[j + 1] = keyRow;
                sums[j + 1] = keySum;
            }
            // end

        }
    }
}
