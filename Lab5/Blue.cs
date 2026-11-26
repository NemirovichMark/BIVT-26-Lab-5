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
            answer = new double[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int s = 0;
                int count = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        s += matrix[i, j];
                        count++;
                    }
                }
                if (count != 0)
                {
                    answer[i] = (double)s / count;
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
            int max = matrix[0,0];
            int maxstr = 0;
            int maxstolb = 0;
            // code here
            for (int i = 0; i < matrix.GetLength(0);i++)
            {
                for (int j = 0; j < matrix.GetLength(1);j++)
                {
                    if (matrix[i,j] > max)
                    {
                        max = matrix[i,j];
                        maxstr = i;
                        maxstolb = j;
                    }
                }
            }
            int str = matrix.GetLength(0);
            int stolb = matrix.GetLength(1);
            answer = new int[str - 1, stolb - 1];
            int newi = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i != maxstr)
                {
                    int newj = 0;
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (j != maxstolb)
                        {
                            answer[newi, newj] = matrix[i, j];
                            newj++;
                        }
                    }
                    newi++;
                }
            }
            // end
            return answer;
        }
        public void Task3(int[,] matrix)
        {
            // code here
            int str = matrix.GetLength(0);
            int stolb = matrix.GetLength(1);
            for (int i = 0; i < str; i++)
            {
                int max = matrix[i, 0];
                int maxi = 0;
                for (int j = 0; j < stolb;j++)
                {
                    if (matrix[i,j] > max)
                    {
                        max = matrix[i, j];
                        maxi = j;
                    }
                }
                for (int j = maxi;j < stolb - 1;j++)
                {
                    matrix[i, j] = matrix[i, j + 1];
                }
                matrix[i, stolb - 1] = max;
            }
            // end
        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;
            // code here
            int str = matrix.GetLength(0);
            int stolb = matrix.GetLength(1);
            answer = new int[str, stolb + 1];
            for (int i = 0; i < str; i++)
            {
                int max = matrix[i, 0];
                for (int j = 0; j < stolb; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                    }
                }
                for (int j = 0; j < stolb - 1; j++)
                {
                    answer[i, j] = matrix[i, j];
                }
                answer[i, stolb - 1] = max;
                answer[i, stolb] = matrix[i, stolb - 1];
            }
            // end
            return answer;
        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;
            // code here
            int count = 0;
            int str = matrix.GetLength (0);
            int stolb = matrix.GetLength (1);
            for (int i = 0; i < str;i++)
            {
                for (int j = 0; j < stolb;j++)
                {
                    if ((i + j) % 2 != 0)
                    {
                        count++;
                    }
                }
            }
            answer = new int[count];
            int ind = 0;
            for (int i = 0; i < str; i++)
            {
                for (int j = 0; j < stolb; j++)
                {
                    if ((i + j) % 2 != 0)
                    {
                        answer[ind] = matrix[i, j];
                        ind++;
                    }
                }
            }
            // end
            return answer;
        }
        public void Task6(int[,] matrix, int k)
        {
            // code here
            int maxstr = 0;
            int str = matrix.GetLength (0);
            int stolb = matrix.GetLength (1);
            int max = int.MinValue;
            int otrk = -1;
            if (str != stolb) return;
            if (k < 0 || k >= stolb) return;
            for (int i = 0; i < str;i++)
            {
                if (matrix[i,i] > max)
                {
                    max = matrix[i,i];
                    maxstr = i;
                }
            }
            for (int i = 0; i < str; i++)
            {
                if (matrix[i, k] < 0)
                {
                    otrk = i;
                    break;
                }
            }
             for (int j = 0;j < stolb; j++)
             {
                 if (otrk != -1  && maxstr != otrk)
                 {
                     (matrix[maxstr, j], matrix[otrk, j]) = (matrix[otrk, j], matrix[maxstr, j]);
                 }
             }
            // end
        }
        public void Task7(int[,] matrix, int[] array)
        {
            // code here
            int str = matrix.GetLength(0);
            int stolb = matrix.GetLength(1);
            if (str == 0 || stolb < 2) return;              
            if (array.Length != stolb) return;
            int col = stolb - 2;                  
            int max = int.MinValue;
            int maxR = 0;
            
            for (int i = 0; i < str; i++)
            {
                if (matrix[i, col] > max)
                {
                    max = matrix[i, col];
                    maxR = i;
                }
            }
            
            for (int j = 0; j < stolb; j++)
            {
                matrix[maxR, j] = array[j];
            }
            // end
        }
        public void Task8(int[,] matrix)
        {
            // code here
            if (matrix == null) return;
            int str = matrix.GetLength(0);
            int stolb = matrix.GetLength(1);
            for (int j = 0; j < stolb; j++)
            {
                int max = matrix[0, j];
                int maxR = 0;
                for (int i = 1; i < str; i++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxR = i;
                    }
                }
                if (maxR < str / 2)
                {
                    int sum = 0;
                    for (int i = maxR + 1; i < str; i++)
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

            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here

            // end

        }
        public void Task11(int[,] matrix)
        {

            // code here

            // end

        }
        public int[][] Task12(int[][] array)
        {
            int[][] answer = null;

            // code here

            // end

            return answer;
        }
    }
}
