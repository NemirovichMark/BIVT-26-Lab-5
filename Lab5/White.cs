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
            int n=matrix.GetLength(0);
            int m=matrix.GetLength(1);
            int count = 0;
            for (int i = 0; i<n; i++)
            {
                for (int j = 0; j < m; j++)     
                {
                    if (matrix[i,j] >0)
                    {
                        average += matrix[i,j];
                        count++;
                    }
                }
            }
            if (count != 0)
            { 
                average /= count; 
            }

            // end

            return average;
        }
        public (int row, int col) Task2(int[,] matrix)
        {
            int row = 0, col = 0;

            // code here
            int n= matrix.GetLength(0);
            int m= matrix.GetLength(1);
            int min = matrix[0,0];
            for (int i = 0; i<n;i++)
            {
                for (int j = 0; j<m; j++)
                {
                    if (matrix[i,j] < min)
                    {
                        min= matrix[i,j];
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
            if (k < 0 || k >= matrix.GetLength(1))
            {
                return;
            }
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int max = matrix[0, k];
            int row = 0;

            int[] mat = new int[m];

            for (int i = 0; i < n; i++)
            {
                if (matrix[i, k] > max)
                {
                    max = matrix[i, k];
                    row = i;
                }
            }

            if (row != 0)
            {
                for (int i = 0; i <m; i++)
                {
                    mat[i] = matrix[0, i];
                }

                for (int i = 0; i < m; i++)
                {
                    matrix[0, i] = matrix[row, i];
                    matrix[row, i] = mat[i];
                }
            }

            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int n=matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int row = 0;
            int min = matrix[0, 0];
            int c = 0;
            if (n > 1)
            {
                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, 0] < min)
                    {
                        min = matrix[i, 0];
                        row = i;
                    }
                }

                answer = new int[n - 1, m];
                for (int i = 0; i < n; i++)
                {
                    if (i != row)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            answer[c, j] = matrix[i, j];
                        }
                        c++;
                    }
                }
            }
            else
            {
                answer = new int[0, m];
            }



            // end

            return answer;
        }
        public int Task5(int[,] matrix)
        {
            int sum = 0;

            // code here
            int n = matrix.GetLength(0);
            int m= matrix.GetLength(1);
            if (n!=m)
            {
                return 0;
            }
            for (int i = 0;i<n;i++)
            {
                sum+= matrix[i,i];
            }

            // end

            return sum;
        }
        public void Task6(int[,] matrix)
        {

            // code here
            int n= matrix.GetLength(0);
            int m=matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                int f = -1;
                int l = -1;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        if (f == -1)
                        {
                            f = j;
                        }
                        l = j;
                    }
                }
                if (f > 0)
                {
                    int max = matrix[i, 0];
                    int t = 0;
                    for (int j = 0; j < f; j++)
                    {
                        if ((matrix[i, j] > max))
                        {
                            max = matrix[i, j];
                            t = j;
                        }
                    }
                    int h = matrix[i, t];
                    matrix[i, t] = matrix[i, l];
                    matrix[i, l] = h;
                }
            }

            // end

        }
        public int[] Task7(int[,] matrix)
        {
            int[] negatives = null;

            // code here
            int n=matrix.GetLength (0);
            int m = matrix.GetLength (1);
            int k = 0;
            for (int i = 0; i<n; i++)
            {
                for (int j = 0;j < m; j++)
                {
                    if (matrix[i, j]<0)
                    {
                        k++;
                    }
                }
            }
            if (k==0)
            {
                return null;
            }
            negatives = new int[k];
            int v = 0;

            for (int i = 0; i<n;i++)
            {
                for (int j = 0; j<m;j++)
                {
                    if (matrix[i,j]<0)
                    {
                        negatives[v] = matrix[i,j];
                        v++;
                    }
                }
            }

            // end

            return negatives;
        }
        public void Task8(int[,] matrix)
        {

            // code here
            int n= matrix.GetLength (0);
            int m= matrix.GetLength (1);
            for (int i = 0; i < n; i++)
            {
                if (m == 1)
                {
                    continue;
                }
                int max = matrix[i, 0];
                int h = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        h = j;
                    }
                }
                if (h == 0)
                {
                    matrix[i, h + 1] *= 2;
                }
                else  if (h == m - 1)
                    {
                        matrix[i, h - 1] *= 2;
                    }
                
                else
                {
                    if (matrix[i, h - 1] <= matrix[i, h + 1])
                    {
                        matrix[i, h - 1] *= 2;
                    }
                    else
                    {
                        matrix[i, h + 1] *= 2;
                    }
                }
            }


            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            int n= matrix.GetLength (0);
            int m= matrix.GetLength (1);
            //int l=0;
            for (int i = 0; i < n; i++)
            {
                int l = 0;
                int r = m - 1;
                while (l < r)
                {
                    int t = matrix[i, l];
                    matrix[i, l] = matrix[i, r];
                    matrix[i, r] = t;
                    l++;
                    r--;

                }
            }

            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here            
            if (matrix.GetLength(0)!= matrix.GetLength(1))
            {
                return;
            }
            int n = matrix.GetLength(0);
            //int m = matrix.GetLength(1);
            for (int i = n/2; i<n;i++)
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
            int n=matrix.GetLength (0);
            int m=matrix.GetLength (1);
            int r = 0;
            for (int i = 0; i < n; i++)
            {
                bool zero = false;

                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        zero = true;
                    }
                }

                if (!zero)
                {
                    r++;
                }
            }

            answer = new int[r, m];

            int v = 0;

            for (int i = 0; i < n; i++)
            {
                bool zero = false;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        zero = true;
                    }
                }

                if (!zero)
                {
                    for (int j = 0; j < m; j++)
                    {
                        answer[v, j] = matrix[i, j];
                    }

                    v++;
                }
            }

            // end

            return answer;
        }
        public void Task12(int[][] array)
        {

            // code here
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    int summ1 = 0;
                    int summ2 = 0;

                    for (int k = 0; k < array[j].Length; k++)
                    {
                        summ1 += array[j][k];
                    }

                    for (int k = 0; k < array[j + 1].Length; k++)
                    {
                        summ2 += array[j + 1][k];
                    }

                    if (summ1 > summ2)
                    {
                        int[] temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }

            // end

        }
    }
}
