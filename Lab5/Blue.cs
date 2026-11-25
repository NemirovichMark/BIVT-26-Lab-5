using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Blue
    {
        public double[] Task1(int[,] matrix)
        {
            double[] answer = new double [matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                double summ = 0;
                for (int j = 0; j <  matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] > 0)
                    {
                        summ += matrix[i,j];
                    }
                }
                answer[i] = summ / matrix.GetLength(0);
            }
            return answer;
        }



        public int[,] Task2(int[,] matrix)
        {
            int[,] answer = new int[matrix.GetLength(0)-1, matrix.GetLength(1) - 1];
            int max = -999;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] > max)
                    {
                        max = matrix[i, j];
                    }
                }
            }
            int a = 0;
            int b = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == max)
                    {
                        a = i;
                        b = j;
                        break;
                    }
                }
            }
            int ii = 0;
            int plusi = 0;
            int plusj = 0;
            for (int i = 0; i < matrix.GetLength(0)-1; i++)
            {
                if (i == a)
                {
                    plusi = 1;
                }
                plusj = 0;
                for (int j = 0; j < matrix.GetLength(1)-1; j++)
                {
                    if (j == b)
                    {
                        plusj = 1;
                    }
                    ii = i + plusi;
                    int jj = j + plusj;
                    answer[i, j] = matrix[ii , jj];
                }
            }
            return answer;
        }



        public void Task3(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int max = -999;
                int a = 0;
                int plusj = 0;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[j,i] > max)
                    {
                        max = matrix[j, i];
                        a = j;
                    }
                }
                for (int j = 0; j < matrix.GetLength(0)-1; j++)
                {
                    if (j == a)
                    {
                        plusj = 1;
                    }
                    matrix[j, i] = matrix[j + plusj, i];
                }
                matrix[matrix.GetLength(0), i] = max;
            }
        }



        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = new int[matrix.GetLength(0)+1, matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int max = -999;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[j, i] > max)
                    {
                        max = matrix[j, i];
                    }
                }
                answer[i, matrix.GetLength(1)] = max;

            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int plusj = 0;
                for (int j = 0; j < matrix.GetLength(1)-1; j++)
                {
                    if (j == matrix.GetLength(1) - 1)
                    {
                        plusj = 1;
                    }
                    answer[i, j + plusj] = matrix[i, j];
                }
            }
            return answer;
        }



        public int[] Task5(int[,] matrix)
        {
            int a = matrix.GetLength(0);
            int b = matrix.GetLength(1);
            int[] answer = new int[(a*b+1)/2];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((i+j)%2 == 1)
                    {
                        answer[i*matrix.GetLength(1)+j] = matrix[i, j];
                    }
                }
            }
            return answer;
        }
        public void Task6(int[,] matrix, int k)
        {
            int maxx = -999;
            int b = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i,i] > maxx)
                {
                    maxx = matrix[i, i];
                    b = i;
                }
            }
            int a = -1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i,k] < 0)
                {
                    a = i;
                }
            }
            if (a != -1)
            {
                if (b != a)
                {
                    int temp = matrix[b, b];
                    matrix[b, b] = matrix[a, k];
                    matrix[a, k] = temp;
                }
            }
        }



        public void Task7(int[,] matrix, int[] array)
        {
            if (matrix.GetLength(1) > 1)
            {
                int max = -999;
                int a = 0;
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    if (matrix[matrix.GetLength(0)-1, i] > max)
                    {
                        max = matrix[matrix.GetLength(0) - 1, i];
                        a = i;
                    }
                }
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    matrix[a, i] = array[i];
                }
            }
        }



        public void Task8(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int maxx = -999;
                int a = 0;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[i,j] > maxx)
                    {
                        maxx = matrix[i, j];
                        a = j;
                    }
                }
                if (a <= matrix.GetLength(0)/2)
                {
                    matrix[i, a] = 0;
                    for (int l = 0; l < a; l++)
                    {
                        matrix[i, a] += matrix[i, l];
                    }
                }
            }
        }



        public void Task9(int[,] matrix)
        {
            int minus = 1;
            if (matrix.GetLength(0) % 2 == 1)
            {
                minus = 2;
            }
            for (int i = 0; i < matrix.GetLength(0)-minus; i += 2)
            {
                int maxx = -999;
                int maxx1 = -999;
                int a = 0;
                int b = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxx)
                    {
                        maxx = matrix[i, j];
                        a = j;
                    }
                }
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i+1, j] > maxx1)
                    {
                        maxx1 = matrix[i+1, j];
                        b = j;
                    }
                }
                matrix[i + 1, b] = maxx;
                matrix[i, a] = maxx1;
            }
        }



        public void Task10(int[,] matrix)
        {
            int maxx = -999;
            int a = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > maxx)
                {
                    maxx = matrix[i, i];
                    a = i;
                }
            }
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    matrix[i, j] = 0;
                }
            }
        }



        public void Task11(int[,] matrix)
        {
            int[] A = [matrix.GetLength(0)];
            int[] B = [matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int summ = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] > 0)
                    {
                        summ++;
                    }
                }
                A[i] = summ;
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0)-2-i; j++)
                {
                    if (A[j] < A[j + 1])
                    {
                        int temp = A[j];
                        A[j] = A[j + 1];
                        A[j + 1] = temp;
                        for (int l = 0; l < matrix.GetLength(0); l++)
                        {
                            B[l] = matrix[j, l];
                            matrix[j, l] = matrix[j + 1, l];
                            matrix[j + 1, l] = B[l];
                        }
                    }
                }
            }
        }



        public int[][] Task12(int[][] array)
        {
            int summ = 0;
            int k = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    summ += array[i][j];
                    k++;
                }
            }
            int kk = 0;
            double sred = summ / k;
            for (int i = 0; i < array.Length; i++)
            {
                int sum2 = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    sum2 += array[i][j];
                }
                if (sum2/ array[i].Length >= sred)
                {
                    kk++;
                }
            }
            int[][] answer = new int[kk][];
            kk = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int sum2 = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    sum2 += array[i][j];
                }
                if (sum2 / array[i].Length >= sred)
                {
                    answer[kk] = array[i];
                    kk++;
                }
            }
            return answer;
        }
    }
}
