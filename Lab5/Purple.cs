namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;
           
            
            // code here
            int index = 0;
            answer = new int[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int counter = 0;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[j, i] < 0)
                    {
                        counter++;
                    }
                    
                }
                answer[index++] = counter;
                
            }

            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int index = 0;
                
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    
                    int min = matrix[i,index];
                    if (matrix[i, j] < matrix[i,index])
                    {
                        
                        index = j;
                    }
                }
                if (index == 0) continue;

                int  minnumb = matrix[i,index];
                for (int j = index; j > 0; j--)
                {
                    matrix[i,j] = matrix[i,j-1];
                }
                matrix[i,0] = minnumb;
                
            }

            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;
            
            // code here
            answer = new int[matrix.GetLength(0), matrix.GetLength(1)+1];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int indexmax = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > matrix[i, indexmax])
                    {
                        indexmax = j;
                    }
                }
                for (int j =0; j < matrix.GetLength(1); j++){answer[i,j] = matrix[i,j];}
                answer[i,indexmax+1] = matrix[i,indexmax];
                for (int j = indexmax + 1; j < matrix.GetLength(1); j++)
                {
                    answer[i,j+1] = matrix[i,j];
                }
            }
            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int maxindex = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > matrix[i, maxindex])
                    {
                        maxindex = j;
                    }
                }

                int sum = 0;
                int c = 0;
                for (int j = maxindex + 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        c++;
                    }
                }
                if (c ==0)continue;

                sum /= c;

                for (int j = 0; j < maxindex; j++)
                {
                    if (matrix[i, j] < 0) matrix[i,j] = sum;
                }
            }
            // end

        }
        public void Task5(int[,] matrix, int k)
        {

            if (k < 0 || k >= matrix.GetLength(1)) return;

            int[] a = new int[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int max = matrix[i, 0];
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                    }
                }
                a[i] = max;
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i, k] = a[matrix.GetLength(0) - 1 - i];
            }
        }

        public void Task6(int[,] matrix, int[] array)
        {

            if (array.Length != matrix.GetLength(1)) return;

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int max = 0;
                for (int i = 1; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] > matrix[max, j])
                    {
                        max = i;
                    }
                }

                if (array[j] > matrix[max, j])
                {
                    matrix[max, j] = array[j];
                }
            }
        }

        public void Task7(int[,] matrix)
        {
            int[] min = new int[matrix.GetLength(0)];
            int[] ind = new int[matrix.GetLength(0)];
            int[,] b = new int[matrix.GetLength(0), matrix.GetLength(1)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                min[i] = matrix[i, 0];
                ind[i] = i;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    b[i, j] = matrix[i, j];
                    if (matrix[i, j] < min[i])
                    {
                        min[i] = matrix[i, j];
                    }
                }
            }

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(0) - 1 - i; j++)
                {
                    if (min[j] < min[j + 1])
                    {
                        (min[j], min[j + 1]) = (min[j + 1], min[j]);
                        (ind[j], ind[j + 1]) = (ind[j + 1], ind[j]);
                    }
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = b[ind[i], j];
                }
            }
        }

        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            if (matrix.GetLength(0) != matrix.GetLength(1)) return answer;

            answer = new int[2 * matrix.GetLength(0) - 1];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    answer[matrix.GetLength(0) - 1 + j - i] += matrix[i, j];
                }
            }

            return answer;
        }

        public void Task9(int[,] matrix, int k)
        {

            if (matrix.GetLength(0) != matrix.GetLength(1) || k < 0 || k >= matrix.GetLength(0)) return;

            int im = 0;
            int jm = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (Math.Abs(matrix[i, j]) > Math.Abs(matrix[im, jm]))
                    {
                        im = i;
                        jm = j;
                    }
                }
            }

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int q = matrix[im, j];
                if (im < k)
                {
                    for (int i = im; i < k; i++)
                    {
                        matrix[i, j] = matrix[i + 1, j];
                    }
                }
                else
                {
                    for (int i = im; i > k; i--)
                    {
                        matrix[i, j] = matrix[i - 1, j];
                    }
                }
                matrix[k, j] = q;
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int q = matrix[i, jm];
                if (jm < k)
                {
                    for (int j = jm; j < k; j++)
                    {
                        matrix[i, j] = matrix[i, j + 1];
                    }
                }
                else
                {
                    for (int j = jm; j > k; j--)
                    {
                        matrix[i, j] = matrix[i, j - 1];
                    }
                }
                matrix[i, k] = q;
            }
        }

        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            if (A.GetLength(1) != B.GetLength(0)) return answer;

            answer = new int[A.GetLength(0), B.GetLength(1)];

            for (int p = 0; p < answer.Length; p++)
            {
                int i = p / B.GetLength(1);
                int j = p % B.GetLength(1);

                for (int k = 0; k < A.GetLength(1); k++)
                {
                    answer[i, j] += A[i, k] * B[k, j];
                }
            }

            return answer;
        }

        public int[][] Task11(int[,] matrix)
        {
            int[][] answer = null;

            answer = new int[matrix.GetLength(0)][];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int c = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        c++;
                    }
                }

                answer[i] = new int[c];
                int k = 0;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        answer[i][k] = matrix[i, j];
                        k++;
                    }
                }
            }

            return answer;
        }

        public int[,] Task12(int[][] array)
        {
            int[,] answer = null;

            int c = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null)
                {
                    c += array[i].Length;
                }
            }

            int n = 0;

            for (int i = 0; i * i < c; i++)
            {
                n++;
            }

            answer = new int[n, n];
            int k = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null)
                {
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        answer[k / n, k % n] = array[i][j];
                        k++;
                    }
                }
            }

            return answer;
        }
    }
}
