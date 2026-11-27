using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;
            answer = new int[matrix.GetLength(1)];

            for (int column = 0; column < matrix.GetLength(1); column++)
            {
                int count = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    if (matrix[row, column] < 0) count++;
                }

                answer[column] = count;
            }

            return answer;
        }
        public void Task2(int[,] matrix)
        {
            
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int min = 0;
                int i = 0;
                
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    if (matrix[row, column] < matrix[row,min])
                    {
                        min = column;
                    }
                }

                int minC = matrix[row, min];

                for (int column = min; column > 0; column--)
                {
                    matrix[row, column] = matrix[row, column - 1];
                }

                matrix[row, 0] = minC;
            }

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;
            answer = new int[matrix.GetLength(0), matrix.GetLength(1) + 1];

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                int maxC = 0;
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    if (matrix[rows, column] > matrix[rows, maxC])
                    {
                        maxC = column;
                    }
                }

                for (int column = 0; column <= maxC; column++)
                {
                    answer[rows, column] = matrix[rows, column];
                }

                answer[rows, maxC + 1] = matrix[rows, maxC];

                for (int column = maxC + 1; column < matrix.GetLength(1); column++)
                {
                    answer[rows, column + 1] = matrix[rows, column];
                }
            }

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                int maxC = 0;
                int sum = 0;
                int count = 0;
                
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    if (matrix[rows, column] > matrix[rows, maxC]) maxC = column;
                }

                for (int column = maxC + 1; column < matrix.GetLength(1); column++)
                {
                    if (matrix[rows, column] > 0)
                    {
                        sum += matrix[rows, column];
                        count++;
                    }
                }

                if (count == 0) continue;
                
                for (int column = 0; column < maxC; column++)
                {
                    if (matrix[rows, column] < 0)
                    {
                        matrix[rows, column] = (sum / count);
                    }
                }
            }
        }
        public void Task5(int[,] matrix, int k)
        {
            int[] maxV = new int[matrix.GetLength(0)];
            if (matrix.GetLength(0) == 0 || k < 0 || k >= matrix.GetLength(1))
                return;
            
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int maxC = 0;

                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    if (matrix[row, column] > matrix[row, maxC]) maxC = column;
                }

                maxV[row] = matrix[row,maxC];
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                matrix[row, k] = maxV[matrix.GetLength(0) - 1 - row];
            }
        }
        public void Task6(int[,] matrix, int[] array)
        {
            if (matrix == null || array == null) return;

            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);

            if (r == 0 || c == 0 || array.Length != c) return;

            for (int j = 0; j < c; j++)
            {
                int maxI = 0;

                for (int i = 1; i < r; i++)
                {
                    if (matrix[i, j] > matrix[maxI, j])
                        maxI = i;
                }

                if (array[j] > matrix[maxI, j])
                    matrix[maxI, j] = array[j];
            }
        }
        public void Task7(int[,] matrix)
        {
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);

            for (int i = 0; i < row - 1; i++)
            {
                for (int j = 0; j < row - i - 1; j++)
                {
                    int min1 = matrix[j, 0];
                    int min2 = matrix[j + 1,0];

                    for (int k = 0; k < col; k++)
                    {
                        if (matrix[j, k] < min1) min1 = matrix[j, k];
                        if (matrix[j + 1, k] < min2) min2 = matrix[j + 1, k];
                    }

                    if (min1 < min2)
                    {
                        for (int k = 0; k < col; k++)
                        {
                            int temp = matrix[j, k];
                            matrix[j, k] = matrix[j + 1, k];
                            matrix[j + 1, k] = temp;
                        }
                    }
                }
            }
        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;
            if (matrix == null) return null;

            int n = matrix.GetLength(0);

            if (n == 0 || n != matrix.GetLength(1)) return null;

            answer = new int[2 * n - 1];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    answer[j - i + n - 1] += matrix[i, j];
                }
            }


            return answer;
        }

        public void Task9(int[,] matrix, int k)
        {
            int n = matrix.GetLength(0);

            if (n == 0 || n != matrix.GetLength(1) || k < 0 || k >= n) return;

            int maxI = 0;
            int maxJ = 0;
            long max = -1;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    long x = matrix[i, j];
                    if (x < 0) x = -x;

                    if (x > max)
                    {
                        max = x;
                        maxI = i;
                        maxJ = j;
                    }
                }
            }

            while (maxI != k)
            {
                int nextI = maxI < k ? maxI + 1 : maxI - 1;

                for (int j = 0; j < n; j++)
                {
                    int temp = matrix[maxI, j];
                    matrix[maxI, j] = matrix[nextI, j];
                    matrix[nextI, j] = temp;
                }

                maxI = nextI;
            }

            while (maxJ != k)
            {
                int nextJ = maxJ < k ? maxJ + 1 : maxJ - 1;

                for (int i = 0; i < n; i++)
                {
                    int temp = matrix[i, maxJ];
                    matrix[i, maxJ] = matrix[i, nextJ];
                    matrix[i, nextJ] = temp;
                }

                maxJ = nextJ;
            }
        }

        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;
            int n = A.GetLength(0);
            int m = A.GetLength(1);
            int p = B.GetLength(1);

            if (n == 0 || m == 0 || p == 0 || m != B.GetLength(0)) return null;

            answer = new int[n, p];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < p; j++)
                {
                    for (int k = 0; k < m; k++)
                    {
                        answer[i, j] += A[i, k] * B[k, j];
                    }
                }
            }
            
            return answer;
        }
        public int[][] Task11(int[,] matrix)
        {
            int[][] answer = null;
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            answer = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                int count = 0;

                for (int j = 0; j < columns; j++)
                {
                    if (matrix[i, j] > 0)
                        count++;
                }

                answer[i] = new int[count];
                int index = 0;

                for (int j = 0; j < columns; j++)
                {
                    if (matrix[i, j] > 0)
                        answer[i][index++] = matrix[i, j];
                }
            }
            return answer;
        }
        public int[,] Task12(int[][] array)
        {
            int[,] answer = null;
            int total = 0;

            for (int i = 0; i < array.Length; i++)
                total += array[i].Length;

            int size = 0;
            while ((long)size * size < total)
                size++;

            answer = new int[size, size];
            int index = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    answer[index / size, index % size] = array[i][j];
                    index++;
                }
            }
            
            return answer;
        }
    }
}