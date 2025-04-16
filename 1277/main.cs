using System;
using System.Collections.Generic;

class Program
{
    static List<int>[] a = new List<int>[101]; // Adjacency lists
    static int[] c = new int[101], f = new int[101], l = new int[101]; // Cost, flow, levels

    static int K, N, M, S, F, x, y;

    static int Bfs(int node)
    {
        // Sets up the level graph
        Queue<int> q = new Queue<int>();
        Array.Clear(l, 0, l.Length);
        q.Enqueue(node);
        l[node] = 1;

        while (q.Count > 0)
        {
            int n = q.Dequeue();
            foreach (var v in a[n])
            {
                if (c[v] > f[v] && l[v] == 0)
                {
                    q.Enqueue(v);
                    l[v] = l[n] + 1;
                }
            }
        }

        return l[F];
    }

    static int Dfs(int n, int flow)
    {
        // Finds some augmenting flow in the level graph
        if (n == F)
            return flow;

        int sum = 0;
        foreach (var v in a[n])
        {
            if (l[v] == l[n] + 1)
            {
                int fl = Dfs(v, Math.Min(c[v] - f[v], flow));
                sum += fl;
                flow -= fl;
                f[v] += fl;
            }
        }

        return sum;
    }

    static void Main()
    {
        string[] inputs = Console.ReadLine().Split();
        K = int.Parse(inputs[0]);
        N = int.Parse(inputs[1]);
        M = int.Parse(inputs[2]);
        S = int.Parse(inputs[3]);
        F = int.Parse(inputs[4]);

        for (int i = 1; i <= N; i++)
        {
            c[i] = int.Parse(Console.ReadLine());
        }

        c[S] = c[F] = 10000;

        // Initialize adjacency lists
        for (int i = 0; i <= 100; i++)
        {
            a[i] = new List<int>();
        }

        for (int i = 1; i <= M; i++)
        {
            string[] edge = Console.ReadLine().Split();
            x = int.Parse(edge[0]);
            y = int.Parse(edge[1]);
            a[x].Add(y);
            a[y].Add(x);
        }

        int sum = 0;

        if (F == S)
        {
            Console.WriteLine("NO");
            return;
        }

        while (Bfs(S) > 0)
        {
            sum += Dfs(S, 10000);
        }

        Console.WriteLine(K < sum ? "NO" : "YES");
    }
}
