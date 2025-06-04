using System;

public class FordBelman
{
    public static int[,] sortedMatrix(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int[,] newmat = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (matrix[i, j] == 0)
                    newmat[i, j] = int.MaxValue;
                else
                    newmat[i, j] = matrix[i, j];
            }
        }
        return newmat;
    }
     public static void displayResult(int[] distances)
    {
        Console.WriteLine("Длина минимального пути из вершины в вершину: ");

        for (int i = 0; i < distances.Length; i++)
        {
            Console.WriteLine($"{i + 1} -> {i + 1}  -  {(distances[i] == int.MaxValue ? "∞" : distances[i].ToString())}");
        }
    }

    public static int[] fordBellmanAlg(int[,] matrix, int startPos)
    {
        matrix = sortedMatrix(matrix);
        int n = matrix.GetLength(0);
        int[] distances = new int[n];
        for (int i = 0; i < n; i++)
        {
            distances[i] = int.MaxValue;
        }
        distances[startPos] = 0;

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n; j++)
            {
                for (int k = 0; k < n; k++)
                {
                    if (matrix[j, k] != int.MaxValue)
                    {
                        int distancenow = distances[j] + matrix[j, k];
                        if (distancenow < distances[k])
                        {
                            distances[k] = distancenow;
                        }
                    }
                }
            }
        }
        return distances;
    }

    public static void Main()
    {
        int[,] matrix = {
            { 0, 1, 0, 0, 3 },
            { 0, 0, 8, 7, 1 },
            { 0, 0, 0, 1, -5 },
            { 0, 0, 2, 0, 0 },
            { 0, 0, 0, 4, 0 },
        };

        displayResult(fordBellmanAlg(matrix, 0));
    }
}
