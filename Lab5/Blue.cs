using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;

namespace Lab5
{
    public class Blue
    {
        public double[] Task1(int[,] matrix)
        {
            double[] answer = null;

            // code here
            double[] newaa = new double[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                double count = 0;
                double sum = 0;
                double sred = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {

                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        count++;
                    }
                    

                }

                if (sum != 0)
                {
                    sred = sum / count;
                    newaa[i] = sred;
                }
                else
                {
                    sred = 0;
                    newaa[i] = sred;
                }
            }
            answer = newaa;
            // end

            return answer;
        }
        public int[,] Task2(int[,] matrix)
        {
            int[,] answer = null;

            // code here

            int[,] b = new int[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
            int maxi = 0, maxj = 0;
            int masx = int.MinValue;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0;j < matrix.GetLength(1); j++)
                {
                    if ( matrix[i, j] > masx)
                    {
                        masx = matrix[i, j];
                        maxi = i;
                        maxj = j;
                    }
                }
            }
            for (int i = 0, k = 0; i < matrix.GetLength(0); i++)
            {
                if (i == maxi)
                    continue;
                for (int j = 0, t = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == maxj)
                        continue;

                    b[k, t] = matrix[i, j];
                    t++;
                }
                k++;
            }
            answer = b;
            // end

            return answer;
        }
        public void Task3(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            
            for (int i = 0; i < n;i++)
            {
                int mstrk = int.MinValue;
                int indms = 0;
               
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > mstrk)
                        {
                        mstrk = matrix[i, j];
                        indms = j;
                    }
                }
                int sdwig = m - 1 - indms;
                for (int j = indms; j < m - 1; j++)
                {
                    matrix[i, j] = matrix[i, j + 1];
                }
                matrix[i, m - 1] = mstrk;
            }
            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[,] daw = new int[n, m + 1];
           for (int i = 0; i < n; i++)
            {
                int mas = int.MinValue;

                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > mas)
                    {
                        mas = matrix[i, j];
                    }

                    daw[i, j] = matrix[i, j];             
                }
                daw[i, m] = matrix[i, m - 1];
                daw[i, m - 1] = mas;
            }
            answer = daw;
            // end

            return answer;
        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int cnt = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((i + j) % 2 != 0)
                    {
                        cnt++;
                    }
                }
            }

            int[] m = new int[cnt];

            for (int i = 0, t = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((i + j) % 2 != 0)
                    {
                        m[t] = matrix[i, j];
                        t++;
                    }
                }
            }
            if (cnt > 0)
            {
               
                answer = m;
            }
            else
            {
                return answer;
            }
            // end

            return answer;
        }
        public void Task6(int[,] matrix, int k)
        {

            // code here
            int indmax = 0;
            if (matrix.GetLength(0) != matrix.GetLength(1))
                { return; }
            if (k < 0 || k > (matrix.GetLength(0) - 1))
               { return; }
            int m = matrix.GetLength(0);
            int mas = int.MinValue;
            for (int i = 0; i < m; i++)
            {
                if (matrix[i, i] > mas)
                {
                    mas = matrix[i, i];
                    indmax = i;
                }
            }
            int otr = -1;
            for (int i = 0; i < m; i++)
            {
                if (matrix[i, k] < 0)
                {
                    otr = i;
                    break;
                }
            }
            if (otr == -1 || indmax == otr)
            {
                return;
            }
            for (int i = 0; i < m; i++)
            {
                int tem = matrix[indmax, i];
                matrix[indmax, i] = matrix[otr, i];
                matrix[otr, i] = tem;

            }
            // end

        }
        public void Task7(int[,] matrix, int[] array)
        {

            // code here
            if (matrix.GetLength(1) < 2 || array.Length != matrix.GetLength(1)) 
            {
                return;
            }
            int index = 0;
            int maxx = int.MinValue;
            for (int j = matrix.GetLength(1) - 2; j < matrix.GetLength(1) - 1; j++)
            {
                for (int i = 0;i < matrix.GetLength(0);i++)
                {
                    if (matrix[i, j] > maxx)
                    {
                        index = i;
                        maxx = matrix[i, j];
                    }
                }
            }
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                matrix[index, i] = array[i];
            }
            // end

        }
        public void Task8(int[,] matrix)
        {

            // code here
            int m = matrix.GetLength(1);
            int n = matrix.GetLength(0);
            for (int j = 0; j < m; j++)
            { 
                int max = matrix[0, j];
                int inx = 0;

                for (int i = 1; i < n; i++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        inx = i;
                    }
                }
                if (inx < n/2)
                {
                    int sum = 0;
                    for (int i = inx + 1; i < n; i++)
                    {
                        sum += matrix[i, j];
                    }
                    matrix[0, j] = sum; 
                }
            }

            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);


            for (int i = 0; i + 1 < n; i += 2)
            {
                int inxc = 0;
                int inyc = 0;
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] > matrix[i, inxc])
                    {
                        inxc = j;
                    }
                }
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i + 1, j] > matrix[i + 1, inyc])
                    {
                        inyc = j;
                    }
                }
                int t = matrix[i, inxc];
                matrix[i, inxc] = matrix[i + 1, inyc];
                matrix[i + 1, inyc] = t;
            }
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength (0);
            int m = matrix.GetLength(1);
            if (n != m || m == 0)
            {
                return;
            }
            int maxi = 0;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i, i] > matrix[maxi, maxi])
                {
                    maxi = i;
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i < maxi && j > i)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }
            // end

        }
        public void Task11(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for(int k = 0; k < n - 1; k++)
            {
                for (int i = 0; i < n - 1 - k; i++)
                {
                    int cnt = 0;
                    int cnt1 = 0;
                    for (int j = 0; j < m; j++)
                    {
                        if (matrix[i, j] > 0)
                        {
                            cnt++;
                        }
                    }
                    for (int j = 0; j < m; j++)
                    {
                        if (matrix[i + 1, j] > 0)
                        {
                            cnt1++;
                        }
                    }
                    if (cnt < cnt1)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            (matrix[i, j], matrix[i + 1, j]) = (matrix[i + 1, j], matrix[i, j]);
                        }
                    }
                }
            }
            // end

        }
        public int[][] Task12(int[][] array)
        {
            int[][] answer = null;

            // code here
            int n = array.Length;
            double cnt = 0;
            double sum = 0;
            for (int i = 0; i < n; i++)
            {
                if (array[i] == null || array[i].Length == 0)
                {
                    continue;
                }
                for (int j = 0; j < array[i].Length; j++)
                {
                    cnt++;
                    sum += array[i][j];
                }
            }

            if (cnt == 0)
            {
                return null;
            }
            double sred = sum / cnt;
            int kol = 0;
            for (int i = 0; i < n; i++)
            {
                if (array[i] == null || array[i].Length == 0)
                {
                    continue;
                }
                double ccnt = 0;
                double sums = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    sums += array[i][j];
                    ccnt++;
                }
                double sr = sums / ccnt;
                if (sr >= sred)
                {
                    kol++;
                }
            }
            int[][] mm = new int[kol][];
            for (int i = 0, k = 0; i < n; i++)
            {
                if (array[i] == null || array[i].Length == 0)
                {
                    continue;
                }
                double ccnt = 0;
                double sums = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    sums += array[i][j];
                    ccnt++;
                }
                double sr = sums / ccnt;
                if (sr >= sred)
                {
                    mm[k] = new int[array[i].Length];
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        mm[k][j] = array[i][j];
                    }
                    k++;
                }
            }

            answer = mm;
            // end

            return answer;
        }
    }
}
