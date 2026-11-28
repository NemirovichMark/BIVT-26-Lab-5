using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;

            // code here
            answer = new int[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        answer[j]++;
                    }
                }
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
                int minN = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, minN] > matrix[i, j])
                    {
                        minN = j;
                    }
                }
                int mini = matrix[i, minN];
                for (int j = minN; j > 0; j--)
                {
                    matrix[i, j] = matrix[i, j - 1];
                }
                matrix[i, 0] = mini;
            }

            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            answer = new int[n, m + 1];
            for (int i = 0; i < n; i++)
            {
                int maxi = matrix[i, 0];
                int maxN = 0;

                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] > maxi)
                    {
                        maxi = matrix[i, j];
                        maxN = j;
                    }
                }

                for (int j = 0; j <= maxN; j++)
                {
                    answer[i, j] = matrix[i, j];
                }

                answer[i, maxN + 1] = maxi;

                for (int j = maxN + 1; j < m; j++)
                {
                    answer[i, j + 1] = matrix[i, j];
                }
            }

            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                int maxi = matrix[i, 0];
                int maxN = -1;
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] > maxi)
                    {
                        maxi = matrix[i, j];
                        maxN = j;
                    }
                }
                int sum = 0;
                int count = 0;
                for (int j = maxN + 1; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        count++;
                    }
                }
                if (count != 0)
                {
                    int mid = sum / count;
                    for (int j = 0; j < maxN; j++)
                    {
                        if (matrix[i, j] < 0)
                        {
                            matrix[i, j] = mid;
                        }
                    }
                }
            }
            // end

        }
        public void Task5(int[,] matrix, int k)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (k < 0 || k >= m)
            {
                return;
            }
            int[] matrixMax = new int[n];
            for (int i = 0; i < n; i++)
            {
                matrixMax[i] = matrix[i, 0];
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] > matrixMax[i])
                    {
                        matrixMax[i] = matrix[i, j];
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                matrix[i, k] = matrixMax[n - 1 - i];
            }
            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (array.Length != m) { return; }

            for (int i = 0; i < m; i++)
            {
                int maxi = matrix[0, i];
                int maxN = 0;

                for (int j = 1; j < n; j++)
                {
                    if (matrix[j, i] > maxi)
                    {
                        maxi = matrix[j, i];
                        maxN = j;
                    }
                }

                if (array[i] > maxi)
                {
                    matrix[maxN, i] = array[i];
                }
            }
            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int[] minis = new int[n];
            int[] newMatrix = new int[n];

            for (int i = 0; i < n; i++)
            {
                newMatrix[i] = i;
                minis[i] = matrix[i, 0];

                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] < minis[i])
                    {
                        minis[i] = matrix[i, j];
                    }
                }
            }

            for (int i = 1; i < n; i++)
            {
                int k = newMatrix[i];
                int k2 = i - 1;

                while (k2 >= 0 && minis[newMatrix[k2]] < minis[k])
                {
                    newMatrix[k2 + 1] = newMatrix[k2];
                    k2--;
                }
                newMatrix[k2 + 1] = k;
            }

            int[,] newMatrix2 = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    newMatrix2[i, j] = matrix[i, j];
                }

            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = newMatrix2[newMatrix[i], j];
                }
            }
            // end

        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (n != m)
            {
                return null;
            }

            answer = new int[(2 * n) - 1];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    answer[j + n - 1 - i] += matrix[i, j];
                }
            }
            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here
            int n = matrix.GetLength(0);
            if (n != matrix.GetLength(1) || k < 0 || k >= n) return;

            int row = 0, column = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (System.Math.Abs(matrix[i, j]) > System.Math.Abs(matrix[row, column]))
                    {
                        row = i;
                        column = j;
                    }
                }
            }

            int[] rows = new int[n];
            int[] columns = new int[n];
            int srow = 0, scolumn = 0;

            for (int i = 0; i < n; i++)
            {
                if (i == k)
                {
                    rows[i] = row;
                    columns[i] = column;
                }
                else
                {
                    if (srow == row) 
                        srow++;
                    if (scolumn == column) 
                        scolumn++;

                    rows[i] = srow++;
                    columns[i] = scolumn++;
                }
            }

            int[,] newMatrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    newMatrix[i, j] = matrix[i, j];
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = newMatrix[rows[i], columns[j]];
                }
            }
            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here
            int n = A.GetLength(0);
            int m = A.GetLength(1);
            int m2 = B.GetLength(1);

            if (m != B.GetLength(0)) 
            { 
                return null; 
            }

            answer = new int[n, m2];

            for (int i = 0; i < n * m2; i++)
            {
                int i2 = i / m2;
                int j = i % m2;
                int sum = 0;

                for (int i3 = 0; i3 < m; i3++)
                {
                    sum += A[i2, i3] * B[i3, j];
                }

                answer[i2, j] = sum;
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
                    if (matrix[i, j] > 0) 
                    { 
                        count++; 
                    }
                }

                answer[i] = new int[count];
                int position = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0) answer[i][position++] = matrix[i, j];
                }
            }
            // end

            return answer;
        }
        public int[,] Task12(int[][] array)
        {
            int[,] answer = null;

            // code here
            if (array == null) 
            {
                return null; 
            }

            int total = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null) 
                { 
                    total += array[i].Length; 
                }
            }

            int size = 0;

            while (size * size < total) size++;

            answer = new int[size, size];
            int position = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null)
                { 
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        answer[position / size, position % size] = array[i][j];
                        position++;
                    }
                }
            }
            // end

            return answer;
        }
    }
}
