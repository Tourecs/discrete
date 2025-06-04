using System;

public class AlgorithmDeikstr
{
    public static int Deikstr(int[,] graph, int start, int end)
    {
        int n = graph.GetLength(0);
        int[] distances = new int[n];
        bool[] visited = new bool[n];

        for (int i = 0; i < n; i++)
        {
            distances[i] = int.MaxValue;
            visited[i] = false;
        }
        distances[start] = 0;
        for (int i = 0; i < n - 1; i++)
        {
            int current = GetMinimumDistanceNode(distances, visited, n);
            if (current == -1) break;
            visited[current] = true;
            for (int j = 0; j < n; j++)
            {
                if (!visited[j] && graph[current, j] != 0 && 
                    distances[current] != int.MaxValue && 
                    distances[current] + graph[current, j] < distances[j])
                {
                    distances[j] = distances[current] + graph[current, j];
                }
            }
        }
        return distances[end] == int.MaxValue ? -1 : distances[end];
    }
    private static int GetMinimumDistanceNode(int[] distances, bool[] visited, int n)
    {
        int minDistance = int.MaxValue;
        int minIndex = -1;

        for (int i = 0; i < n; i++)
        {
            if (!visited[i] && distances[i] <= minDistance)
            {
                minDistance = distances[i];
                minIndex = i;
            }
        }

        return minIndex;
    }
    public static void Main()
    {
        int[,] graph1 = {
            { 0, 0, 0, 0 },
            { 0, 0, 0, 0 },
        };
        Console.WriteLine(Deikstr(graph1, 0, 1)); // -1
        int[,] graph2 = {
            { 0, 1, 4 },
            { 0, 0, 2 },
            { 1, 2, 0 },
        };
        Console.WriteLine(Deikstr(graph2, 0, 2)); // 3
        int[,] graph3 = {
            { 0, 23, 0, 45, 0 },
            { 0, 0, 7, 0, 57 },
            { 789, 0, 0, 0, 0 },
            { 0, 56, 0, 0, 65 },
            { 45, 0, 86, 908, 0 },
        };
        Console.WriteLine(Deikstr(graph3, 2, 4)); // 869
        int[,] graph4 = {
            { 0, 5, 10, 13, 0, 0 },
            { 0, 0, 8, 9, 13, 0 },
            { 0, 0, 0, 5, 3, 6 },
            { 0, 0, 0, 0, 8, 10 },
            { 0, 0, 0, 0, 0, 9 },
            { 0, 0, 0, 0, 0, 0 },
        };
        Console.WriteLine(Deikstr(graph4, 0, 5)); // 16
    }
}
