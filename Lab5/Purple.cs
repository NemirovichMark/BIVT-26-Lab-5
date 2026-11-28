using System.Buffers;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;

            // code here
            answer = new int[matrix.GetLength(1)];

            for (int col = 0, j = 0; col < matrix.GetLength(1); col++)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    if (matrix[row, col] < 0)
                        answer[j]++;
                }
                j++;
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int iMin = 0;
                int temp = matrix[row, 0];

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] < matrix[row, iMin])
                        iMin = col;
                }

                for (int col = iMin; col > 0; col--)
                {
                    (matrix[row,col], matrix[row,col - 1]) = (matrix[row, col - 1], matrix[row, col]);
                }

            }

            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            answer = new int[matrix.GetLength(0), matrix.GetLength(1) + 1];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int jMax = 0;
                int max = int.MinValue;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        jMax = j;
                    }
                }

                for (int j = 0; j < answer.GetLength(1); j++)
                {
                    if (j <= jMax)
                        answer[i, j] = matrix[i, j];
                    else if (j == jMax + 1)
                        answer[i, j] = max;
                    else
                        answer[i, j] = matrix[i, j - 1];
                }
            }

            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                int aver = 0;
                int jMax = 0;
                int count = 0;
                int sum = 0;

                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > matrix[i, jMax])
                    {
                        jMax = j;
                        sum = 0;
                        count = 0;
                    }
                    if (matrix[i, j] > 0 && j > jMax)
                    {
                        sum += matrix[i, j];
                        count++;
                    }
                }

                if (count != 0)
                {
                    aver = sum / count;


                    for (int j = 0; j < jMax; j++)
                    {
                        if (matrix[i, j] < 0)
                            matrix[i, j] = aver;
                    }
                }
            }


            // end

        }
        public void Task5(int[,] matrix, int k)
        {

            // code here

            int[] temp = new int[matrix.GetLength(0)];
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (k >= cols || k < 0) return;

            for (int i = rows - 1; i >= 0; i--)
            {
                int iMax = 0;
                for (int j = 0; j < cols; j++)
                    if (matrix[i, j] > matrix[i, iMax])
                        iMax = j;
                temp[rows - i - 1] = matrix[i, iMax];
            }

            for (int i = 0; i < rows; i++)
                matrix[i, k] = temp[i];

            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (cols != array.Length) return;

            for (int c = 0; c < cols; c++)
            {
                int rMax = 0;
                for (int r = 0; r < rows; r++)
                {
                    if (matrix[r, c] > matrix[rMax, c])
                        rMax = r;
                }
                if (matrix[rMax, c] < array[c])
                    matrix[rMax, c] = array[c];
            }


            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);



            (int row, int value)[] minSort = new (int, int)[rows];

            for (int r = 0; r < rows; r++)
            {
                int min = int.MaxValue;
                for (int c = 0; c < cols; c++)
                {
                    if (matrix[r, c] < min)
                        min = matrix[r, c];
                }
                minSort[r] = (row: r, value: min);
            }

            for (int i = 0; i < minSort.Length - 1; i++)
            {
                bool swapped = false;
                for (int j = 0; j < minSort.Length - i - 1; j++)
                {
                    if (minSort[j].value < minSort[j + 1].value)
                    {
                        swapped = true;
                        (minSort[j], minSort[j + 1]) = (minSort[j + 1], minSort[j]);
                    }
                }
                if (!swapped) break;
            }

            int[,]temp = new int[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                for(int c = 0; c < cols; c++)
                {
                    temp[r, c] = matrix[minSort[r].row, c];
                }
            }

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    matrix[r, c] = temp[r, c];
                }
            }

            // end

        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here

            if (matrix.GetLength(0) != matrix.GetLength(1)) return answer;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int iAnswer = 0;

            answer = new int[2 * matrix.GetLength(0) - 1];


            for (int dRow = rows - 1; dRow >= 0; dRow--)
            {
                int dSum = 0;
                for (int c = 0, r = dRow; c < cols && r < rows; c++, r++)
                {
                    dSum += matrix[r, c];
                }
                answer[iAnswer++] = dSum;
            }

            for (int dCol = 1; dCol < cols; dCol++)
            {
                int dSum = 0;
                for (int c = dCol, r = 0; c < cols && r < rows; c++, r++)
                {
                    dSum += matrix[r, c];
                }
                answer[iAnswer++] = dSum;
            }

            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (rows != cols) return;
            if (k > rows || k < 0) return;

            int rMaxAbsolute = 0;
            int cMaxAbsolute = 0;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (Math.Abs(matrix[r,c]) > Math.Abs(matrix[rMaxAbsolute, cMaxAbsolute]))
                    {
                        rMaxAbsolute = r;
                        cMaxAbsolute = c;
                    }
                }
            }

            if (k == rMaxAbsolute && k == cMaxAbsolute) return;

            if (k > rMaxAbsolute) 
            {
                for (int r = rMaxAbsolute; r <= k - 1; r++)
                    for (int c = 0; c < cols; c++)
                        (matrix[r, c], matrix[r + 1,c]) = (matrix[r + 1, c], matrix[r, c]);
            } else if (k < rMaxAbsolute) 
            {
                for (int r = rMaxAbsolute; r >= k + 1; r--)
                    for (int c = 0; c < cols; c++)
                        (matrix[r, c], matrix[r - 1, c]) = (matrix[r - 1, c], matrix[r, c]);
            }
            if (k > cMaxAbsolute)
            {
                for (int c = cMaxAbsolute; c <= k - 1; c++)
                    for (int r = 0; r < rows; r++)
                        (matrix[r, c], matrix[r, c + 1]) = (matrix[r, c + 1], matrix[r, c]);
            }
            else if (k < cMaxAbsolute)
            {
                for (int c = cMaxAbsolute; c >= k + 1; c--)
                    for (int r = 0; r < rows; r++)
                        (matrix[r, c], matrix[r, c - 1]) = (matrix[r, c - 1], matrix[r, c]);
            }

            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here

            int ARows = A.GetLength(0);
            int ACols = A.GetLength(1);
            int BRows = B.GetLength(0);
            int BCols = B.GetLength(1);

            if (ACols != BRows) return answer;

            answer = new int[ARows, BCols];

            for (int aR = 0, bC = 0; aR < ARows;)
            {
                if (bC < BCols) 
                {
                    for (int aC = 0; aC < ACols; aC++)
                    {
                        answer[aR, bC] += A[aR, aC] * B[aC, bC];
                    } 
                }

                bC++;

                if (bC == BCols)
                {
                    bC = 0;
                    aR++;
                }
            }

                // end

                return answer;
        }
        public int[][] Task11(int[,] matrix)
        {
            int[][] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            
            answer = new int[n][];
            
            for (int i = 0; i < n; i++)
            {
                int count = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i,j] > 0)
                    {
                        count++;
                    }
                }
                answer[i] = new int[count];
            }
            
            for (int i = 0; i < n; i++)
            {
                int count = 0;
                for (int j = 0, k = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        answer[i][k++] = matrix[i,j];
                    }
                }
            }
            // end

            return answer;
        }
        public int[,] Task12(int[][] array)
        {
            int[,] answer = null;

            // code here

            int totalElements = 0;

            foreach (var row in array)
                totalElements += row.Length;

            
            int minimumSize = (int)Math.Ceiling(Math.Sqrt(totalElements));

            answer = new int[minimumSize, minimumSize];

            int k = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    answer[k / minimumSize, k % minimumSize] = array[i][j];
                    k++;
                }
            }
            
            // end

            return answer;
        }
    }
}