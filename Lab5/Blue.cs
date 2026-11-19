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
            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);
            answer = new double[r];
            for (int i = 0; i < r; i++)
            {
                double sum = 0;
                int cnt = 0;
                for (int j = 0; j < c; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        cnt++;
                    }
                }
                if (cnt > 0)
                {
                    answer[i] = sum / cnt;
                }
                else
                {
                    answer[i] = 0;
                }
            }
            // end

            return answer;
        }
        public int[,] Task2(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);
            int maxi = 0;
            int maxj = 0;
            int max = matrix[0, 0];
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxi = i;
                        maxj = j;
                    }
                }
            }
            answer = new int[r - 1, c - 1];
            int a = 0;
            for (int i = 0; i < r; i++)
            {
                if (i == maxi) continue;
                int b = 0;
                for (int j = 0; j < c; j++)
                {
                    if (j == maxj) continue;
                    answer[a, b] = matrix[i, j];
                    b++;
                }
                a++;
            }
            // end

            return answer;
        }
        public void Task3(int[,] matrix)
        {

            // code here
            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);
            for (int i = 0; i < r; i++)
            {
                int maxj = 0;
                int max = matrix[i, 0];
                for (int j = 1; j < c; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxj = j;
                    }
                }
                int temp = matrix[i, maxj];
                for (int j = maxj; j < c - 1; j++)
                {
                    matrix[i, j] = matrix[i, j + 1];
                }
                matrix[i, c - 1] = temp;
            }
            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);
            answer = new int[r, c + 1];
            for (int i = 0; i < r; i++)
            {
                int max = matrix[i, 0];
                for (int j = 1; j < c; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                    }
                }
                for (int j = 0; j < c - 1; j++)
                {
                    answer[i, j] = matrix[i, j];
                }
                answer[i, c - 1] = max;
                answer[i, c] = matrix[i, c - 1];
            }
            // end

            return answer;
        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);
            int cnt = 0;
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if ((i + j) % 2 != 0) cnt++;
                }
            }
            answer = new int[cnt];
            int k = 0;
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if ((i + j) % 2 != 0)
                    {
                        answer[k] = matrix[i, j];
                        k++;
                    }
                }
            }
            // end

            return answer;
        }
        public void Task6(int[,] matrix, int k)
        {

            // code here
            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);
            if (r != c) return;
            if (k < 0 || k >= c) return;
            int maxi = 0;
            int max = matrix[0, 0];
            for (int i = 1; i < r; i++)
            {
                if (matrix[i, i] > max)
                {
                    max = matrix[i, i];
                    maxi = i;
                }
            }
            int ni = -1;
            for (int i = 0; i < r; i++)
            {
                if (matrix[i, k] < 0)
                {
                    ni = i;
                    break;
                }
            }
            if (ni == -1 || ni == maxi) return;
            for (int j = 0; j < c; j++)
            {
                int temp = matrix[maxi, j];
                matrix[maxi, j] = matrix[ni, j];
                matrix[ni, j] = temp;
            }
            // end

        }
        public void Task7(int[,] matrix, int[] array)
        {

            // code here
            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);
            if (r == 0 || c < 2) return;
            int maxi = 0;
            int max = matrix[0, c - 2];
            for (int i = 1; i < r; i++)
            {
                if (matrix[i, c - 2] > max)
                {
                    max = matrix[i, c - 2];
                    maxi = i;
                }
            }
            if (array.Length != c) return;
            for (int j = 0; j < c; j++)
            {
                if (j < array.Length)
                {
                    matrix[maxi, j] = array[j];
                }
            }
            // end

        }
        public void Task8(int[,] matrix)
        {

            // code here
            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);
            for (int j = 0; j < c; j++)
            {
                int maxi = 0;
                int max = matrix[0, j];
                for (int i = 1; i < r; i++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxi = i;
                    }
                }
                if (maxi < r / 2)
                {
                    int sum = 0;
                    for (int i = maxi + 1; i < r; i++)
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
            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);
            for (int i = 0; i < r - 1; i += 2)
            {
                int max1 = matrix[i, 0];
                int max1j = 0;
                for (int j = 1; j < c; j++)
                {
                    if (matrix[i, j] > max1)
                    {
                        max1 = matrix[i, j];
                        max1j = j;
                    }
                }
                int max2 = matrix[i + 1, 0];
                int max2j = 0;
                for (int j = 1; j < c; j++)
                {
                    if (matrix[i + 1, j] > max2)
                    {
                        max2 = matrix[i + 1, j];
                        max2j = j;
                    }
                }
                int temp = matrix[i, max1j];
                matrix[i, max1j] = matrix[i + 1, max2j];
                matrix[i + 1, max2j] = temp;
            }
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);
            if (r != c) return;
            int max = matrix[0, 0];
            int maxi = 0;
            for (int i = 1; i < r; i++)
            {
                if (matrix[i, i] > max)
                {
                    max = matrix[i, i];
                    maxi = i;
                }
            }
            for (int i = 0; i < maxi; i++)
            {
                for (int j = i + 1; j < c; j++)
                {
                    matrix[i, j] = 0;
                }
            }
            // end

        }
        public void Task11(int[,] matrix)
        {

            // code here
            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);
            int[] cnts = new int[r];
            for (int i = 0; i < r; i++)
            {
                int cnt = 0;
                for (int j = 0; j < c; j++)
                {
                    if (matrix[i, j] > 0) cnt++;
                }
                cnts[i] = cnt;
            }
            for (int i = 0; i < r - 1; i++)
            {
                for (int k = 0; k < r - 1 - i; k++)
                {
                    if (cnts[k] < cnts[k + 1])
                    {
                        int tempcnt = cnts[k];
                        cnts[k] = cnts[k + 1];
                        cnts[k + 1] = tempcnt;
                        for (int j = 0; j < c; j++)
                        {
                            int tempval = matrix[k, j];
                            matrix[k, j] = matrix[k + 1, j];
                            matrix[k + 1, j] = tempval;
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
            if (array == null || array.Length == 0) return new int[0][];
            double sumall = 0;
            int cntall = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    sumall += array[i][j];
                    cntall++;
                }
            }
            double avg = 0;
            if (cntall > 0)
            {
                avg = sumall / cntall;
            }
            int rwgood = 0;
            for (int i = 0; i < array.Length; i++)
            {
                double sumrw = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    sumrw += array[i][j];
                }
                double avgrw = 0;
                if (array[i].Length > 0)
                {
                    avgrw = sumrw / array[i].Length;
                }
                if (avgrw >= avg) rwgood++;
            }
            answer = new int[rwgood][];
            int k = 0;
            for (int i = 0; i < array.Length; i++)
            {
                double sumrw = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    sumrw += array[i][j];
                }
                double avgrw = 0;
                if (array[i].Length > 0)
                {
                    avgrw = sumrw / array[i].Length;
                }
                if (avgrw >= avg)
                {
                    answer[k] = new int[array[i].Length];
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        answer[k][j] = array[i][j];
                    }
                    k++;
                }
            }
            // end

            return answer;
        }
    }
}
