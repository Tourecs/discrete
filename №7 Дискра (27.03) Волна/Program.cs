using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int[,] maze = {
            { 0, -1, 0, 0, 0, -1, 0, 0, 0, -1, 0, 0 },
            { 0, -1, 0, -1, 0, -1, 0, -1, 0, -1, 0, 0 },
            { 0, 0, 0, -1, 0, 0, 0, -1, 0, -1, -1, 0 },
            { -1, -1, 0, -1, -1, -1, 0, -1, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, -1, 0, -1, -1, -1, -1, 0 },
            { 0, -1, -1, -1, 0, -1, 0, 0, 0, 0, -1, 0 },
            { 0, -1, 0, 0, 0, -1, -1, -1, -1, 0, -1, 0 },
            { 0, -1, 0, -1, -1, -1, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, -1, 0, 0, 0, -1, -1, -1, 0, -1 },
            { 0, -1, -1, -1, 0, -1, 0, 0, 0, 0, 0, 0 },
        };
        Wave(maze, 0, 0, 9, 11);
    }

    static void Wave(int[,] maze, int startX, int startY, int endX, int endY)
    {
        int rows = maze.GetLength(0);
        int cols = maze.GetLength(1);
        int[,] distances = new int[rows, cols];
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                distances[i, j] = int.MaxValue;

        distances[startX, startY] = 0;
        Queue<int[]> queue = new Queue<int[]>();
        queue.Enqueue(new int[] { startX, startY });
        int[][] directions = new int[][]
        {
            new int[] { -1, 0 }, // вверх
            new int[] { 0, -1 }, // влево
            new int[] { 1, 0 },  // вниз
            new int[] { 0, 1 }   // вправо
        };
        while (queue.Count > 0)
        {
            var pos = queue.Dequeue();
            foreach (var dir in directions)
            {
                int newX = pos[0] + dir[0];
                int newY = pos[1] + dir[1];
                if (newX >= 0 && newX < rows && newY >= 0 && newY < cols && maze[newX, newY] == 0)
                {
                    if (distances[newX, newY] == int.MaxValue)
                    {
                        distances[newX, newY] = distances[pos[0], pos[1]] + 1;
                        queue.Enqueue(new int[] {newX, newY});
                    }
                }
            }
        }
        DrawMaze(distances);
    }

    static void DrawMaze(int[,] distances)
    {
        for (int i = 0; i < distances.GetLength(0); i++)
        {
            for (int j = 0; j < distances.GetLength(1); j++)
            {
                if (distances[i, j] == int.MaxValue)
                    Console.Write(" -- ");
                else
                    Console.Write($"{distances[i, j]}  ");
            }
            Console.WriteLine();
        }
    }
}
