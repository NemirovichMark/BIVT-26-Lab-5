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
    for (int i = 0; i < matrix.GetLength(0); i++)
{
    int firstNegative = -1;
    int lastNegative = -1;

    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if (matrix[i, j] < 0)
        {
            if (firstNegative == -1)
            {
                firstNegative = j;
            }

            lastNegative = j;
        }
    }

    if (firstNegative > 0)
    {
        int maxIndex = 0;

        for (int j = 1; j < firstNegative; j++)
        {
            if (matrix[i, j] > matrix[i, maxIndex])
            {
                maxIndex = j;
            }
        }

        int temp = matrix[i, maxIndex];
        matrix[i, maxIndex] = matrix[i, lastNegative];
        matrix[i, lastNegative] = temp;
    }
}
            // end

        }
        public int[] Task7(int[,] matrix)
        {
            int[] negatives = null;

            // code here
        int count = 0;

for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if (matrix[i, j] < 0)
        {
            count++;
        }
    }
}

negatives = new int[count];

int index = 0;

for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if (matrix[i, j] < 0)
        {
            negatives[index] = matrix[i, j];
            index++;
        }
    }
}
            // end

            return negatives;
        }
        public void Task8(int[,] matrix)
        {

            // code here
    for (int i = 0; i < matrix.GetLength(0); i++)
{
    if (matrix.GetLength(1) == 1)
    {
        continue;
    }

    int maxIndex = 0;

    for (int j = 1; j < matrix.GetLength(1); j++)
    {
        if (matrix[i, j] > matrix[i, maxIndex])
        {
            maxIndex = j;
        }
    }

    if (maxIndex == 0)
    {
        matrix[i, 1] *= 2;
    }
    else if (maxIndex == matrix.GetLength(1) - 1)
    {
        matrix[i, maxIndex - 1] *= 2;
    }
    else
    {
        if (matrix[i, maxIndex - 1] <= matrix[i, maxIndex + 1])
        {
            matrix[i, maxIndex - 1] *= 2;
        }
        else
        {
            matrix[i, maxIndex + 1] *= 2;
        }
    }
}
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
        for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1) / 2; j++)
    {
        int temp = matrix[i, j];

        matrix[i, j] = matrix[i, matrix.GetLength(1) - 1 - j];

        matrix[i, matrix.GetLength(1) - 1 - j] = temp;
    }
}
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
