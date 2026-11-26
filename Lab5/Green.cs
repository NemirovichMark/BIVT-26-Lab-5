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
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            answer = new int[m];
            for (int i = 0; i < m; i++)
            {
                int min_i = 0;
                for (int j = 1; j < n; j++)
                {
                    if (matrix[i, j] < matrix[i, min_i])
                    {
                        min_i = j;
                    }
                }
                answer[i] = min_i;
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            
            for (int i = 0; i < m; i++)
            {
                int maxi = 0;
                for (int j = 1; j < n; j++)
                {
                    if (matrix[i, j] > matrix[i, maxi])
                    {
                        maxi = j;
                    }
                }

                int maxv = matrix[i, maxi];
                if (maxv==0) continue;
                for (int y = 0; y < maxi; y++)
                {
                    if (matrix[i, y] < 0)
                    {
                        matrix[i, y] = (int)Math.Floor((double)matrix[i, y]/ maxv);
                    }
                }
            }
            // end

        }
        public void Task3(int[,] matrix, int k)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (rows != cols || k < 0 || k >= cols) return;
            int maxc = 0;
            for (int i = 1; i < rows; i++)
            {
                if (matrix[i, i] > matrix[maxc, maxc])
                {
                    maxc = i;
                }
            }

            if (maxc != k)
            {
                for (int i = 0; i < rows; i++)
                {
                    int s = matrix[i, k];
                    matrix[i, k] = matrix[i, maxc];
                    matrix[i, maxc] = s;
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
            int maxi = 0;
            for (int i = 1; i < n; i++)
            {
                
                if (matrix[i, i] > matrix[maxi, maxi])
                {
                    maxi = i;
                }
            }
            
            for (int i = 0; i < n; i++)
            {
                int s = matrix[maxi, i];
                matrix[maxi, i] = matrix[i, maxi];
                matrix[i, maxi] = s;
            }
            // end

        }
        public int[,] Task5(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int mi = 0;
            int ms = -1; 
            
            for (int i = 0; i < n; i++)
            {
                int s = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        s += matrix[i, j];
                    }
                }

                
                if (s > ms)
                {
                    ms = s;
                    mi = i;
                }
            }

            
            answer = new int[n - 1, m];
            int nn = 0;

            for (int y = 0; y < n; y++)
            {
                if (y == mi) continue; 

                for (int x = 0; x < m; x++)
                {
                    answer[nn, x] = matrix[y, x];
                }
                nn++;
            }
            // end

            return answer;
        }
        public void Task6(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[] cs = new int[n];

            for (int i = 0; i < n; i++)
            {
                int c = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < 0) c++;
                }
                cs[i] = c;
            }

            int min = 0;
            int max = 0;
            for (int i = 1; i < n; i++)
            {
                if (cs[i] < cs[min]) min = i;
                if (cs[i] > cs[max]) max = i;
            }

            bool f = true;
            for (int i = 1; i < n; i++)
            {
                if (cs[i] != cs[0])
                {
                    f = false;
                    break;
                }
            }
            if (!f && min != max)
            {
                for (int j = 0; j < m; j++)
                {
                    int t = matrix[min, j];
                    matrix[min, j] = matrix[max, j];
                    matrix[max, j] = t;
                }
            }
            // end

        }
        public int[,] Task7(int[,] matrix, int[] array)
        {
            int[,] answer = null;

            // code here
            if (matrix == null)
            {
                return null;
            }

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

           
            if (array == null || n == 0 || m == 0 || array.Length != n)
            {
                return matrix;
            }

            
            int v = matrix[0, 0];
            int c = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < v)
                    {
                        v = matrix[i, j];
                        c = j;
                    }
                }
            }
            answer = new int[n, m + 1];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= c; j++)
                {
                    answer[i, j] = matrix[i, j];
                }

                answer[i, c + 1] = array[i];

                for (int j = c + 1; j < m; j++)
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
            
                int n = matrix.GetLength(0);
                int m = matrix.GetLength(1);
                for (int j = 0; j < m; j++)
                {
                    int p = 0;
                    int ne = 0;
                    int max = 0;
                    for (int i = 0; i < n; i++)
                    {
                        if (matrix[i, j] > 0)
                        {
                            p++;
                        }
                        else if (matrix[i, j] < 0)
                        {
                            ne++;
                        }

                        if (matrix[i, j] > matrix[max, j])
                        {
                            max = i;
                        }
                    }

                    if (p > ne)
                    {
                        matrix[max, j] = 0;
                    }
                    else if (ne > p)
                    {
                        matrix[max, j] = max;
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
                matrix[i, n - 1] = 0;    
            }
            
            // end

        }
        public (int[] A, int[] B) Task10(int[,] matrix)
        {
            int[] A = null, B = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n == m)
            {
                A = new int[n * (n + 1) / 2];
                B = new int[n * (n - 1) / 2];
                int iA = 0;
                int iB = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (j >= i)
                        {
                            A[iA++] = matrix[i, j];
                        }
                        else
                        {
                            B[iB++] = matrix[i, j];
                        }
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
            {
                return;
            }

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (n <= 1 || m == 0)
            {
                return;
            }

            for (int j = 0; j < m; j++)
            {
                int i = 1;

                while (i < n)
                {
                    if (i == 0)
                    {
                        i++;
                        continue;
                    }

                    bool f;
                    if (j % 2 == 0)
                    {
                        f = matrix[i - 1, j] >= matrix[i, j];
                    }
                    else
                    {
                        f = matrix[i - 1, j] <= matrix[i, j];
                    }

                    if (f)
                    {
                        i++;
                    }
                    else
                    {
                        int t = matrix[i, j];
                        matrix[i, j] = matrix[i - 1, j];
                        matrix[i - 1, j] = t;
                        i--;
                    }
                }
            }
            // end

        }
        public void Task12(int[][] array)
        {

            // code here
            int n = array.Length;
            if (n > 1)
            {
                int[] sums = new int[n];
                for (int i = 0; i < n; i++)
                {
                    int s = 0;
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        s += array[i][j];
                    }
                    sums[i] = s;
                }

                for (int i = 1; i < n; i++)
                {
                    int[] m = array[i];
                    int s = sums[i];
                    int j = i - 1;

                    while (j >= 0 && (array[j].Length < m.Length || (array[j].Length == m.Length && sums[j] < s)))
                    {
                        array[j + 1] = array[j];
                        sums[j + 1] = sums[j];
                        j--;
                    }

                    array[j + 1] = m;
                    sums[j + 1] = s;
                }
            }
            // end

        }
    }
}