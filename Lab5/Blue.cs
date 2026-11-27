using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

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
            answer = new double[n];
            for (int i = 0; i < n; i++)
            {
                double summ = 0;
                int count = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        summ += matrix[i, j];
                        count++;
                    }
                }
                
                if (count > 0)
                {
                answer[i] = summ / count;
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
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
           
            int nIdx = -1;
            int mIdx = -1;
            int max = int.MinValue;
            int[,] newMatrix = new int[n-1, m-1];
            int a = newMatrix.GetLength(0);
            int b = newMatrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] == max)
                    {
                        nIdx = i;
                        mIdx = j;
                        break;
                    }
                   

                }
                if (nIdx != -1 )
                {
                    break;
                }
            }
            for (int i = 0, a1 = 0; i < n && a1 < a; i++)
            {

                for (int j = 0, b1 = 0; j < m && b1 < b; j++)
                {
                    if (i != nIdx && j != mIdx)
                    {
                        newMatrix[a1, b1] = matrix[i, j];
                        b1++;
                        
                    }
                }
                if (i != nIdx)
                {
                    a1++;
                }
            }
            answer = newMatrix;
            // end

            return answer;
        }
        public void Task3(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            
            for (int i = 0; i < n; i++)
            {
                int max = int.MinValue;
                int maxIdx = -1;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxIdx = j;

                    }
                }
                for (int j = maxIdx + 1; j < m; j++)
                {
                    if (maxIdx != -1)
                    {
                        (matrix[i , j - 1], matrix[i, j]) = (matrix[i, j], matrix[i , j - 1]);
                    }
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
            int[,] newMatrix = new int[n, m + 1];
            for (int i = 0; i < n; i++)
            {
                int max = int.MinValue;
                
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                       
                    }
                }
                newMatrix[i, m - 1] = max;
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (j != (m-1))
                    {
                        newMatrix[i, j] = matrix[i, j];
                    }
                    else
                    {
                        newMatrix[i, m] = matrix[i, j];
                    }
                }
            }




            answer = newMatrix;
            // end

            return answer;
        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            
            int m1 = 0;
            for (int i = 0; i < n; i++)
            {
                
                for (int j = 0; j < m; j++)
                {
                    if ((i + j) % 2 != 0)
                    {
                        m1++;
                    }

                }
                
            }
            int[] newArray = new int[m1];
            int k = 0;
            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < m; j++)
                {
                    if ((i + j) % 2 != 0)
                    {
                        newArray[k] = matrix[i, j];
                        k++;
                    }

                }

            }
            answer = newArray;
            // end

            return answer;
        }
        public void Task6(int[,] matrix, int k)
        {

            // code here
            
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if ((k >= m || k < 0)|| n != m)
            {
                return;
            }
            int max = int.MinValue;
            int idxMax = 0;
            int idxMin = -1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if ( i == j &&matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        idxMax = i;
                    }
                }
            }
            

            for (int i = 0; i < n; i++)
            {
                    if (matrix[i, k] < 0)
                    {
                        
                        idxMin = i;
                        break;
                    }
            }
            if (idxMin == -1)
            {
                return;
            }
            if (idxMax == idxMin)
            {
                return;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i == idxMax)
                    {
                       ( matrix[i,j], matrix[idxMin, j]) = (matrix[idxMin, j], matrix[i, j]);
                    }
                }
            }


            // end

        }
        public void Task7(int[,] matrix, int[] array)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int maxIdx = 0;
            
            int max = int.MinValue;
            if (array.Length != m)
            {
                return;
            }
            if (m < 2)
            {
                return;
            }
            for (int j = 0; j < n; j++)
            {
               if (matrix[j, m-2] > max)
               {
                  max = matrix[j, m-2];
                    maxIdx = j;
               }
            }
            int a = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i == maxIdx)
                    {
                        matrix[i, j] = array[a];
                        a++;
                    }
                }
            }

            // end

        }
        public void Task8(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int mid = (n) / 2;
            for (int j = 0; j < m; j++)
            {
                int max = int.MinValue;
                int nIdx = 0;
                int mIdx = j;
               
                for (int i = 0; i < n; i++)
                {
                    
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        nIdx = i;
                        mIdx = j;
                    }

                }
                if (nIdx < mid)
                {
                    int summ = 0;
                    for (int i1 = nIdx + 1; i1 < n; i1++)
                    {
                        summ += matrix[i1, mIdx];
                    }
                    matrix[0, j] = summ;

                }


            }



            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            
            
           
            for (int i = 0; i < n; i++)
            {
                
                int max1 = int.MinValue;
                int max2 = int.MinValue;
                int maxIdx1 = 0;
                int maxIdx2 = 0;
                for (int j = 0; j < m; j++)
                {

                    if (matrix[i, j] > max1)
                    {
                        max1 = matrix[i, j];
                        maxIdx1 = j;

                    }
                    
                   

                }
                i++;
                if (i >= n)
                {
                    break;
                }
                for (int j = 0; j < m; j++)
                {
                    
                    if (matrix[i, j] > max2)
                    {
                        max2 = matrix[i, j];
                        maxIdx2 = j;

                    }
                    
                }
                (matrix[i - 1, maxIdx1], matrix[i, maxIdx2]) = (matrix[i, maxIdx2], matrix[i - 1, maxIdx1]);

            }
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int maxIdx = 0;
            int max = int.MinValue;
            if (n != m)
            {
                return;
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i == j && matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxIdx = i;
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (j > i && i < maxIdx)
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
            int[] arrIdx = new int[n];
            for (int i = 0; i < n; i++)
            {
                int count1 = 0;
                
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        count1++;
                    }
                    
                }
                arrIdx[i] = count1;
               
            }

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (arrIdx[j] < arrIdx[j + 1])
                    {
                        (arrIdx[j], arrIdx[j + 1]) =
                        (arrIdx[j + 1], arrIdx[j]);

                        for (int k = 0; k < m; k++)
                        {
                            (matrix[j, k], matrix[j + 1, k]) =
                            (matrix[j + 1, k], matrix[j, k]);
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
            double summ = 0;

            int count = 0;


            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    summ += array[i][j];
                    count++;
                }
            }
            double mid = 0;
            if (count != 0)
            {
                mid = summ / count;
            }
            double[] arrMid = new double[n];
            int countRows = 0;


            for (int i = 0; i < n; i++)
            {
                double summ1 = 0;

                for (int j = 0; j < array[i].Length; j++)
                {
                    summ1 += array[i][j];
                }


                if (array[i].Length != 0)
                {
                    arrMid[i] = summ1 / array[i].Length;
                }

                if (arrMid[i] >= mid)
                {
                    countRows++;
                }
            }

            int[][] newArray = new int[countRows][];
            int k = 0;

            for (int i = 0; i < n; i++)
            {
                if (arrMid[i] >= mid)
                {
                    newArray[k] = new int[array[i].Length];

                    for (int j = 0; j < array[i].Length; j++)
                    {
                        newArray[k][j] = array[i][j];
                    }

                    k++;

                }
            }

            answer = newArray;


            // end

            return answer;
        }
    }
}
