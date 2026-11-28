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
            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);
            answer = new int[r];
            for (int i = 0; i < r; i++)
            {
                int minindex = 0;
                for (int j = 0; j < c; j++)
                {
                    if (matrix[i, j] < matrix[i, minindex])
                    {
                        minindex = j;
                    }
                }
                answer[i] = minindex;
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);
            for (int i = 0; i < r; i++)
            {
                int maxIndex = 0;
                for (int j = 0; j < c; ++j)
                {
                    if (matrix[i, j] > matrix[i, maxIndex])
                    {
                        maxIndex = j;

                    }
                }
                int max = matrix[i, maxIndex];
                if (max ==0) continue;
                for (int j = 0; j < maxIndex; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        matrix[i, j] = (int)Math.Floor((double)matrix[i, j] / max);
                    }
                }

            }
            // end

        }
        public void Task3(int[,] matrix, int k)
        {

            // code here
            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);
            if (k < 0 || k >= c || r != c) return;
            int maxIndex = 0;
            for (int i = 0; i < r; i++)
            {
                if (matrix[i, i] > matrix[maxIndex, maxIndex])
                {
                    maxIndex = i;
                }
            }
            if (maxIndex == k) return;
            for (int i = 0; i < r; i++)
            {
                int temp = matrix[i, k];
                matrix[i, k] = matrix[i, maxIndex];
                matrix[i, maxIndex] = temp;
            }

            // end

        }
        public void Task4(int[,] matrix)
        {

            // code here
            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);
            if (r != c) return;

            int diagpos = 0;
            for (int i = 0; i < r; i++)
            {
                if (matrix[i,i] > matrix[diagpos, diagpos])
                {
                    diagpos = i;
                }
            }
            for (int j = 0; j < r; j++)
            {
                int temp = matrix[diagpos, j];
                matrix[diagpos, j] = matrix[j, diagpos];
                matrix[j, diagpos] = temp;

            }
            // end

        }
        public int[,] Task5(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            if (matrix == null) return new int[0, 0];
            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);
            if (r == 0 || c == 0) return matrix;
            int maxsum = -1;
            int rd = 0;
            
            for (int i = 0; i < r; i++)
            {
                int sum = 0;
                for (int j = 0; j < c; j++)
                {
                    if (matrix[i, j] > 0)
                        sum += matrix[i, j];
                }
                if (sum > maxsum)
                {
                    maxsum = sum;
                    rd = i;
                }
            
            }
            int[,] newmatrix = new int[r - 1, c];
            int newrow = 0;
            for (int i = 0; i < r; i++)
            {
                if (i == rd) continue;
                for (int j = 0; j < c; j++)
                {
                    newmatrix[newrow, j] = matrix[i, j];
                    
                }
                newrow++;
            } 
            answer = newmatrix;
            // end

            return answer;
        }
        public void Task6(int[,] matrix)
        {

            // code here
            if (matrix == null) return;
            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);
            if ( r == 0 || c == 0 ) return;
            int minnegcount = c + 1;
            int minnegrow = 0;
            int maxnegcount = -1;
            int maxnegrow = 0;
            for (int i = 0; i < r; i++)
            {
                int count = 0;
                for (int j = 0; j < c; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        count++;
                    }
                }
                if (count < minnegcount)
                {
                    minnegcount = count;
                    minnegrow = i;
                }
                if (count > maxnegcount)
                {
                    maxnegcount = count;
                    maxnegrow = i;
                }
            }
                if (minnegrow != maxnegrow)
                {
                    for (int j = 0; j < c; j++)
                    {
                        int temp = matrix[minnegrow , j];
                        matrix[minnegrow, j] = matrix[maxnegrow, j];
                        matrix[maxnegrow, j ] = temp;
                    }
                }
            
            // end

        }
        public int[,] Task7(int[,] matrix, int[] array)
        {
            int[,] answer = null;

            // code here
            if (matrix == null) return new int[0,0];
            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);
            if (c == 0 || r == 0 || array == null || array.Length != r) return matrix;
            int minval = matrix[0,0];
            int mincol= 0;
            for (int i = 0; i < r; i++)
            {
               
               
                
                    for (int j = 0; j < c; j++)
                    {
                        if (matrix[i, j] < minval)
                        {
                            minval = matrix[i, j];
                            mincol = j;
                        }
                    }
                
            }
            int[,] newmatrix = new int[r, c + 1];
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j <= mincol; j++)
                {
                    newmatrix[i,j] = matrix[i, j]; 
                }
                newmatrix[i, mincol + 1] = array[i]; 

                for (int j = mincol + 1; j < c; j++) 
                {
                    newmatrix[i, j + 1] = matrix[i, j]; 
                }
            }
            answer  = newmatrix;
            // end

            return answer;
        }
        public void Task8(int[,] matrix)
        {

            // code here
            if (matrix == null || matrix.GetLength(0) == 0)
                return;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int j = 0; j < cols; j++)
            {
                int positive = 0;
                int negative = 0;

                int max = matrix[0, j];
                int maxRow = 0;

                for (int i = 0; i < rows; i++)
                {
                    if (matrix[i, j] > 0)
                        positive++;

                    if (matrix[i, j] < 0)
                        negative++;

                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxRow = i;
                    }
                }

                if (positive > negative)
                {
                    matrix[maxRow, j] = 0;
                }
                else if (negative > positive)
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

            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);

            if (r == 0 || c == 0 || r != c) return;

            for (int k = 0; k < r; k++)
            {
                matrix[0, k] = 0;         
                matrix[r - 1, k] = 0;  
                matrix[k, 0] = 0;         
                matrix[k, r - 1] = 0;    
            }
            // end

        }
        public (int[] A, int[] B) Task10(int[,] matrix)
        {
            int[] A = null, B = null;

            // code here
            if (matrix == null)
            {
                return (A, B);
            }

            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);

            if (r == 0 || c == 0 || r != c)
            {
                return (A, B);
            }

            int upperSize = r * (r + 1) / 2;
            int lowerSize = r * (r - 1) / 2;

            A = new int[upperSize];
            B = new int[lowerSize];

            int indexA = 0;
            int indexB = 0;

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if (j >= i)
                    {
                        A[indexA] = matrix[i, j];
                        indexA++;
                    }
                    else
                    {
                        B[indexB] = matrix[i, j];
                        indexB++;
                    }
                }
            }
            // end
            return (A, B);
        }
        public void Task11(int[,] matrix)
        {

            // code here
            if (matrix == null)
                return;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int j = 0; j < cols; j++)
            {
                for (int pass = 0; pass < rows - 1; pass++)
                {
                    for (int i = 0; i < rows - 1 - pass; i++)
                    {
                        bool swap;

                        if (j % 2 == 0)
                            swap = matrix[i, j] < matrix[i + 1, j];
                        else
                            swap = matrix[i, j] > matrix[i + 1, j];

                        if (swap)
                        {
                            int temp = matrix[i, j];
                            matrix[i, j] = matrix[i + 1, j];
                            matrix[i + 1, j] = temp;
                        }
                    }
                }
            }
            // end

        }
        public void Task12(int[][] array)
        {

            // code here
            if (array == null)
                return;

            for (int i = 1; i < array.Length; i++)
            {
                int[] current = array[i];

                int currentLength = current == null ? 0 : current.Length;
                long currentSum = 0;

                if (current != null)
                {
                    for (int j = 0; j < current.Length; j++)
                        currentSum += current[j];
                }

                int k = i - 1;

                while (k >= 0)
                {
                    int previousLength = array[k] == null ? 0 : array[k].Length;
                    long previousSum = 0;

                    if (array[k] != null)
                    {
                        for (int j = 0; j < array[k].Length; j++)
                            previousSum += array[k][j];
                    }

                    if (previousLength > currentLength)
                        break;

                    if (previousLength == currentLength &&
                        previousSum >= currentSum)
                        break;

                    array[k + 1] = array[k];
                    k--;
                }

                array[k + 1] = current;
            }
            // end

        }
    }
}
