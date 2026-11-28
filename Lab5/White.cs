using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class White
    {
        public double Task1(int[,] matrix)
        {
            double average = 0;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            double sum = 0;
            int count = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                average = sum / count;
            }
            // end

            return average;
        }

        public (int row, int col) Task2(int[,] matrix)
        {
            int row = 0, col = 0;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int min = matrix[0, 0];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        row = i;
                        col = j;
                    }
                }
            }
            // end

            return (row, col);
        }

        public void Task3(int[,] matrix, int k)
        {
            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (k < 0 || k >= cols) return;

            int maxRow = 0;
            int maxVal = matrix[0, k];
            for (int i = 1; i < rows; i++)
            {
                if (matrix[i, k] > maxVal)
                {
                    maxVal = matrix[i, k];
                    maxRow = i;
                }
            }

            if (maxRow == 0) return;

            for (int j = 0; j < cols; j++)
            {
                int temp = matrix[0, j];
                matrix[0, j] = matrix[maxRow, j];
                matrix[maxRow, j] = temp;
            }
            // end
        }

        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int minRow = 0;
            int minVal = matrix[0, 0];
            for (int i = 1; i < rows; i++)
            {
                if (matrix[i, 0] < minVal)
                {
                    minVal = matrix[i, 0];
                    minRow = i;
                }
            }

            int newRows = rows - 1;
            answer = new int[newRows, cols];
            int r = 0;
            for (int i = 0; i < rows; i++)
            {
                if (i == minRow) continue;
                for (int j = 0; j < cols; j++)
                {
                    answer[r, j] = matrix[i, j];
                }
                r++;
            }
            // end

            return answer;
        }

        public int Task5(int[,] matrix)
        {
            int sum = 0;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (rows != cols) return 0;

            for (int i = 0; i < rows; i++)
            {
                sum += matrix[i, i];
            }
            // end

            return sum;
        }

        public void Task6(int[,] matrix)
        {
            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                int firstNeg = -1;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        firstNeg = j;
                        break;
                    }
                }
                if (firstNeg <= 0) continue;

                int lastNeg = -1;
                for (int j = cols - 1; j >= 0; j--)
                {
                    if (matrix[i, j] < 0)
                    {
                        lastNeg = j;
                        break;
                    }
                }

                int maxIdx = 0;
                int maxVal = matrix[i, 0];
                for (int j = 1; j < firstNeg; j++)
                {
                    if (matrix[i, j] > maxVal)
                    {
                        maxVal = matrix[i, j];
                        maxIdx = j;
                    }
                }

                int temp = matrix[i, maxIdx];
                matrix[i, maxIdx] = matrix[i, lastNeg];
                matrix[i, lastNeg] = temp;
            }
            // end
        }

        public int[] Task7(int[,] matrix)
        {
            int[] negatives = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int count = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < 0) count++;
                }
            }

            if (count == 0)
            {
                return new int[0];
            }

            negatives = new int[count];
            int idx = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        negatives[idx++] = matrix[i, j];
                    }
                }
            }
            // end

            return negatives;
        }

        public void Task8(int[,] matrix)
        {
            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                if (cols == 1) continue;

                int maxIdx = 0;
                int maxVal = matrix[i, 0];
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > maxVal)
                    {
                        maxVal = matrix[i, j];
                        maxIdx = j;
                    }
                }

                bool hasLeft = maxIdx > 0;
                bool hasRight = maxIdx < cols - 1;

                if (hasLeft && hasRight)
                {
                    int left = matrix[i, maxIdx - 1];
                    int right = matrix[i, maxIdx + 1];
                    if (left <= right)
                    {
                        matrix[i, maxIdx - 1] = left * 2;
                    }
                    else
                    {
                        matrix[i, maxIdx + 1] = right * 2;
                    }
                }
                else if (hasLeft)
                {
                    matrix[i, maxIdx - 1] *= 2;
                }
                else if (hasRight)
                {
                    matrix[i, maxIdx + 1] *= 2;
                }
            }
            // end
        }

        public void Task9(int[,] matrix)
        {
            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols / 2; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[i, cols - 1 - j];
                    matrix[i, cols - 1 - j] = temp;
                }
            }
            // end
        }

        public void Task10(int[,] matrix)
        {
            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (rows != cols) return;

            int half = (rows + 1) / 2;
            int startRow = rows - half;

            for (int i = startRow; i < rows; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    matrix[i, j] = 1;
                }
            }
            // end
        }

        public int[,] Task11(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int keep = 0;
            for (int i = 0; i < rows; i++)
            {
                bool hasZero = false;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] == 0) { hasZero = true; break; }
                }
                if (!hasZero) keep++;
            }

            answer = new int[keep, cols];
            int r = 0;
            for (int i = 0; i < rows; i++)
            {
                bool hasZero = false;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] == 0) { hasZero = true; break; }
                }
                if (hasZero) continue;
                for (int j = 0; j < cols; j++)
                {
                    answer[r, j] = matrix[i, j];
                }
                r++;
            }
            // end

            return answer;
        }

        public void Task12(int[][] array)
        {
            // code here
            if (array == null || array.Length <= 1) return;

            int n = array.Length;
            for (int i = 1; i < n; i++)
            {
                int[] key = array[i];
                int keySum = 0;
                for (int t = 0; t < key.Length; t++) keySum += key[t];

                int j = i - 1;
                while (j >= 0)
                {
                    int curSum = 0;
                    for (int t = 0; t < array[j].Length; t++) curSum += array[j][t];
                    if (curSum > keySum)
                    {
                        array[j + 1] = array[j];
                        j--;
                    }
                    else
                    {
                        break;
                    }
                }
                array[j + 1] = key;
            }
            // end
        }
    }
}
