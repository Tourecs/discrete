﻿using System;
using System.Collections.Generic;

namespace Omgtu
{
    class Edge : IComparable<Edge>
    {
        public int Source { get; set; }
        public int Destination { get; set; }
        public int Weight { get; set; }

        public Edge(int source, int destination, int weight)
        {
            Source = source;
            Destination = destination;
            Weight = weight;
        }

        public int CompareTo(Edge other)
        {
            return Weight.CompareTo(other.Weight);
        }
    }

    class Graph
    {
        public int V { get; set; }
        public List<Edge> Edges { get; set; }

        public Graph(int vertices)
        {
            V = vertices;
            Edges = new List<Edge>();
        }

        public void AddEdge(int source, int destination, int weight)
        {
            Edges.Add(new Edge(source, destination, weight));
        }

        private int Find(int[] parent, int i)
        {
            if (parent[i] == -1)
                return i;
            return Find(parent, parent[i]);
        }

        private void Union(int[] parent, int x, int y)
        {
            parent[x] = y;
        }

        public void Kruskal()
        {
            Edges.Sort();

            int[] parent = new int[V];
            for (int i = 0; i < V; i++)
            {
                parent[i] = -1;
            }

            int minimumCost = 0;
            List<Edge> resultEdges = new List<Edge>();

            foreach (var edge in Edges)
            {
                int x = Find(parent, edge.Source);
                int y = Find(parent, edge.Destination);

                // Если корни разные, значит добавляем ребро в MST
                if (x != y)
                {
                    minimumCost += edge.Weight;
                    resultEdges.Add(edge);
                    Union(parent, x, y);
                }
            }
            foreach (var edge in resultEdges)
            {
                Console.WriteLine($"({edge.Source}, {edge.Destination}), вес: {edge.Weight}");
            }
            Console.WriteLine("Минимальное остовное дерево: " + minimumCost);
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

            g.Kruskal(); // Исправлено название метода
        }
    }
}
