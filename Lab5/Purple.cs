using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;

namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;

            // code here
            answer = new int[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int cnt = 0;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[j, i] < 0) cnt++;
                }
                answer[i] = cnt;
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int[] array = new int [matrix.GetLength(0)];
            for(int j = 0; j < matrix.GetLength(1); j++)
            {
                int min = matrix[0, j];
                int index = 0;
                for(int i = 0; i < matrix.GetLength(0); i++)
                {
                    min = Math.Min(matrix[i, j], min);
                }
                
            }


            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here

            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here

            // end

        }
        public void Task5(int[,] matrix, int k)
        {

            // code here

            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here

            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here

            // end

        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here

            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here

            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here

            // end

            return answer;
        }
        public int[][] Task11(int[,] matrix)
        {
            int[][] answer = null;

            // code here

            // end

            return answer;
        }
        public int[,] Task12(int[][] array)
        {
            int[,] answer = null;

            // code here

            // end

            return answer;
        }
    }
}