using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Blue
    {
        public double[] Task1(int[,] matrix)
        {
            double[] answer = null;

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
    
            answer = new double[n];

            for (int i = 0; i < n; i++)
            {
                double sum = 0;
                int count = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        count++;
                    }
                }
                if (count > 0)
                {
                    answer[i] = sum / count;
                }
                else
                {
                    answer[i] = 0;
                }
            }

            return answer;
        }

        public int[,] Task2(int[,] matrix)
        {
            int[,] answer = null;
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int I = 0;
            int J = 0;
            int max = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        I = i;
                        J = j;
                    }
                }
            }
            int[,] temp = new int[n - 1, m - 1];
            for (int i = 0; i < n - 1; i++)
            {
                if (i < I)
                {
                    for (int j = 0; j < m - 1; j++)
                    {
                        if (j < J) temp[i, j] = matrix[i, j];
                        else temp[i, j] = matrix[i, j + 1];
                    }
                }
                else
                {
                    for (int j = 0; j < m - 1; j++)
                    {
                        if (j < J) temp[i, j] = matrix[i + 1, j];
                        else temp[i, j] = matrix[i + 1, j + 1];
                    }
                }
            }
            answer = temp;

            return answer;
    }
        public void Task3(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            for (int i = 0; i < n; i++)
            {
                int max = matrix[i, 0];
                int jmax = 0;
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        jmax = j;
                    }
                }
                for (int j = jmax; j < m - 1; j++)
                {
                    matrix[i, j] = matrix[i, j + 1];
                }
                matrix[i, m - 1] = max;
            }
        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            answer = new int[n, m + 1];

            for (int i = 0; i < n; i++)
            {
                int max = matrix[i, 0];
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                    }
                }
                for (int j = 0; j < m - 1; j++)
                {
                    answer[i, j] = matrix[i, j];
                }
                answer[i, m - 1] = max;
                answer[i, m] = matrix[i, m - 1];
            }

            return answer;
        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if ((i + j) % 2 != 0)
                    {
                        count++;
                    }
                }
            }
            answer = new int[count];
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if ((i + j) % 2 != 0)
                    {
                        answer[k] = matrix[i, j];
                        k++;
                    }
                }
            }

            return answer;
        }

        public void Task6(int[,] matrix, int k)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n == 0 || n != m || k < 0 || k >= m) return;

        int imax = 0;
            for (int i = 1; i < n; i++)
            {
                if (matrix[i, i] > matrix[imax, imax])
                {
                    imax = i;
                }
            }
            int ineg = -1;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i, k] < 0)
                {
                    ineg = i;
                    break;
                }
            }
            if (ineg != -1 && imax != ineg)
            {
                for (int j = 0; j < n; j++)
                {
                    int temp = matrix[imax, j];
                    matrix[imax, j] = matrix[ineg, j];
                    matrix[ineg, j] = temp;
                }
            }

        }

        public void Task7(int[,] matrix, int[] array)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n == 0 || m < 2 || array == null || array.Length !=m) return;

        int imax = 0;
            for (int i = 1; i < n; i++)
            {
                if (matrix[i, m - 2] > matrix[imax, m - 2])
                {
                    imax = i;
                }
            }
            for (int j = 0; j < m; j++)
            {
                matrix[imax, j] = array[j];
            }

        }
        public void Task8(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int j = 0; j < m; j++)
            {
                int imax = 0;
                for (int i = 1; i < n; i++)
                {
                    if (matrix[i, j] > matrix[imax, j])
                    {
                        imax = i;
                    }
                }
                if (imax < n / 2)
                {
                    int sum = 0;
                    for (int i = imax + 1; i < n; i++)
                    {
                        sum += matrix[i, j];
                    }
                    matrix[0, j] = sum;
                }
            }

        }
        public void Task9(int[,] matrix)
        {
                int n = matrix.GetLength(0);
                int m = matrix.GetLength(1);
                if (n < 2 || m == 0) return;
                for (int i = 0; i < n - 1; i += 2)
                {
                    int jmax1 = 0;
                    for (int j = 1; j < m; j++)
                    {
                        if (matrix[i, j] > matrix[i, jmax1])
                        {
                            jmax1 = j;
                        }
                    }
                    int jmax2 = 0;
                    for (int j = 1; j < m; j++)
                    {
                        if (matrix[i + 1, j] > matrix[i + 1, jmax2])
                        {
                            jmax2 = j;
                        }
                    }
                    int temp = matrix[i, jmax1];
                    matrix[i, jmax1] = matrix[i + 1, jmax2];
                    matrix[i + 1, jmax2] = temp;
                }
        }

        public void Task10(int[,] matrix)
        { 
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n == 0 || n != m) return;
            int imax = 0;
            for (int i = 1; i < n; i++)
            { 
                if (matrix[i, i] > matrix[imax, imax])
                { 
                    imax = i;
                }
            }

            for (int i = 0; i < imax; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                        matrix[i, j] = 0;
                }
            }
        }
        
    
        public void Task11(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[] a = new int[n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        a[i]++;
                    }
                }
            }
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (a[j] < a[j + 1])
                    {
                        int t = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = t;

                        for (int k = 0; k < m; k++)
                        {
                            t = matrix[j, k];
                            matrix[j, k] = matrix[j + 1, k];
                            matrix[j + 1, k] = t;
                        }
                    }
                }
            }   
        }
        public int[][] Task12(int[][] array)
        {
            int[][] answer = null;
            int n = array.Length;
            double[] sr = new double[n];
            double sAll = 0;
            int cAll = 0;
            for (int i = 0; i < n; i++)
            {
                double s = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    s += array[i][j];
                }
                sr[i] = s / array[i].Length;
                sAll += s;
                cAll += array[i].Length;
            }
            double srAll = sAll / cAll;
            int c = 0;
            for (int i = 0; i < n; i++)
            {
                if (sr[i] >= srAll)
                {
                    c++;
                }
            }
            answer = new int[c][];
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                if (sr[i] >= srAll)
                {
                    answer[k] = array[i];
                    k++;
                }
            }

            return answer;
        }
    }
}