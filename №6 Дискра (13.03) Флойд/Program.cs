using System;

class Program
{
    static void Main()
    {
        int[,] matrix = {
            { 0, 5, 0, 10 },
            { 0, 0, 3, 0 },
            { 0, 0, 0, 1 },
            { 0, 0, 0, 0 },
        };
         int n = matrix.GetLength(0);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i != j && matrix[i, j] == 0)
                {
                    matrix[i, j] = int.MaxValue / 2;
                }
            }
        }
        for (int k = 0; k < n; k++)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, k] + matrix[k, j] < matrix[i, j])
                    {
                        matrix[i, j] = matrix[i, k] + matrix[k, j];
                    }
                }
            }
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (matrix[i, j] == int.MaxValue / 2)
                    Console.Write("∞\t");
                else
                    Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
