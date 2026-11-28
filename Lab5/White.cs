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
            int num = 0;
            double summ = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        num++;
                        summ += matrix[i, j];
                    }
                }
            }

            if (num != 0)
            {
                average = summ / num;
            }
            // end

            return average;
        }

        public (int row, int col) Task2(int[,] matrix)
        {
            int row = 0, col = 0;

            // code here
            int minim = matrix[0, 0];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < minim)
                    {
                        minim = matrix[i, j];
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

            int maxx = matrix[0, k];
            int stro = 0;

            int[] mat = new int[matrix.GetLength(1)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, k] > maxx)
                {
                    maxx = matrix[i, k];
                    stro = i;
                }
            }

            if (stro != 0)
            {
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    mat[i] = matrix[0, i];
                }

                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    matrix[0, i] = matrix[stro, i];
                    matrix[stro, i] = mat[i];
                }
            }
            // end
        }

        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int row = 0;
            int minn = matrix[0, 0];
            int v = 0;

            if (matrix.GetLength(0) > 1)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, 0] < minn)
                    {
                        minn = matrix[i, 0];
                        row = i;
                    }
                }

                answer = new int[matrix.GetLength(0) - 1,
                                 matrix.GetLength(1)];

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (i != row)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            answer[v, j] = matrix[i, j];
                        }

                        v++;
                    }
                }
            }
            else
            {
                answer = new int[0, matrix.GetLength(1)];
            }
            // end

            return answer;
        }

        public int Task5(int[,] matrix)
        {
            int sum = 0;

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                return 0;
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[i, i];
            }
            // end
            return sum;
        }

        public void Task6(int[,] matrix)
        {
            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int first = -1;
                int last = -1;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        if (first == -1)
                        {
                            first = j;
                        }
                        last = j;
                    }
                }

                if (first > 0)
                {
                    int maxx = matrix[i, 0];
                    int index = 0;

                    for (int j = 0; j < first; j++)
                    {
                        if (matrix[i, j] > maxx)
                        {
                            maxx = matrix[i, j];
                            index = j;
                        }
                    }

                    int temp = matrix[i, index];
                    matrix[i, index] = matrix[i, last];
                    matrix[i, last] = temp;
                }
            }
            // end
        }

        
        public int[] Task7(int[,] matrix)
        {
            int[] negatives = null;

            // code here
            int num = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        num++;
                    }
                }
            }

            if (num == 0)
            {
                return null;
            }

            negatives = new int[num];

            int k = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        negatives[k] = matrix[i, j];
                        k++;
                    }
                }
            }
            // end

            return negatives;
        }


        public void Task8(int[,] matrix)
        {
            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix.GetLength(1) == 1)
                {
                    continue;
                }

                int maxx = matrix[i, 0];
                int index = 0;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxx)
                    {
                        maxx = matrix[i, j];
                        index = j;
                    }
                }

                if (index == 0)
                {
                    matrix[i, index + 1] *= 2;
                }
                else if (index == matrix.GetLength(1) - 1)
                {
                    matrix[i, index - 1] *= 2;
                }
                else
                {
                    if (matrix[i, index - 1] <= matrix[i, index + 1])
                    {
                        matrix[i, index - 1] *= 2;
                    }
                    else
                    {
                        matrix[i, index + 1] *= 2;
                    }
                }
            }
            // end
        }

        public void Task9(int[,] matrix)
        {
            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int left = 0;
                int right = matrix.GetLength(1) - 1;

                while (left < right)
                {
                    int temp = matrix[i, left];
                    matrix[i, left] = matrix[i, right];
                    matrix[i, right] = temp;

                    left++;
                    right--;
                }
            }
            // end
        }

        public void Task10(int[,] matrix)
        {
            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                return;
            }

            int n = matrix.GetLength(0);

            for (int i = n / 2; i < n; i++)
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
            int num = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
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
                    num++;
                }
            }

            answer = new int[num, matrix.GetLength(1)];

            int v = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
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
                    for (int j = 0; j < matrix.GetLength(1); j++)
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
