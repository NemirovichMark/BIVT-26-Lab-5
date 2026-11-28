using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Green
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int r = matrix.GetLength(0);
            int l = matrix.GetLength(1);
            answer = new int[r];
            for (int i = 0; i < r; i++)
            {
                int min = matrix[i, 0];
                int indmin = 0;
                for (int j = 0; j < l; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        indmin = j;
                    }
                }
                answer[i] = indmin;
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int r = matrix.GetLength(0);
            int l = matrix.GetLength(1);
            
            for (int i = 0; i < r; i++)
            {
                int max = matrix[i, 0];
                int indmax = 0;
                for (int j = 0; j < l; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        indmax = j;
                    }
                }
                for (int j = 0; j < indmax; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        matrix[i, j] = (int)Math.Floor((double)matrix[i, j] / max);
                    }
                }
            }
            // end

        }
        public void Task3(int[,] matrix, int k)
        {

            // code here
            int r = matrix.GetLength(0);
            int l = matrix.GetLength(1);
            if (r != l) return;
            if (r == 0 || l == 0|| k >= l || k < 0) return;
            int lim = Math.Min(r, l);
            int max = matrix[0, 0];
            int k1 = 0;
            for (int i = 1; i < lim; i++)
            {
                if (matrix[i, i] > max)
                {
                    max = matrix[i, i];
                    k1 = i;
                }
            }
            if (k == k1) return;
            for (int i = 0; i < r; i++)
            {
                int t = matrix[i, k];
                matrix[i, k] = matrix[i, k1];
                matrix[i, k1] = t;
            }
            // end

        }
        public void Task4(int[,] matrix)
        {

            // code here
            int r = matrix.GetLength(0);
            int l = matrix.GetLength(1);
            if (r == 0 || l == 0) return;
            if (r != l) return;
            int indmax = 0;
            int max = matrix[0, 0];
            int d = Math.Min(r, l);

            for (int i = 1; i < d; i++)
            {
                if (matrix[i, i] > max)
                {
                    max = matrix[i, i];
                    indmax = i;
                }
            }

            int lim = Math.Min(r, l);

            for (int i = 0; i < lim; i++)
            {
                if (i == indmax) continue;

                int s = matrix[indmax, i];
                matrix[indmax, i] = matrix[i, indmax];
                matrix[i, indmax] = s;
            }
            // end

        }
        public int[,] Task5(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int r = matrix.GetLength(0);
            int l = matrix.GetLength(1);
            if (r == 0 || l == 0) return matrix;

            int maxsum = -1;
            int n = 0;

            for (int i = 0; i < r; i++)
            {
                int sum = 0;
                for (int j = 0; j < l; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                    }
                }

                if (sum > maxsum)
                {
                    maxsum = sum;
                    n = i;
                }
            }

            answer = new int[r - 1, l];
            int nr = 0;

            for (int i = 0; i < r; i++)
            {
                if (i == n) continue;

                for (int j = 0; j < l; j++)
                {
                    answer[nr, j] = matrix[i, j];
                }
                nr++;
            }
            // end

            return answer;
        }
        public void Task6(int[,] matrix)
        {

            // code here
            int r = matrix.GetLength(0);
            int l = matrix.GetLength(1);
            int[] negc = new int[r];
            for (int i = 0; i < r; i++)
            {
                int count = 0;
                for (int j = 0; j < l; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        count++;
                    }
                }
                negc[i] = count;
            }
            int indmin = 0, indmax = 0;
            for (int i = 1; i < r; i++)
            {
                if (negc[i] < negc[indmin])
                {
                    indmin = i;
                }
                if (negc[i] > negc[indmax])
                {
                    indmax = i;
                }
            }
            if (negc[indmin] == negc[indmax]) return;
            for (int j = 0; j < l; j++)
            {
                int s = matrix[indmin, j];
                matrix[indmin, j] = matrix[indmax, j];
                matrix[indmax, j] = s;
            }
            // end

        }
        public int[,] Task7(int[,] matrix, int[] array)
        {
            int[,] answer = null;

            // code here
            int min = int.MaxValue;
            int ind = 0;
            int r = matrix.GetLength(0);
            int l = matrix.GetLength(1);
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < l; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        ind = j; 
                    }
                }
            }
            answer = new int[r,l+1];
            if (array.Length != r) return matrix;
            for (int i = 0; i < r; i++)
            {
                int n = 0;
                for (int j = 0; j < l; j++)
                {
                    answer[i, n] = matrix[i, j];
                    n++;
                    if (j == ind)
                    {
                        answer[i, n] = array[i];
                        n++;
                    }
                }
            }
            // end

            return answer;
        }
        public void Task8(int[,] matrix)
        {

            // code here
            int r = matrix.GetLength(0), l = matrix.GetLength(1);
            
            for (int j = 0; j < l; j++)
            {
                int posc = 0, negc = 0;
                int max = int.MinValue, indmax = 0;
                for (int i = 0; i < r; i++)
                {
                    if (matrix[i, j] > 0) posc++;
                    else if (matrix[i, j] < 0) negc++;
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        indmax = i;
                    }
                }
                if (posc > negc)
                {
                    matrix[indmax, j] = 0;
                }
                else if (negc > posc)
                {
                    matrix[indmax, j] = indmax;
                }
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            int r = matrix.GetLength(0);
            int l = matrix.GetLength(1);
            if (r != l) return;
            for (int i = 0; i < r; i++)
            {
                matrix[0, i] = 0;
                matrix[r - 1, i] = 0;
                matrix[i, 0] = 0;
                matrix[i,l - 1] = 0;
            }
            // end

        }
        public (int[] A, int[] B) Task10(int[,] matrix)
        {
            int[] A = null, B = null;

            // code here
            A = new int[0];
            B = new int[0];
            int r = matrix.GetLength(0);
            int l = matrix.GetLength(1);
            if (r == 0 || l == 0 || r != l) return (null, null);
            int sizeA = 0, sizeB = 0;
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < l; j++)
                {
                    if (j >= i) sizeA++;
                    else sizeB++;
                }
            }
            A = new int[sizeA];
            B = new int[sizeB];
            int a = 0, b = 0;
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < l; j++)
                {
                    if (j >= i)
                    {
                        A[a++] = matrix[i, j];
                    }
                    else 
                    {
                        B[b++] = matrix[i, j]; 
                    }
                }
            }
            // end

            return (A, B);
        }
        public void Task11(int[,] matrix)
        {

            // code here
            int r = matrix.GetLength(0);
            int l = matrix.GetLength(1);
            if (r == 0 || l == 0) return;
            for (int i = 1; i < r; i++)
            {
                for (int j = 0; j < l; j++)
                {
                    int c = matrix[i, j];
                    int k = i - 1;
                    if (j % 2 == 0)
                    {
                        while (k >= 0 && matrix[k, j] < c)
                        {
                            matrix[k + 1, j] = matrix[k, j];
                            k--;
                        }
                    }
                    else
                    {
                        while (k >= 0 && matrix[k, j] > c)
                        {
                            matrix[k + 1, j] = matrix[k, j];
                            k--;
                        }
                    }
                    matrix[k + 1, j] = c;
                }
            }
            // end

        }
        public void Task12(int[][] array)
        {

            // code here
            int n = array.Length;

            int[] lens = new int[n];
            int[] sums = new int[n];

            for (int i = 0; i < n; i++)
            {
                if (array[i] != null)
                {
                    lens[i] = array[i].Length;
                    for (int j = 0; j < lens[i]; j++)
                    {
                        sums[i] = sums[i] + array[i][j];
                    }
                }
            }

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    bool nd = false;

                    if (lens[j] < lens[j + 1])
                    {
                        nd = true;
                    }
                    else if (lens[j] == lens[j + 1] && sums[j] < sums[j + 1])
                    {
                        nd = true;
                    }

                    if (nd)
                    {
                        int[] tr = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = tr;

                        int tl = lens[j];
                        lens[j] = lens[j + 1];
                        lens[j + 1] = tl;

                        int ts = sums[j];
                        sums[j] = sums[j + 1];
                        sums[j + 1] = ts;
                    }
                }
            }
            // end

        }
    }
}
