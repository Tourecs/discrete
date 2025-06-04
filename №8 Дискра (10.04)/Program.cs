using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        double inf = double.PositiveInfinity;
        double[][] m = {
            new double[]{inf,27,43,16,30,26},
            new double[]{7,inf,16,1,30,25},
            new double[]{20,13,inf,35,5,0},
            new double[]{21,16,25,inf,18,18},
            new double[]{12,46,27,48,inf,5},
            new double[]{23,5,5,9,5,inf}
        };
        Console.WriteLine(littleTsp(m)); // 63
    }

    static (double[][], double) reduce(double[][] m)
    {
        int n = m.Length;
        double cost = 0;
        var res = new double[n][];
        for (int i=0; i<n; i++) res[i] = (double[])m[i].Clone();
        for (int i=0; i<n; i++)
        {
            double rowMin = double.PositiveInfinity;
            for (int j=0; j<n; j++) if (res[i][j]<rowMin) rowMin = res[i][j];
            if (rowMin > 0 && rowMin < double.PositiveInfinity)
            {
                for (int j=0; j<n; j++) if (res[i][j]<double.PositiveInfinity) res[i][j]-=rowMin;
                cost += rowMin;
            }
        }
        for (int j=0; j<n; j++)
        {
            double colMin = double.PositiveInfinity;
            for (int i=0; i<n; i++) if (res[i][j]<colMin) colMin = res[i][j];
            if (colMin > 0 && colMin < double.PositiveInfinity)
            {
                for (int i=0; i<n; i++) if (res[i][j]<double.PositiveInfinity) res[i][j]-=colMin;
                cost += colMin;
            }
        }
        return (res, cost);
    }

    static (int, int) maxPenaltyZero(double[][] m)
    {
        int n = m.Length, r=-1, c=-1;
        double maxP = -1;
        for (int i=0; i<n; i++)
            for (int j=0; j<n; j++)
                if (m[i][j]==0)
                {
                    double rowMin = double.PositiveInfinity, colMin = double.PositiveInfinity;
                    for (int k=0; k<n; k++) if (k!=j && m[i][k]<rowMin) rowMin = m[i][k];
                    for (int k=0; k<n; k++) if (k!=i && m[k][j]<colMin) colMin = m[k][j];
                    double p = (rowMin==double.PositiveInfinity?0:rowMin)+(colMin==double.PositiveInfinity?0:colMin);
                    if (p>maxP) { maxP=p; r=i; c=j; }
                }
        return (r,c);
    }

    static double littleTsp(double[][] m)
    {
        int n = m.Length;
        double best = double.PositiveInfinity;
        var stack = new Stack<(double[][], double, int)>();
        var (red, cost) = reduce(m);
        stack.Push((red, cost,0));

        while(stack.Count>0)
        {
            var (mat, bound, level) = stack.Pop();
            if (bound>=best) continue;
            if (level==n-1) { if(bound<best) best=bound; continue; }
            var (r,c) = maxPenaltyZero(mat);
            if (r==-1) continue;
            var incl = new double[n][];
            for(int i=0; i<n; i++) incl[i] = (double[])mat[i].Clone();
            for(int k=0; k<n; k++) { incl[r][k]=double.PositiveInfinity; incl[k][c]=double.PositiveInfinity; }
            incl[c][r] = double.PositiveInfinity;
            var (redIncl, costIncl) = reduce(incl);
            double newBound = bound + costIncl;
            if (newBound < best) stack.Push((redIncl, newBound, level+1));
        }
        return best;
    }
}
