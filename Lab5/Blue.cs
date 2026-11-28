using System.Linq;
using System.Runtime.InteropServices;
using System.Timers;

namespace Lab5
{
    public class Blue
    {
        public double[] Task1(int[,] matrix)
        {
            double[] answer = null;
            int y = 0;
            double sr = 0;
            int n=matrix.GetLength(0);
            int m=matrix.GetLength(1);
            answer= new double[n];
            for (int i=0; i<n; i++)
            {
                double s = 0;
                int k = 0;
                for (int j=0; j<m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        s = s + matrix[i, j];
                        k = k + 1;
                    }
                }
                if (s == 0)
                {
                    sr = 0;
                }
                else
                {
                    sr = s / k;
                }
                answer[i]=sr;
            }
            return answer;
        }
        public int[,] Task2(int[,] matrix)
        {
            int[,] answer = null;
            int n = matrix.GetLength(0);
            int m=matrix.GetLength(1);
            int el = int.MinValue;
            int iind = -1;
            int jind = -1;
            for (int i=0; i<n; i++)
            {
                for (int j=0; j<m; j++)
                {
                    if (matrix[i, j] > el)
                    {
                        el=matrix[i, j];
                        iind = i;
                        jind = j;
                    }
                }
            }

            int[,] answer1 = new int[n - 1, m];
            for (int i=0; i<n-1; i++)
            {
                if (i<iind)
                {
                    for (int j = 0; j < m; j++)
                    {
                        answer1[i, j]=matrix[i, j];
                    }
                }
                else
                {
                    for (int j = 0; j < m; j++)
                    {
                        answer1[i, j] = matrix[i+1, j];
                    }
                }
            } //удаление строки

            answer= new int[n-1, m-1];
            for (int j=0; j<m-1; j++)
            {
                if (j<jind)
                {
                    for (int i = 0; i < n-1; i++)
                    {
                        answer[i, j] = answer1[i, j];
                    }
                }
                else
                {
                    for (int i = 0; i < n-1; i++)
                    {
                        answer[i, j] = answer1[i, j+1];
                    }
                }
            }
            return answer;
        }
        public void Task3(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                int el = int.MinValue;
                int iind = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j]>el)
                    {
                        el=matrix[i, j];
                        iind = j;
                    }
                }
                for (int j = 0; j < m; j++)
                {
                    if (j>=iind && j<m-1) 
                    {
                        matrix[i, j] = matrix[i, j + 1];
                    }
                }
                matrix[i, m - 1] = el;
            }

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;
            int n= matrix.GetLength(0);
            int m= matrix.GetLength(1);
            answer= new int[n, m+1];
            for (int i=0; i<n; i++)
            {
                int el= int.MinValue;
                for (int j=0; j<m; j++)
                {
                    if (matrix[i, j] > el)
                    { 
                        el= matrix[i, j];
                    }
                }

                for (int j = 0; j < m+1; j++) //проход по answer
                                              //m послдений столбец
                                              //m-1 предпоследний столбец
                {
                    if (j < m - 1)
                    {
                        answer[i, j] = matrix[i, j];
                    }
                    else if (j == m - 1)
                    {
                        answer[i, j] = el;
                    }
                    else if (j==m)
                    {
                        answer[i, j] = matrix[i, m-1];
                    }
                }

            }
            return answer;
        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;
            int n=matrix.GetLength(0);
            int m=matrix.GetLength(1);
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if ((i+j)%2!=0)
                    {
                        k = k + 1;
                    }
                }
            }

            answer= new int[k];
            int y = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if ((i + j)%2!= 0)
                    {
                        answer[y]=matrix[i, j];
                        y++;
                    }
                }
            }
            return answer;
        }
        public void Task6(int[,] matrix, int k)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n!=m || k<0 || k>=m)
            {
                return;
            }
            else
            {
                int el = int.MinValue;
                int iind1 = -1;
                int iind2 = -1;
                for (int i = 0;i < n; i++)
                {
                    for (int j = 0;j < m; j++)
                    {
                        if (i==j && matrix[i, j]>el)
                        {
                            el=matrix[i,j];
                            iind1 = i;
                        }
                    }
                }
                for (int i = 0; i<n; i++)
                {
                    if (matrix[i, k]<0)
                    {
                        iind2 = i;
                        break;
                    }
                }
                if (iind2!=-1 && iind1!=iind2)
                {
                    for (int j=0; j<m; j++)
                    {
                        int p = matrix[iind1, j];
                        matrix[iind1, j] = matrix[iind2, j];
                        matrix[iind2, j] = p;
                    }
                }

            }

        }
        public void Task7(int[,] matrix, int[] array)
        {
            int n=matrix.GetLength(0);
            int m=matrix.GetLength(1);
            if (m < 2)
            {
                return;
            }
            if (array.Length!=m)
            {
                return;
            }
            //m-1 индекс последнего столбца
            //m-2 индекс предпоследего столбца 
            int el = int.MinValue;
            int iind = 0;
            for (int i=0; i<n; i++)
            {
                if (matrix[i, m-2]>el)
                {
                    el= matrix[i, m-2];
                    iind = i;
                }
            }
            for (int j=0; j<m; j++)
            {
                matrix[iind, j] = array[j];
            }
            
        }
        public void Task8(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int j=0; j<m; j++)
            {
                int el = int.MinValue;
                int iind = 0;
                int jind = 0;
                for (int i=0; i<n; i++)
                {
                    if (matrix[i, j]>el)
                    {
                        el=matrix[i, j];
                        iind = i;
                        jind = j;
                    }
                }
                if (iind<n/2)
                {
                    int s = 0;
                    for (int i=0; i<n; i++)
                    {
                        if (i > iind)
                        {
                            s = s + matrix[i, j];
                        }

                    }
                    matrix[0, j] = s;
                }
            }

        }
        public void Task9(int[,] matrix)
        {
            int n= matrix.GetLength(0);
            int m= matrix.GetLength(1);
            //if (n!=m)
            //{
            //    return;
            //}
            for (int i = 0; i < n-1; i=i+2)
            {
                int el1= int.MinValue;
                int el2 = int.MinValue;
                int jind1 = 0;
                int jind2 = 0;
                for (int j=0; j<m;j++)
                {
                    if (matrix[i, j]>el1)
                    {
                        el1= matrix[i, j];
                        jind1 = j;
                    }
                    if (matrix[i+1, j]>el2)
                    {
                        el2 = matrix[i+1, j];
                        jind2 = j;
                    }
                }
                int p = matrix[i, jind1];
                matrix[i, jind1] = matrix[i + 1, jind2];
                matrix[i+1, jind2] = p;
            }

        }
        public void Task10(int[,] matrix)
        {
            int n=matrix.GetLength(0);
            int m=matrix.GetLength(1);
            if (n!=m)
            {
                return;
            }
            int el = int.MinValue;
            int iind = 0;
            for (int i = 0;i < n; i++)
            {
                for (int j=0; j<m; j++)
                {
                    if (i==j && matrix[i, j]>el)
                    {
                        el= matrix[i, j];
                        iind = i;
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (j>i && i<iind)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }
        }
        public void Task11(int[,] matrix)
        {
            int n=matrix.GetLength(0);
            int m= matrix.GetLength(1);
            int[] kk=new int[n];
            for (int i=0; i<n; i++)
            {
                int k = 0;
                for (int j=0; j<m;j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        k = k + 1;
                    }
                }
                kk[i] = k;
            }

            for (int i=0; i<n-1; i++)
            {
                for (int j=0; j<n-i-1; j++)
                {
                    if (kk[j] < kk[j+1])
                    {
                        int p = kk[j];
                        kk[j]=kk[j+1];
                        kk[j + 1] = p;

                        for (int h = 0; h < m; h++)
                        {
                            int pp = matrix[j, h];
                            matrix[j, h] = matrix[j + 1, h];
                            matrix[j + 1, h] = pp;
                        }
                    }
                }
            }
        
        }
        public int[][] Task12(int[][] array)
        {
            int[][] answer = null;
            int k = 0;
            double s = 0;
            for (int i=0; i<array.Length; i++)
            {
                for (int j=0; j < array[i].Length; j++)
                {
                    k = k + 1;
                    s = s + array[i][j];
                }
            }
            int y = 0;
            int kk = 0;
            double sr = s / k;
            for (int i=0; i<array.Length; i++)
            {
                double ss = 0;
                for (int j=0; j < array[i].Length; j++)
                {

                    ss = ss + array[i][j];
                }
                double ssr = ss / array[i].Length;
                if (ssr >= sr)
                {
                    kk = kk + 1;
                }

            }
            answer= new int[kk][];
            for (int i = 0; i < array.Length; i++)
            {
                double ss = 0;
                for (int j = 0; j < array[i].Length; j++)
                {

                    ss = ss + array[i][j];
                }
                double ssr = ss / array[i].Length;
                if (ssr >= sr)
                {
                    answer[y] = array[i];
                    y++;
                }

            }
            return answer;
        }
    }
}
