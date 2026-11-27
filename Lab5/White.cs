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
    int count = 0;

for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if (matrix[i, j] > 0)
        {
            average += matrix[i, j];
            count++;
        }
    }
}

if (count > 0)
{
    average = average / count;
}
            // end

            return average;
        }
        public (int row, int col) Task2(int[,] matrix)
        {
            int row = 0, col = 0;

            // code here
    int min = matrix[0, 0];

for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if (matrix[i, j] < min)
        {
            min = matrix[i, j];
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
        int maxRow = 0;

for (int i = 1; i < matrix.GetLength(0); i++)
{
    if (matrix[i, k] > matrix[maxRow, k])
    {
        maxRow = i;
    }
}

for (int j = 0; j < matrix.GetLength(1); j++)
{
    int temp = matrix[0, j];
    matrix[0, j] = matrix[maxRow, j];
    matrix[maxRow, j] = temp;
}
            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
int minRow = 0;

for (int i = 1; i < matrix.GetLength(0); i++)
{
    if (matrix[i, 0] < matrix[minRow, 0])
    {
        minRow = i;
    }
}

answer = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];

int newRow = 0;

for (int i = 0; i < matrix.GetLength(0); i++)
{
    if (i != minRow)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            answer[newRow, j] = matrix[i, j];
        }

        newRow++;
    }
}
            // end

            return answer;
        }
        public int Task5(int[,] matrix)
        {
            int sum = 0;

            // code here
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

            // end

        }
        public int[] Task7(int[,] matrix)
        {
            int[] negatives = null;

            // code here

            // end

            return negatives;
        }
        public void Task8(int[,] matrix)
        {

            // code here

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
        public int[,] Task11(int[,] matrix)
        {
            int[,] answer = null;

            // code here

            // end

            return answer;
        }
        public void Task12(int[][] array)
        {

            // code here

            // end

        }
    }
}
