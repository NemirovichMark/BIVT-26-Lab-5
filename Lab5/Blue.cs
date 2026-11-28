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
                double sum = 0;
                int count = 0;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        count++;
                    }
                }
                if (count > 0)
                    answer[i] = sum / count;
                else
                    answer[i] = 0;
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
            int MaxVal = matrix[0, 0];
            int maxn = 0;
            int maxm = 0;

            for(int i=0;i<n;i++)
            {
                for(int j=0;j<m;j++)
                {
                    if (matrix[i,j]>MaxVal)
                    {
                        MaxVal = matrix[i, j];
                        maxn = i;
                        maxm = j;

                    }
                }
            }
            answer = new int[n - 1, m - 1];
            
            
            for(int i=0;i<n-1;i++)
            {
                for (int j=0;j<m-1;j++)
                {
                    if(i<maxn && j<maxm)
                        answer[i,j]= matrix[i,j];
                    else if (i < maxn && j >= maxm)
                        answer[i, j] = matrix[i, j+1];
                    else if (i >= maxn && j < maxm)
                        answer[i, j] = matrix[i+1, j];
                    else
                        answer[i, j] = matrix[i+1, j+1];

                }
            }

            // end

            return answer;
        }
        public void Task3(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i=0;i<n;i++)
            {
                int maxm = 0;
                for(int j=0;j<m;j++)
                {
                    if (matrix[i, j] > matrix[i, maxm])
                        maxm = j;
                }
                int MaxVal = matrix[i, maxm];
                for (int j = maxm; j < m - 1; j++)
                    matrix[i, j] = matrix[i, j + 1];
                matrix[i, m - 1] = MaxVal;

            }

            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            answer = new int[n,m+1];
            for (int i=0;i<n;i++)
            {
                int maxVal = matrix[i,0];
                for (int j=0;j<m;j++)
                {
                    if (matrix[i,j]>maxVal)
                    {
                        maxVal = matrix[i, j];
                    }
                }
                for (int j=0;j<m-1;j++)
                {
                    answer[i, j] = matrix[i, j];
                }
                answer[i, m - 1] = maxVal;
                answer[i, m] = matrix[i, m - 1];
            }
                

                    

            // end

            return answer;
        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int count = 0;
            for (int i=0;i<n;i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if ((i+j)%2!=0)
                    {
                        count++;

                    }
                }
            }
            answer = new int[count];
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
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
            int n= matrix.GetLength(0);
            int m= matrix.GetLength(1);
            if (n==m && k<m && k>0)
            {
                int maxi = 0;
                for (int i=0;i<n;i++)
                {
                    if (matrix[i, i] > matrix[maxi, maxi])
                        maxi = i;
                }
                int neg = -1;
                for (int i=0;i<n;i++)
                {
                    if (matrix[i,k]<0)
                    {
                        neg = i;
                        break;
                    }
                }
                if (neg!=-1 && maxi!=neg)
                {
                    for (int j=0;j<m;j++)
                    {
                        (matrix[maxi, j], matrix[neg, j]) = (matrix[neg, j], matrix[maxi, j]);
                    }
                }
            }
            else
            {
                matrix = null;
            }
            // end

        }
        public void Task7(int[,] matrix, int[] array)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (m > 2 && array.Length==m)
            {
                int prevLastCol = m-2;
                int maxRow = 0;
                for (int i=0;i<n;i++)
                {
                    if (matrix[i, prevLastCol] > matrix[maxRow,prevLastCol])
                    {
                        maxRow = i;
                    }                                                  
                    
                }
                for (int j=0;j<m;j++)
                {
                    matrix[maxRow, j] = array[j];
                }

            }
            else
                return;
            // end

        }
        public void Task8(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for(int j=0;j<m;j++)
            {
                int maxRow = 0;
                for(int i=0;i<n;i++)
                {
                    if (matrix[i, j] > matrix[maxRow,j])
                    {
                        maxRow = i;
                    }
                }
                if (n/2>maxRow)
                {
                    int sum = 0;
                    for(int i=maxRow+1;i<n;i++)
                    {
                        sum += matrix[i, j];
                    }
                    matrix[0,j]= sum;
                }
            }

            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            
                for (int i = 0; i+1 < n; i+=2)
                {
                    int maxCol1 = 0;
                    for (int j = 0; j < m; j++)
                    {
                        if (matrix[i, j] > matrix[i, maxCol1])
                        {
                            maxCol1 = j;
                        }
                    }
                    int maxCol2 = 0;
                    for (int j = 0; j < m; j++)
                    {
                        if (matrix[i + 1, j] > matrix[i + 1, maxCol2])
                        {
                            maxCol2 = j;
                        }
                    }

                    (matrix[i, maxCol1], matrix[i+1,maxCol2]) = (matrix[i+1, maxCol2], matrix[i, maxCol1]);
                }
                

            

            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            int n=matrix.GetLength(0);
            int m=matrix.GetLength(1);
            if (n == m)
            {
                int maxd = 0;
                for (int i=0;i<n;i++)
                {
                    if (matrix[i, i] > matrix[maxd, maxd])
                        maxd = i;
                }
                for (int i=0;i<maxd;i++)
                {
                    for (int j=i+1;j<m;j++)
                    {
                        matrix[i, j] = 0;
                    }
                }

            }
            else
                return;
            // end

        }
        public void Task11(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[] posCounts = new int[n];
            for (int i = 0; i < n; i++)
            {
                int count = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        count++;
                    }
                }
                posCounts[i] = count;
            }
            int index = 1, nextindex = 2;
            while (index < n)
            {
                if (posCounts[index - 1] >= posCounts[index])
                {
                    index = nextindex;
                    nextindex++;
                }
                else
                {
                    (posCounts[index - 1],posCounts[index]) = (posCounts[index], posCounts[index-1]);
                    for (int j=0;j<m;j++)
                    {
                        (matrix[index - 1, j], matrix[index,j]) = (matrix[index, j], matrix[index-1, j]);
                    }
                    index--;
                    if (index==0)
                    {
                        index = nextindex;
                        nextindex++;
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
            double sum = 0;
            double[] m = new double[n];
            double count = 0;
            for(int i = 0; i <n; i++)
            {
                if (array[i] == null || array[i].Length == 0)
                    continue;
                double sumrow = 0;
                for (int j= 0; j < array[i].Length;j++)
                {
                    
                    sumrow += array[i][j];
                }
                m[i] = sumrow / array[i].Length;
                sum += sumrow;
                count += array[i].Length;
            }
            if (count == 0)
                return null;
            double avg = sum / count;
            int k = 0;
            for(int i=0;i<n;i++)
            {
                if (array != null && array[i].Length > 0 && m[i] >= avg)
                    k++;
            }
            answer = new int[k][];
            int index = 0;
            for(int i=0;i<n;i++)
            {
                if(array != null && array[i].Length > 0 && m[i] >= avg)
                {
                    answer[index] = new int[array[i].Length];
                    for (int j = 0; j < array[i].Length;j++)
                    {
                        answer[index][j] = array[i][j];
                    }
                    index++;
                }
            }

            // end

            return answer;
        }
    }
}
