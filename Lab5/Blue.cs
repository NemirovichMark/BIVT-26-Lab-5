using System;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Blue
    {
        public double[] Task1(int[,] matrix)
        {
            double[] answer = new double[matrix.GetLength(0)];
            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int kolvo = 0;
                double summa = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        kolvo++;
                        summa += matrix[i, j];
                    }
                }
                if (kolvo == 0) 
                {
                    answer[i] = 0; 
                }
                else
                {
                    answer[i] = summa / kolvo;
                }
            }
            // end

            return answer;
        }
        public int[,] Task2(int[,] matrix)
        {


            // code here
            int max = int.MinValue;
            int maxX = 0;
            int maxY = 0;
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxX = i;
                        maxY = j;
                    }
                }
            }
            int[,] answer = new int[matrix.GetLength(0) - 1 , matrix.GetLength(1) - 1];
            for (int i = 0; i < answer.GetLength(0); i++)
            {
                for (int j = 0; j < answer.GetLength(1); j++)
                {
                    int curX = i < maxX ? i : i + 1;
                    int curY = j < maxY ? j : j + 1;
                    answer[i, j] = matrix[curX, curY];
                }
            }
            // end

            return answer;
        }
        public void Task3(int[,] matrix)
        {
            int[,] answer = new int[matrix.GetLength(0), matrix.GetLength(1)]; 
            // code here
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                int curmax = int.MinValue;
                int curmaxID = -1;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > curmax)
                    {
                        curmax = matrix[i, j];
                        curmaxID = j;
                    }
                }
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j < curmaxID)
                    {
                        answer[i,j] = matrix[i, j];
                    }
                    else if(j>=curmaxID && j != matrix.GetLength(1)-1)
                    {
                        answer[i, j] = matrix[i, j+1];
                    }
                    else
                    {
                        answer[i, j] = curmax;
                    }
                }
                
            }
            for(int i = 0; i< answer.GetLength(0); i++)
            {
                for (int j = 0; j < answer.GetLength(1); j++)
                {
                    matrix[i,j] = answer[i,j];
                }
            }
            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = new int[matrix.GetLength(0), matrix.GetLength(1)+1];

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int curmax = int.MinValue;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > curmax)
                    {
                        curmax = matrix[i, j];
                    }
                }
                for (int j = 0; j < answer.GetLength(1); j++)
                {
                    if (j < answer.GetLength(1) -2)
                    {
                        answer[i, j] = matrix[i, j];
                    }
                    else if (j==answer.GetLength(1)-2)
                    {
                        answer[i, j] = curmax;
                    }
                    else
                    {
                        answer[i, j] = matrix[i,j-1];
                    }
                }

            }
            // end

            return answer;
        }
        public int[] Task5(int[,] matrix)
        {
            // code here
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((i + j) % 2 != 0)
                    {
                        count++;
                    }
                }
            }
            int[] answer = new int[count];
            int index = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((i + j) % 2 != 0)
                    {
                        answer[index] = matrix[i, j];
                        index++;
                    }
                }
            }
            // end

            return answer;
        }
        public void Task6(int[,] matrix, int k)
        {

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                return;
            }
            if (k >= matrix.GetLength(1))
            {
                return;
            }
            int firstneg = -1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i,k] < 0)
                {
                    firstneg = i;
                    break;
                }
            }
            if(firstneg == -1)
            {
                return;
            }
            int maxmaindiag = int.MinValue;
            int rowID = -1;
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > maxmaindiag)
                {
                    maxmaindiag = matrix[i, i];
                    rowID = i;
                }
            }
            if(firstneg == rowID || rowID == -1)
            {
                return;
            }
            for(int i = 0; i< matrix.GetLength(0); i++)
            {
                (matrix[firstneg, i], matrix[rowID, i]) = (matrix[rowID, i], matrix[firstneg, i]);
            }
            // end

        }
        public void Task7(int[,] matrix, int[] array)
        {

            // code here
            if (matrix.GetLength(1) < 2 || matrix.GetLength(0) != array.Length)
            {
                return;
            }
            int strokaID = 0;
            int max = int.MinValue;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, matrix.GetLength(1) - 2] > max)
                {
                    max = matrix[i, matrix.GetLength(1) - 2];
                    strokaID = i;
                }
            }


            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[strokaID, i] = array[i];
            }
        
            // end

        }
        public void Task8(int[,] matrix)
        {

            // code here

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int max = int.MinValue;
                int maxID = 0;

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxID = i;
                    }
                }
                if (maxID < matrix.GetLength(0) / 2)
                {
                    int sum = 0;
                    for (int i = maxID + 1; i < matrix.GetLength(0); i++)
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
            {

                for (int i = 0; i < matrix.GetLength(0) - 1; i += 2)
                {
                    int max1 = int.MinValue;
                    int maxCol1 = 0;

                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] > max1)
                        {
                            max1 = matrix[i, j];
                            maxCol1 = j;
                        }
                    }

                    int max2 = int.MinValue;
                    int maxCol2 = 0;

                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i + 1, j] > max2)
                        {
                            max2 = matrix[i + 1, j];
                            maxCol2 = j;
                        }
                    }
                    (matrix[i + 1, maxCol2],matrix[i, maxCol1])  = (matrix[i, maxCol1],matrix[i + 1, maxCol2]);
                }
                // end

            }
        }
        public void Task10(int[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                return;
            }
            // code here

            int max = matrix[0, 0];
            int maxID = 0;
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > max)
                {
                    max = matrix[i, i];
                    maxID = i;
                }
            }

            for (int i = 0; i < maxID; i++)
            {
                for (int j = i + 1; j < matrix.GetLength(0); j++)
                {
                    matrix[i, j] = 0;
                }
            }
            // end

        }
        public void Task11(int[,] matrix)
        {
            // code here
            int[] count = new int[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        count[i]++;
                    }
                }
            }

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                int k = i - 1;

                while (k >= 0 && count[k] < count[k + 1])
                {
                    int x = count[k];
                    count[k] = count[k + 1];
                    count[k + 1] = x;

                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        int y = matrix[k, j];
                        matrix[k, j] = matrix[k + 1, j];
                        matrix[k + 1, j] = y;
                    }

                    k--;
                }
            }
            //end
        }

        private void SwapRows(int[,] matrix, int row1, int row2)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int temp = matrix[row1, j];
                matrix[row1, j] = matrix[row2, j];
                matrix[row2, j] = temp;
            }
            // end
        }
        public int[][] Task12(int[][] array)
        {
            double sum = 0;
            int count = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    sum += array[i][j];
                    count++;
                }
            }

            if (count == 0)
            {
                return array;
            }

            double avg = sum / count;
            int newLen = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Length == 0)
                {
                    continue;
                }

                double rowSum = 0;

                for (int j = 0; j < array[i].Length; j++)
                {
                    rowSum += array[i][j];
                }

                if (rowSum / array[i].Length >= avg)
                {
                    newLen++;
                }
            }
            int[][] answer = new int[newLen][];
            int index = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Length == 0)
                {
                    continue;
                }

                double rowSum = 0;

                for (int j = 0; j < array[i].Length; j++)
                {
                    rowSum += array[i][j];
                }

                if (rowSum / array[i].Length >= avg)
                {
                    answer[index] = array[i];
                    index++;
                }
            }

            return answer;
        }
    }
}
