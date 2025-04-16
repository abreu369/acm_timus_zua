using System;
using System.Collections.Generic;

class Program
{
    static int n;
    static int c = 0;
    static List<List<int>> g = new List<List<int>>();
    static int[] mt;
    static bool[] used;
    
    static bool Kuhn(int v)
    {
        if (used[v]) return false;
        used[v] = true;
        foreach (var to in g[v])
        {
            if (mt[to] == -1 || Kuhn(mt[to]))
            {
                mt[to] = v;
                return true;
            }
        }
        return false;
    }

    static void Main()
    {
        n = int.Parse(Console.ReadLine());
        int[] S = new int[n];
        int[] A = new int[n];
        int[] B = new int[n];
        g = new List<List<int>>();
        for (int i = 0; i < n; i++) g.Add(new List<int>());
        
        string[] sInput = Console.ReadLine().Split();
        for (int i = 0; i < n; i++) S[i] = int.Parse(sInput[i]);
        
        for (int i = 0; i < n; i++)
        {
            string[] ab = Console.ReadLine().Split();
            A[i] = int.Parse(ab[0]);
            B[i] = int.Parse(ab[1]);
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (A[j] <= S[i] && S[i] <= B[j])
                {
                    g[i].Add(j);
                }
            }
        }

        mt = new int[n];
        Array.Fill(mt, -1);
        bool[] used1 = new bool[n];

        for (int i = 0; i < n; i++)
        {
            foreach (var to in g[i])
            {
                if (mt[to] == -1)
                {
                    mt[to] = i;
                    used1[i] = true;
                    c++;
                    break;
                }
            }
        }

        for (int v = 0; v < n; v++)
        {
            if (used1[v]) continue;
            used = new bool[n];
            if (Kuhn(v)) c++;
        }

        if (c != n)
        {
            Console.WriteLine("Let's search for another office.");
            return;
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (mt[j] == -1 || mt[i] == -1)
                    continue;
                if (i != j && A[j] <= S[mt[i]] && S[mt[i]] <= B[j] && A[i] <= S[mt[j]] && S[mt[j]] <= B[i])
                {
                    Console.WriteLine("Ask Shiftman for help.");
                    return;
                }
            }
        }

        Console.WriteLine("Perfect!");
        for (int i = 0; i < n; i++)
            if (mt[i] != -1)
                Console.Write((mt[i] + 1) + " ");
    }
}
