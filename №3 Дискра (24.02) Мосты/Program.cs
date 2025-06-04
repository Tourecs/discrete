using System;
    class Program
    {
        static void Main()
        {
            int[,] graph = new int[,]   {
                {0, 1, 1, 0, 0},
                {1, 0, 0, 1, 0},
                {1, 0, 0, 1, 0},
                {0, 1, 1, 0, 1},
                {0, 0, 0, 1, 0}

            };

            int V = graph.GetLength(0);
            bool[] visited = new bool[V];
            int[] disc = new int[V];
            int[] low = new int[V];
            int time = 0;

            for (int i = 0; i < V; i++)
            {
                if (!visited[i])
                {
                    DFS(graph, i, visited, disc, low, ref time, -1);
                }
            }
        }

        static void DFS(int[,] graph, int u, bool[] visited, int[] disc, int[] low, ref int time, int parent)
        {
            visited[u] = true;
            disc[u] = low[u] = time++;

            for (int v = 0; v < graph.GetLength(0); v++)
            {
                if (graph[u, v] == 1) // Если есть ребро между u и v
                {
                    if (!visited[v]) // Если v не посещена
                    {
                        DFS(graph, v, visited, disc, low, ref time, u);
                        low[u] = Math.Min(low[u], low[v]);

                        // Проверяем, является ли (u, v) мостом
                        if (low[v] > disc[u])
                        {
                            Console.WriteLine($"({u}, {v})");
                        }
                    }
                    else if (v != parent) // Обновляем low[u] для обратного ребра
                    {
                        low[u] = Math.Min(low[u], disc[v]);
                    }
                }
            }
        }
    }
