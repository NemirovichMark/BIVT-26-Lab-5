using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Blue
    {
        public double[] Task1(int[,] matrix)
        {
            double[] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);


            int cnt = 0;
            double sum = 0;


            double srzn = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0) { sum += matrix[i, j]; cnt++; }
                    //Console.WriteLine(sum + "  " + cnt);

                    if (cnt != 0) { srzn = sum / cnt; }

                    else if (cnt == 0) { srzn = 0; }

                    //Console.WriteLine(sum + "  " + cnt + "  " + srzn);
                }
                sum = 0; cnt = 0; srzn = 0;
            }


            double[] prototype = new double[n];
            int schetchik = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0) { sum += matrix[i, j]; cnt++; }

                    if (cnt != 0) { srzn = sum / cnt; }

                    else if (cnt == 0) { srzn = 0; }
                }
                prototype[schetchik] = srzn; schetchik++;
                sum = 0; cnt = 0; srzn = 0;
            }

            answer = prototype;

            // end

            return answer;
        }
        public int[,] Task2(int[,] matrix)
        {
            int[,] answer = null;

            // code here

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int k = -1;

            int I = 0;
            int J = 0;

            double max = double.MinValue;
            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > max) { max = matrix[i, j]; }
                }

            }
            //Console.WriteLine(max);
            //Console.WriteLine();

            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] == max) { k = j; I = i; J = j; break; }

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
                        else { temp[i, j] = matrix[i, j + 1]; }
                    }

                }
                else
                {
                    for (int j = 0; j < m - 1; j++)
                    {
                        if (j < J) temp[i, j] = matrix[i + 1, j];
                        else { temp[i, j] = matrix[i + 1, j + 1]; }
                    }

                }
            }
            answer = temp;
            // end

            return answer;
        }
        public void Task3(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int k = -1;

            for (int i = 0; i < n; i++)
            {
                double max = double.MinValue;

                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > max) { max = matrix[i, j]; }
                }

                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] == max) { k = j; break; }

                }
                //Console.WriteLine(k);

                Console.WriteLine(matrix[i, k] + "  " + k);

                int temp = matrix[i, k];
                for (int j = 0; j < k; j++)
                { matrix[i, j] = matrix[i, j]; }

                for (int j = k; j < m; j++)
                {
                    if (j != m - 1) { matrix[i, j] = matrix[i, j + 1]; }
                    else { matrix[i, j] = temp; }
                }
            }
                // end

            }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int[,] temp = new int[n, m + 1];

            for (int i = 0; i < n; i++)
            {
                int max = int.MinValue;

                for (int j = 0; j < m; ++j)
                {
                    if (matrix[i, j] > max) { max = matrix[i, j]; }
                }

                temp[i, m - 1] = max;

                for (int j = 0; j < m; j++)
                {
                    if (j != m - 1)
                    {
                        temp[i, j] = matrix[i, j];
                    }

                    else { temp[i, j + 1] = matrix[i, j]; }
                }

                Console.WriteLine(max);
            }
            answer = temp;
            // end

            return answer;
        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int cnt = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if ((i + j) % 2 != 0) cnt++;
                }

            }

            int k = 0;
            int[] temp = new int[cnt];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if ((i + j) % 2 != 0) { temp[k] = matrix[i, j]; k++; }
                }

            }
            answer = temp;
            // end

            return answer;
        }
        public void Task6(int[,] matrix, int k)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int max = int.MinValue;
            int I = -1;

            for (int i = 0; i < Math.Min(n, m); i++)
            {
                if (matrix[i, i] > max)
                {
                    max = matrix[i, i];
                    I = i;
                }
            }

            
            int Otr = -1;
            if (k >= 0 && k < m)
            {
                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, k] < 0)
                    {
                        Otr = i;
                        break;
                    }
                }
            }
            if (Otr != -1 && Otr != I && n == m)
            {
                for (int j = 0; j < m; j++)
                {
                    int p = matrix[I, j];
                    matrix[I, j] = matrix[Otr, j];
                    matrix[Otr, j] = p;
                }
            }
            // end

        }
        public void Task7(int[,] matrix, int[] array)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (m < 2 || array.Length != m)
                return;

            int I = -1;
            int max = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                if (matrix[i, m - 2] > max)
                {
                    max = matrix[i, m - 2];
                    I = i;
                }
            }

            if (I != -1)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[I, j] = array[j];
                }
            }
            // end

        }
        public void Task8(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);


            for (int j = 0; j < m; j++)
            {
                int max = int.MinValue; int I = 0; int J = 0;
                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, j] > max) { max = matrix[i, j]; I = i; J = j; }
                }

                if (I < Math.Floor(n / (double)2))
                {
                    int sum = 0;
                    for (int i = 0; i < n; i++)
                    {
                        if (i > I) { sum += matrix[i, j]; }
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



            for (int i = 0; i + 1 < n; i +=2)
            {
                int max1 = int.MinValue; int J1 = 0;
                int max2 = int.MinValue; int J2 = 0;

                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > max1)
                    {
                        max1 = matrix[i, j];
                        J1 = j;
                    }
                }


                for (int j = 0; j < m; j++)
                {
                    if (matrix[i + 1, j] > max2)
                    {
                        max2 = matrix[i + 1, j];
                        J2 = j;
                    }
                }

                int temp = matrix[i, J1];
                matrix[i, J1] = matrix[i + 1, J2];
                matrix[i + 1, J2] = temp;
            }
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int max = int.MinValue;
            int I = -1;

            for (int i = 0; i < Math.Min(n, m); i++)
            {
                if (matrix[i, i] > max)
                {
                    max = matrix[i, i];
                    I = i;
                }
            }


            if (n == m)
            {
                for (int i = 0; i < I; i++)
                {
                    for (int j = i + 1; j < m; j++)
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

            for (int k = 0; k < n - 1; k++)
            {
                for (int i = 0; i < n - 1 - k; i++)
                {
                    int sum = 0;
                    int sum1 = 0;

                    for (int j = 0; j < m; j++)
                    {
                        if (matrix[i, j] > 0)
                            sum++;

                        if (matrix[i + 1, j] > 0)
                            sum1++;
                    }

                    if (sum < sum1)
                    {
                        for (int j = 0; j < m; j++)
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
        public int[][] Task12(int[][] array)
        {
            int[][] answer = null;

            // code here
            
            int sum = 0;
            int count = 0;

            
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    sum += array[i][j];
                    count++;
                }
            }

            if (count != 0)
            {
                double avg = (double)sum / count;

                
                int k = 0;

                for (int i = 0; i < array.Length; i++)
                {
                    long s = 0;

                    for (int j = 0; j < array[i].Length; j++)
                    {
                        s += array[i][j];
                    }

                    if (array[i].Length == 0 ||
                        (double)s / array[i].Length >= avg)
                    {
                        array[k] = array[i];
                        k++;
                    }
                }


                int[][] result = new int[k][];

                for (int i = 0; i < k; i++)
                {
                    result[i] = array[i];
                }

                answer = result;
            }
        
            // end

            return answer;
        }
    }
}
