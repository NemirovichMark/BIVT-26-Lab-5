namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer;

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            answer = new int[columns];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    if (matrix[row, col] < 0)
                        answer[col]++;
                }
            }
            // end
            return answer;
        }

        public void Task2(int[,] matrix)
        {
            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                int minCol = 0;
                for (int col = 1; col < columns; col++)
                {
                    if (matrix[row, col] < matrix[row, minCol])
                        minCol = col;
                }

                int minimum = matrix[row, minCol];
                for (int col = minCol; col > 0; col--)
                    matrix[row, col] = matrix[row, col - 1];

                matrix[row, 0] = minimum;
            }
            // end
        }

        public int[,] Task3(int[,] matrix)
        {
            int[,] answer;

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            answer = new int[rows, columns + 1];

            for (int row = 0; row < rows; row++)
            {
                int maxCol = 0;
                for (int col = 1; col < columns; col++)
                {
                    if (matrix[row, col] > matrix[row, maxCol])
                        maxCol = col;
                }

                for (int col = 0; col <= maxCol; col++)
                    answer[row, col] = matrix[row, col];

                answer[row, maxCol + 1] = matrix[row, maxCol];

                for (int col = maxCol + 1; col < columns; col++)
                    answer[row, col + 1] = matrix[row, col];
            }
            // end
            return answer;
        }

        public void Task4(int[,] matrix)
        {
            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                int maxCol = 0;
                for (int col = 1; col < columns; col++)
                {
                    if (matrix[row, col] > matrix[row, maxCol])
                        maxCol = col;
                }

                long sum = 0;
                int count = 0;
                for (int col = maxCol + 1; col < columns; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        sum += matrix[row, col];
                        count++;
                    }
                }

                if (count == 0)
                    continue;

                int average = (int)(sum / count);
                for (int col = 0; col < maxCol; col++)
                {
                    if (matrix[row, col] < 0)
                        matrix[row, col] = average;
                }
            }
            // end
        }

        public void Task5(int[,] matrix, int k)
        {
            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            if (k < 0 || k >= columns)
                return;

            int[] maxima = new int[rows];
            for (int row = 0; row < rows; row++)
            {
                int maximum = matrix[row, 0];
                for (int col = 1; col < columns; col++)
                    maximum = Math.Max(maximum, matrix[row, col]);

                maxima[row] = maximum;
            }

            for (int row = 0; row < rows; row++)
                matrix[row, k] = maxima[rows - 1 - row];
            // end
        }

        public void Task6(int[,] matrix, int[] array)
        {
            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            if (array.Length != columns)
                return;

            for (int col = 0; col < columns; col++)
            {
                int maxRow = 0;
                for (int row = 1; row < rows; row++)
                {
                    if (matrix[row, col] > matrix[maxRow, col])
                        maxRow = row;
                }

                if (array[col] > matrix[maxRow, col])
                    matrix[maxRow, col] = array[col];
            }
            // end
        }

        public void Task7(int[,] matrix)
        {
            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            if (rows < 2)
                return;

            int[] minima = new int[rows];
            int[] rowOrder = new int[rows];
            for (int row = 0; row < rows; row++)
            {
                minima[row] = matrix[row, 0];
                for (int col = 1; col < columns; col++)
                    minima[row] = Math.Min(minima[row], matrix[row, col]);

                rowOrder[row] = row;
            }

            for (int index = 1; index < rows; index++)
            {
                int currentRow = rowOrder[index];
                int position = index;
                while (position > 0 && minima[currentRow] > minima[rowOrder[position - 1]])
                {
                    rowOrder[position] = rowOrder[position - 1];
                    position--;
                }

                rowOrder[position] = currentRow;
            }

            int[,] sorted = new int[rows, columns];
            for (int row = 0; row < rows; row++)
            {
                int sourceRow = rowOrder[row];
                for (int col = 0; col < columns; col++)
                    sorted[row, col] = matrix[sourceRow, col];
            }

            Array.Copy(sorted, matrix, matrix.Length);
            // end
        }

        public int[] Task8(int[,] matrix)
        {
            int[] answer;

            // code here
            int size = matrix.GetLength(0);
            if (size != matrix.GetLength(1))
                return null!;

            answer = new int[2 * size - 1];
            int mainDiagonal = size - 1;
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    int diagonal = mainDiagonal + (col - row);
                    answer[diagonal] += matrix[row, col];
                }
            }
            // end
            return answer;
        }

        public void Task9(int[,] matrix, int k)
        {
            // code here
            int size = matrix.GetLength(0);
            if (size != matrix.GetLength(1) || k < 0 || k >= size)
                return;

            int maxRow = 0;
            int maxCol = 0;
            long maxMagnitude = Math.Abs((long)matrix[0, 0]);
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    long magnitude = Math.Abs((long)matrix[row, col]);
                    if (magnitude > maxMagnitude)
                    {
                        maxMagnitude = magnitude;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }

            int rowStep = Math.Sign(k - maxRow);
            for (int col = 0; col < size; col++)
            {
                int value = matrix[maxRow, col];
                for (int row = maxRow; row != k; row += rowStep)
                    matrix[row, col] = matrix[row + rowStep, col];

                matrix[k, col] = value;
            }

            int colStep = Math.Sign(k - maxCol);
            for (int row = 0; row < size; row++)
            {
                int value = matrix[row, maxCol];
                for (int col = maxCol; col != k; col += colStep)
                    matrix[row, col] = matrix[row, col + colStep];

                matrix[row, k] = value;
            }
            // end
        }

        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer;

            // code here
            int rows = A.GetLength(0);
            int commonLength = A.GetLength(1);
            int columns = B.GetLength(1);
            if (commonLength != B.GetLength(0))
                return null!;

            answer = new int[rows, columns];
            for (int cell = 0; cell < answer.Length; cell++)
            {
                int row = cell / columns;
                int col = cell % columns;
                int sum = 0;
                for (int i = 0; i < commonLength; i++)
                    sum += A[row, i] * B[i, col];

                answer[row, col] = sum;
            }
            // end
            return answer;
        }

        public int[][] Task11(int[,] matrix)
        {
            int[][] answer;

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            answer = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                int count = 0;
                for (int col = 0; col < columns; col++)
                {
                    if (matrix[row, col] > 0)
                        count++;
                }

                int[] positives = new int[count];
                int index = 0;
                for (int col = 0; col < columns; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        positives[index] = matrix[row, col];
                        index++;
                    }
                }

                answer[row] = positives;
            }
            // end
            return answer;
        }

        public int[,] Task12(int[][] array)
        {
            int[,] answer;

            // code here
            long count = 0;
            foreach (int[] row in array)
                count += row.Length;

            int size = (int)Math.Ceiling(Math.Sqrt(count));
            answer = new int[size, size];

            int targetRow = 0;
            int targetCol = 0;
            foreach (int[] row in array)
            {
                foreach (int value in row)
                {
                    answer[targetRow, targetCol] = value;
                    targetCol++;
                    if (targetCol == size)
                    {
                        targetRow++;
                        targetCol = 0;
                    }
                }
            }
            // end
            return answer;
        }
    }
}
