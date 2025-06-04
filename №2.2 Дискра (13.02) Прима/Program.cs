using System;
using System.Collections.Generic;
    class Graph
    {
        private int V;
        private List<(int destination, int weight)>[] adjacencyList;

        public Graph(int vertices)
        {
            V = vertices;
            adjacencyList = new List<(int, int)>[V];
            for (int i = 0; i < V; i++)
            {
                adjacencyList[i] = new List<(int, int)>();
            }
        }

        public void AddEdge(int source, int destination, int weight)
        {
            adjacencyList[source].Add((destination, weight));
            adjacencyList[destination].Add((source, weight)); // Для неориентированного графа
        }

        public void Prim()
        {
            bool[] inMST = new bool[V];
            int[] minEdge = new int[V];
            int[] parent = new int[V];

            Array.Fill(minEdge, int.MaxValue);
            minEdge[0] = 0; // Начинаем с первого узла
            parent[0] = -1;

            for (int count = 0; count < V - 1; count++)
            {
                int u = SelectMinVertex(inMST, minEdge);
                inMST[u] = true;

                foreach (var (v, weight) in adjacencyList[u])
                {
                    if (!inMST[v] && weight < minEdge[v])
                    {
                        minEdge[v] = weight;
                        parent[v] = u;
                    }
                }
            }

            PrintMST(parent, minEdge);
        }

        private int SelectMinVertex(bool[] inMST, int[] minEdge)
        {
            int minVertex = -1;
            for (int i = 0; i < V; i++)
            {
                if (!inMST[i] && (minVertex == -1 || minEdge[i] < minEdge[minVertex]))
                {
                    minVertex = i;
                }
            }
            return minVertex;
        }

        private void PrintMST(int[] parent, int[] minEdge)
        {
        int minimumCost = 0;
            for (int i = 1; i < V; i++)
            {
                Console.WriteLine($"({parent[i]}, {i}), вес: {minEdge[i]}");
                minimumCost += minEdge[i];
            }
            Console.WriteLine("Минимальное остовное дерево:" + minimumCost);
    }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph(4);
            g.AddEdge(0, 1, 7);
            g.AddEdge(0, 2, 3);
            g.AddEdge(0, 3, 8);
            g.AddEdge(1, 2, 5);
            g.AddEdge(1, 3, 12);
            g.AddEdge(2, 3, 2);

            g.Prim();
        }
    }
