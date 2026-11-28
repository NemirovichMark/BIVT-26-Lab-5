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
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            answer = new double[n];
            int ind_answer = 0;
            for (int r = 0; r < n; ++r)
            {
                int current_sum = 0, current_count = 0;
                double sr = 0;
                for (int c = 0; c < m; ++c)
                {
                    if (matrix[r, c] > 0)
                    {
                        current_sum += matrix[r, c];
                        current_count += 1;
                    }
                }
                if (current_count > 0)
                {
                    sr = (double)current_sum / current_count;
                }
                answer[ind_answer] = sr;
                ++ind_answer;
            }
            // end

            return answer;
        }
        public int[,] Task2(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            answer = new int[n - 1, m - 1];
            int maxx = int.MinValue, ind_r = 0, ind_c = 0;
            for (int r = 0; r < n; ++r)
            {
                for (int c = 0; c < m; ++c)
                {
                    if (matrix[r, c] > maxx)
                    {
                        maxx = matrix[r, c];
                        ind_r = r;
                        ind_c = c;
                    }
                }
            }
            int ind_answer_r = 0;
            for (int r = 0; r < n; ++r)
            {
                if (r == ind_r)
                    continue;
                int ind_answer_c = 0;
                for (int c = 0; c < m; ++c)
                {
                    if (c == ind_c)
                        continue;
                    answer[ind_answer_r, ind_answer_c] = matrix[r, c];
                    ++ind_answer_c;
                }
                ++ind_answer_r;
            }
            // end

            return answer;
        }
        public void Task3(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            for (int r = 0; r < n; ++r)
            {
                int maxx = int.MinValue, ind_c = 0;
                for (int c = 0; c < m; ++c)
                {
                    if (matrix[r, c] > maxx)
                    {
                        maxx = matrix[r, c];
                        ind_c = c;
                    }
                }
                if (ind_c != m - 1)
                {
                    for (int c = ind_c + 1; c < m; ++c)
                    {
                        matrix[r, c - 1] = matrix[r, c];
                    }
                    matrix[r, m - 1] = maxx;
                }
            }
            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            answer = new int[n, m + 1];
            int[] max_els = new int[n];
            int ind_max_els = 0;
            for (int r = 0; r < n; ++r)
            {
                int maxx = int.MinValue, ind_c = 0;
                for (int c = 0; c < m; ++c)
                {
                    if (matrix[r, c] > maxx)
                    {
                        maxx = matrix[r, c];
                        ind_c = c;
                    }
                }
                max_els[ind_max_els] = maxx;
                ++ind_max_els;
            }
            int ind_max_els_2 = 0;
            for (int r = 0; r < answer.GetLength(0); ++r)
            {
                int ind_matrix_c = 0;
                for (int c = 0; c < answer.GetLength(1); ++c)
                {
                    if (c == answer.GetLength(1) - 2)
                    {
                        answer[r, c] = max_els[ind_max_els_2];
                        ++ind_max_els_2;
                        continue;
                    }
                    answer[r, c] = matrix[r, ind_matrix_c];
                    ++ind_matrix_c;
                }
            }
            // end

            return answer;
        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int count = 0;
            for (int r = 0; r < n; ++r)
            {
                for (int c = 0; c < m; ++c)
                {
                    if ((r + c) % 2 != 0)
                        ++count;
                }
            }
            answer = new int[count];
            int ind_answer = 0;
            for (int r = 0; r < n; ++r)
            {
                for (int c = 0; c < m; ++c)
                {
                    if ((r + c) % 2 != 0)
                    {
                        answer[ind_answer] = matrix[r, c];
                        ++ind_answer;
                    }
                }
            }
            // end

            return answer;
        }
        public void Task6(int[,] matrix, int k)
        {

            // code here
            if (matrix == null) return;
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;
            int n = matrix.GetLength(0);
            int maxx = int.MinValue, ind_row1 = 0;
            for (int i = 0; i < n; ++i)
            {
                if (matrix[i, i] > maxx)
                {
                    maxx = matrix[i, i];
                    ind_row1 = i;
                }
            }
            int ind_row2 = -1;
            for (int r = 0; r < n; ++r)
            {
                if (matrix[r, k] < 0)
                {
                    ind_row2 = r;
                    break;
                }
            }
            if (ind_row2 != -1 && ind_row1 != ind_row2) {
                for (int c = 0; c < n; ++c)
                {
                    int temp = matrix[ind_row1, c];
                    matrix[ind_row1, c] = matrix[ind_row2, c];
                    matrix[ind_row2, c] = temp;
                }
            }
            // end

        }
        public void Task7(int[,] matrix, int[] array)
        {

            // code here
            if (array.Length != matrix.GetLength(1)) return;
            if (matrix.GetLength(1) < 2) return;
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int maxx = int.MinValue, ind_r = 0;
            for (int r = 0; r < n; ++r)
            {
                if (matrix[r, m - 2] > maxx)
                {
                    maxx = matrix[r, m - 2];
                    ind_r = r;
                }
            }
            for (int c = 0; c < m; ++c)
            {
                matrix[ind_r, c] = array[c];
            }
            // end

        }
        public void Task8(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            for (int c = 0; c < m; ++c)
            {
                int maxx = int.MinValue, ind_r = 0;
                for (int r = 0; r < n; ++r)
                {
                    if (matrix[r, c] > maxx)
                    {
                        maxx = matrix[r, c];
                        ind_r = r;
                    }
                }
                if (ind_r < n / 2)
                {
                    int summ = 0;
                    for (int r = n - 1; r > ind_r; --r)
                    {
                        summ += matrix[r, c];
                    }
                    matrix[0, c] = summ;
                }
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            for (int r = 0; r < n - 1; r += 2)
            {
                int maxx1 = int.MinValue, maxx2 = int.MinValue, ind_r1 = 0, ind_c1 = 0, ind_r2 = 0, ind_c2 = 0;
                for (int c = 0; c < m; ++c)
                {
                    if (matrix[r, c] > maxx1)
                    {
                        maxx1 = matrix[r, c];
                        ind_r1 = r;
                        ind_c1 = c;
                    }
                    if (matrix[r + 1, c] > maxx2)
                    {
                        maxx2 = matrix[r + 1, c];
                        ind_r2 = r + 1;
                        ind_c2 = c;
                    }
                }
                int temp = matrix[ind_r1, ind_c1];
                matrix[ind_r1, ind_c1] = matrix[ind_r2, ind_c2];
                matrix[ind_r2, ind_c2] = temp;
            }
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;
            int n = matrix.GetLength(0);
            int maxx = int.MinValue, ind = 0;
            for (int i = 0; i < n; ++i)
            {
                if (matrix[i, i] > maxx)
                {
                    maxx = matrix[i, i];
                    ind = i;
                }
            }
            for (int r = 0; r < ind; ++r)
            {
                for (int c = 0; c < n; ++c)
                {
                    if (c > r)
                    {
                        matrix[r, c] = 0;
                    }
                }
            }
            // end

        }
        public void Task11(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            for (int r = 0; r < n - 1; ++r)
            {
                for (int r2 = 0; r2 < n - r - 1; ++r2)
                {
                    int count1 = 0;
                    for (int c = 0; c < m; ++c)
                    {
                        if (matrix[r2, c] > 0)
                            ++count1;
                    }
                    int count2 = 0;
                    for (int c = 0; c < m; ++c)
                    {
                        if (matrix[r2 + 1, c] > 0)
                            ++count2;
                    }
                    if (count1 < count2)
                    {
                        for (int c = 0; c < m; ++c)
                        {
                            int temp = matrix[r2, c];
                            matrix[r2, c] = matrix[r2 + 1, c];
                            matrix[r2 + 1, c] = temp;
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
            double summ = 0, count = 0;
            for (int r = 0; r < array.GetLength(0); ++r)
            {
                for (int c = 0; c < array[r].Length; ++c)
                {
                    summ += array[r][c];
                    ++count;
                }
            }
            double sr = summ / count;
            int count_del = 0;
            for (int r = 0; r < array.GetLength(0); ++r)
            {
                double summ_r = 0, count_r = 0;
                for (int c = 0; c < array[r].Length; ++c)
                {
                    summ_r += array[r][c];
                    ++count_r;
                }
                double sr_r = summ_r / count_r;
                if (sr_r < sr)
                {
                    ++count_del;
                }
            }
            int[] rows_del = new int[count_del];
            int ind_rows_del = 0;
            for (int r = 0; r < array.GetLength(0); ++r)
            {
                double summ_r = 0, count_r = 0;
                for (int c = 0; c < array[r].Length; ++c)
                {
                    summ_r += array[r][c];
                    ++count_r;
                }
                double sr_r = summ_r / count_r;
                if (sr_r < sr)
                {
                    rows_del[ind_rows_del] = r;
                    ++ind_rows_del;
                }
            }
            answer = new int[array.GetLength(0) - count_del][];
            int ind_answer = 0;
            for (int r = 0; r < array.GetLength(0); ++r)
            {
                bool is_in_rows_del = false;
                for (int i = 0; i < rows_del.Length; ++i)
                {
                    if (r == rows_del[i])
                    {
                        is_in_rows_del = true;
                        break;
                    }
                }
                if (!is_in_rows_del)
                {
                    answer[ind_answer] = array[r];
                    ++ind_answer;
                }

            }
            // end

            return answer;
        }
    }
}
