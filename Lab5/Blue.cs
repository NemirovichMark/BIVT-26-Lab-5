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
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            answer = new double[rows];

            for (int row = 0; row < rows; row++)
            {
                long sum = 0;
                int count = 0;

                for (int column = 0; column < columns; column++)
                {
                    if (matrix[row, column] > 0)
                    {
                        sum += matrix[row, column];
                        count++;
                    }
                }

                if (count > 0)
                {
                    answer[row] = (double)sum / count;
                }
            }
            // end

            return answer;
        }
        public int[,] Task2(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            int maxRow = 0;
            int maxColumn = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    if (matrix[row, column] > matrix[maxRow, maxColumn])
                    {
                        maxRow = row;
                        maxColumn = column;
                    }
                }
            }

            answer = new int[rows - 1, columns - 1];
            int targetRow = 0;

            for (int row = 0; row < rows; row++)
            {
                if (row == maxRow)
                {
                    continue;
                }

                int targetColumn = 0;

                for (int column = 0; column < columns; column++)
                {
                    if (column != maxColumn)
                    {
                        answer[targetRow, targetColumn] = matrix[row, column];
                        targetColumn++;
                    }
                }

                targetRow++;
            }
            // end

            return answer;
        }
        public void Task3(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                int maxColumn = 0;

                for (int column = 1; column < columns; column++)
                {
                    if (matrix[row, column] > matrix[row, maxColumn])
                    {
                        maxColumn = column;
                    }
                }

                int maxValue = matrix[row, maxColumn];

                for (int column = maxColumn; column < columns - 1; column++)
                {
                    matrix[row, column] = matrix[row, column + 1];
                }

                matrix[row, columns - 1] = maxValue;
            }
            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            int lastColumn = columns - 1;
            answer = new int[rows, columns + 1];

            for (int row = 0; row < rows; row++)
            {
                int maxValue = matrix[row, lastColumn];

                for (int column = 0; column < lastColumn; column++)
                {
                    int value = matrix[row, column];
                    answer[row, column] = value;

                    if (value > maxValue)
                    {
                        maxValue = value;
                    }
                }

                answer[row, lastColumn] = maxValue;
                answer[row, columns] = matrix[row, lastColumn];
            }
            // end

            return answer;
        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            answer = new int[matrix.Length / 2];
            int index = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    if ((row + column) % 2 != 0)
                    {
                        answer[index] = matrix[row, column];
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
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            if (rows != columns || k < 0 || k >= columns)
            {
                return;
            }

            int diagonalRow = 0;

            for (int row = 1; row < rows; row++)
            {
                if (matrix[row, row] > matrix[diagonalRow, diagonalRow])
                {
                    diagonalRow = row;
                }
            }

            int negativeRow = -1;

            for (int row = 0; row < rows; row++)
            {
                if (matrix[row, k] < 0)
                {
                    negativeRow = row;
                    break;
                }
            }

            if (negativeRow == -1 || negativeRow == diagonalRow)
            {
                return;
            }

            for (int column = 0; column < columns; column++)
            {
                (matrix[diagonalRow, column], matrix[negativeRow, column]) =
                    (matrix[negativeRow, column], matrix[diagonalRow, column]);
            }
            // end

        }
        public void Task7(int[,] matrix, int[] array)
        {

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            if (columns < 2 || array.Length != columns)
            {
                return;
            }

            int targetColumn = columns - 2;
            int maxRow = 0;

            for (int row = 1; row < rows; row++)
            {
                if (matrix[row, targetColumn] > matrix[maxRow, targetColumn])
                {
                    maxRow = row;
                }
            }

            for (int column = 0; column < columns; column++)
            {
                matrix[maxRow, column] = array[column];
            }
            // end

        }
        public void Task8(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            for (int column = 0; column < columns; column++)
            {
                int maxRow = 0;

                for (int row = 1; row < rows; row++)
                {
                    if (matrix[row, column] > matrix[maxRow, column])
                    {
                        maxRow = row;
                    }
                }

                if (maxRow < rows / 2)
                {
                    int sum = 0;

                    for (int row = maxRow + 1; row < rows; row++)
                    {
                        sum += matrix[row, column];
                    }

                    matrix[0, column] = sum;
                }
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            for (int row = 0; row + 1 < rows; row += 2)
            {
                int firstMaxColumn = 0;
                int secondMaxColumn = 0;

                for (int column = 1; column < columns; column++)
                {
                    if (matrix[row, column] > matrix[row, firstMaxColumn])
                    {
                        firstMaxColumn = column;
                    }

                    if (matrix[row + 1, column] > matrix[row + 1, secondMaxColumn])
                    {
                        secondMaxColumn = column;
                    }
                }

                (matrix[row, firstMaxColumn], matrix[row + 1, secondMaxColumn]) =
                    (matrix[row + 1, secondMaxColumn], matrix[row, firstMaxColumn]);
            }
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            if (rows != columns)
            {
                return;
            }

            int maxRow = 0;

            for (int row = 1; row < rows; row++)
            {
                if (matrix[row, row] > matrix[maxRow, maxRow])
                {
                    maxRow = row;
                }
            }

            for (int row = 0; row < maxRow; row++)
            {
                for (int column = row + 1; column < columns; column++)
                {
                    matrix[row, column] = 0;
                }
            }
            // end

        }
        public void Task11(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            int[] positiveCounts = new int[rows];

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    if (matrix[row, column] > 0)
                    {
                        positiveCounts[row]++;
                    }
                }
            }

            for (int end = rows - 1; end > 0; end--)
            {
                for (int row = 0; row < end; row++)
                {
                    // При равном количестве положительных порядок строк сохраняется.
                    if (positiveCounts[row] < positiveCounts[row + 1])
                    {
                        (positiveCounts[row], positiveCounts[row + 1]) =
                            (positiveCounts[row + 1], positiveCounts[row]);

                        for (int column = 0; column < columns; column++)
                        {
                            (matrix[row, column], matrix[row + 1, column]) =
                                (matrix[row + 1, column], matrix[row, column]);
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
            double[] rowAverages = new double[array.Length];
            long totalSum = 0;
            long totalCount = 0;

            for (int row = 0; row < array.Length; row++)
            {
                int columns = array[row].Length;
                long rowSum = 0;

                for (int column = 0; column < columns; column++)
                {
                    rowSum += array[row][column];
                }

                if (columns > 0)
                {
                    rowAverages[row] = (double)rowSum / columns;
                }

                totalSum += rowSum;
                totalCount += columns;
            }

            double average = totalCount == 0 ? 0 : (double)totalSum / totalCount;
            int keptCount = 0;

            for (int row = 0; row < array.Length; row++)
            {
                if (rowAverages[row] >= average)
                {
                    keptCount++;
                }
            }

            answer = new int[keptCount][];
            int targetRow = 0;

            for (int row = 0; row < array.Length; row++)
            {
                if (rowAverages[row] >= average)
                {
                    int columns = array[row].Length;
                    answer[targetRow] = new int[columns];
                    Array.Copy(array[row], answer[targetRow], columns);
                    targetRow++;
                }
            }
            // end

            return answer;
        }
    }
}