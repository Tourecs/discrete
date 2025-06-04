using System;
using System.Collections.Generic;
    class Program
    {
        static void Main()
        {
            int[,] graph ={
            {1,1,1,0,1,1},
            {0,1,0,1,0,0},
            {1,0,1,0,0,1},
            {1,0,1,0,0,0},
            {0,0,1,1,1,0},
            {0,0,1,0,1,0},
            };

            List<int> visit = new List<int>();
            int result = 0;

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                if (!visit.Contains(i))
                {
                    DFS(graph, i, visit);
                    result++;
                }
            }

            Console.WriteLine("Кол-во уникальных посещенных узлов равно " + result);
        }

        static void DFS(int[,] graph, int node, List<int> visit)
        {
            visit.Add(node);

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                if (graph[node, i] == 1 && !visit.Contains(i))
                {
                    DFS(graph, i, visit);
                }
            }
        }
    }
