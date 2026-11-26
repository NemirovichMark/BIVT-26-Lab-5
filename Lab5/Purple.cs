using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int count = 0;
            int n= matrix.GetLength(0);
            
            int m = matrix.GetLength(1);
            answer = new int[m];
            for (int i = 0; i < m; i++)
            {
                count = 0;
                for (int j = 0;j<n;  j++)
                {
                    if (matrix[j, i] < 0)
                        count += 1;
                }
                answer[i] = count;
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int n=matrix.GetLength(0);
            int m=matrix.GetLength(1);
            for (int i = 0;i<n;i++)
            {
                int mn = int.MaxValue;
                int c = 0;
                for (int j = 0;j<m;j++)
                {
                    if (matrix[i, j] < mn)
                    {
                        mn = matrix[i, j];
                        c = j;
                    }
                }
                if (c!=0)
                {
                    while(c>0)
                    {
                        matrix[i, c] = matrix[i, c - 1];
                        c--;
                    }
                    matrix[i,0] = mn;
                }
            }
            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            answer = new int[n,m + 1];
            for (int i = 0; i < n; i++)
            {
                int mx = int.MinValue;
                int c = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > mx)
                    {
                        mx = matrix[i, j];
                        c = j;
                    }
                }
                
                int c0 = m;
                while (c0 > 0)
                {
                    if (c0 > c)
                    {
                        answer[i, c0] = matrix[i, c0 - 1];
                        c0--;
                    }
                    else
                    {
                        answer[i, c0] = matrix[i, c0];
                        c0--;
                    }
                }
                answer[i, 0] = matrix[i, 0];    
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
                int mx = int.MinValue;
                int ind = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > mx)
                    {
                        mx = matrix[i, j];
                        ind = j;
                    }
                }
                int srs = 0;
                int c = 0;
                for (int j = ind+1; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        srs += matrix[i, j];
                        c++;
                    }
                }
                if (c != 0)
                {
                    srs /= c;
                    for (int j = 0; j < ind; j++)
                    {
                        if (matrix[i, j] < 0)
                            matrix[i, j] = srs;
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
            int[] k0 = new int[n];
            if (k < m)
            {
                for (int i = 0; i < n; i++)
                {
                    int mx = int.MinValue;
                    int ind = 0;
                    for (int j = 0; j < m; j++)
                    {
                        if (matrix[i, j] > mx)
                        {
                            mx = matrix[i, j];
                            ind = j;
                        }
                    }
                    k0[n - i - 1] = matrix[i, ind];
                }
                for (int i = 0; i < n; i++)
                    matrix[i, k] = k0[i];
            }
                // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int k = array.GetLength(0);
            if (k == m)
            {
                for (int i = 0; i < m; i++)
                {
                    int mx = int.MinValue;
                    int ind = 0;
                    for (int j = 0; j < n; j++)
                    {
                        if (matrix[j, i] > mx)
                        {
                            mx = matrix[j, i];
                            ind = j;
                        }
                    }
                    if (matrix[ind,i] < array[i])
                        matrix[ind,i] = array[i];
                }
            }
                        // end

        }
        public void Task7(int[,] matrix)
        {

            // code here
            int n= matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[] last = new int[n];
            if (n <= 1 || m == 0) return;

            int mew0 = int.MaxValue;
            for (int j = 0; j < m; j++)
            {
                if (matrix[0, j] < mew0)
                    mew0 = matrix[0, j];
            }
            last[0] = mew0;

            for (int i=1;i<n; i++)
            {
                int mew = int.MaxValue;
                for (int j=0;j<m; j++)
                {
                    if (matrix[i, j] < mew)
                        mew = matrix[i, j];
                }
                last[i] = mew;
                if (last[i] > last[i-1])
                {
                    for (int j = 0; j < m; j++)
                        (matrix[i - 1, j], matrix[i, j]) = (matrix[i, j], matrix[i - 1, j]);

                    (last[i - 1], last[i]) = (last[i], last[i - 1]);
                    if (i>1)
                        i -= 2;
                }
            }
            // end

        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int n1 = matrix.GetLength(1);
            int m = 2 * n - 1;
            
            
            if (n == n1&&n!=0)
            {
                answer = new int[m];
                for (int i = 0; i < n; i++)
                {
                    int ind = (m / 2) - i;
                    for (int j = 0; j < n; j++)
                    {
                        answer[ind] += matrix[i, j];
                        ind += 1;
                    }
                }
            }
            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            long mx = -1;
            int ii = 0;
            int jj = 0;

            if (n == m && k < n && k >= 0)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (Math.Abs((long)matrix[i, j]) > mx)
                        {
                            mx = Math.Abs((long)matrix[i, j]);
                            ii = i;
                            jj = j;
                        }
                    }
                }

                int stepRow;
                if (k < ii)
                {
                    stepRow = -1;
                }
                else
                {
                    stepRow = 1;
                }

                while (ii != k)
                {
                    for (int j = 0; j < m; j++)
                        (matrix[ii + stepRow, j], matrix[ii, j]) = (matrix[ii, j], matrix[ii + stepRow, j]);
                    ii += stepRow;
                }

                int stepCol = k < jj ? -1 : 1;
                while (jj != k)
                {
                    for (int i = 0; i < n; i++)
                        (matrix[i, jj + stepCol], matrix[i, jj]) = (matrix[i, jj], matrix[i, jj + stepCol]);
                    jj += stepCol;
                }
            }
            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here
            int n1 = A.GetLength(0);
            int m1 = A.GetLength(1);
            int n2 = B.GetLength(0);
            int m2 = B.GetLength(1);

            if (n1 > 0 && m1 > 0 && m2 > 0 && m1 == n2)
            {
                answer = new int[n1, m2];
                int c = n1 * m2;

                for (int ind = 0; ind < c; ind++)
                {
                    int i = ind / m2; 
                    int j = ind % m2; 

                    int sum = 0;
                    for (int k = 0; k < m1; k++)
                    {
                        sum += A[i, k] * B[k, j];
                    }
                    answer[i, j] = sum;
                }
            }
            // end

            return answer;
        }
        public int[][] Task11(int[,] matrix)
        {
            int[][] answer = null;

            // code here
           
            int n= matrix.GetLength(0);
            int m= matrix.GetLength(1);
            int[] c = new int[n];
            answer = new int[n][];
            for (int i=0;i<n;i++)
            {
                int co = 0;
                for (int j=0;j<m;j++)
                {
                    if (matrix[i, j] > 0)
                        co++;
                }
                c[i] = co;
            }
            for (int i=0;i<n;i++)
            { 
                answer[i] = new int[c[i]];
                int ii = 0;
                for (int j=0;j<m; j++)
                {
                    if (matrix[i,j] > 0)
                    {
                        answer[i][ii] = matrix[i, j];
                        ii++;
                    }
                }
            }
            // end

            return answer;
        }
        public int[,] Task12(int[][] array)
        {
            int[,] answer = null;

            //code here

            if (array.Length == 0)
                return null;

            int c = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null)
                    c += array[i].Length;
            }
            int mn = 1;
            while (mn * mn < c)
            {
                mn++;
            }
            answer = new int[mn, mn];
            int ind = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    answer[ind / mn, ind % mn] = array[i][j];
                    ind++;
                }
            }
            //end

            return answer;
        }
    }
}
