using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.JavaScript;

namespace Lab5
{
    public class Blue
    {
        public double[] Task1(int[,] matrix)
        {
            double[] answer = null;

            // code here
            int stroki = matrix.GetLength(0);
            int stolbi = matrix.GetLength(1);
            answer = new double[stroki];
            for(int i = 0; i < stroki; i ++)
            {
                double sum = 0;
                int count = 0;
                for(int j = 0;  j < stolbi; j ++)
                {
                    if (matrix[i,j] > 0)
                    {
                        count++;
                        sum += matrix[i,j];
                    }
                }  
                if(count > 0)
                {
                    answer[i] = sum / count;
                }
            }
            // end

            return answer;
        }
        public int[,] Task2(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int stroki = matrix.GetLength(0);
            int stolbi = matrix.GetLength(1);
            int max = matrix[0, 0];
            int maxStroka = 0;
            int maxStolb = 0;
            for(int i = 0; i < stroki; i ++)
            {
                for(int j = 0;  j < stolbi; j ++)
                {
                    if(matrix[i,j] > max)
                    {
                        max  = matrix[i,j];
                        maxStroka = i;
                        maxStolb = j;
                    }
                }

            }
            answer = new int[stroki - 1, stolbi - 1];
            int newI = 0;
            for(int i = 0; i < stroki; i ++)
            {
                if(i != maxStroka)
                {
                    int newJ = 0;
                    for (int j = 0; j < stolbi; j++)
                    {
                        if (j != maxStolb)
                        {
                            answer[newI, newJ] = matrix[i, j];
                            newJ++;
                        }
                    }
                    newI++;

                }
            }
            // end

            return answer;
        }
        public void Task3(int[,] matrix)
        {

            // code here
            int stroki = matrix.GetLength(0);
            int stolbi = matrix.GetLength(1);
            for(int i = 0; i < stroki; i ++)
            {
                int maxIndex = 0;
                for(int j = 1; j < stolbi; j ++)
                {
                    if (matrix[i, j] > matrix[i, maxIndex] )
                    {
                        maxIndex = j;
                    }
                }
                int temp = matrix[i, maxIndex];
                for(int j = maxIndex; j < stolbi - 1; j ++)
                {
                    matrix[i, j] = matrix[i, j + 1];

                }
                matrix[i, stolbi-1] = temp;

            }
            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int stroki = matrix.GetLength(0);
            int stolbi = matrix.GetLength(1);
            answer = new int[stroki, stolbi + 1];
            for(int i = 0; i < stroki; i ++)
            {
                int maxChislo = matrix[i, 0];
                for(int j = 1;j < stolbi; j ++)
                {
                    if (matrix[i, j] > maxChislo)
                    {
                        maxChislo = matrix[i, j];
                    }
                }
                answer[i, stolbi - 1] = maxChislo;
                for(int j = 0; j < stolbi; j ++)
                {
                    if(j <  stolbi - 1)
                    {
                        answer[i, j] = matrix[i, j];
                    }
                    else
                    {
                        answer[i, stolbi] = matrix[i, j];
                    }
                }
            }
            // end

            return answer;
        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int stroki = matrix.GetLength(0);
            int stolbi = matrix.GetLength(1);
            int cnt = 0;
            for(int i = 0; i < stroki; i ++)
            {
                for(int j = 0;j < stolbi; j ++)
                {
                    if ((i + j) % 2 != 0)
                    {
                        cnt++;
                    }
                }
            }
            answer = new int[cnt];
            int k = 0;
            for(int i = 0; i < stroki; i ++)
            {
                for(int j = 0; j < stolbi; j++)
                {
                    if((i + j) % 2 != 0)
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
            int stroki = matrix.GetLength(0);
            int stolbi = matrix.GetLength(1);
            if(stroki != stolbi || k <0 || k>= stolbi)
            {
                return;
            }
            int maxIndex = 0;
            for(int i = 1;  i < stroki; i ++)
            {
                if (matrix[i,i] > matrix[maxIndex, maxIndex])
                {
                    maxIndex = i;
                }
            }
            int negative = -1;
            for(int i = 0; i < stroki; i ++)
            {
                if (matrix[i, k] < 0)
                {
                    negative = i;
                    break;
                }
            }
            if(negative != -1 && negative != maxIndex)
            {
                for(int j = 0; j < stolbi; j++)
                {
                    int temp = matrix[maxIndex, j];
                    matrix[maxIndex, j] = matrix[negative, j];
                    matrix[negative, j] = temp; 
                }
            }
            // end

        }
        public void Task7(int[,] matrix, int[] array)
        {

            // code here
            int stroki = matrix.GetLength(0);
            int stolbi = matrix.GetLength(1);
            int maxIndex = 0;
            if(stolbi >= 2 && array.Length == stolbi)
            {
                for (int i = 1; i < stroki; i++)
                {
                    if (matrix[i, stolbi - 2] > matrix[maxIndex, stolbi - 2])
                    {
                        maxIndex = i;
                    }
                }
                for(int j = 0; j < stolbi; j++)
                {
                    matrix[maxIndex, j] = array[j];
                }
            }
            // end

        }
        public void Task8(int[,] matrix)
        {

            // code here
            int stroki = matrix.GetLength(0);
            int stolbi = matrix.GetLength(1);
            for(int j =0; j < stolbi; j++)
            {
                int maxIndex = 0;
                for(int i = 1;  i < stroki; i++)
                {
                    if (matrix[i, j] > matrix[maxIndex, j])
                    {
                        maxIndex = i;
                    }
                }
                if(maxIndex < stroki/2)
                {
                    int sum = 0;
                    for(int i = maxIndex+1; i < stroki; i++)
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
            int stroki = matrix.GetLength(0);
            int stolbi = matrix.GetLength(1);
            for (int i = 0; i < stroki - 1; i+=2)
            {
                int maxIndex1 = 0;
                int maxIndex2 = 0;
                for(int j = 1; j < stolbi; j++)
                {
                    if (matrix[i,j] > matrix[i, maxIndex1] )
                    {
                        maxIndex1 = j;
                    }
                    if (matrix[i+1, j] > matrix[i+1, maxIndex2])
                    {
                        maxIndex2 = j;
                    }
                }
                int temp = matrix[i, maxIndex1];
                matrix[i, maxIndex1] = matrix[i + 1, maxIndex2];
                matrix[i+1, maxIndex2] = temp;
            }
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            int stroki = matrix.GetLength(0);
            int stolbi = matrix.GetLength(1);
            if(stroki != stolbi)
            {
                return;
            }
            int maxIndex = 0;
            for(int i = 1; i < stroki; i ++)
            {
                if (matrix[i,i] > matrix[maxIndex, maxIndex])
                { 
                    maxIndex = i;
                }
            }
            for(int i = 0; i < maxIndex; i ++)
            {
                for(int j = i+1;  j < stolbi; j ++)
                {
                    matrix[i, j] = 0;
                }
            }

            // end

        }
        public void Task11(int[,] matrix)
        {

            // code here
            int stroki = matrix.GetLength(0);
            int stolbi = matrix.GetLength(1);
            int[] count = new int[stroki];

            for (int i = 0; i < stroki; i++)
            {
                for (int j = 0; j < stolbi; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        count[i]++;
                    }
                }
            }
            int[] index = new int[stroki];

            for (int i = 0; i < stroki; i++)
            {
                index[i] = i;
            }
            for (int i = 0; i < stroki - 1; i ++)
            {
                for(int j = 0; j < stroki- i -1; j ++)
                {
                    if (count[j] < count[j+1])
                    {
                        int temp = count[j];
                        count[j] = count[j+1];
                        count[j+1] = temp;
                        int temp2 = index[j];
                        index[j] = index[j + 1];
                        index[j + 1] = temp2;
                    }
                }
            }
            int[,] tempMatrix = new int[stroki, stolbi];
            for (int i = 0; i < stroki; i++)
            {
                for (int j = 0; j < stolbi; j++)
                {
                    tempMatrix[i, j] = matrix[index[i], j];
                }
            }


            for (int i = 0; i < stroki; i++)
            {
                for (int j = 0; j < stolbi; j++)
                {
                    matrix[i, j] = tempMatrix[i, j];
                }
            }

                    // end

                }
        public int[][] Task12(int[][] array)
        {
            int[][] answer = null;

            // code here
            int stroki = array.Length;

            double sum = 0;
            int count = 0;

            for (int i = 0; i < stroki; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    sum += array[i][j];
                    count++;
                }
            }
            double average = sum / count;
            int keepCount = 0;

            for (int i = 0; i < stroki; i++)
            {
                double rowSum = 0;

                for (int j = 0; j < array[i].Length; j++)
                {
                    rowSum += array[i][j];
                }
                double srednee = rowSum / array[i].Length;
                if( srednee >= average)
                {
                    keepCount++;
                }
            }
            answer = new int[keepCount][];
            int k = 0;
            for (int i = 0; i < stroki; i++)
            {
                double rowSum = 0;

                for (int j = 0; j < array[i].Length; j++)
                {
                    rowSum += array[i][j];
                }

                double srednee = rowSum / array[i].Length;

                if (srednee >= average)
                {
                    answer[k] = array[i];
                    k++;
                }
            }
            // end

            return answer;
        }
    }
}
